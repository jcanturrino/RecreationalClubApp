﻿using Configurations.BaseInterface;
using Configurations.BaseReturn.Interface;
using Configurations.JWT;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Configurations.BaseLogic
{
    public class TokenRepository : Repository<Tokens>, ITokenRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IRepository<Usuario> _usuarioRepository;
        private readonly IRepository<Permiso> _permisoRepository;
        private readonly IRepository<RolPermiso> _rolePermisoRepository;

        public TokenRepository(DbContext context, IServiceScopeFactory
            serviceScopeFactory, IConfiguration configuration, IRepository<Usuario> usuarioRepository,
            IRepository<Permiso> permisoRepository, IRepository<RolPermiso> rolePermisoRepository) : base(context, serviceScopeFactory)
        {
            _configuration = configuration;
            _usuarioRepository = usuarioRepository;
            _permisoRepository = permisoRepository;
            _rolePermisoRepository = rolePermisoRepository;
            _serviceScopeFactory = serviceScopeFactory;
        }


        public async Task<IOperationResult<bool>> ValidateTokenAndPerformActionAsync(string token, string action)
        {
            // Crear una nueva instancia de DbContext para esta operación
            using var scope = _serviceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<DbContext>();

            // Buscar el token en la base de datos
            var tokenEntity = await this.FindAsync(t => t.Token == token);
            var validToken = tokenEntity.Data.OrderByDescending(t => t.FechaCreacion).FirstOrDefault();

            if (validToken == null)
            {
                return IOperationResult<bool>.ErrorResult("Token no encontrado", false);
            }

            // Validar la vigencia del token
            if (validToken.ExpiryDate.Hour <= DateTime.Now.Hour)
            {
                return IOperationResult<bool>.ErrorResult("Token expirado", false);
            }

            // Validar privilegios del usuario
            var userHasPrivilege = await ValidateUserPrivilegesAsync(validToken.UsuarioId, action);
            if (!userHasPrivilege.Data)
            {
                return IOperationResult<bool>.ErrorResult(userHasPrivilege.Message, false);
            }

            // Si el token y los privilegios son válidos
            return IOperationResult<bool>.SuccessResult(true, "Token y privilegios válidos");
        }

        private async Task<IOperationResult<bool>> ValidateUserPrivilegesAsync(int usuarioId, string action)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<DbContext>();

            var permisoEntity = await _permisoRepository.FindAsync(p => p.Nombre == action.ToUpper());
            var permiso = permisoEntity.Data.FirstOrDefault();
            var usuarioRolId = _usuarioRepository.FindAsync(p => p.Id == usuarioId).Result.Data.FirstOrDefault().RolId;
            if (permiso == null)
            {
                return IOperationResult<bool>.ErrorResult("Permiso no encontrado", false);
            }

            // Verificar si el usuario tiene el permiso configurado en RolPermisos
            var rolPermisoEntity = await context.Set<RolPermiso>().Where(rp => rp.RolId == usuarioRolId && rp.PermisoId == permiso.Id).ToListAsync();
            var rolPermiso = rolPermisoEntity.FirstOrDefault();

            if (rolPermiso == null)
            {
                return IOperationResult<bool>.ErrorResult("Usuario no tiene el privilegio para realizar esta acción", false);
            }

            if (rolPermiso == null)
            {
                return IOperationResult<bool>.ErrorResult("Usuario no tiene el privilegio para realizar esta acción", false);
            }

            // Si el usuario tiene el privilegio
            return IOperationResult<bool>.SuccessResult(true, "Privilegio válido");
        }
        public void ValidateToken(string token, string secret, string accion)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Token no proporcionado");
            }

            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var key = System.Text.Encoding.ASCII.GetBytes(secret);

            try
            {
                tokenHandler.ValidateToken(token, new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true
                }, out _);

                ValidateTokenAndPerformActionAsync(token, accion);
            }
            catch (Exception ex)
            {
                throw new UnauthorizedAccessException($"Token inválido o expirado: {ex.Message}");
            }
        }

        public async Task<IOperationResult<string>> GenerateTokenAsync(int usuarioId)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(usuarioId); // Asume que hay un método para encontrar al usuario
            if (usuario == null)
                return IOperationResult<string>.ErrorResult("Usuario no encontrado");

            var tokenEntity = await GenerateJwtTokenAsync(usuario.Data.NombreUsuario, usuario.Data.Id);
            return IOperationResult<string>.SuccessResult(tokenEntity.Token, "Token generado con éxito");
        }

        public async Task<IOperationResult<string>> RefreshTokenAsync(string refreshToken)
        {
            var tokenEntity = await this.FindAsync(t => t.RefreshToken == refreshToken);
            var token = tokenEntity.Data.FirstOrDefault();
            if (token == null || token.ExpiryDate <= DateTime.UtcNow)
                return IOperationResult<string>.ErrorResult("Refresh token inválido o expirado");

            var newToken = await GenerateJwtTokenAsync(token.Usuario.NombreUsuario, token.UsuarioId);
            token.Token = newToken.Token;
            token.ExpiryDate = newToken.ExpiryDate;

            await this.UpdateAsync(token);
            return IOperationResult<string>.SuccessResult(newToken.Token, "Token renovado con éxito");
        }

        private async Task<Tokens> GenerateJwtTokenAsync(string username, int usuarioId)
        {
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var key = System.Text.Encoding.ASCII.GetBytes(_configuration["JwtSecret"]);
            var tokenDescriptor = new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new System.Security.Claims.Claim[]
                {
                new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name, username)
                }),
                Expires = System.DateTime.UtcNow.AddHours(1),
                SigningCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key), Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            var refreshToken = GenerateRefreshToken();
            var expiryDate = DateTime.UtcNow.AddHours(1);

            var tokenEntity = new Tokens
            {
                UsuarioId = usuarioId,
                Token = tokenString,
                RefreshToken = refreshToken,
                ExpiryDate = expiryDate,
                FechaCreacion = DateTime.UtcNow,
                FechaUltimaModificacion = DateTime.UtcNow
            };

            await this.AddAsync(tokenEntity);
            return tokenEntity;
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}

using Configurations.BaseInterface;

namespace Configurations.JWT
{
    public class ServiceConfiguration
    {
        public ITokenRepository TokenRepository { get; }
        public string JwtSecret { get; }

        public ServiceConfiguration(ITokenRepository tokenRepository, JwtConfiguration jwtConfiguration)
        {
            TokenRepository = tokenRepository;
            JwtSecret = jwtConfiguration.JwtSecret;
        }
    }

}

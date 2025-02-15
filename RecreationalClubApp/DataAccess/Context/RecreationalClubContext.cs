using Entities;
using Microsoft.EntityFrameworkCore;

public class RecreationalClubContext : DbContext
{
    public RecreationalClubContext(DbContextOptions<RecreationalClubContext> options) : base(options) { }

    public DbSet<Rol> Roles { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<TipoCliente> TiposClientes { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<TipoContacto> TiposContacto { get; set; }
    public DbSet<InformacionContacto> InformacionContacto { get; set; }
    public DbSet<RegistroAcceso> RegistrosAcceso { get; set; }
    public DbSet<Marca> Marcas { get; set; }
    public DbSet<Modelo> Modelos { get; set; }
    public DbSet<Vehiculo> Vehiculos { get; set; }
    public DbSet<ParqueoValet> ParqueoValets { get; set; }
    public DbSet<CodigoUbicacion> CodigosUbicacion { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}

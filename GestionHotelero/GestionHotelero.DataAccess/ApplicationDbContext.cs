using GestionHotelero.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GestionHotelero.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<GestionHoteleroIdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; } = default!;
        public DbSet<Empleado> Empleados { get; set; } = default!;
        public DbSet<Habitacion> Habitaciones { get; set; } = default!;
        public DbSet<Limpieza> Limpiezas { get; set; } = default!;
        public DbSet<Pago> Pagos { get; set; } = default!;
        public DbSet<Reservacion> Reservaciones { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);//Esta linea nunca se tiene que borrar

            builder.Entity<Habitacion>()
                .HasData(new List<Habitacion>()
                {
                    new () {IdHabitacion = 1, NumeroHabitacion = 101, TipoHabitacion = "Simple", Precio = 50.00M, Descripcion = "Habitacion simple con TV y cama de 1 plaza", Estado = "Disponible"},
                    new () {IdHabitacion = 2, NumeroHabitacion = 205, TipoHabitacion = "Matrimonial", Precio = 150.00M, Descripcion = "Habitacion con TV de 17 pulgadas y cama de 2 plaza", Estado = "Ocupado"},
                    new () {IdHabitacion = 3, NumeroHabitacion = 125, TipoHabitacion = "Suite", Precio = 250.00M, Descripcion = "Habitacion con Jacuzzi, TV de 50 pulgadas y cama de 3 plaza", Estado = "Mantenimiento"}
                });

            builder.Entity<GestionHoteleroIdentityUser>(e => e.ToTable("Usuarios"));
            builder.Entity<IdentityRole>(e => e.ToTable("Roles"));
            builder.Entity<IdentityUserRole<string>>(e => e.ToTable("UsuarioRoles"));
        }
    }
}
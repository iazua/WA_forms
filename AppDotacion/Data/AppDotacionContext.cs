using Microsoft.EntityFrameworkCore;
using AppDotacion.Models;

namespace AppDotacion.Data
{
    public class AppDotacionContext : DbContext
    {
        // Constructor que se utiliza para inyectar las configuraciones de la base de datos
        public AppDotacionContext(DbContextOptions<AppDotacionContext> options)
            : base(options)
        {
        }

        // DbSet para las entidades de tipo Dotacion
        public DbSet<Dotacion> Dotaciones { get; set; }

        // Configuración del modelo a través de Fluent API (si es necesario)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de la tabla Dotaciones
            modelBuilder.Entity<Dotacion>(entity =>
            {
                // Configuración para la tabla 'Dotaciones'
                entity.ToTable("Dotaciones");

                // Configuración de las columnas
                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("smallint")
                    .ValueGeneratedOnAdd(); // Indica que el valor se genera automáticamente

                entity.Property(e => e.Rut_DNI)
                    .HasColumnName("Rut_DNI")
                    .HasColumnType("nvarchar(50)");

                entity.Property(e => e.Agente)
                    .HasColumnName("Agente")
                    .HasColumnType("nvarchar(100)");

                entity.Property(e => e.Pais_Call_Center)
                    .HasColumnName("Pais_Call_Center")
                    .HasColumnType("nvarchar(100)");

                entity.Property(e => e.Nombre_Call_Center)
                    .HasColumnName("Nombre_Call_Center")
                    .HasColumnType("nvarchar(100)");

                entity.Property(e => e.Area)
                    .HasColumnName("Area")
                    .HasColumnType("nvarchar(100)");

                entity.Property(e => e.AreaGestion)
                    .HasColumnName("AreaGestion")
                    .HasColumnType("nvarchar(100)");

                entity.Property(e => e.Contrato)
                    .HasColumnName("Contrato")
                    .HasColumnType("tinyint");

                entity.Property(e => e.Tipos_de_agente)
                    .HasColumnName("Tipos_de_agente")
                    .HasColumnType("nvarchar(100)");

                entity.Property(e => e.Servicio)
                    .HasColumnName("Servicio")
                    .HasColumnType("nvarchar(100)");

                entity.Property(e => e.Usuarios_RcWeb)
                    .HasColumnName("Usuarios_RcWeb")
                    .HasColumnType("nvarchar(100)");

                entity.Property(e => e.Nombre_Jefatura)
                    .HasColumnName("Nombre_Jefatura")
                    .HasColumnType("nvarchar(100)");

                entity.Property(e => e.Rut_Ficticio)
                    .HasColumnName("Rut_Ficticio")
                    .HasColumnType("nvarchar(50)");

                entity.Property(e => e.Rut_DNI2)
                    .HasColumnName("Rut_DNI2")
                    .HasColumnType("nvarchar(50)");

                entity.Property(e => e.DV)
                    .HasColumnName("DV")
                    .HasColumnType("tinyint");

                entity.Property(e => e.Clasifica_Cargo)
                    .HasColumnName("Clasifica_Cargo")
                    .HasColumnType("nvarchar(100)");

                entity.Property(e => e.CARGO)
                    .HasColumnName("CARGO")
                    .HasColumnType("nvarchar(100)");

                entity.Property(e => e.Fecha_Ingreso)
                    .HasColumnName("Fecha_Ingreso")
                    .HasColumnType("int");

                entity.Property(e => e.Fecha_Baja)
                    .HasColumnName("Fecha_Baja")
                    .HasColumnType("int");

                entity.Property(e => e.N_Personal)
                    .HasColumnName("N_Personal")
                    .HasColumnType("int");

                entity.Property(e => e.Correo)
                    .HasColumnName("Correo")
                    .HasColumnType("nvarchar(100)");

                

                // Configura las relaciones si las tienes (por ejemplo, si hay claves foráneas)
            });
        }
    }
}

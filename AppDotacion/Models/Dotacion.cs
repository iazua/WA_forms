using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppDotacion.Models
{
    [Table("Dotaciones")]
    public class Dotacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Indica que el valor se genera automáticamente
        public short ID { get; set; } // smallint en SQL

        public string? Rut_DNI { get; set; } // nvarchar
        public string? Agente { get; set; } // nvarchar
        public string? Pais_Call_Center { get; set; } // nvarchar
        public string? Nombre_Call_Center { get; set; } // nvarchar
        public string? Area { get; set; } // nvarchar
        public string? AreaGestion { get; set; } // nvarchar
        public byte? Contrato { get; set; } // tinyint en SQL, se mapea como byte
        public string? Tipos_de_agente { get; set; } // nvarchar
        public string? Servicio { get; set; } // nvarchar
        public string? Usuarios_RcWeb { get; set; } // nvarchar
        public string? Nombre_Jefatura { get; set; } // nvarchar
        public string? Rut_Ficticio { get; set; } // nvarchar
        public string? Rut_DNI2 { get; set; } // nvarchar
        public byte? DV { get; set; } // tinyint en SQL, se mapea como byte
        public string? Clasifica_Cargo { get; set; } // nvarchar
        public string? CARGO { get; set; } // nvarchar

        // Fecha de ingreso y fecha de baja como int, probablemente en formato yyyyMMdd
        public int? Fecha_Ingreso { get; set; } // int en SQL, se mapea como int
        public int? Fecha_Baja { get; set; } // int en SQL, se mapea como int

        public int? N_Personal { get; set; } // int en SQL
        public string? Correo { get; set; } // nvarchar
    }
}

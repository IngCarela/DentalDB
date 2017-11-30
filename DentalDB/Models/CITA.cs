//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DentalDB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class CITA
    {
        [Key]
        public int IdCita { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "No se aceptan campos vacios")]
        [DisplayName("Numero de cita")]
        public int NumeroCitas { get; set; }

        
        [Required(ErrorMessage = "No se aceptan campos vacios")]
        [DisplayName("Paciente")]
        public int IdPaciente { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "No se aceptan campos vacios")]
        public System.DateTime Fecha { get; set; }

        [DataType(DataType.Time)]
        [Required(ErrorMessage = "No se aceptan campos vacios")]
        public System.TimeSpan Hora { get; set; }

        
        [Required(ErrorMessage = "No se aceptan campos vacios")]
        [DataType(DataType.Text)]
        public string Descripcion { get; set; }

        [DisplayName("Centro")]
        [Required(ErrorMessage = "No se aceptan campos vacios")]
        public int IdCentro { get; set; }

        [DisplayName("Proxima cita")]
        [Required(ErrorMessage ="No se aceptan campos vacios")]
        public string FuturaCita { get; set; }
    
        public virtual CENTRO CENTRO { get; set; }
        public virtual PACIENTE PACIENTE { get; set; }
    }
}

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
        [Required(ErrorMessage ="No se aceptan campos vacios")]
        [DisplayName("Numero de citas")]
        public int NumeroCitas { get; set; }

        [Required(ErrorMessage = "No se aceptan campos vacios")]
        [DisplayName("Pacientes")]
        public int IdPaciente { get; set; }

        [Required(ErrorMessage = "No se aceptan campos vacios")]
        [DataType(DataType.Date)]
        public System.DateTime Fecha { get; set; }

        [Required(ErrorMessage = "No se aceptan campos vacios")]
        [DataType(DataType.Time)]
        public System.TimeSpan Hora { get; set; }

        [Required(ErrorMessage = "No se aceptan campos vacios")]
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "No se aceptan campos vacios")]
        [DisplayName("Centro")]
        public int IdCentro { get; set; }
    
        public virtual PACIENTE PACIENTE { get; set; }
        public virtual CENTRO CENTRO { get; set; }
    }
}

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

    public partial class ESTADOCUENTALABORATORIO
    {
        [Key]
        public int IdEstadoL { get; set; }

        [Required(ErrorMessage ="No se aceptan campos vacios")]
        public int Monto { get; set; }

        [Required(ErrorMessage = "No se aceptan campos vacios")]
        public int Abono { get; set; }

        [Required(ErrorMessage = "No se aceptan campos vacios")]
        public int Faltante { get; set; }

        [Required(ErrorMessage = "No se aceptan campos vacios")]
        [DisplayName("Laboratorio")]
        public int IdLaboratorio { get; set; }
    
        public virtual LABORATORIO LABORATORIO { get; set; }
    }
}

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
    using System.ComponentModel.DataAnnotations;

    public partial class ESTADOTRABAJO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ESTADOTRABAJO()
        {
            this.RELACIONTRALA = new HashSet<RELACIONTRALA>();
            this.TRABAJO = new HashSet<TRABAJO>();
            this.TRABAJO1 = new HashSet<TRABAJO>();
        }
    
        [Key]
        public int IdEstadoT { get; set; }

        [Required(ErrorMessage = "No se aceptan campos vacios")]
        [DataType(DataType.Text)]
        public string Estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RELACIONTRALA> RELACIONTRALA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRABAJO> TRABAJO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRABAJO> TRABAJO1 { get; set; }
    }
}

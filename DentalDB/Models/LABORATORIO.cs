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
    
    public partial class LABORATORIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LABORATORIO()
        {
            this.ESTADOCUENTALABORATORIO = new HashSet<ESTADOCUENTALABORATORIO>();
            this.RELACIONTRALA = new HashSet<RELACIONTRALA>();
        }
    
        public int IdLaboratorio { get; set; }
        public System.DateTime Fecha { get; set; }
        public string Nombre { get; set; }
        public Nullable<int> IdPaciente { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ESTADOCUENTALABORATORIO> ESTADOCUENTALABORATORIO { get; set; }
        public virtual PACIENTE PACIENTE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RELACIONTRALA> RELACIONTRALA { get; set; }
    }
}

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
    
    public partial class ESTADODECUENTA
    {
        public int IdEstadoP { get; set; }
        public int Monto { get; set; }
        public int Abono { get; set; }
        public int Faltante { get; set; }
        public int IdPaciente { get; set; }
    
        public virtual PACIENTE PACIENTE { get; set; }
    }
}

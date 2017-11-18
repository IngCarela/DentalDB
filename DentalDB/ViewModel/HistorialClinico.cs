using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DentalDB.Models;

namespace DentalDB.ViewModel
{
    public class HistorialClinico
    {
        public List<PACIENTE> paciente { get; set; }
        public List<TRABAJO> trabajo { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace merindo.Models
{
    public class Cita
    {
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public string NombreCliente { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }
}

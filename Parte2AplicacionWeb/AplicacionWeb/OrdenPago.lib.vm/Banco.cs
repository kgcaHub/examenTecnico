using System;
using System.Collections.Generic;
using System.Text;

namespace OrdenPago.lib.vm
{
    public class Banco
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string FechaRegistro { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OrdenPago.lib.vm
{
    public class OrdenPago
    {
        public Guid Id { get; set; }
        public decimal Monto { get; set; }
        public string Estado { get; set; }
        public string FechaPago { get; set; }
    }
}

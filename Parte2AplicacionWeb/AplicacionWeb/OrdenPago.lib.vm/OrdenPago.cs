using System;
using System.Collections.Generic;
using System.Text;

namespace OrdenPago.lib.vm
{
    public class OrdenPago
    {
        public Guid Id { get; set; }
        public Guid Banco { get; set; }
        public Guid Sucursal { get; set; }
        public decimal Monto { get; set; }
        public string Moneda { get; set; }
        public string Estado { get; set; }
        public string FechaPago { get; set; }
    }
}

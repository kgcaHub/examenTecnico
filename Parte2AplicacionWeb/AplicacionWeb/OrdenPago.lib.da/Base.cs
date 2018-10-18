using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace OrdenPago.lib.da
{
    public class Base
    {
        internal SqlConnection _Conexion;

        public Base(SqlConnection conexion)
        {
            this._Conexion = conexion;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace OrdenPago.lib.bn
{
    public class Base:IDisposable
    {
        internal SqlConnection _Conexion;

        public Base()
        {
            this._Conexion = new SqlConnection("Server = N551JK-PC; Database = OrdenPago; Trusted_Connection=Yes;");
            //this._Conexion.Open();
        }

        public Base(string usuario)
        {
            this._Conexion = new SqlConnection("Server = N551JK-PC; Database = OrdenPago; Trusted_Connection=Yes;");
            //this._Conexion.Open();
        }

        public void Dispose()
        {
            //this._Conexion.Close();
            //this._Conexion.Dispose();
        }
    }
}

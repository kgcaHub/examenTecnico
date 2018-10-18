using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace OrdenPago.lib.bn
{
    public class OrdenPago: Base
    {
        private string _Usuario;

        public OrdenPago()
        {

        }

        public OrdenPago(string usuario)
        {
            this._Usuario = usuario;
        }

        public void Registrar(vm.Banco banco)
        {
            da.OrdenPago _daOrdenPago = new da.OrdenPago(this._Conexion);
            _daOrdenPago.Registrar();
        }

        public void Actualizar(vm.Banco banco)
        {
            da.OrdenPago _daOrdenPago = new da.OrdenPago(this._Conexion);
            _daOrdenPago.Actualizar();
        }

        public void Eliminar(Guid id)
        {
            da.OrdenPago _daOrdenPago = new da.OrdenPago(this._Conexion);
            _daOrdenPago.Eliminar(id);
        }

        public List<vm.OrdenPago> Filtrar(string nombreSucursal, string moneda)
        {
            List<vm.OrdenPago> _resultado = new List<vm.OrdenPago>();

            da.OrdenPago _daOrdenPago = new da.OrdenPago(this._Conexion);
            _resultado = _daOrdenPago.Filtrar(nombreSucursal, moneda);

            return _resultado;

        }
    }
}

using OrdenPago.lib.util;
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

        public void Registrar(vm.OrdenPago ordenPago)
        {
            da.OrdenPago _daOrdenPago = new da.OrdenPago(this._Conexion);
            ordenPago.Id = Guid.NewGuid();
            this.ValidarEntidad(ordenPago);
            _daOrdenPago.Registrar(ordenPago, this._Usuario);
        }

        public void Actualizar(vm.OrdenPago ordenPago)
        {
            da.OrdenPago _daOrdenPago = new da.OrdenPago(this._Conexion);
            this.ValidarEntidad(ordenPago);
            _daOrdenPago.Actualizar(ordenPago, this._Usuario);
        }

        public void Eliminar(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new OpException("Seleccione una orden de pago por favor");
            }
            else
            {
                da.OrdenPago _daOrdenPago = new da.OrdenPago(this._Conexion);
                _daOrdenPago.Eliminar(id, this._Usuario);
            }
        }

        public vm.OrdenPago Obtener(Guid id)
        {
            vm.OrdenPago _resultado = new vm.OrdenPago();

            da.OrdenPago _daSucursal = new da.OrdenPago(this._Conexion);
            _resultado = _daSucursal.Obtener(id);

            return _resultado;
        }

        public List<vm.OrdenPago> Listar(Guid sucursal)
        {
            List<vm.OrdenPago> _resultado = new List<vm.OrdenPago>();

            da.OrdenPago _daOrdenPago = new da.OrdenPago(this._Conexion);
            _resultado = _daOrdenPago.Listar(sucursal);

            return _resultado;
        }

        public List<vm.OrdenPago> Filtrar(string nombreSucursal, string moneda)
        {
            List<vm.OrdenPago> _resultado = new List<vm.OrdenPago>();

            da.OrdenPago _daOrdenPago = new da.OrdenPago(this._Conexion);
            _resultado = _daOrdenPago.Filtrar(nombreSucursal, moneda);

            return _resultado;

        }

        private void ValidarEntidad(vm.OrdenPago ordenPago)
        {
            if (ordenPago.Id == Guid.Empty)
            {
                throw new OpException("Seleccione la orden de pago");
            }
            if (ordenPago.Banco == Guid.Empty)
            {
                throw new OpException("El valor del banco es nulo");
            }
            if (ordenPago.Monto<=0)
            {
                throw new OpException("El monto debe ser mayor a 0");
            }

            switch (ordenPago.Estado)
            {
                case "PAGADA":
                    if (string.IsNullOrEmpty(ordenPago.FechaPago))
                    {
                        throw new OpException("La fecha de pago está vacia");
                    }
                    if (ordenPago.Sucursal == Guid.Empty)
                    {
                        throw new OpException("El valor de la sucursal es nula");
                    }
                    break;
                default:
                    break;
            }
        }
    }
}

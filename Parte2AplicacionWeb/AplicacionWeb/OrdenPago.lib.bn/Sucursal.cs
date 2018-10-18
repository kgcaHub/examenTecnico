using OrdenPago.lib.util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace OrdenPago.lib.bn
{
    public class Sucursal: Base
    {
        private string _Usuario;
        
        public Sucursal()
        {
        }

        public Sucursal(string usuario)
        {
            this._Usuario = usuario;
        }

        public void Registrar(vm.Sucursal sucursal)
        {
            da.Sucursal _daSucursal = new da.Sucursal(this._Conexion);
            sucursal.Id = Guid.NewGuid();
            this.ValidarEntidad(sucursal);
            if (_daSucursal.Obtener(sucursal.Nombre, sucursal.Banco) != Guid.Empty)
            {
                throw new OpException("El nombre de la sucursal ya se encuentra registrado");
            }
            _daSucursal.Registrar(sucursal, this._Usuario);
        }

        public void Actualizar(vm.Sucursal sucursal)
        {
            da.Sucursal _daSucursal = new da.Sucursal(this._Conexion);
            this.ValidarEntidad(sucursal);
            if (_daSucursal.Obtener(sucursal.Nombre, sucursal.Banco) != sucursal.Id)
            {
                throw new OpException("El nombre de la sucursal ya se encuentra registrado");
            }
            _daSucursal.Actualizar(sucursal, this._Usuario);
        }

        public void Eliminar(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new OpException("Seleccione una sucursal por favor");
            }
            else
            {
                da.Sucursal _daSucursal = new da.Sucursal(this._Conexion);
                da.OrdenPago _daOrdenPago = new da.OrdenPago(this._Conexion);

                using (SqlTransaction _transaction = this._Conexion.BeginTransaction())
                {
                    try
                    {
                        _daOrdenPago.EliminarSucursal(id, this._Usuario, _transaction);
                        _daSucursal.Eliminar(id, this._Usuario, _transaction);
                    }
                    catch (Exception ex)
                    {
                        _transaction.Rollback();
                        throw ex;
                    }
                    _transaction.Commit();
                }
            }
        }

        public vm.Sucursal Obtener(Guid id)
        {
            vm.Sucursal _resultado = new vm.Sucursal();

            da.Sucursal _daSucursal = new da.Sucursal(this._Conexion);
            _resultado = _daSucursal.Obtener(id);

            return _resultado;
        }

        public List<vm.Sucursal> Listar(Guid banco)
        {
            List<vm.Sucursal> _resultado = new List<vm.Sucursal>();

            da.Sucursal _daSucursal = new da.Sucursal(this._Conexion);
            _resultado = _daSucursal.Listar(banco);

            return _resultado;
        }

        public List<vm.Sucursal> Filtrar(string nombreBanco)
        {
            List<vm.Sucursal> _resultado = new List<vm.Sucursal>();

            da.Sucursal _daSucursal = new da.Sucursal(this._Conexion);
            _resultado = _daSucursal.Filtrar(nombreBanco);

            return _resultado;
        }

        private void ValidarEntidad(vm.Sucursal sucursal)
        {
            if (sucursal.Id == Guid.Empty)
            {
                throw new OpException("Seleccione la sucursal");
            }
            if (sucursal.Banco == Guid.Empty)
            {
                throw new OpException("El valor del banco es nulo");
            }
            if (string.IsNullOrEmpty(sucursal.Nombre))
            {
                throw new OpException("El nombre de la sucursal esta vacia");
            }
            if (string.IsNullOrEmpty(sucursal.Direccion))
            {
                throw new OpException("El dirección de la sucursal esta vacia");
            }
        }
    }
}

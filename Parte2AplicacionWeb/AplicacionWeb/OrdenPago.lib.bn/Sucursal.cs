using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace OrdenPago.lib.bn
{
    public class Sucursal: Base
    {
        private string _Usuario;

        public Sucursal(string usuario)
        {
            this._Usuario = usuario;
        }

        public Sucursal()
        {
        }

        public void Registrar(vm.Sucursal sucursal)
        {
            da.Sucursal _daSucursal = new da.Sucursal(this._Conexion);
            if (_daSucursal.Obtener(sucursal.Nombre, sucursal.Banco) == Guid.Empty)
            {
                _daSucursal.Registrar(sucursal, this._Usuario);
            }
            else
            {
                throw new Exception("El nombre de la sucursal ya se encuentra registrado");
            }
        }

        public void Actualizar(vm.Sucursal sucursal)
        {
            da.Sucursal _daSucursal = new da.Sucursal(this._Conexion);
            if (_daSucursal.Obtener(sucursal.Nombre, sucursal.Banco, sucursal.Id) == Guid.Empty)
            {
                _daSucursal.Actualizar(sucursal, this._Usuario);
            }
            else
            {
                throw new Exception("El nombre de la sucursal ya se encuentra registrado");
            }
        }

        public void Eliminar(Guid id)
        {
            da.Sucursal _daSucursal = new da.Sucursal(this._Conexion);
            da.OrdenPago _daOrdenPago = new da.OrdenPago(this._Conexion);

            using (SqlTransaction _transaction = this._Conexion.BeginTransaction())
            {
                try
                {
                    _daOrdenPago.EliminarSucursal(id, this._Usuario);
                    _daSucursal.Eliminar(id, this._Usuario);
                }
                catch (Exception ex)
                {
                    _transaction.Rollback();
                    throw ex;
                }
                _transaction.Commit();
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
    }
}

using OrdenPago.lib.util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace OrdenPago.lib.bn
{
    public class Banco:Base
    {
        private string _Usuario;

        public Banco()
        {
        }

        public Banco(string usuario)
        {
            this._Usuario = usuario;
        }

        public void Registrar(vm.Banco banco)
        {
            da.Banco _daBanco = new da.Banco(this._Conexion);
            banco.Id = Guid.NewGuid();
            this.ValidarEntidad(banco);
            if (_daBanco.Obtener(banco.Nombre) != Guid.Empty)
            {
                throw new OpException("El nombre del banco ya se encuentra registrado");
            }
            _daBanco.Registrar(banco, this._Usuario);
        }

        public void Actualizar(vm.Banco banco)
        {
            da.Banco _daBanco = new da.Banco(this._Conexion);
            this.ValidarEntidad(banco);
            if (_daBanco.Obtener(banco.Nombre) != banco.Id)
            {
                throw new OpException("El nombre del banco ya se encuentra registrado");
            }
            _daBanco.Actualizar(banco, this._Usuario);
        }

        public void Eliminar(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new OpException("Seleccione un banco por favor");
            }
            else
            {
                da.Banco _daBanco = new da.Banco(this._Conexion);
                da.Sucursal _daSucursal = new da.Sucursal(this._Conexion);
                da.OrdenPago _daOrdenPago = new da.OrdenPago(this._Conexion);

                using (SqlTransaction _transaction = this._Conexion.BeginTransaction())
                {
                    try
                    {
                        _daOrdenPago.EliminarBanco(id, this._Usuario, _transaction);
                        _daSucursal.EliminarBanco(id, this._Usuario, _transaction);
                        _daBanco.Eliminar(id, this._Usuario, _transaction);
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

        public vm.Banco Obtener(Guid id)
        {
            vm.Banco _resultado = new vm.Banco();
            da.Banco _daBanco = new da.Banco(this._Conexion);
            _resultado = _daBanco.Obtener(id);
            return _resultado;
        }

        public List<vm.Banco> Listar()
        {
            List<vm.Banco> _resultado = new List<vm.Banco>();

            da.Banco _daBanco = new da.Banco(this._Conexion);
            _resultado = _daBanco.Listar();

            return _resultado;
        }

        private void ValidarEntidad(vm.Banco banco)
        {
            if (banco.Id == Guid.Empty)
            {
                throw new OpException("Seleccione el banco");
            }
            if (string.IsNullOrEmpty(banco.Nombre))
            {
                throw new OpException("El nombre del banco esta vacio");
            }
            if (string.IsNullOrEmpty(banco.Direccion))
            {
                throw new OpException("La dirección del banco esta vacia");
            }
        }
    }
}

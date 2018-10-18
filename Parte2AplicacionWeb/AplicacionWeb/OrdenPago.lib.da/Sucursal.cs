using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace OrdenPago.lib.da
{
    public class Sucursal:Base
    {
        public Sucursal(SqlConnection conexion) : base(conexion)
        {
        }

        public void Registrar(vm.Sucursal sucursal, string usuario)
        {
            using (SqlCommand _comando = this._Conexion.CreateCommand())
            {
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.CommandText = "OP.SP_sucursal_insertar";
                _comando.Parameters.AddWithValue("@id", sucursal.Id);
                _comando.Parameters.AddWithValue("@banco", sucursal.Banco);
                _comando.Parameters.AddWithValue("@nombre", sucursal.Nombre);
                _comando.Parameters.AddWithValue("@direccion", sucursal.Direccion);
                _comando.Parameters.AddWithValue("@usuario", usuario);
                _comando.ExecuteNonQuery();
            }
        }

        public void Actualizar(vm.Sucursal sucursal, string usuario)
        {
            using (SqlCommand _comando = this._Conexion.CreateCommand())
            {
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.CommandText = "OP.SP_sucursal_actualizar";
                _comando.Parameters.AddWithValue("@id", sucursal.Id);
                _comando.Parameters.AddWithValue("@banco", sucursal.Banco);
                _comando.Parameters.AddWithValue("@nombre", sucursal.Nombre);
                _comando.Parameters.AddWithValue("@direccion", sucursal.Direccion);
                _comando.Parameters.AddWithValue("@usuario", usuario);
                _comando.ExecuteNonQuery();
            }
        }

        public void Eliminar(Guid id, string usuario, SqlTransaction transaction)
        {
            using (SqlCommand _comando = this._Conexion.CreateCommand())
            {
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.CommandText = "OP.SP_sucursal_eliminar";
                _comando.Parameters.AddWithValue("@id", id);
                _comando.Parameters.AddWithValue("@usuario", usuario);
                _comando.Transaction = transaction;
                _comando.ExecuteNonQuery();
            }
        }

        public void EliminarBanco(Guid banco, string usuario, SqlTransaction transaccion)
        {
            using (SqlCommand _comando = this._Conexion.CreateCommand())
            {
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.CommandText = "OP.SP_sucursal_eliminar_banco";
                _comando.Parameters.AddWithValue("@banco", banco);
                _comando.Parameters.AddWithValue("@usuario", usuario);
                _comando.Transaction = transaccion;
                _comando.ExecuteNonQuery();
            }
        }

        public vm.Sucursal Obtener(Guid id)
        {
            vm.Sucursal _resultado = new vm.Sucursal();
            using (SqlCommand _comando = this._Conexion.CreateCommand())
            {
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.CommandText = "OP.SP_sucursal_obtener";
                _comando.Parameters.AddWithValue("@id", id);

                using (SqlDataReader _lector = _comando.ExecuteReader(CommandBehavior.SingleRow))
                {
                    while (_lector.Read())
                    {
                        _resultado.Id = id;
                        _resultado.Nombre = _lector.GetString(_lector.GetOrdinal("nombre"));
                        _resultado.Direccion = _lector.GetString(_lector.GetOrdinal("direccion"));
                        _resultado.FechaRegistro = _lector.GetDateTime(_lector.GetOrdinal("fecha_registro")).ToString("dd/MM/yyyy");
                    }
                }
            }

            return _resultado;
        }

        public Guid Obtener(string nombre, Guid banco)
        {
            Guid _resultado = Guid.Empty;
            using (SqlCommand _comando = this._Conexion.CreateCommand())
            {
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.CommandText = "OP.SP_sucursal_obtener_nombre";
                _comando.Parameters.AddWithValue("@nombre", nombre);
                _comando.Parameters.AddWithValue("@banco", banco);

                object _scalar = _comando.ExecuteScalar();

                if (_scalar != null)
                {
                    if (_scalar != DBNull.Value)
                    {
                        _resultado = Guid.Parse(_scalar.ToString());
                    }
                }
            }
            return _resultado;
        }

        public List<vm.Sucursal> Listar(Guid banco)
        {
            List<vm.Sucursal> _resultado = new List<vm.Sucursal>();
            using (SqlCommand _comando = this._Conexion.CreateCommand())
            {
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.CommandText = "OP.SP_sucursal_listar";
                _comando.Parameters.AddWithValue("@banco", banco);

                using (SqlDataReader _lector = _comando.ExecuteReader(CommandBehavior.Default))
                {
                    while (_lector.Read())
                    {
                        vm.Sucursal _banco = new vm.Sucursal();
                        _banco.Id = _lector.GetGuid(_lector.GetOrdinal("id"));
                        _banco.Nombre = _lector.GetString(_lector.GetOrdinal("nombre"));
                        _resultado.Add(_banco);
                    }
                }
            }
            return _resultado;
        }

        public List<vm.Sucursal> Filtrar(string nombreBanco)
        {
            List<vm.Sucursal> _resultado = new List<vm.Sucursal>();
            using (SqlCommand _comando = this._Conexion.CreateCommand())
            {
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.CommandText = "OP.SP_sucursal_filtrar";
                _comando.Parameters.AddWithValue("@nombre_banco", nombreBanco);

                using (SqlDataReader _lector = _comando.ExecuteReader(CommandBehavior.Default))
                {
                    while (_lector.Read())
                    {
                        vm.Sucursal _banco = new vm.Sucursal();
                        _banco.Id = _lector.GetGuid(_lector.GetOrdinal("id"));
                        _banco.Nombre = _lector.GetString(_lector.GetOrdinal("nombre"));
                        _banco.Direccion = _lector.GetString(_lector.GetOrdinal("direccion"));
                        _banco.FechaRegistro = _lector.GetDateTime(_lector.GetOrdinal("fecha_registro")).ToString("dd/MM/yyyy");
                        _resultado.Add(_banco);
                    }
                }
            }
            return _resultado;
        }
    }
}

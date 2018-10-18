using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace OrdenPago.lib.da
{
    public class Banco: Base
    {
        public Banco(SqlConnection conexion) : base(conexion)
        {
        }

        public void Registrar(vm.Banco banco, string usuario)
        {
            using (SqlCommand _comando = this._Conexion.CreateCommand())
            {
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.CommandText = "OP.SP_banco_insertar";
                _comando.Parameters.AddWithValue("@id", banco.Id);
                _comando.Parameters.AddWithValue("@nombre", banco.Nombre);
                _comando.Parameters.AddWithValue("@direccion", banco.Direccion);
                _comando.Parameters.AddWithValue("@usuario", usuario);
                _comando.ExecuteNonQuery();
            }
        }

        public void Actualizar(vm.Banco banco, string usuario)
        {
            using (SqlCommand _comando = this._Conexion.CreateCommand())
            {
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.CommandText = "OP.SP_banco_actualizar";
                _comando.Parameters.AddWithValue("@id", banco.Id);
                _comando.Parameters.AddWithValue("@nombre", banco.Nombre);
                _comando.Parameters.AddWithValue("@direccion", banco.Direccion);
                _comando.Parameters.AddWithValue("@usuario", usuario);
                _comando.ExecuteNonQuery();
            }
        }

        public void Eliminar(Guid id, string usuario)
        {
            using (SqlCommand _comando = this._Conexion.CreateCommand())
            {
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.CommandText = "OP.SP_banco_eliminar";
                _comando.Parameters.AddWithValue("@id", id);
                _comando.Parameters.AddWithValue("@usuario", usuario);
                _comando.ExecuteNonQuery();
            }
        }

        public vm.Banco Obtener(Guid id)
        {
            vm.Banco _resultado = new vm.Banco();
            using (SqlCommand _comando = this._Conexion.CreateCommand())
            {
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.CommandText = "OP.SP_banco_obtener";
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

        public Guid Obtener(string nombre)
        {
            Guid _resultado = Guid.Empty;
            using (SqlCommand _comando = this._Conexion.CreateCommand())
            {
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.CommandText = "OP.SP_banco_obtener_nombre";
                _comando.Parameters.AddWithValue("@nombre", nombre);

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

        public Guid Obtener(string nombre, Guid id)
        {
            Guid _resultado = Guid.Empty;
            using (SqlCommand _comando = this._Conexion.CreateCommand())
            {
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.CommandText = "OP.SP_banco_obtener_nombre_id";
                _comando.Parameters.AddWithValue("@nombre", nombre);
                _comando.Parameters.AddWithValue("@id", id);

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

        public List<vm.Banco> Listar()
        {
            List<vm.Banco> _resultado = new List<vm.Banco>();
            using (SqlCommand _comando = this._Conexion.CreateCommand())
            {
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.CommandText = "OP.SP_banco_listar";

                using (SqlDataReader _lector = _comando.ExecuteReader(CommandBehavior.SingleRow))
                {
                    while (_lector.Read())
                    {
                        vm.Banco _banco = new vm.Banco();
                        _banco.Id = _lector.GetGuid(_lector.GetOrdinal("id"));
                        _banco.Nombre = _lector.GetString(_lector.GetOrdinal("nombre"));
                        _resultado.Add(_banco);
                    }
                }
            }
            return _resultado;
        }
    }
}

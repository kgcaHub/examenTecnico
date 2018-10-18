using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace OrdenPago.lib.da
{
    public class OrdenPago: Base
    {
        public OrdenPago(SqlConnection conexion) : base(conexion)
        {
        }

        public void Registrar(vm.OrdenPago sucursal, string usuario)
        {
            using (SqlCommand _comando = this._Conexion.CreateCommand())
            {
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.CommandText = "OP.SP_orden_pago_insertar";
                _comando.Parameters.AddWithValue("@id", sucursal.Id);
                _comando.Parameters.AddWithValue("@banco", sucursal.Banco);
                _comando.Parameters.AddWithValue("@sucursal", sucursal.Sucursal);
                _comando.Parameters.AddWithValue("@monto", sucursal.Monto);
                _comando.Parameters.AddWithValue("@moneda", sucursal.Moneda);
                _comando.Parameters.AddWithValue("@estado", sucursal.Estado);
                _comando.Parameters.AddWithValue("@fecha_pago", sucursal.FechaPago);
                _comando.Parameters.AddWithValue("@usuario", usuario);
                _comando.ExecuteNonQuery();
            }
        }

        public void Actualizar(vm.OrdenPago sucursal, string usuario)
        {
            using (SqlCommand _comando = this._Conexion.CreateCommand())
            {
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.CommandText = "OP.SP_orden_pago_actualizar";
                _comando.Parameters.AddWithValue("@id", sucursal.Id);
                _comando.Parameters.AddWithValue("@banco", sucursal.Banco);
                _comando.Parameters.AddWithValue("@sucursal", sucursal.Sucursal);
                _comando.Parameters.AddWithValue("@monto", sucursal.Monto);
                _comando.Parameters.AddWithValue("@moneda", sucursal.Moneda);
                _comando.Parameters.AddWithValue("@estado", sucursal.Estado);
                _comando.Parameters.AddWithValue("@fecha_pago", sucursal.FechaPago);
                _comando.Parameters.AddWithValue("@usuario", usuario);
                _comando.ExecuteNonQuery();
            }
        }

        public void Eliminar(Guid id, string usuario)
        {
            using (SqlCommand _comando = this._Conexion.CreateCommand())
            {
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.CommandText = "OP.SP_orden_pago_eliminar";
                _comando.Parameters.AddWithValue("@id", id);
                _comando.Parameters.AddWithValue("@usuario", usuario);
                _comando.ExecuteNonQuery();
            }
        }

        public void EliminarSucursal(Guid sucursal, string usuario, SqlTransaction transaction)
        {
            using (SqlCommand _comando = this._Conexion.CreateCommand())
            {
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.CommandText = "OP.SP_orden_pago_eliminar_sucursal";
                _comando.Parameters.AddWithValue("@sucursal", sucursal);
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
                _comando.CommandText = "OP.SP_orden_pago_eliminar_banco";
                _comando.Parameters.AddWithValue("@banco", banco);
                _comando.Parameters.AddWithValue("@usuario", usuario);
                _comando.Transaction = transaccion;
                _comando.ExecuteNonQuery();
            }
        }

        public vm.OrdenPago Obtener(Guid id)
        {
            vm.OrdenPago _resultado = new vm.OrdenPago();
            using (SqlCommand _comando = this._Conexion.CreateCommand())
            {
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.CommandText = "OP.SP_orden_pago_obtener";
                _comando.Parameters.AddWithValue("@id", id);

                using (SqlDataReader _lector = _comando.ExecuteReader(CommandBehavior.SingleRow))
                {
                    while (_lector.Read())
                    {
                        _resultado.Id = id;
                        _resultado.Monto = _lector.GetDecimal(_lector.GetOrdinal("monto"));
                        _resultado.Moneda = _lector.GetString(_lector.GetOrdinal("moneda"));
                        _resultado.Estado = _lector.GetString(_lector.GetOrdinal("estado"));

                        object _objeto = _lector.GetValue(_lector.GetOrdinal("fecha_pago"));

                        if (_objeto != null)
                        {
                            if (_objeto != DBNull.Value)
                            {
                                _resultado.FechaPago = Convert.ToDateTime(_objeto).ToString("yyyy-MM-dd");
                            }
                        }
                    }
                }
            }

            return _resultado;
        }

        public List<vm.OrdenPago> Listar(Guid sucursal)
        {
            List<vm.OrdenPago> _resultado = new List<vm.OrdenPago>();
            using (SqlCommand _comando = this._Conexion.CreateCommand())
            {
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.CommandText = "OP.SP_orden_pago_listar";
                _comando.Parameters.AddWithValue("@sucursal", sucursal);

                using (SqlDataReader _lector = _comando.ExecuteReader(CommandBehavior.Default))
                {
                    while (_lector.Read())
                    {
                        vm.OrdenPago _banco = new vm.OrdenPago();
                        _banco.Id = _lector.GetGuid(_lector.GetOrdinal("id"));
                        _banco.Monto = _lector.GetDecimal(_lector.GetOrdinal("monto"));
                        _resultado.Add(_banco);
                    }
                }
            }
            return _resultado;
        }


        public List<vm.OrdenPago> Filtrar(string nombreSucursal, string moneda)
        {
            List<vm.OrdenPago> _resultado = new List<vm.OrdenPago>();
            using (SqlCommand _comando = this._Conexion.CreateCommand())
            {
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.CommandText = "OP.SP_orden_pago_filtrar";
                _comando.Parameters.AddWithValue("@nombre_sucursal", nombreSucursal);
                _comando.Parameters.AddWithValue("@moneda", moneda);

                using (SqlDataReader _lector = _comando.ExecuteReader(CommandBehavior.Default))
                {
                    while (_lector.Read())
                    {
                        vm.OrdenPago _ordenPago = new vm.OrdenPago();
                        _ordenPago.Id = _lector.GetGuid(_lector.GetOrdinal("id"));
                        _ordenPago.Monto = _lector.GetDecimal(_lector.GetOrdinal("monto"));
                        _ordenPago.Estado = _lector.GetString(_lector.GetOrdinal("estado"));

                        object _objeto = _lector.GetValue(_lector.GetOrdinal("fecha_pago"));

                        if (_objeto != null)
                        {
                            if (_objeto != DBNull.Value)
                            {
                                _ordenPago.FechaPago = Convert.ToDateTime(_objeto).ToString("dd/MM/yyyy");
                            }
                        }
                        _resultado.Add(_ordenPago);
                    }
                }
            }
            return _resultado;
        }
    }
}

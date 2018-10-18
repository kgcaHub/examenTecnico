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

        public void Registrar()
        {

        }

        public void Actualizar()
        {

        }

        public void Eliminar(Guid id)
        {

        }

        public void EliminarSucursal(Guid sucursal, string usuario)
        {
            using (SqlCommand _comando = this._Conexion.CreateCommand())
            {
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.CommandText = "OP.SP_orden_pago_eliminar_sucursal";
                _comando.Parameters.AddWithValue("@sucursal", sucursal);
                _comando.Parameters.AddWithValue("@usuario", usuario);
                _comando.ExecuteNonQuery();
            }
        }

        public void EliminarBanco(Guid banco, string usuario)
        {
            using (SqlCommand _comando = this._Conexion.CreateCommand())
            {
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.CommandText = "OP.SP_orden_pago_eliminar_banco";
                _comando.Parameters.AddWithValue("@banco", banco);
                _comando.Parameters.AddWithValue("@usuario", usuario);
                _comando.ExecuteNonQuery();
            }
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

                using (SqlDataReader _lector = _comando.ExecuteReader(CommandBehavior.SingleRow))
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

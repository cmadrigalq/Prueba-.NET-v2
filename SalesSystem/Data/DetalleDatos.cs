using Microsoft.Data.SqlClient;
using SalesSystem.Models;
using System.Collections.Generic;
using System.Data;
using System;

namespace SalesSystem.Data
{
    public class DetalleDatos
    {
        public List<TDetalle> ListarDetalles(int ConsecutivoFactura)
        {
             var oLista = new List<TDetalle>();

            var cn = new ApplicationDbContext();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerDetallesFactura", conexion);
                cmd.Parameters.AddWithValue("ConsecutivoFactura", ConsecutivoFactura);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oLista.Add(new TDetalle()
                        {
                            CodigoDetalle = Convert.ToInt32(dr["CodigoDetalle"]),
                            ConsecutivoFactura = Convert.ToInt32(dr["ConsecutivoFactura"]),
                            CodigoArticulo = (dr["CodigoArticulo"]).ToString(),
                            Cantidad = Convert.ToInt32(dr["Cantidad"]),
                            PrecioFinal = Convert.ToInt32(dr["PrecioCoPrecioFinalnIVA"])
                            /*UsuarioFactura = Convert.ToInt32(dr["UsuarioFactura"]),
                            FechaFactura = Convert.ToDecimal(dr["FechaFactura"]),
                            DetallesFactura = Convert.ToDecimal(dr["DetallesFactura"])*/
                        });
                    }
                }
            }

            return oLista;
        }
        public bool GuardarDetalle(TDetalle oDetalle)
        {
            bool rpta;

            try
            {
                var cn = new ApplicationDbContext();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_CrearDetalle", conexion);
                    cmd.Parameters.AddWithValue("CodigoDetalle", oDetalle.CodigoDetalle);
                    cmd.Parameters.AddWithValue("ConsecutivoFactura", oDetalle.ConsecutivoFactura);
                    cmd.Parameters.AddWithValue("CodigoArticulo", oDetalle.CodigoArticulo);
                    cmd.Parameters.AddWithValue("Cantidad", oDetalle.Cantidad);
                    cmd.Parameters.AddWithValue("PrecioFinal", oDetalle.PrecioFinal);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;


            }
            catch (Exception e)
            {

                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }
    }
}

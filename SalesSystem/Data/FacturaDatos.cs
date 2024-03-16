using SalesSystem.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System;

namespace SalesSystem.Data
{
    public class FacturaDatos
    {
        public List<TFactura> Listar()
        {

            var oLista = new List<TFactura>();

            var cn = new ApplicationDbContext();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarFactura", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oLista.Add(new TFactura()
                        {
                            CodigoArticulo = dr["CodigoArticulo"].ToString(),
                            UsuarioFactura = Convert.ToInt32(dr["UsuarioFactura"]),
                            CantidadArticulo = Convert.ToInt32(dr["CantidadArticulo"]),
                            ConsecutivoFactura = Convert.ToInt32(dr["ConsecutivoFactura"]),
                            FechaFactura = (DateTime)dr["FechaFactura"],
                            DetallesFactura = dr["DetallesFactura"].ToString()
                        });
                    }
                }
            }

            return oLista;
        }
        public TArticulo Obtener(string codArticulo)
        {

            var oArticulo = new TArticulo();

            var cn = new ApplicationDbContext();

            using (SqlConnection conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerArticulo", conexion);
                cmd.Parameters.AddWithValue("CodigoArticulo", codArticulo);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oArticulo.Codigo = dr["Codigo"].ToString();
                        oArticulo.NombreArticulo = dr["NombreArticulo"].ToString();
                        oArticulo.PrecioArticulo = Convert.ToDecimal(dr["PrecioArticulo"]);
                        oArticulo.AplicarIVA = Convert.ToBoolean(dr["AplicarIVA"]);
                        oArticulo.PrecioConIVA = Convert.ToDecimal(dr["PrecioConIVA"]);
                    }
                }
            }

            return oArticulo;
        }
        public TFactura ObtenerFactura(string codFactura)
        {

            var oFactura = new TFactura();

            var cn = new ApplicationDbContext();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerFactura", conexion);
                cmd.Parameters.AddWithValue("CodigoArticulo", codFactura);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oFactura.CodigoArticulo = dr["CodigoArticulo"].ToString();
                        oFactura.UsuarioFactura = Convert.ToInt32(dr["UsuarioFactura"]);
                        oFactura.CantidadArticulo = Convert.ToInt32(dr["CantidadArticulo"]);
                        oFactura.ConsecutivoFactura = Convert.ToInt32(dr["ConsecutivoFactura"]);
                        oFactura.FechaFactura = (DateTime)dr["FechaFactura"];
                        oFactura.DetallesFactura = dr["DetallesFactura"].ToString();
                    }
                }
            }

            return oFactura;
        }

        public bool Guardar(TFactura oFactura)
        {
            bool rpta;

            try
            {
                var cn = new ApplicationDbContext();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_CrearArticuloFactura", conexion);
                    cmd.Parameters.AddWithValue("CodigoArticulo", oFactura.CodigoArticulo);
                    cmd.Parameters.AddWithValue("UsuarioFactura", oFactura.UsuarioFactura);
                    cmd.Parameters.AddWithValue("CantidadArticulo", oFactura.CantidadArticulo);
                    cmd.Parameters.AddWithValue("ConsecutivoFactura", oFactura.ConsecutivoFactura);
                    cmd.Parameters.AddWithValue("FechaFactura", DateTime.Now);
                    cmd.Parameters.AddWithValue("DetallesFactura", oFactura.DetallesFactura);
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


        public bool Editar(TFactura oFactura)
        {
            bool rpta;

            try
            {
                var cn = new ApplicationDbContext();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarFactura", conexion);
                    cmd.Parameters.AddWithValue("CodigoArticulo", oFactura.CodigoArticulo);
                    cmd.Parameters.AddWithValue("UsuarioFactura", oFactura.UsuarioFactura);
                    cmd.Parameters.AddWithValue("CantidadArticulo", oFactura.CantidadArticulo);
                    cmd.Parameters.AddWithValue("ConsecutivoFactura", oFactura.ConsecutivoFactura);
                    cmd.Parameters.AddWithValue("FechaFactura", oFactura.FechaFactura);
                    cmd.Parameters.AddWithValue("DetallesFactura", oFactura.DetallesFactura);
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

        public bool Eliminar(string codFactura, int consecutivo)
        {
            bool rpta;

            try
            {
                var cn = new ApplicationDbContext();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarFactura", conexion);
                    cmd.Parameters.AddWithValue("CodigoArticulo", codFactura);
                    cmd.Parameters.AddWithValue("ConsecutivoFactura", consecutivo);
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

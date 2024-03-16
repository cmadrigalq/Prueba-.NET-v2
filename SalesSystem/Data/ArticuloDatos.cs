using SalesSystem.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System;

namespace SalesSystem.Data
{
    public class ArticuloDatos
    {
        public List<TArticulo> Listar()
        {

            var oLista = new List<TArticulo>();

            var cn = new ApplicationDbContext();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarArticulos", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oLista.Add(new TArticulo()
                        {
                            Codigo = dr["Codigo"].ToString(),
                            NombreArticulo = dr["NombreArticulo"].ToString(),
                            PrecioArticulo = Convert.ToDecimal(dr["PrecioArticulo"]),
                            AplicarIVA = Convert.ToByte(dr["AplicarIVA"]),
                            PrecioConIVA = Convert.ToDecimal(dr["PrecioConIVA"])
                        });
                    }
                }
            }
            
            return oLista;
        }

        public TArticulo Obtener(string Codigo)
        {

            var oArticulo = new TArticulo();

            var cn = new ApplicationDbContext();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerArticulo", conexion);
                cmd.Parameters.AddWithValue("CodigoArticulo", Codigo);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oArticulo.Codigo = dr["Codigo"].ToString();
                        oArticulo.NombreArticulo = dr["NombreArticulo"].ToString();
                        oArticulo.PrecioArticulo = Convert.ToDecimal(dr["PrecioArticulo"]);
                        oArticulo.AplicarIVA = Convert.ToByte(dr["AplicarIVA"]);
                        oArticulo.PrecioConIVA = Convert.ToDecimal(dr["PrecioConIVA"]);
                    }
                }
            }

            return oArticulo;
        }

        public bool Guardar(TArticulo oArticulo)
        {
            bool rpta;

            try
            {
                var cn = new ApplicationDbContext();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_CrearArticulo", conexion);
                    cmd.Parameters.AddWithValue("Codigo", oArticulo.Codigo);
                    cmd.Parameters.AddWithValue("NombreArticulo", oArticulo.NombreArticulo);
                    cmd.Parameters.AddWithValue("PrecioArticulo", oArticulo.PrecioArticulo);
                    cmd.Parameters.AddWithValue("AplicarIVA", oArticulo.AplicarIVA);
                    cmd.Parameters.AddWithValue("PrecioConIVA", oArticulo.PrecioConIVA);
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


        public bool Editar(TArticulo oArticulo)
        {
            bool rpta;

            try
            {
                var cn = new ApplicationDbContext();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarArticulo", conexion);
                    cmd.Parameters.AddWithValue("Codigo", oArticulo.Codigo);
                    cmd.Parameters.AddWithValue("NombreArticulo", oArticulo.NombreArticulo);
                    cmd.Parameters.AddWithValue("PrecioArticulo", oArticulo.PrecioArticulo);
                    cmd.Parameters.AddWithValue("AplicarIVA", oArticulo.AplicarIVA);
                    cmd.Parameters.AddWithValue("PrecioConIVA", oArticulo.PrecioConIVA);
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

        public bool Eliminar(string codArticulo)
        {
            bool rpta;

            try
            {
                var cn = new ApplicationDbContext();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarArticulo", conexion);
                    cmd.Parameters.AddWithValue("Codigo", codArticulo);
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
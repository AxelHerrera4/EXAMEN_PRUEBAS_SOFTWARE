using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using TDDTestingMVC1.Models;

namespace TDDTestingMVC1.Data
{
    public class OpinionClienteDataAccessLayer
    {
        private readonly string _connectionString = "Data Source=DESKTOP-9ARAUIJ;Initial Catalog=dbproductos;User ID=sa;Password=12345678;TrustServerCertificate=True;";

        public List<OpinionCliente> GetOpiniones()
        {
            List<OpinionCliente> opiniones = new List<OpinionCliente>();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("opinionCliente_SelectAll", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        OpinionCliente opinion = new OpinionCliente
                        {
                            OpinionID = Convert.ToInt32(reader["OpinionID"]),
                            ClienteID = Convert.ToInt32(reader["ClienteID"]),
                            ProductoID = reader["ProductoID"] != DBNull.Value ? Convert.ToInt32(reader["ProductoID"]) : (int?)null,
                            Calificacion = Convert.ToInt32(reader["Calificacion"]),
                            Comentario = reader["Comentario"].ToString(),
                            Fecha = Convert.ToDateTime(reader["Fecha"])
                        };
                        opiniones.Add(opinion);
                    }
                }
            }
            return opiniones;
        }

        public void AddOpinion(OpinionCliente opinion)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("opinionCliente_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ClienteID", opinion.ClienteID);
                cmd.Parameters.AddWithValue("@ProductoID", (object)opinion.ProductoID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Calificacion", opinion.Calificacion);
                cmd.Parameters.AddWithValue("@Comentario", opinion.Comentario);
                cmd.Parameters.AddWithValue("@Fecha", opinion.Fecha);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateOpinion(OpinionCliente opinion)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("opinionCliente_Update", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@OpinionID", opinion.OpinionID);
                cmd.Parameters.AddWithValue("@ClienteID", opinion.ClienteID);
                cmd.Parameters.AddWithValue("@ProductoID", (object)opinion.ProductoID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Calificacion", opinion.Calificacion);
                cmd.Parameters.AddWithValue("@Comentario", opinion.Comentario);
                cmd.Parameters.AddWithValue("@Fecha", opinion.Fecha);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteOpinion(int opinionID)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("opinionCliente_Delete", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@OpinionID", opinionID);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
using Microsoft.Data.SqlClient;
using TEST_MVC2.Models;

namespace TEST_MVC2.Data
{
    public class ClienteDataAccessLayer
    {
        private readonly string _connectionString = "Data Source=DESKTOP-9ARAUIJ;Initial Catalog=dbproductos;User ID=sa; Password=12345678;TrustServerCertificate=True;";

        public List<Cliente> GetClientes()
        {
            List<Cliente> lst = new List<Cliente>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("Cliente_SelectAll", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader()) // Cerrar automáticamente el reader
                {
                    while (rdr.Read())
                    {
                        Cliente cliente = new Cliente
                        {
                            Codigo = Convert.ToInt32(rdr["codigo"]),
                            Cedula = rdr["cedula"]?.ToString() ?? string.Empty,
                            Apellidos = rdr["apellidos"]?.ToString() ?? string.Empty,
                            Nombres = rdr["nombres"]?.ToString() ?? string.Empty,
                            FechaNacimiento = rdr["fechaNacimiento"] != DBNull.Value ? Convert.ToDateTime(rdr["fechaNacimiento"]) : DateTime.MinValue,
                            Mail = rdr["mail"]?.ToString() ?? string.Empty,
                            Telefono = rdr["telefono"]?.ToString() ?? string.Empty,
                            Direccion = rdr["direccion"]?.ToString() ?? string.Empty,
                            Estado = rdr["estado"] != DBNull.Value && Convert.ToBoolean(rdr["estado"])
                        };

                        lst.Add(cliente);
                    }
                }
            }
            return lst;
        }

        public void InsertCliente(Cliente cliente)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("cliente_Insert", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Cedula", cliente.Cedula);
                cmd.Parameters.AddWithValue("@Apellidos", cliente.Apellidos);
                cmd.Parameters.AddWithValue("@Nombres", cliente.Nombres);
                cmd.Parameters.AddWithValue("@FechaNacimiento", cliente.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Mail", cliente.Mail);
                cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                cmd.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                cmd.Parameters.AddWithValue("@Estado", cliente.Estado);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateCliente(Cliente cliente)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("cliente_Update", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Codigo", cliente.Codigo);
                cmd.Parameters.AddWithValue("@Cedula", cliente.Cedula);
                cmd.Parameters.AddWithValue("@Apellidos", cliente.Apellidos);
                cmd.Parameters.AddWithValue("@Nombres", cliente.Nombres);
                cmd.Parameters.AddWithValue("@FechaNacimiento", cliente.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Mail", cliente.Mail);
                cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                cmd.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                cmd.Parameters.AddWithValue("@Estado", cliente.Estado);

                con.Open();
                cmd.ExecuteNonQuery(); // No es necesario un SqlDataReader
            }
        }

        public void DeleteCliente(int codigo)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("cliente_Delete", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Codigo", codigo);

                con.Open();
                cmd.ExecuteNonQuery(); // No es necesario un SqlDataReader
            }
        }
        public void DeleteClienteByCedula(string cedula)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("cliente_DeleteByCedula", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Cedula", cedula);

                con.Open();
                cmd.ExecuteNonQuery(); // No es necesario un SqlDataReader
            }
        }



        public Cliente GetClienteByCedula(string cedula)
        {
            Cliente cliente = null;
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Cliente WHERE Cedula = @Cedula";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Cedula", cedula);

                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        cliente = new Cliente
                        {
                            Codigo = Convert.ToInt32(rdr["codigo"]),
                            Cedula = rdr["Cedula"].ToString(),
                            Nombres = rdr["Nombres"].ToString(),
                            Apellidos = rdr["Apellidos"].ToString(),
                            FechaNacimiento = rdr["FechaNacimiento"] != DBNull.Value ? Convert.ToDateTime(rdr["FechaNacimiento"]) : DateTime.MinValue,
                            Mail = rdr["Mail"]?.ToString() ?? string.Empty,
                            Telefono = rdr["Telefono"]?.ToString() ?? string.Empty,
                            Direccion = rdr["Direccion"]?.ToString() ?? string.Empty,
                            Estado = rdr["Estado"] != DBNull.Value && Convert.ToBoolean(rdr["Estado"])
                        };
                    }
                }
            }
            return cliente;
        }



    }
}

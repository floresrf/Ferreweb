using Ferreweb.conexion;
using Ferreweb.Models;
using System.Data;
using System.Data.SqlClient;

namespace Ferreweb.Conexion
{
    public class userData
    {
        public List<userModel> listar()
        {
            var olista = new List<userModel>();

            var cn = new conexion1();

            using (var conn = new SqlConnection(cn.getcadenasql()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("list_User", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        olista.Add(new userModel()
                        {
                            ID = Convert.ToInt32(dr["ID"]),
                            FirstName = dr["FirstName"].ToString(),
                            LastName = dr["LastName"].ToString(),
                            PhoneNumber = dr["PhoneNumber"].ToString(),
                            Email = dr["Email"].ToString(),
                            Password = dr["Password"].ToString()
                        }
                            );
                    }

                }
            }
            return olista;
        }

        public userModel Obtener(int ID)
        {
            var nRegistro = new userModel();
            var cn = new conexion1();

            using (var conexion = new SqlConnection(cn.getcadenasql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("search_User", conexion);
                cmd.Parameters.AddWithValue("ID", ID);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        nRegistro.ID = Convert.ToInt32(dr["ID"]);
                        nRegistro.FirstName = dr["FirstName"].ToString();
                        nRegistro.LastName = dr["LastName"].ToString();
                        nRegistro.PhoneNumber = dr["PhoneNumber"].ToString();
                        nRegistro.Email = dr["Email"].ToString();
                        nRegistro.Password = dr["Password"].ToString();
                    }
                }
            }

            return nRegistro;
        }

        public bool Guardar(userModel UserModel)
        {
            bool respuesta;
            try
            {

                var cn = new conexion1();

                using (var conn = new SqlConnection(cn.getcadenasql()))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("insert_User", conn);

                    cmd.Parameters.AddWithValue("FirstName", UserModel.FirstName);
                    cmd.Parameters.AddWithValue("LastName", UserModel.LastName);
                    cmd.Parameters.AddWithValue("PhoneNumber", UserModel.PhoneNumber);
                    cmd.Parameters.AddWithValue("Email", UserModel.Email);
                    cmd.Parameters.AddWithValue("Password", UserModel.Password);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                respuesta = false;
            }
            return respuesta;

        }

        public bool Eliminar(int ID)
        {
            bool respuesta;
            try
            {

                var cn = new conexion1();

                using (var conn = new SqlConnection(cn.getcadenasql()))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("delete_User", conn);

                    cmd.Parameters.AddWithValue("ID", ID);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                respuesta = false;
            }
            return respuesta;

        }

        public bool Editar(userModel UserModel)
        {
            bool rpta;

            try
            {
                var cn = new conexion1();

                using (var conn = new SqlConnection(cn.getcadenasql()))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("edit_User", conn);
                    cmd.Parameters.AddWithValue("ID", UserModel.ID);
                    cmd.Parameters.AddWithValue("FirstName", UserModel.FirstName);
                    cmd.Parameters.AddWithValue("LastName", UserModel.LastName);
                    cmd.Parameters.AddWithValue("PhoneNumber", UserModel.PhoneNumber);
                    cmd.Parameters.AddWithValue("Email", UserModel.Email);
                    cmd.Parameters.AddWithValue("Password", UserModel.Password);

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
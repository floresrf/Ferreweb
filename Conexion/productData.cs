using Ferreweb.conexion;
using Ferreweb.Models;
using System.Data;
using System.Data.SqlClient;

namespace Ferreweb.Conexion
{
    public class productData
    {
        public List<productModel> listar()
        {
            var olista = new List<productModel>();

            var cn = new conexion1();

            using (var conn = new SqlConnection(cn.getcadenasql()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("list_Product", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        olista.Add(new productModel()
                        {
                            ID = Convert.ToInt32(dr["ID"]),
                            Name = dr["Name"].ToString(),
                            Price = dr["Price"].ToString(),
                            Description = dr["Description"].ToString(),
                            Picture = dr["Picture"].ToString()
                        }
                            );
                    }

                }
            }
            return olista;
        }

        public productModel Obtener(int ID)
        {
            var nRegistro = new productModel();
            var cn = new conexion1();

            using (var conexion = new SqlConnection(cn.getcadenasql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("search_Product", conexion);
                cmd.Parameters.AddWithValue("ID", ID);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        nRegistro.ID = Convert.ToInt32(dr["ID"]);
                        nRegistro.Name = dr["Name"].ToString();
                        nRegistro.Price = dr["Price"].ToString();
                        nRegistro.Description = dr["Description"].ToString();
                        nRegistro.Picture = dr["Picture"].ToString();
                    }
                }
            }

            return nRegistro;
        }

        public bool Guardar(productModel ProductModel)
        {
            bool respuesta;
            try
            {

                var cn = new conexion1();

                using (var conn = new SqlConnection(cn.getcadenasql()))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("insert_Product", conn);

                    cmd.Parameters.AddWithValue("Name", ProductModel.Name);
                    cmd.Parameters.AddWithValue("Price", ProductModel.Price);
                    cmd.Parameters.AddWithValue("Description", ProductModel.Description);
                    cmd.Parameters.AddWithValue("Picture", ProductModel.Picture);

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
                    SqlCommand cmd = new SqlCommand("delete_Product", conn);

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

        public bool Editar(productModel ProductModel)
        {
            bool rpta;

            try
            {
                var cn = new conexion1();

                using (var conn = new SqlConnection(cn.getcadenasql()))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("edit_Product", conn);
                    cmd.Parameters.AddWithValue("ID", ProductModel.ID);
                    cmd.Parameters.AddWithValue("Name", ProductModel.Name);
                    cmd.Parameters.AddWithValue("Price", ProductModel.Price);
                    cmd.Parameters.AddWithValue("Description", ProductModel.Description);
                    cmd.Parameters.AddWithValue("Picture", ProductModel.Picture);

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
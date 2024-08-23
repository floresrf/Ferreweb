using Ferreweb.conexion;
using Ferreweb.Models;
using Microsoft.CodeAnalysis;
using System.Data;
using System.Data.SqlClient;

namespace Ferreweb.Conexion
{
    public class orderData
    {
        public List<orderModel> listar()
        {
            var olista = new List<orderModel>();

            var cn = new conexion1();

            using (var conn = new SqlConnection(cn.getcadenasql()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("list_Orders", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        olista.Add(new orderModel
                        {
                            OrderID = Convert.ToInt32(dr["OrderID"]),

                            ProductID = dr["ProductID"].ToString(),
							Product = dr["Product"].ToString(),
                            Quantity = dr["Quantity"].ToString(),
							Total_Price = dr["Total_Price"].ToString(),

                            UserID = dr["UserID"].ToString(),
							U_FirstName = dr["U_FirstName"].ToString(),
                            U_LastName = dr["U_LastName"].ToString(),
                            U_Phone = dr["U_Phone"].ToString(),
                            Direction = dr["Direction"].ToString(),

                            EmployeeID = dr["EmployeeID"].ToString(),
                            E_FirstName = dr["E_FirstName"].ToString(),
                            E_LastName = dr["E_LastName"].ToString()
                        }
                            );
                    }

                }
            }
            return olista;
        }
        public bool Guardar(orderModel OrderModel)
        {
            bool respuesta;
            try
            {

                var cn = new conexion1();

                using (var conn = new SqlConnection(cn.getcadenasql()))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("insert_Order", conn);

                    cmd.Parameters.AddWithValue("ProductID", OrderModel.ProductID);
                    cmd.Parameters.AddWithValue("UserID", OrderModel.UserID);
                    cmd.Parameters.AddWithValue("EmployeeID", OrderModel.EmployeeID);
                    cmd.Parameters.AddWithValue("Direction", OrderModel.Direction);
                    cmd.Parameters.AddWithValue("Quantity", OrderModel.Quantity);

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
    }
}

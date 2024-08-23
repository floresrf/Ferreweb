using Ferreweb.conexion;
using Ferreweb.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Mono.TextTemplating;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace Ferreweb.Conexion
{
    public class employeeData
    {
        public List<employeeModel> listar()
        {
            var olista = new List<employeeModel>();

            var cn = new conexion1();

            using (var conn = new SqlConnection(cn.getcadenasql()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("list_Employee", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        olista.Add(new employeeModel()
                        {
                            ID = Convert.ToInt32(dr["ID"]),
                            FirstName = dr["FirstName"].ToString(),
                            LastName = dr["LastName"].ToString(),
                            BDate = dr["BDate"].ToString(),
                            PhoneNumber = dr["PhoneNumber"].ToString(),
                            Email = dr["Email"].ToString(),
                            Direction = dr["Direction"].ToString(),
                            Salary = dr["Salary"].ToString()
                        }
                            );
                    }

                }
            }
            return olista;
        }

        public employeeModel Obtener(int ID)
        {
            var nRegistro = new employeeModel();
            var cn = new conexion1();

            using (var conexion = new SqlConnection(cn.getcadenasql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("search_Employee", conexion);
                cmd.Parameters.AddWithValue("ID", ID);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        nRegistro.ID = Convert.ToInt32(dr["ID"]);
                        nRegistro.FirstName = dr["FirstName"].ToString();
                        nRegistro.LastName = dr["LastName"].ToString();
                        nRegistro.BDate = dr["BDate"].ToString();
                        nRegistro.PhoneNumber = dr["PhoneNumber"].ToString();
                        nRegistro.Email = dr["Email"].ToString();
                        nRegistro.Direction = dr["Direction"].ToString();
                        nRegistro.Salary = dr["Salary"].ToString();
                    }
                }
            }

            return nRegistro;
        }

        public bool Guardar(employeeModel EmployeeModel)
        {
            bool respuesta;
            try
            {

                var cn = new conexion1();

                using (var conn = new SqlConnection(cn.getcadenasql()))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("insert_Employee", conn);

                    cmd.Parameters.AddWithValue("FirstName", EmployeeModel.FirstName);
                    cmd.Parameters.AddWithValue("LastName", EmployeeModel.LastName);
                    cmd.Parameters.AddWithValue("BDate", EmployeeModel.BDate);
                    cmd.Parameters.AddWithValue("PhoneNumber", EmployeeModel.PhoneNumber);
                    cmd.Parameters.AddWithValue("Email", EmployeeModel.Email);
                    cmd.Parameters.AddWithValue("Direction", EmployeeModel.Direction);
                    cmd.Parameters.AddWithValue("Salary", EmployeeModel.Salary);

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
                    SqlCommand cmd = new SqlCommand("delete_Employee", conn);

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

        public bool Editar(employeeModel EmployeeModel)
        {
            bool rpta;

            try
            {
                var cn = new conexion1();

                using (var conn = new SqlConnection(cn.getcadenasql()))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("edit_Employee", conn);
                    cmd.Parameters.AddWithValue("ID", EmployeeModel.ID);
                    cmd.Parameters.AddWithValue("FirstName", EmployeeModel.FirstName);
                    cmd.Parameters.AddWithValue("LastName", EmployeeModel.LastName);
                    cmd.Parameters.AddWithValue("BDate", EmployeeModel.BDate);
                    cmd.Parameters.AddWithValue("PhoneNumber", EmployeeModel.PhoneNumber);
                    cmd.Parameters.AddWithValue("Email", EmployeeModel.Email);
                    cmd.Parameters.AddWithValue("Direction", EmployeeModel.Direction);
                    cmd.Parameters.AddWithValue("Salary", EmployeeModel.Salary);

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
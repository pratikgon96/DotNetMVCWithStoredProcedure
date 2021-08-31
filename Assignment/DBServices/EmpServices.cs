using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Assignment.DBServices
{
    public class EmpServices
    {
        public string connect = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private SqlDataAdapter _adapter;
       // private IConfiguration _config;
        private DataSet _ds;
        public IList<Employee> GetEmployees()
        {
            IList<Employee> getEmployees = new List<Employee>();
            _ds = new DataSet();

            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "GetEmployee");
                _adapter = new SqlDataAdapter(cmd);
                _adapter.Fill(_ds);

                if (_ds.Tables.Count > 0)
                {
                    for (int i = 0; i < _ds.Tables[0].Rows.Count; i++)
                    {
                        Employee obj = new Employee();
                        obj.Id = Convert.ToInt32(_ds.Tables[0].Rows[i]["Id"]);
                        obj.FirstName = Convert.ToString(_ds.Tables[0].Rows[i]["FirstName"]);
                        obj.LastName = Convert.ToString(_ds.Tables[0].Rows[i]["LastName"]);
                        obj.DOB = Convert.ToDateTime(_ds.Tables[0].Rows[i]["DOB"]);
                        obj.Contact = Convert.ToInt64(_ds.Tables[0].Rows[i]["Contact"]);
                        obj.RoleId = Convert.ToInt32(_ds.Tables[0].Rows[i]["RoleId"]);
                        getEmployees.Add(obj);
                    }
                }
            }

            return getEmployees;

        }

        public void InsertEmployee(Employee model)
        {
            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "AddEmployee");
                cmd.Parameters.AddWithValue("@Id", model.Id);
                cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
                cmd.Parameters.AddWithValue("@LastName", model.LastName);
                cmd.Parameters.AddWithValue("@DOB", model.DOB);
                cmd.Parameters.AddWithValue("@Contact", model.Contact);
                cmd.Parameters.AddWithValue("@RoleId", model.RoleId);
                cmd.ExecuteNonQuery();


            }
        }

        public Employee GetEmployeeById(int Id)
        {
            var model = new Employee();

            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "GetEmpById");
                cmd.Parameters.AddWithValue("@Id", Id);
                _adapter = new SqlDataAdapter(cmd);
                _ds = new DataSet();
                _adapter.Fill(_ds);
                if (_ds.Tables.Count > 0 && _ds.Tables[0].Rows.Count > 0)
                {
                    model.Id = Convert.ToInt32(_ds.Tables[0].Rows[0]["Id"]);
                    model.FirstName = Convert.ToString(_ds.Tables[0].Rows[0]["FirstName"]);
                    model.LastName = Convert.ToString(_ds.Tables[0].Rows[0]["LastName"]);
                    model.DOB = Convert.ToDateTime(_ds.Tables[0].Rows[0]["DOB"]);
                    model.Contact = Convert.ToInt64(_ds.Tables[0].Rows[0]["Contact"]);
                    model.RoleId = Convert.ToInt32(_ds.Tables[0].Rows[0]["RoleId"]);
                }
            }
            return model;
        }

        public void UpdateEmployee(Employee model)
        {
            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeDetails",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "UpdateEmp");
                //cmd.Parameters.AddWithValue("Id", model.Id);
               // cmd.Parameters.AddWithValue("FirstName", model.FirstName);
               // cmd.Parameters.AddWithValue("LastName", model.LastName);
                //cmd.Parameters.AddWithValue("DOB", model.DOB);
              //  cmd.Parameters.AddWithValue("Contact", model.Contact);
                cmd.Parameters.AddWithValue("RoleId", model.RoleId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
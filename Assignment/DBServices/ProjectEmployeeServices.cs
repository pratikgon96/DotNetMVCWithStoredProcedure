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
    public class ProjectEmployeeServices
    {
        public string connect = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private SqlDataAdapter _adapter;
        private DataSet _ds;
        public IList<ProjectEmployee> GetProjectEmployee()
        {
            IList<ProjectEmployee> getProemp = new List<ProjectEmployee>();
            _ds = new DataSet();

            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("ProjectEmployeeDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "GetProjectEmployee");
                _adapter = new SqlDataAdapter(cmd);
                _adapter.Fill(_ds);

                if (_ds.Tables.Count > 0)
                {
                    for (int i = 0; i < _ds.Tables[0].Rows.Count; i++)
                    {
                        ProjectEmployee obj = new ProjectEmployee();
                        obj.ProjectId = Convert.ToInt32(_ds.Tables[0].Rows[i]["ProjectId"]);
                        obj.EmployeeId = Convert.ToInt32(_ds.Tables[0].Rows[i]["EmployeeId"]);
                       // obj.employee.FirstName = Convert.ToString(_ds.Tables[0].Rows[i]["FirstName"]);
                        getProemp.Add(obj);
                    }
                }
            }

            return getProemp;
        }

        public void InsertProjectEmployee(ProjectEmployee model)
        {
            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("ProjectEmployeeDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "AddProjectEmployee");
                cmd.Parameters.AddWithValue("@ProjectId", model.ProjectId);
                cmd.Parameters.AddWithValue("@EmployeeId", model.EmployeeId);
                cmd.ExecuteNonQuery();


            }
        }
    }
}
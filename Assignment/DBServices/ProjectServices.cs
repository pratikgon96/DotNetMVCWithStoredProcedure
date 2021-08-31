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
    public class ProjectServices
    {
        public string connect = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private SqlDataAdapter _adapter;
        private DataSet _ds;

        public IList<Project> GetProject()
        {
            IList<Project> getProjects = new List<Project>();
            _ds = new DataSet();

            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("ProjectDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "GetProject");
                _adapter = new SqlDataAdapter(cmd);
                _adapter.Fill(_ds);

                if (_ds.Tables.Count > 0)
                {
                    for (int i = 0; i < _ds.Tables[0].Rows.Count; i++)
                    {
                        Project obj = new Project();
                        obj.Id = Convert.ToInt32(_ds.Tables[0].Rows[i]["Id"]);
                        obj.Name = Convert.ToString(_ds.Tables[0].Rows[i]["Name"]);
                        obj.StartDate = Convert.ToString(_ds.Tables[0].Rows[i]["StartDate"]);
                        obj.EndDate = Convert.ToString(_ds.Tables[0].Rows[i]["EndDate"]);
                        obj.Budget = Convert.ToDecimal(_ds.Tables[0].Rows[i]["Budget"]);
                        obj.Manager = Convert.ToString(_ds.Tables[0].Rows[i]["Manager"]);
                        getProjects.Add(obj);
                    }
                }
            }

            return getProjects;

        }

        public void InsertProject(Project model)
        {
            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("ProjectDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "AddProject");
                //cmd.Parameters.AddWithValue("@Id", model.Id);
                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@StartDate", model.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", model.EndDate);
                cmd.Parameters.AddWithValue("@Budget", model.Budget);
                cmd.Parameters.AddWithValue("@Manager", model.Manager);
                cmd.ExecuteNonQuery();


            }
        }

        public Project GetProjectById(int Id)
        {
            var model = new Project();

            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("ProjectDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "GetProjectById");
                cmd.Parameters.AddWithValue("@Id", Id);
                _adapter = new SqlDataAdapter(cmd);
                _ds = new DataSet();
                _adapter.Fill(_ds);
                if (_ds.Tables.Count > 0 && _ds.Tables[0].Rows.Count > 0)
                {
                    model.Id = Convert.ToInt32(_ds.Tables[0].Rows[0]["Id"]);
                    model.Name = Convert.ToString(_ds.Tables[0].Rows[0]["Name"]);
                    model.StartDate = Convert.ToString(_ds.Tables[0].Rows[0]["StartDate"]);
                    model.EndDate = Convert.ToString(_ds.Tables[0].Rows[0]["EndDate"]);
                    model.Budget = Convert.ToDecimal(_ds.Tables[0].Rows[0]["Budget"]);
                    model.Manager = Convert.ToString(_ds.Tables[0].Rows[0]["Manager"]);
                }
            }
            return model;
        }

        public void UpdateProject(Project model)
        {
            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("ProjectDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "UpdateProject");
                cmd.Parameters.AddWithValue("Id", model.Id);
                cmd.Parameters.AddWithValue("Name", model.Name);
                cmd.Parameters.AddWithValue("StartDate", model.StartDate);
                cmd.Parameters.AddWithValue("EndDate", model.EndDate);
                cmd.Parameters.AddWithValue("Budget", model.Budget);
                cmd.Parameters.AddWithValue("Manager", model.Manager);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIInClass.Models;

namespace WebAPIInClass.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public List<Employee> Get()
        {
            
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeCS"].ConnectionString);
            SqlCommand cmd = new SqlCommand("select EmpId,EmpName,Salary from Employee", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<Employee> lstEmp = new List<Employee>();
            while (dr.Read())
            {

                lstEmp.Add(new Employee()
                {
                    EmpId = dr["EmpId"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(dr["EmpId"]),
                    EmpName = dr["EmpName"].Equals(String.Empty) ? "" : Convert.ToString(dr["EmpName"]),

                    Salary = dr["Salary"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(dr["Salary"]),
                });

            }
            con.Close();
            return lstEmp;
        }

        // GET api/values/5
        public Employee Get(int Id)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeCS"].ConnectionString);
            SqlCommand cmd = new SqlCommand("select EmpId,EmpName,Salary from Employee where EmpId = " + Id, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            Employee employee = new Employee()
            {
                EmpId = dr["EmpId"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(dr["EmpId"]),
                EmpName = dr["EmpName"].Equals(String.Empty) ? "" : Convert.ToString(dr["EmpName"]),

                Salary = dr["Salary"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(dr["Salary"]),
            };

            con.Close();
            return employee;
        }

        // POST api/values
        public void Post(Employee emp)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeCS"].ConnectionString);
            SqlCommand cmd = new SqlCommand("insert into Employee(EmpName,Salary) values('" + emp.EmpName + "'," + emp.Salary +")", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}

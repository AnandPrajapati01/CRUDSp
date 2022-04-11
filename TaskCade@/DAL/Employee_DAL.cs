using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TaskCade_.Models;

namespace TaskCade_.DAL
{
    public class Employee_DAL
    {
        string conn = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        //Get All Recoreds

        public List<Employee> GetEmployees()
        {
            List<Employee> employeelist = new List<Employee>();
            using (SqlConnection connection = new SqlConnection(conn))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_GetAllEmployee";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                connection.Open();
                dataAdapter.Fill(dataTable);
                connection.Close();
                foreach (DataRow emp in dataTable.Rows)
                {
                    employeelist.Add(new Employee
                    {
                        Id = Convert.ToInt32(emp["Id"]),
                        Name = emp["Name"].ToString(),
                        Email=emp["Email"].ToString(),
                        Gender=emp["Gender"].ToString(),
                        Department=emp["Department"].ToString(),
                        Status=emp["Status"].ToString(),

                    }) ;
                }
            }
            return employeelist;
        }
    }
}




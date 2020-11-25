using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLab
{
    class DBConnection
    {
        private readonly string ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Project contracts;Integrated Security=True";
        private readonly string sqlExpression = "SELECT firstname, lastname, surname, city, street, home, position_name, projectName, projectStart, " +
                                   "projectEnd, projectDescription, characterizationText, days, salary " +
                                   "FROM Employee " +
                                   "INNER JOIN Fullname ON Employee.fullname_id = Fullname.fullname_id " +
                                   "INNER JOIN Address ON Employee.address_id = Address.address_id " +
                                   "INNER JOIN Position ON Employee.position_id = Position.position_id " +
                                   "INNER JOIN ProjectInfo ON Employee.project_id = ProjectInfo.project_id " +
                                   "INNER JOIN Characterization ON Employee.characterization_id = Characterization.characterization_id";

        public List<Contracts> GetContracts()
        {
            List<Contracts> contracts = new List<Contracts>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Contracts contract = new Contracts();
                        contract.FirstName = reader.GetValue(0).ToString();
                        contract.LastName = reader.GetValue(1).ToString();
                        contract.SurName = reader.GetValue(2).ToString();
                        contract.City = reader.GetValue(3).ToString();
                        contract.Street = reader.GetValue(4).ToString();
                        contract.Home = Convert.ToInt32(reader.GetValue(5));
                        contract.PositionName = reader.GetValue(6).ToString();
                        contract.ProjectName = reader.GetValue(7).ToString();
                        contract.ProjectStart = Convert.ToDateTime(reader.GetValue(8));
                        contract.ProjectEnd = Convert.ToDateTime(reader.GetValue(9));
                        contract.ProjectDescription = reader.GetValue(10).ToString();
                        contract.Characterization = reader.GetValue(11).ToString();
                        contract.Days = Convert.ToInt32(reader.GetValue(12));
                        contract.Salary = Convert.ToInt32(reader.GetValue(13));
                        contracts.Add(contract);
                    }
                }
                reader.Close();
            }
            return contracts;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoSample
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-0IN3O3P\HUMBERBRIDGING;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True");
            using (connection)
            {
                connection.Open();
                string query = "select * from Applicant_Profiles";
                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataReader reader = cmd.ExecuteReader();
                List<ApplicantProfile> applicantProfile = new List<ApplicantProfile>();

                while (reader.Read())
                {
                    applicantProfile.Add(new ApplicantProfile { Id = (Guid)reader["Id"], Login = (Guid)reader["Login"], 
                        Current_Salary = (Decimal)reader[2], Current_Rate = (Decimal)reader[3], Currency = reader["Currency"].ToString() });
                }

                Console.WriteLine();
                foreach (ApplicantProfile ap in applicantProfile)
                {
                    Console.WriteLine($"The applicant with Id {ap.Id} and login Id {ap.Login} receives {ap.Currency}{ap.Current_Salary} salary at {ap.Current_Rate}% rate");
                    Console.WriteLine();
                }
                Console.ReadLine();
            }
        }
    }
}

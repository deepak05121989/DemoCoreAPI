namespace DemoCoreAPI.Repository
{
    using System.Data.SqlClient;
    using System.Data;
    using DemoCoreAPI.Model;
    using System.Collections.Generic;

    public class StudentsRepository : IStudentsRepository
    {
        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-MFTT75J;Initial Catalog=TestDB;Integrated Security=True"))
            {
                con.Open();
                using (SqlCommand cmd = new())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "select * from Student";
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {

                        Student student = new()
                        {
                            RolleNO = Convert.ToInt32(dr["roleno"].ToString()),
                            Address= dr["address"].ToString(),
                            Mobile= Convert.ToInt64(dr["mobile"].ToString()),
                            Name= dr["name"].ToString()
                        };
                        students.Add(student);
                    }
                }
                con.Close();

            }
            return students;
        }
    }
}

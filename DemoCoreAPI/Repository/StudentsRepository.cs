namespace DemoCoreAPI.Repository
{
    using System.Data.SqlClient;
    using System.Data;
    using DemoCoreAPI.Model;
    using System.Collections.Generic;

    public class StudentsRepository : IStudentsRepository
    {
        public string ConnectionString { get; set; }
        public StudentsRepository(IConfiguration configuration)
        {
            ConnectionString=configuration.GetConnectionString("TestDbConnection");

        }
        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
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
                            Id = Convert.ToInt32(dr["roleno"].ToString()),
                            Address = dr["address"].ToString(),
                            Mobile = Convert.ToInt64(dr["mobile"].ToString()),
                            Name = dr["name"].ToString()
                        };
                        students.Add(student);
                    }
                }
                con.Close();

            }
            return students;
        }
        public Student GetStudentById(int id)
        {
            Student? student = default;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "select * from Student where roleno=@roleno";
                    cmd.Parameters.AddWithValue("@roleno", id);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {

                        student = new()
                        {
                            Id = Convert.ToInt32(dr["roleno"].ToString()),
                            Address = dr["address"].ToString(),
                            Mobile = Convert.ToInt64(dr["mobile"].ToString()),
                            Name = dr["name"].ToString()
                        };
                    }
                }
                con.Close();

            }
            return student;
        }
        public int SaveStudent(Student student)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "insert into student([Name], [Address], [mobile]) values(@Name, @Address, @mobile)";
                    cmd.Parameters.AddWithValue("@Name", student.Name);
                    cmd.Parameters.AddWithValue("@Address", student.Address);
                    cmd.Parameters.AddWithValue("@mobile", student.Mobile);
                    int result = cmd.ExecuteNonQuery();
                    con.Close();
                    return result;
                }
            }
        }
        public int UpdateStudent(int id,Student student)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "update student set [Name]=@Name, [Address]=@Address, [mobile]=@Mobile where roleNo=@roleNo";
                    cmd.Parameters.AddWithValue("@roleNo", id);
                    cmd.Parameters.AddWithValue("@Name", student.Name);
                    cmd.Parameters.AddWithValue("@Address", student.Address);
                    cmd.Parameters.AddWithValue("@mobile", student.Mobile);
                    int result = cmd.ExecuteNonQuery();
                    con.Close();
                    return result;
                }
            }
        }
        public int DeleteStudent(int id)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "delete from student where roleNo=@roleNo";
                    cmd.Parameters.AddWithValue("@roleNo", id);
                    int result = cmd.ExecuteNonQuery();
                    con.Close();
                    return result;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English_center
{
    internal class ClassModel
    {
        List<Class_Users> Classes;
        public string GetConnectionString()
        {
            Classes = new List<Class_Users>();
            SqlConnectionStringBuilder builder;

            builder = new System.Data.SqlClient.SqlConnectionStringBuilder();
            builder["Data Source"] = "DESKTOP-IQ7PPOR\\SQLEXPRESS";
            builder["integrated Security"] = true;
            builder["Initial Catalog"] = "English_center";
            builder.UserID = "DESKTOP-IQ7PPOR\\TU";
            Console.WriteLine(builder.ConnectionString);
            builder["Password"] = "";
            Console.Write(builder.ConnectionString);
            return builder.ConnectionString;
        }
        public bool Find(string coursename)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                string query = "SELECT * FROM Classes where CourseName=@coursename" ;
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@coursename",coursename);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    reader.Close();
                    return false;
                }
                else
                {
                    reader.Close();
                    return true;

                }
            }
        }
        public List<Class_Users> GetClasses()
        {
            Classes = new List<Class_Users>();
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                string query = "SELECT * FROM Classes";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Class_Users users = new Class_Users();
                    users.id = reader["id"].ToString();
                    users.NameCourse = reader["CourseName"].ToString();
                    users.Quantity = reader["Quantity"].ToString();
                    users.status = reader["status"].ToString();
                    Classes.Add(users);
                }

                reader.Close();
            }

            return Classes;
        }
        public List<Class_Users> FindClasses(string coursename)
        {
            Classes = new List<Class_Users>();
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                string query = "SELECT * FROM Courses WHERE CourseName LIKE '%" + coursename + "%'";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@coursename", coursename);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Class_Users users = new Class_Users();
                    Classes.Add(users);
                }

                reader.Close();
            }

            return Classes;
        }
        public void AddClass(Class_Users users)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                string query = "INSERT INTO Classes (id,CourseName,Teacher_Name,Status,Quantity) " +
                    "VALUES (@id, @CourseName,@NameTeacher,@status,@Quantity)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", users.id);
                command.Parameters.AddWithValue("@CourseName", users.NameCourse);
                command.Parameters.AddWithValue("@NameTeacher", users.TeacherName);
                command.Parameters.AddWithValue("@Quantity", users.Quantity);
                command.Parameters.AddWithValue("@status", users.status);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void UpdateClass(Class_Users users)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                string query = "UPDATE Classes SET id = @id, CourseName = @CourseName, " +"Teacher_Name=@NameTeacher, Quantity=@Quantity, Status=@status " +
                "WHERE id = @id";


                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", users.id);
                command.Parameters.AddWithValue("@CourseName", users.NameCourse);
                command.Parameters.AddWithValue("@NameTeacher", users.TeacherName);
                command.Parameters.AddWithValue("@Quantity", users.Quantity);
                command.Parameters.AddWithValue("@status", users.status);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }


        public void DeleteClass(string id)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                string query = "DELETE FROM Classes WHERE id = @UserId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserId", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public string AutoID()
        {
            string id = "";
            string ms = "";
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                    string query = "SELECT TOP 1 id FROM Classes ORDER BY id DESC ";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    id = reader.GetString(0).Trim();
                    int id1 = Int32.Parse(id.Substring(id.Length - 4));
                    if (id1 < 10)
                    {
                        ms = "000" + (id1 + 1).ToString();
                    }
                    else if (id1 < 100)
                    {
                        ms = "00" + (id1 + 1).ToString();
                    }
                    else
                    {
                        ms = "0" + (id1 + 1).ToString();
                    }
                }
                else
                {
                    ms = "0000";
                }
                reader.Close();
                return "Class" + ms;
            }

        }

    }
}

using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace ST10026525.CLDV.Poe.Models
{
    public class UserTable
    {
        public static string con_string = "Server=tcp:st10026525-cldv-poe.database.windows.net,1433;Initial Catalog=clouddev-sql-database;Persist Security Info=False;User ID=nk;Password=Mabuza321;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public static SqlConnection con = new SqlConnection(con_string);

        public string Name {  get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public bool InsertUser(UserTable a)
        {
            using (SqlConnection con = new SqlConnection(con_string))
            {
                con.Open();
                string query = "INSERT INTO Users (username, userSurname, userEmail, userPassword) VALUES (@Name, @Surname, @Email, @Password)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Name", a.Name);
                    cmd.Parameters.AddWithValue("@Surname", a.Surname);
                    cmd.Parameters.AddWithValue("@Email", a.Email);
                    cmd.Parameters.AddWithValue("@Password", a.Password);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

      
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace ST10026525.CLDV.Poe.Models
{
    public class LoginModel
    {
        public static string con_string = "Integrated Security=SSPI;Persist Security Info=False;User ID=\"\";Initial Catalog=test;Data Source=labVMH8OX\\SQLEXPRESS";

        public int SelectUser(string password, string name)
        {
            int userId = -1; // Default value if user is not found
            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT userID FROM userTable WHERE userPassword = @Password AND username = @Name";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@Name", name);
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        userId = Convert.ToInt32(result);
                    }
            }
            return userId;
        }
    }
}

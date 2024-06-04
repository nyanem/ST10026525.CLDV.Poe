using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace ST10026525.CLDV.Poe.Models
{
    public class productDisplay 
    {
        public static string con_string = "Server=tcp:st10026525-cldv-poe.database.windows.net,1433;Initial" +
                                            " Catalog=clouddev-sql-database;Persist Security Info=False;User ID=nk;Password=Mabuza321;MultipleActiveResultSets=False" +
                                            ";Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public static SqlConnection con = new SqlConnection(con_string);
        
        public int productID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductCategory { get; set; }
        public bool ProductAvailability { get; set;}

        public productDisplay() { }
        public productDisplay(int id, string name, decimal price, string category, bool availability)  
        { 
            productID = id;
            ProductName = name;
            ProductPrice = price;
            ProductCategory = category;
            ProductAvailability = availability;
        }
        public static List<productDisplay> SelectProducts()
        {
            List<productDisplay> products = new List<productDisplay>();

            string con_string = "Integrated Security=SSPI;Persist Security Info=False;User ID=\"\";Initial Catalog=test;Data Source=labVMH8OX\\SQLEXPRESS";
            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT ProductID, ProductName, ProductPrice, ProductCategory, ProductAvailability FROM productTable";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    productDisplay product = new productDisplay();
                    product.productID = Convert.ToInt32(reader["ProductID"]);
                    product.ProductName = Convert.ToString(reader["ProductName"]);
                    product.ProductPrice = Convert.ToDecimal(reader["ProductPrice"]);
                    product.ProductCategory = Convert.ToString(reader["ProductCategory"]);
                    product.ProductAvailability = Convert.ToBoolean(reader["ProductAvailability"]);
                    products.Add(product);
                }
                reader.Close();
            }
            return products;
        }

    }
}

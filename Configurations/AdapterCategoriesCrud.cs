using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DapperCategoriesCrud : ICategoriesCrud
    {
        public DataTable GetAllCategories()
        {
            var dt = new DataTable();
            string strConString = Configuration.ConnectionString;
            using (var con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("" +
                    "SELECT [CategoryID] ,[CategoryName] ,[Description] ,[Picture] " +
                    "FROM [Northwind].[dbo].[Categories]", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public int InsertCategory(string categoryName, string description)
        {
            string strConString = Configuration.ConnectionString;
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string query = "Insert into [Northwind].[dbo].[Categories] " +
                    "([CategoryName], [Description]) values(@category_name, @description)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@category_name", categoryName);
                cmd.Parameters.AddWithValue("@description", description);
                return cmd.ExecuteNonQuery();
            }
        }

        public int DeleteCategory(int categoryId)
        {
            string strConString = Configuration.ConnectionString;
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string query = "DELETE [Categories] WHERE [categoryId] = @categoryId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@categoryId", categoryId);
                return cmd.ExecuteNonQuery();
            }
        }

        public int UpdateCategory(int categoryId, string categoryName, string description)
        {
            string strConString = Configuration.ConnectionString;
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string query = "UPDATE [Categories] SET [CategoryName] = @category_name, [description] = @description WHERE [categoryId] = @categoryId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@categoryId", categoryId);
                cmd.Parameters.AddWithValue("@category_name", categoryName);
                cmd.Parameters.AddWithValue("@description", description);
                return cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetAllCategoriesByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}

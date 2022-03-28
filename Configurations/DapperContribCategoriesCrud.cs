using Dapper;
using Dapper.Contrib.Extensions;
using FastMember;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DapperContribCategoriesCrud : ICategoriesCrud
    {
        [Table("Categories")]
        public class Category
        {
            [Key]
            public int CategoryID { get; set; }
            public string CategoryName { get; set; }
            public string Description { get; set; }
        }
        
        public DataTable GetAllCategories()
        {
            var connectionString = Configuration.ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                IEnumerable<Category> allCategories = connection.GetAll<Category>();
                DataTable table = new DataTable();
                using (var reader = ObjectReader.Create(allCategories))
                {
                    table.Load(reader);
                }
                return table;
            }
        }

        public DataTable GetAllCategoriesByName(string name)
        {
            var connectionString = Configuration.ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                string sqlCommand = "SELECT * FROM [Categories] WHERE [CategoryName] LIKE '%'+@new_name+'%'";
                var allCategories = connection
                    .Query<Category>(sqlCommand, new { new_name = name }).AsList();

                DataTable table = new DataTable();
                using (var reader = ObjectReader.Create(allCategories))
                {
                    table.Load(reader);
                }
                return table;
            }
        }

        public int InsertCategory(string categoryName, string description)
        {
            using (var connection = new SqlConnection(Configuration.ConnectionString))
            {
                var newCategory = new Category
                {
                    CategoryName = categoryName,
                    Description = description
                };
                connection.Insert(newCategory);
                return 1;
            }
        }

        public int UpdateCategory(int categoryId, string categoryName, string description)
        {
            using (var connection = new SqlConnection(Configuration.ConnectionString))
            {
                var updateCategory = connection.Get<Category>(categoryId);
                updateCategory.CategoryName=categoryName;
                updateCategory.Description=description;
                connection.Update(updateCategory);
                return 1;
            }
        }

        public int DeleteCategory(int categoryId)
        {
            using (var connection = new SqlConnection(Configuration.ConnectionString))
            {
                var updateCategory = connection.Get<Category>(categoryId);
                connection.Delete<Category>(updateCategory);
                return 1;
            }
        }
    }
}

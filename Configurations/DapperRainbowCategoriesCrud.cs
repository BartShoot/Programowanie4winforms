using Dapper;
using FastMember;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
    }

    public class NorthwindDatabase : Database<NorthwindDatabase>
    {
        public Table<Category> Categories { get; set; }
    }

    public class DapperRainbowCategoriesCrud : ICategoriesCrud
    {
        public int DeleteCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAllCategories()
        {
            var connectionString = Configuration.ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                var db = NorthwindDatabase.Init(connection, commandTimeout: 2);
                List<Category> categories = db.Categories.All().ToList();

                DataTable table = new DataTable();
                using (var reader = ObjectReader.Create(categories))
                {
                    table.Load(reader);
                }
                return table;
            }
            
        }

        public DataTable GetAllCategoriesByName(string name)
        {
            throw new NotImplementedException();
        }

        public int InsertCategory(string categoryName, string description)
        {
            throw new NotImplementedException();
        }

        public int UpdateCategory(int categoryId, string categoryName, string description)
        {
            throw new NotImplementedException();
        }
    }
}

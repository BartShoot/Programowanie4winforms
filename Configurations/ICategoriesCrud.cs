using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ICategoriesCrud
    {
        DataTable GetAllCategories();
        int InsertCategory(string categoryName, string description);
        int DeleteCategory(int categoryId);
        int UpdateCategory(int categoryId, string categoryName, string description);
        DataTable GetAllCategoriesByName(string name);
    }
}

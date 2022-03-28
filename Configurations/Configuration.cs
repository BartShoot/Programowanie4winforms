using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class Configuration
    {
        public static string ConnectionString { get => @"Data Source=XPS-13;Initial Catalog=Northwind;Integrated Security=True"; }
    }
}

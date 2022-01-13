using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaWeb.DAO
{
    public class Conexao
    {
        protected string GetConnectionString()
        {
            var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            string connectionString = builder
               .Build()
               .GetSection("ConnectionStrings")
               .GetSection("DefaultConnection")
               .Value;
            return connectionString;
        }
    }
}



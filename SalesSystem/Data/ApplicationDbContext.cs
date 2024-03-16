using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SalesSystem.Models;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SalesSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    { 
    
        private string _connectionString = string.Empty;
        static DbContextOptions<ApplicationDbContext> _options;
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            _options = options;
        }
        public ApplicationDbContext() {

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _connectionString = builder.GetSection("ConnectionStrings:DefaultConnection").Value;
        }

        public string getCadenaSQL()
        {
            return _connectionString;
        }
    }
        
}

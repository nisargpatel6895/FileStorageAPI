//using System;
//namespace FileStorageAPI.Entities
//{
//	public class FileDataContext
//	{
//		public FileDataContext()
//		{
//		}
//	}
//}

using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStorageAPI.Entities
{
    public class FileStorageDbContext : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "fileStorage.db" };
        //    var connectionString = connectionStringBuilder.ToString();
        //    var connection = new SqliteConnection(connectionString);

        //    optionsBuilder.UseSqlite(connection);
        //}

        //public FileStorageDbContext()
        //{
        //}

        //public FileStorageDbContext(DbContextOptions<FileStorageDbContext> options)
        //    : base(options)
        //{
        //}
        protected readonly IConfiguration Configuration;

        public FileStorageDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
        }


        public DbSet<FileData> FileData { get; set; }
    }
}

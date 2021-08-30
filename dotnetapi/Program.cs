using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Data.Sqlite;

namespace dotnetapi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if(!File.Exists("PersonsDB.db")){
                CreateDatabase();
            }

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        // Creates a DB with the "persons" table.
        public static void CreateDatabase(){
            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.DataSource = "./PersonsDB.db";

            using(var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();

                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText = @"CREATE TABLE persons(
                        id NVARCHAR(255),
                        name NVARCHAR(255),
                        address NVARCHAR(255),
                        number INT(255)
                    )";
                tableCmd.ExecuteNonQuery();

                /* using(var transaction = connection.BeginTransaction())
                {
                    var insertCmd = connection.CreateCommand();

                    insertCmd.CommandText = @"INSERT INTO persons VALUES(
                        '1',
                        'Alice',
                        'Drammensveien 2',
                        '77777777'
                        )";
                    
                    insertCmd.ExecuteNonQuery();

                    transaction.Commit();
                } */
            }
        }

        
    }
}

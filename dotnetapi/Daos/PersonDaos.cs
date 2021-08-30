using System;
using System.Collections.Generic;
using dotnetapi.Models;
using dotnetapi.Dtos;
using Microsoft.Data.Sqlite;

// This class provides functions for accessing the SQL database

namespace dotnetapi.Daos
{
    public static class PersonDaos
    {
        private static string db = "./PersonsDB.db";
        private static SqliteConnectionStringBuilder connectionStringBuilder = new SqliteConnectionStringBuilder();

        public static IEnumerable<PersonDto> GetPersons()
        {
            connectionStringBuilder.DataSource = db;
            List<PersonDto> result = new();

            using(var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();

                var selectCmd = connection.CreateCommand();
                selectCmd.CommandText = "SELECT * FROM persons";

                using(var reader = selectCmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        PersonDto tempPerson = new PersonDto{
                            Id = Guid.Parse(reader.GetString(0)),
                            Name = reader.GetString(1),
                            Address = reader.GetString(2),
                            Number = int.Parse(reader.GetString(3)) //Assumes the db only stores numbers as ints.
                        };
                        result.Add(tempPerson);
                    }
                }
            }

            return result;
        }

        // Not currently used for anything.
        public static PersonDto GetPerson(Guid id)
        {
            throw new NotImplementedException();
        }

        public static void AddPerson(Person person)
        {
            connectionStringBuilder.DataSource = db;

            using(var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                connection.Open();

                using(var transaction = connection.BeginTransaction())
                {
                    var insertCmd = connection.CreateCommand();

                    insertCmd.CommandText = @"INSERT INTO persons VALUES(@id, @name, @address, @number)";

                    insertCmd.Parameters.AddWithValue("@id", person.Id);
                    insertCmd.Parameters.AddWithValue("@name", person.Name);
                    insertCmd.Parameters.AddWithValue("@address", person.Address);
                    insertCmd.Parameters.AddWithValue("@number", person.Number);
                    insertCmd.Prepare();
                    
                    insertCmd.ExecuteNonQuery();

                    transaction.Commit();
                }
            }
        }
    }
}
using MyFirstWebApplication.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace MyFirstWebApplication.Services
{
    public class ItemsList
    {
        private static MySqlConnectionStringBuilder _stringBuilder = new()
        {
            Server = "localhost",
            Database = "itemsdb",
            UserID = "root",
            Password = "root"
        };

        public List<ItemModel> GetAllItems()
        {
            List<ItemModel> itemList = new();

            using (MySqlConnection connection = new MySqlConnection(_stringBuilder.ConnectionString))
            {
                MySqlCommand command = new("select * from itemstable", connection);

                try
                {
                    connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        itemList.Add(new ItemModel
                        {
                            Id = (UInt32)reader[0],
                            Name = (string)reader[1],
                            Price = (float)reader[2]
                        });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return itemList;
        }

        public ItemModel GetItemById(UInt32 id)
        {
            ItemModel itemModel = null;

            using (MySqlConnection connection = new MySqlConnection(_stringBuilder.ConnectionString))
            {
                MySqlCommand command = new("select * from itemstable where Id = @id", connection);
                command.Parameters.AddWithValue("@id", id);

                try
                {
                    connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        itemModel = new ItemModel
                        {
                            Id = (UInt32)reader[0],
                            Name = (string)reader[1],
                            Price = (float)reader[2]
                        };
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return itemModel;
        }
    }
}
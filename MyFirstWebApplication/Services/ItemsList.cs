using MyFirstWebApplication.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace MyFirstWebApplication.Services
{
    public class ItemsList
    {
        public List<ItemModel> GetAllItems()
        {
            List<ItemModel> itemList = new();

            using (MySqlConnection connection = new MySqlConnection("server=localhost;database=itemsdb;user id=root;password=root"))
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
                }
            }
            return itemList;
        }

        public ItemModel GetItemById(UInt32 id)
        {
            ItemModel item = null;

            using (MySqlConnection connection = new MySqlConnection("server=localhost;database=itemsdb;user id=root;password=root"))
            {
                MySqlCommand command = new("select * from itemstable where Id = @id", connection);
                command.Parameters.AddWithValue("@id", id);

                try
                {
                    connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        item = new ItemModel
                        {
                            Id = (UInt32)reader[0],
                            Name = (string)reader[1],
                            Price = (float)reader[2]
                        };
                    }
                }
                catch (Exception ex)
                {
                }
            }
            return item;
        }
    }
}
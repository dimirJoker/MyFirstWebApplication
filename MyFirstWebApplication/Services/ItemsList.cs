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
                            Id = (uint)reader[0],
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

        public ItemModel GetItemById(uint id)
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
                            Id = (uint)reader[0],
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

        public void Update(ItemModel item)
        {
            using (MySqlConnection connection = new MySqlConnection("server=localhost;database=itemsdb;user id=root;password=root"))
            {
                MySqlCommand command = new("update itemstable set Name=@name, Price=@price where Id=@id", connection);
                command.Parameters.AddWithValue("@name", item.Name);
                command.Parameters.AddWithValue("@price", item.Price);
                command.Parameters.AddWithValue("@id", item.Id);

                try
                {
                    connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();
                }
                catch (Exception ex)
                {
                }
            }
        }

        public void Delete(uint id)
        {
            using (MySqlConnection connection = new MySqlConnection("server=localhost;database=itemsdb;user id=root;password=root"))
            {
                MySqlCommand command = new("delete from itemstable where Id=@id", connection);
                command.Parameters.AddWithValue("@id", id);

                try
                {
                    connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();
                }
                catch (Exception ex)
                {
                }
            }
        }
    }
}
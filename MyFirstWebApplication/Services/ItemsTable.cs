using MyFirstWebApplication.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace MyFirstWebApplication.Services
{
    public class ItemsTable
    {
        private static MySqlConnectionStringBuilder _connectionStringBuilder = new()
        {
            Server = "localhost",
            Database = "itemsdb",
            UserID = "root",
            Password = "root"
        };

        private MySqlConnection _connection = new(_connectionStringBuilder.ConnectionString);

        public List<ItemModel> GetAllItems()
        {
            List<ItemModel> itemsTable = new();

            MySqlCommand command = new("select * from itemstable", _connection);

            try
            {
                _connection.Open();

                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    itemsTable.Add(new ItemModel
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
            return itemsTable;
        }

        public void Insert(ItemModel item)
        {
            MySqlCommand command = new("insert into itemstable (Name, Price) values (@name, @price)", _connection);
            command.Parameters.AddWithValue("@name", item.Name);
            command.Parameters.AddWithValue("@price", item.Price);

            try
            {
                _connection.Open();

                MySqlDataReader reader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
            }
        }

        public ItemModel GetItemById(uint id)
        {
            ItemModel item = null;

            MySqlCommand command = new("select * from itemstable where Id = @id", _connection);
            command.Parameters.AddWithValue("@id", id);

            try
            {
                _connection.Open();

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
            return item;
        }

        public void Update(ItemModel item)
        {
            MySqlCommand command = new("update itemstable set Name=@name, Price=@price where Id=@id", _connection);
            command.Parameters.AddWithValue("@name", item.Name);
            command.Parameters.AddWithValue("@price", item.Price);
            command.Parameters.AddWithValue("@id", item.Id);

            try
            {
                _connection.Open();

                MySqlDataReader reader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
            }
        }

        public void Delete(uint id)
        {
            MySqlCommand command = new("delete from itemstable where Id=@id", _connection);
            command.Parameters.AddWithValue("@id", id);

            try
            {
                _connection.Open();

                MySqlDataReader reader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
﻿using MyFirstWebApplication.Models;
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

        private static MySqlConnection _connection = new(_connectionStringBuilder.ConnectionString);

        public List<ItemModel> GetAllItems()
        {
            List<ItemModel> itemsTable = new();

            using (_connection)
            {
                MySqlCommand command = new($"select * from itemstable", _connection);

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
                            Salary = (float)reader[2],
                            Image = (string)reader[3]
                        });
                    }
                }
                catch (Exception ex)
                {
                }
            }

            return itemsTable;
        }

        public void Insert(ItemModel item)
        {
            using (_connection)
            {
                MySqlCommand command = new("insert into itemstable (Name, Salary) values (@name, @salary)", _connection);
                command.Parameters.AddWithValue("@name", item.Name);
                command.Parameters.AddWithValue("@salary", item.Salary);

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

        public ItemModel GetItemById(uint id)
        {
            ItemModel item = null;

            using (_connection)
            {
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
                            Salary = (float)reader[2],
                            Image = (string)reader[3]
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
            using (_connection)
            {
                MySqlCommand command = new("update itemstable set Name=@name, Salary=@salary where Id=@id", _connection);
                command.Parameters.AddWithValue("@name", item.Name);
                command.Parameters.AddWithValue("@salary", item.Salary);
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
        }

        public void Delete(uint id)
        {
            using (_connection)
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
}
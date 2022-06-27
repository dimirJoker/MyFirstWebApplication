using System;
using System.ComponentModel.DataAnnotations;

namespace MyFirstWebApplication.Models
{
    public class ItemModel
    {
        public UInt32 Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
    }
}
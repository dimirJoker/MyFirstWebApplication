using System.ComponentModel.DataAnnotations;

namespace MyFirstWebApplication.Models
{
    public class ItemModel
    {
        public uint Id { get; set; }

        [Required]
		[StringLength(50)]
        public string Name { get; set; }

		[DataType(DataType.Currency)]
		[Range(0, float.MaxValue)]
		public float Price { get; set; }
    }
}
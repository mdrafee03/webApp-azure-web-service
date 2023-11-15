using System;
namespace webapp.Models
{
	public class Product
	{
		public int ProductID { get; set; }
		public required string ProductName { get; set; }
		public required int Quantity { get; set; }
	}
}


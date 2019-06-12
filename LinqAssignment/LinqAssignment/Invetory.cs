using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqAssignment
{
	public class Invetory
	{
		public List<Product> Retrieve()
		{
			List<Product> productList = new List<Product>
			{
				new Product()
				{
					ProductId = 1,
					ProductName = "Product_1",
					ProductBrand = "Brand_1",
					AvailableToOrder = true,
					ProductStock = 100
				},
				new Product()
				{
					ProductId = 2,
					ProductName = "Product_2",
					ProductBrand = "Brand_1",
					AvailableToOrder = true,
					ProductStock = 80,
					Price = 10
				},
				new Product()
				{
					ProductId = 3,
					ProductName = "Product_3",
					ProductBrand = "Brand_2",
					AvailableToOrder = false,
					ProductStock = 70
				},
				new Product()
				{
					ProductId = 4,
					ProductName = "Product_4",
					ProductBrand = "Brand_2",
					AvailableToOrder = true,
					ProductStock = 150
				},
				new Product()
				{
					ProductId = 5,
					ProductName = "Product_5",
					ProductBrand = "Brand_2",
					AvailableToOrder = true,
					ProductStock = 130
				},
				new Product()
				{
					ProductId = 6,
					ProductName = "Product_6",
					ProductBrand = "Brand_3",
					AvailableToOrder = true,
					ProductStock = 120
				},
				new Product()
				{
					ProductId = 7,
					ProductName = "Product_7",
					ProductBrand = "Brand_3",
					AvailableToOrder = false,
					ProductStock = 190
				}
			};
			return productList;
		}
	}
}

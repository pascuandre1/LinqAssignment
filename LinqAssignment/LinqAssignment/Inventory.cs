using System.Collections.Generic;

namespace LinqAssignment
{
	public class Inventory
	{
		/// <summary>
		/// Retrieves the products.
		/// </summary>
		/// <returns></returns>
		public List<Product> RetrieveProducts()
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

		/// <summary>
		/// Retrieves the spec.
		/// </summary>
		/// <returns></returns>
		public List<BrandSpecifications> RetrieveSpec()
		{
			List<BrandSpecifications> brandSpec = new List<BrandSpecifications>
			{
				new BrandSpecifications()
				{
					ProductBrand = "Brand_1",
					Year = 1980,
					Description = "Description_1"
				},
				new BrandSpecifications()
				{
				ProductBrand = "Brand_2",
				Year = 1990,
				Description = "Description_2"
				},
				new BrandSpecifications()
				{
					ProductBrand = "Brand_3",
					Year = 2000,
					Description = "Description_3"
				}
			};
			return brandSpec;
		}
	}
}

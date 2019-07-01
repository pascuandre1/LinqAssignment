using System;
using LinqAssignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Runtime.InteropServices;

namespace Tests
{
	[TestClass]
	public class UnitTest
	{
		private Inventory inventory = new Inventory();

		[TestMethod]
		public void GetMostExpensiveProduct()
		{
			//arrange
			var list = inventory.RetrieveProducts();
			//query
			var mostExpensiveProduct = list.OrderByDescending(p => p.Price).First();
			//assertion
			Assert.IsNotNull(mostExpensiveProduct);
		}

		[TestMethod]
		public void GetProductById()
		{
			//arrange
			var productId = 1;
			var list = inventory.RetrieveProducts();
			//query
			var product = list.Single(p => p.ProductId == productId);
			//assertion
			Assert.IsNotNull(product);
		}

		[TestMethod]
		public void GetProductsWithPriceGraterThen()
		{
			//arrange
			var list = inventory.RetrieveProducts();
			//query
			var query = from p in list where p.Price > 9 select p ;
			var queryResult = new Product();
			foreach (var result in query)
			{
				queryResult = result;
			}
			var product = list.SingleOrDefault(p => p.Price > 9);
			//
			Assert.AreEqual(queryResult, product);
		}

		[TestMethod]
		public void JoinAllProductsThatHaveSpecifications()
		{
			//arrange
			var products = inventory.RetrieveProducts();
			var specs = inventory.RetrieveSpec();
			//
			var result = from product in products
				join spec in specs on product.ProductBrand equals spec.ProductBrand
				select product;
			//
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Count().Equals(products.Count));
		}
		[TestMethod]
		public void IntersectAfterProductBrand()
		{
			//arrange
			var products = inventory.RetrieveProducts();
			var specs = inventory.RetrieveSpec();
			//
			var result = products.Select(a => a.ProductBrand).Intersect(specs.Select(s => s.ProductBrand));
			//
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Count()==3);
		}

		[TestMethod]
		public void UnionAfterProductBrand()
		{
			//arrange
			var products = inventory.RetrieveProducts();
			var specs = inventory.RetrieveSpec();
			//
			var result = products.Select(a => a.ProductBrand).Union(specs.Select(s => s.ProductBrand));
			//
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Count() == 3);
		}

		[TestMethod]
		public void GroupByBrand()
		{
			//arrange
			var products = inventory.RetrieveProducts();
			//
			var result = products.GroupBy(p => p.ProductBrand);
			//
			Assert.IsTrue(result.Count()==3);
		}

		[TestMethod]
		public void Aggregate()
		{
			//arrange
			var products = inventory.RetrieveProducts();
			//
			var query = products.Select(p => p.ProductBrand).Distinct();
			var result = query.Aggregate((p1, p2) => p1+ "+" + p2);
			//
			Assert.IsTrue(result.Contains("+"));
		}

		[TestMethod]
		public void AverageStock()
		{
			//arrange
			var products = inventory.RetrieveProducts();
			//
			var result = products.Select(p => p.ProductStock).Average();
			//
			Assert.IsTrue(result == 120);
		}

		[TestMethod]
		public void ElementAt()
		{
			//arrange
			var products = inventory.RetrieveProducts();
			//
			var result = products.ElementAt(0);
			var first = products.First();
			//
			Assert.AreEqual(result,first);
		}

		[TestMethod]
		public void ElementAtOrDefault()
		{
			//arrange
			var products = inventory.RetrieveProducts();
			//
			var result = products.ElementAtOrDefault(100);
			//
			Assert.IsNull(result);
		}

		[TestMethod]
		public void Converter()
		{
			//arrange
			var products = inventory.RetrieveProducts();
			//act
			TypeProperties(products);
			TypeProperties(products.AsEnumerable());
			TypeProperties(products.AsQueryable());
		}

		private static void TypeProperties<T>(T obj)
		{
			Console.WriteLine("Compile-time type: {0}", typeof(T).Name);
			Console.WriteLine("Actual type: {0}", obj.GetType().Name);
		}

		[TestMethod]
		public void IsProductAvailable()
		{
			//arrange
			var products = inventory.RetrieveProducts();
			//act
			foreach (var product in products)
			{
				Assert.IsTrue(isInStock(product));
			}
		}
		private Func<Product, bool> isInStock = p => p.ProductStock > 0;
	}
}

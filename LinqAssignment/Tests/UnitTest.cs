using System;
using System.Collections;
using System.Collections.Generic;
using LinqAssignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

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

		[TestMethod]
		public void DefaultIfEmpty()
		{
			//arrange
			var emptyProductList = new List<string>();
			//act
			var emptyResult = emptyProductList.DefaultIfEmpty();
			var valueResult = emptyProductList.DefaultIfEmpty("value");
			//assert
			Assert.IsNotNull(emptyResult);
			Assert.IsNotNull(valueResult);
			Assert.IsTrue(valueResult.Contains("value"));
		}

		[TestMethod]
		public void ExceptProductsThatCannotBeOrdered()
		{
			//arrange
			var products = inventory.RetrieveProducts();
			//act
			var result = products.Except(products.FindAll(p=>p.AvailableToOrder==false));
			//assert
			Assert.IsNotNull(result);
			Assert.IsTrue(products.Count > result.Count());
		}

		[TestMethod]
		public void SequenceEqual()
		{
			//arrange
			IList<string> strList1 = new List<string>() { "One", "Two", "Three", "Four", "Three" };
			IList<string> strList2 = new List<string>() { "One", "Two", "Three", "Four", "Three" };
			//act
			bool isEqual = strList1.SequenceEqual(strList2);
			//assert
			Assert.IsTrue(isEqual);
		}

		[TestMethod]
		public void Mixed()
		{
			IList mixedList = new ArrayList();
			mixedList.Add(0);
			mixedList.Add("zero");
			mixedList.Add(inventory.RetrieveProducts());
			//
			var stringResult = from s in mixedList.OfType<string>()
				select s;

			var intResult = from s in mixedList.OfType<int>()
				select s;
			//
			Assert.IsTrue(stringResult.Contains("zero"));
			Assert.IsTrue(intResult.Contains(0));
		}
	}
}

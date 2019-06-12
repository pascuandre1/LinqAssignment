using System;
using System.Collections.Generic;
using LinqAssignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Tests
{
	[TestClass]
	public class UnitTest
	{
		private Invetory invetory = new Invetory();

		[TestMethod]
		public void GetMostExpensiveProduct()
		{
			//arrange
			var list = invetory.Retrieve();
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
			var list = invetory.Retrieve();
			//query
			var product = list.Single(p => p.ProductId == productId);
			//assertion
			Assert.IsNotNull(product);
		}

		[TestMethod]
		public void GetProductsWithPriceGraterThen()
		{
			//arrange
			var list = invetory.Retrieve();
			//query
			var query = from p in list where p.Price > 9 select p;
		}
	}
}

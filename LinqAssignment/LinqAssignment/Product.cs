using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqAssignment
{
	/// <summary>
	/// Product
	/// </summary>
	public class Product
	{
		/// <summary>
		/// Gets or sets the product identifier.
		/// </summary>
		/// <value>
		/// The product identifier.
		/// </value>
		public int ProductId { get; set; }
		/// <summary>
		/// Gets or sets the name of the product.
		/// </summary>
		/// <value>
		/// The name of the product.
		/// </value>
		public string ProductName { get; set; }
		/// <summary>
		/// Gets or sets the product brand.
		/// </summary>
		/// <value>
		/// The product brand.
		/// </value>
		public string ProductBrand { get; set; }
		/// <summary>
		/// Gets or sets a value indicating whether [available to order].
		/// </summary>
		/// <value>
		///   <c>true</c> if [available to order]; otherwise, <c>false</c>.
		/// </value>
		public bool AvailableToOrder { get; set; }
		/// <summary>
		/// Gets or sets the product stock.
		/// </summary>
		/// <value>
		/// The product stock.
		/// </value>
		public int ProductStock { get; set; }

		public int Price { get; set; }
	}
}

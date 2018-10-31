// Copyright © Microsoft Corporation.  All Rights Reserved.
// This code released under the terms of the 
// Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)
//
//Copyright (C) Microsoft Corporation.  All rights reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Xml.Linq;
using SampleSupport;
using Task.Data;

// Version Mad01

namespace SampleQueries
{
	[Title("LINQ Module")]
	[Prefix("Linq")]
	public class LinqSamples : SampleHarness
	{

		private DataSource dataSource = new DataSource();

		[Category("Restriction Operators")]
		[Title("Where - Task 1")]
		[Description("This sample return customers that has the sum of their orders more than 100000.")]
		public void Linq1()
		{
			var count = 100000;
			var customers = dataSource.Customers.Where(x => x.Orders.Sum(order => order.Total) > count);

			foreach (var p in customers)
			{
				ObjectDumper.Write(p);
			}
		}

		[Category("Restriction Operators")]
		[Title("Where - Task 2")]
		[Description("This sample return all suppliers of all customers that have the same city and country.")]
		public void Linq2()
		{
			var customers = dataSource.Customers;
			var suppliers = dataSource.Suppliers;

			foreach (var c in customers)
			{
				var sample = suppliers.Where(x => x.Country == c.Country && x.City == c.City);
				if (sample.Count() != 0)
				{
					ObjectDumper.Write(c);
					foreach (var s in sample)
					{
						ObjectDumper.Write(s);
					}
				}
			}
		}


		[Category("Restriction Operators")]
		[Title("Where - Task 3")]
		[Description("This sample return all customers that have sum of the order more than 100")]
		public void Linq3()
		{
			var count = 100;
			var customers = dataSource.Customers.Where(x => x.Orders.Any(order => order.Total > count));

			foreach (var p in customers)
			{
				ObjectDumper.Write(p);
			}
		}

		[Category("Restriction Operators")]
		[Title("Where - Task 4")]
		[Description("This sample return list of the clients with date of his first order.")]
		public void Linq4()
		{
			var list = dataSource.Customers.Select(p => new
			{
				customer = p,
				firstOrder = p.Orders.FirstOrDefault()
			});

			foreach (var p in list)
			{
				if (p.firstOrder != null)
				{
					ObjectDumper.Write($"{p.customer.CompanyName} - {p.firstOrder.OrderDate.Month} {p.firstOrder.OrderDate.Year}");
				}
				else
				{
					ObjectDumper.Write($"{p.customer} - No date yet.");
				}
			}
		}

		[Category("Restriction Operators")]
		[Title("Where - Task 5")]
		[Description("This sample return list of the clients with date of his first order, sorted by year, month, order and name of client")]
		public void Linq5()
		{
			var list = dataSource.Customers.Select(p => new
			{
				customer = p,
				firstOrder = p.Orders.FirstOrDefault() == null ? new Order() { OrderDate = DateTime.MinValue } : p.Orders.FirstOrDefault()
			})
			.OrderBy(p => p.firstOrder.OrderDate.Month)
			.OrderBy(p => p.firstOrder.OrderDate.Year)
			.OrderBy(p => p.firstOrder.Total)
			.OrderByDescending(arg => arg.customer.CompanyName);

			foreach (var p in list)
			{
				ObjectDumper.Write($"{p.customer.CompanyName} - {p.firstOrder.OrderDate.Month} {p.firstOrder.OrderDate.Year}");
			}
		}

		[Category("Restriction Operators")]
		[Title("Where - Task 6")]
		[Description("This sample return return all customer that have not calind region, postalcode, or phone.")]
		public void Linq6()
		{
			var customers = dataSource.Customers.Where(customer =>
				customer.Region == null ||
				customer.PostalCode == null ||
				customer.PostalCode.Any(l => Char.IsLetter(l)) ||
				customer.Phone == null ||
				customer.Phone.Any(p => p == '(' || p == ')')
			);

			foreach (var p in customers)
			{
				ObjectDumper.Write(p);
			}
		}

		[Category("Restriction Operators")]
		[Title("Where - Task 7")]
		[Description("This sample return all products grouping by category and sorted inside the groups by price.")]
		public void Linq7()
		{
			var products = dataSource.Products.GroupBy(p => p.Category);

			foreach (var p in products)
			{
				var a = p.OrderBy(x => x.UnitPrice);

				ObjectDumper.Write(p.Key);

				foreach (var t in a)
				{
					ObjectDumper.Write(t);
				}
				ObjectDumper.Write("");
			}
		}

		[Category("Restriction Operators")]
		[Title("Where - Task 8")]
		[Description("This sample return products that have low, middle and high price.")]
		public void Linq8()
		{
			var lowProduct = dataSource.Products.Where(product => product.UnitPrice < 30).OrderBy(x => x.UnitPrice);
			var middleProduct = dataSource.Products.Where(product => product.UnitPrice >= 30 && product.UnitPrice <= 60).OrderBy(x => x.UnitPrice);
			var highProduct = dataSource.Products.Where(product => product.UnitPrice > 60).OrderBy(x => x.UnitPrice);

			ObjectDumper.Write("Low price product");

			foreach (var p in lowProduct)
			{
				ObjectDumper.Write(p);
			}

			ObjectDumper.Write("");

			ObjectDumper.Write("Middle price product");

			foreach (var p in middleProduct)
			{
				ObjectDumper.Write(p);
			}

			ObjectDumper.Write("");

			ObjectDumper.Write("High price product");

			foreach (var p in highProduct)
			{
				ObjectDumper.Write(p);
			}

			ObjectDumper.Write("");
		}

		[Category("Restriction Operators")]
		[Title("Where - Task 9")]
		[Description("This sample return average intensity and profitability of the customers by city.")]
		public void Linq9()
		{
			var groupedBy = dataSource.Customers.GroupBy(x => x.City);

			foreach (var p in groupedBy)
			{
				ObjectDumper.Write(p.Key);
				ObjectDumper.Write(p.Average(x =>
				{
					return x.Orders.Length != 0 ? x.Orders.Average(y => y.Total) : 0;
				}));
				ObjectDumper.Write(p.Average(x =>
				{
					return x.Orders.Length != 0 ? x.Orders.Length : 0;
				}));
			}
		}

		private class OrderResult : Order
		{
			public string CompanyName { get; set; }

			public override string ToString()
			{
				return $"{CompanyName}\t{base.ToString()}";
			}
		}

		[Category("Restriction Operators")]
		[Title("Where - Task 10")]
		[Description("This sample return statistics of the customer activity per month, year and month - year.")]
		public void Linq10()
		{
			var list = new List<OrderResult>();

			foreach (var c in dataSource.Customers)
			{
				if (c.Orders.Length != 0)
				{
					foreach (var o in c.Orders)
					{
						list.Add(new OrderResult()
						{
							CompanyName =  c.CompanyName,
							OrderDate = o.OrderDate,
							Total = o.Total,
							OrderID = o.OrderID
						});
					}
				}
			}

			var orderedByMonth = list.GroupBy(x => x.OrderDate.Month).OrderBy(x => x.Key);
			var orderedByYear = list.GroupBy(x => x.OrderDate.Year).OrderBy(x => x.Key);
			var orderedByDate = list.GroupBy(x => x.OrderDate).OrderBy(x => x.Key);

			ObjectDumper.Write("By Month");

			foreach (var o in orderedByMonth)
			{
				ObjectDumper.Write(o.Key);

				foreach (var t in o)
				{
					ObjectDumper.Write(t);
				}
				ObjectDumper.Write("");
			}

			ObjectDumper.Write("By Year");

			foreach (var o in orderedByYear)
			{
				ObjectDumper.Write(o.Key);

				foreach (var t in o)
				{
					ObjectDumper.Write(t);
				}
				ObjectDumper.Write("");
			}

			ObjectDumper.Write("By Date");

			foreach (var o in orderedByDate)
			{
				ObjectDumper.Write(o.Key);

				foreach (var t in o)
				{
					ObjectDumper.Write(t);
				}
				ObjectDumper.Write("");
			}
		}
	}
}

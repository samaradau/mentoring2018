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
		[Description("This sample return return customers that has the sum of their orders more than 100000.")]

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
		[Description("This sample return return customers that has the sum of their orders more than 100000.")]
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

		//[Category("Restriction Operators")]
		//[Title("Where - Task 4")]
		//[Description("This sample return return all presented in market products")]

		//public void Linq4()
		//{
		//	var products =
		//		from p in dataSource.Products
		//		where p.UnitsInStock > 0
		//		select p;

		//	foreach (var p in products)
		//	{
		//		ObjectDumper.Write(p);
		//	}
		//}

		//[Category("Restriction Operators")]
		//[Title("Where - Task 5")]
		//[Description("This sample return return all presented in market products")]

		//public void Linq5()
		//{
		//	var products =
		//		from p in dataSource.Products
		//		where p.UnitsInStock > 0
		//		select p;

		//	foreach (var p in products)
		//	{
		//		ObjectDumper.Write(p);
		//	}
		//}

		//[Category("Restriction Operators")]
		//[Title("Where - Task 6")]
		//[Description("This sample return return all presented in market products")]

		//public void Linq6()
		//{
		//	var products =
		//		from p in dataSource.Products
		//		where p.UnitsInStock > 0
		//		select p;

		//	foreach (var p in products)
		//	{
		//		ObjectDumper.Write(p);
		//	}
		//}

		//[Category("Restriction Operators")]
		//[Title("Where - Task 7")]
		//[Description("This sample return return all presented in market products")]

		//public void Linq7()
		//{
		//	var products =
		//		from p in dataSource.Products
		//		where p.UnitsInStock > 0
		//		select p;

		//	foreach (var p in products)
		//	{
		//		ObjectDumper.Write(p);
		//	}
		//}

		//[Category("Restriction Operators")]
		//[Title("Where - Task 8")]
		//[Description("This sample return return all presented in market products")]

		//public void Linq8()
		//{
		//	var products =
		//		from p in dataSource.Products
		//		where p.UnitsInStock > 0
		//		select p;

		//	foreach (var p in products)
		//	{
		//		ObjectDumper.Write(p);
		//	}
		//}

		//[Category("Restriction Operators")]
		//[Title("Where - Task 9")]
		//[Description("This sample return return all presented in market products")]

		//public void Linq9()
		//{
		//	var products =
		//		from p in dataSource.Products
		//		where p.UnitsInStock > 0
		//		select p;

		//	foreach (var p in products)
		//	{
		//		ObjectDumper.Write(p);
		//	}
		//}

		//[Category("Restriction Operators")]
		//[Title("Where - Task 10")]
		//[Description("This sample return return all presented in market products")]

		//public void Linq10()
		//{
		//	var products =
		//		from p in dataSource.Products
		//		where p.UnitsInStock > 0
		//		select p;

		//	foreach (var p in products)
		//	{
		//		ObjectDumper.Write(p);
		//	}
		//}
	}
}

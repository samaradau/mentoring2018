using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Threading;
using ConsoleApp.Properties;
using Microsoft.Win32.SafeHandles;

namespace ConsoleApp
{
	class Program
	{
		private static Dictionary<string, string> rules;
		private static string[] paths;
		private static List<FileSystemWatcher> fswlList;
		private static string defaultFolder;
		private static bool addDateToName;

		public static void Main(string[] args)
		{
			Setup();
			Console.ReadKey();
		}

		private static void Setup()
		{
			Properties.Resources.Culture = CultureInfo.GetCultureInfo(ConfigurationManager.AppSettings["Culture"]);
			Console.WriteLine(Properties.Resources.BeginSetup);
			defaultFolder = ConfigurationManager.AppSettings["DafaultFolder"];
			Boolean.TryParse(ConfigurationManager.AppSettings["AddDateToName"], out addDateToName);
			if (!Directory.Exists(defaultFolder))
			{
				Directory.CreateDirectory(defaultFolder);
			}
			rules = new Dictionary<string, string>();
			var rulesClass = new ResourceManager(typeof(Rules));
			var resourceSet = rulesClass.GetResourceSet(CultureInfo.CurrentUICulture, true, true);

			foreach (DictionaryEntry entry in resourceSet)
			{
				rules.Add(entry.Key.ToString(), entry.Value.ToString());
			}

			paths = ConfigurationManager.AppSettings["Paths"].Split(',');

			fswlList = new List<FileSystemWatcher>();

			foreach (var p in paths)
			{
				try
				{
					var fsw = new FileSystemWatcher(p);
					fsw.EnableRaisingEvents = true;
					fsw.Created += Fsw_Created;
					fswlList.Add(fsw);
				}
				catch (Exception e)
				{
					Console.WriteLine(Properties.Resources.ErrorOccurred, DateTime.Now, e.Message);
				}
			}
			Console.WriteLine(Properties.Resources.EndSetup);
			Console.WriteLine(Properties.Resources.BeginListening);
		}


		private static void Fsw_Created(object sender, FileSystemEventArgs e)
		{
			Console.WriteLine(Properties.Resources.FileCreated, DateTime.Now, e.FullPath);

			try
			{
				foreach (var rule in rules)
				{
					if (e.Name == rule.Key)
					{
						Console.WriteLine(Properties.Resources.RuleFound, DateTime.Now);
						File.Move(e.FullPath, $@"{rule.Value}\{e.Name}");

						Console.WriteLine(Properties.Resources.MovedAccordingRule, DateTime.Now, e.FullPath, rule.Value);
						return;
					}
				}
				Console.WriteLine(Properties.Resources.RuleNotFound, DateTime.Now);
				File.Move(e.FullPath, $@"{defaultFolder}\{e.Name}");
				Console.WriteLine(Properties.Resources.MovedByDefault, DateTime.Now, e.FullPath, defaultFolder);
			}
			catch (Exception ex)
			{
				Console.WriteLine(Properties.Resources.ErrorOccurred, DateTime.Now, ex.Message);
			}
		}
	}
}

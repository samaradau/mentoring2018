using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileVisitor
{
	/// <summary>
	/// Represents a file system visitor.
	/// </summary>
	public class FileSystemVisitor
	{
		private int iteration = 0;
		public event EventHandler OnSearchStart;
		public event EventHandler OnSearchStop;

		/// <summary>
		/// Gets all directory elements.
		/// </summary>
		/// <param name="path">Path to folder to analyse.</param>
		/// <param name="directories">Variable that will contain all directories inside.</param>
		/// <param name="files">Variable that will contain all files inside.</param>
		public void GetAllDirectoryElements(string path, ref string[] directories, ref string[] files)
		{
			if (iteration == 0)
			{
				OnSearchStart?.Invoke(this, null);
			}
			
			iteration++;

			string[] _dirs = Array.Empty<string>();
			string[] _files = Array.Empty<string>();

			if (path != null)
			{
				_dirs = Directory.GetDirectories(path);
				_files = Directory.GetFiles(path);
			}
			else
			{
				throw new ArgumentNullException(nameof(path));
			}

			if (files != null)
			{
				files = (files.Concat(_files)).ToArray();
			}
			else
			{
				throw new ArgumentNullException(nameof(files));
			}
			if (_dirs.Count() == 0)
			{
				return;
			}

			if (directories != null)
			{
				directories = (directories.Concat(_dirs)).ToArray();
			}
			else
			{
				throw new ArgumentNullException(nameof(directories));
			}

			for (int i = 0; i < _dirs.Count(); i++)
			{
				GetAllDirectoryElements(_dirs[i], ref directories, ref files);
				iteration--;
			}

			if (iteration == 1)
			{
				OnSearchStop?.Invoke(this, null);
			}
		}
	}
}

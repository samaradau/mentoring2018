using System;
using System.Collections;
using System.Linq;
using System.IO;

namespace FileVisitor
{
	/// <summary>
	/// Represents a file system visitor.
	/// </summary>
	public class FileSystemVisitor
	{
		private int iteration;
		private string _path;
		private string[] _files;
		private Predicate<string> _filter;

		public event EventHandler OnSearchStart;
		public event EventHandler OnSearchStop;

		private void Search(string path)
		{
			if (iteration == 0)
			{
				OnSearchStart?.Invoke(this, null);
			}

			iteration++;

			string[] dirs = Array.Empty<string>();
			string[] files = Array.Empty<string>();

			if (path != null)
			{
				dirs = Directory.GetDirectories(path);
				files = Directory.GetFiles(path);
			}
			else
			{
				throw new ArgumentNullException(nameof(path));
			}

			_files = (_files.Concat(files)).ToArray();

			if (dirs.Length == 0)
			{
				return;
			}

			_files = (_files.Concat(dirs)).ToArray();

			for (int i = 0; i < dirs.Count(); i++)
			{
				Search(dirs[i]);
				iteration--;
			}

			if (iteration == 1)
			{
				OnSearchStop?.Invoke(this, null);
			}
		}

		public FileSystemVisitor(string path)
		{
			_files = new string[] { };
			_path = path;
		}
		
		public FileSystemVisitor(string path, Predicate<string> filter) : this(path)
		{
			_filter = filter;
		}

		public IEnumerator GetEnumerator()
		{
			if (_files.Length == 0)
			{
				Search(_path);
			}

			for (int i = 0; i < _files.Length; i++)
			{
				if (_filter != null)
				{
					if (_filter(_files[i]))
					{
						yield return _files[i];
					}
				}
				else
				{
					yield return _files[i];
				}
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileVisitor
{
	public class FileSystemVisitor
	{
		public void GetAllDirectoryElements(string path, ref string[] directories, ref string[] files)
		{
			string[] _dirs = Array.Empty<string>();
			string[] _files = Array.Empty<string>();

			if (path != null)
			{
				_dirs = Directory.GetDirectories(path);
				_files = Directory.GetFiles(path);
			}

			if (files != null)
			{
				files = (files.Concat(_files)).ToArray();
			}

			if (_dirs.Count() == 0)
			{
				return;
			}

			if (directories != null)
			{
				directories = (directories.Concat(_dirs)).ToArray();
			}
			for (int i = 0; i < _dirs.Count(); i++)
			{
				GetAllDirectoryElements(_dirs[i], ref directories, ref files);
			}
		}
	}
}

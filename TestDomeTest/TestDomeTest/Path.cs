using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TestDomeTest
{
	public class Path
	{
		public string CurrentPath { get; private set; }

		public Path(string path)
		{
			this.CurrentPath = path;
		}

		public Path Cd(string newPath)
		{
			Regex r = new Regex("^[A-z]");

			var tokens = CurrentPath.Split('/');

			var dirs = tokens.Where(token => r.IsMatch(token)).ToList();

			tokens = newPath.Split('/');
			foreach (var token in tokens)
			{
				if (token == ".." && dirs.Count > 0) dirs.RemoveAt(dirs.Count - 1);
				else if (r.IsMatch(token))
				{
					dirs.Add(token);
				}
			}

			if (dirs.Count == 0) return new Path("/");

			var sb = new StringBuilder();
			foreach (var dir in dirs)
			{
				sb.Append("/" + dir);
			}

			return new Path(sb.ToString());
		}

//		public static void Main(string[] args)
//		{
//			Path path = new Path("/a/b/c/d");
//			Console.WriteLine(path.Cd("../x/../z").CurrentPath);
//			Console.ReadKey();
//		}
	}
}
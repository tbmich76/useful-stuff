using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TestDomeTest
{

	public class Program
	{
		public static int CountCompromised(string xml, string fileId)
		{
			var root = XElement.Load(new StringReader(xml));

			var compromisedFileIds = root.Descendants("file")
				.Where(element => element.Attribute("fileId").Value == fileId)
				.SelectMany(
					infectedFile =>
						infectedFile.Parent.Elements("file")
							.Where(element => element.Attribute("fileId").Value != fileId)
							.Select(element => element.Attribute("fileId").Value))
							.ToList();

			return compromisedFileIds.Distinct().Count();
		}

//		public static void Main(string[] args)
//		{
//			string xml =
//				"<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
//				"<root>" +
//				"   <snapshot>" +
//				"      <folder>" +
//				"         <file fileId=\"1\"/>" +
//				"         <file fileId=\"2\"/>" +
//				"         <folder>" +
//				"            <file fileId=\"3\"/>" +
//				"            <file fileId=\"4\"/>" +
//				"         </folder>" +
//				"      </folder>" +
//				"   </snapshot>" +
//				"   <snapshot>" +
//				"      <file fileId=\"1\"/>" +
//				"      <file fileId=\"3\"/>" +
//				"      <folder>" +
//				"         <file fileId=\"2\"/>" +
//				"         <file fileId=\"4\"/>" +
//				"         <folder>" +
//				"            <file fileId=\"3\"/>" +
//				"            <file fileId=\"4\"/>" +
//				"         </folder>" +
//				"      </folder>" +
//				"   </snapshot>" +
//				"</root>";
//
//			Console.WriteLine(CountCompromised(xml, "3"));
//			Console.ReadKey();
//		}
	}
}

// See https://aka.ms/new-console-template for more information
using System.Xml;

namespace XML_First_Project
{
    public class Program
    {
        public static void Main()
        {
            // -- XML --
            // Classes we are dealing with:
            // File, Directory, Path --> Services for Directory and File access
            // XmlDocument --> Class that represent the XML File
            // XmlNode --> Class that represents a single Node (Attributes, Inner Nodes)

            Console.WriteLine("Hello, World!");

            string pathString = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..") + "\\Employees.xml");
            Console.WriteLine("Project Directory: " + pathString);

            // 1.2 Check if file exists
            if (File.Exists(pathString))
            {
                // 1.3 Create a new instance of type XmlDocument
                XmlDocument xmlDoc = new XmlDocument();

                // 1.4 Try and load the XML content into the XmlDocument object
                xmlDoc.Load(pathString);

                // 2. Search for Employee
                XmlNode? xmlNode = xmlDoc.SelectSingleNode("/Employees/Employee[@id='2']");
                
                if (xmlNode != null && xmlNode.Attributes != null)
                {
                    // Check all attributes
                    foreach (XmlAttribute attribute in xmlNode.Attributes)
                    {
                        Console.WriteLine(attribute.Name + ": " + attribute.Value);
                    }
                }

                Console.WriteLine();
                //xmlDoc.Save();

                // 4. Insert new employee - ....
            }
            else
            {
                Console.WriteLine("File not found");
            }
        }
    }
}
// See https://aka.ms/new-console-template for more information
using System.Xml;

namespace XMLSimpleProject
{
    public class Program
    {
        // פרויקט רשימת תלמידים בכיתה
        // <Students>
        //    <Student>
        //       <FirstName>Shalom</FirstName>
        //       <LastName>Raichman</LastName>
        //    </Student>
        //    <Student>
        //       <FirstName>Shmuel</FirstName>
        //       <LastName>Rozental</LastName>
        //    </Student>
        // </Students>
        public static void Main(String[] args)
        {
            // 1. הגדרת קובץ לעבודה
            string _pathString = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..") + "\\Students.xml");
            XmlDocument xmlDoc;

            // 2. קריאת הקובץ
            if (File.Exists(_pathString))
            {
                xmlDoc = new XmlDocument();
                xmlDoc.Load(_pathString);
            }
            else // 3. אם הקובץ לא קיים, נייצר אותו עם נוד ראשון
            {
                xmlDoc = new XmlDocument();
                XmlNode studentsNode = xmlDoc.CreateElement("Students");
                xmlDoc.AppendChild(studentsNode);
            }

            // 4. להוסיף מספר תלמידים ל-XML
            // נייצר את המבנה
            XmlNode oneStudentNode = xmlDoc.CreateElement("Student");
            XmlNode studentFirstName = xmlDoc.CreateElement("FirstName");
            XmlNode studentLastName = xmlDoc.CreateElement("LastName");

            // נזין נתונים
            studentFirstName.InnerText = "Shalom";
            studentLastName.InnerText = "Raichman";

            // לחבר הכל
            oneStudentNode.AppendChild(studentFirstName);
            oneStudentNode.AppendChild(studentLastName);
            XmlNode? rootNode = xmlDoc.FirstChild;

            if (rootNode != null)
            {
                rootNode.AppendChild(oneStudentNode);
            } else
            {
                Console.WriteLine("Can't find any Nodes!");
            }

            // לשמור את הקובץ או העדכונים
            xmlDoc.Save(_pathString);
        }
    }
}
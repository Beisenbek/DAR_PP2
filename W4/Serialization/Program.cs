using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialization
{
    public class Student
    {
        public string name;
        public string gpa;
        public string password;
        public Student()
        {

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            F2();

         }

        private static void F2()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Student));
            FileStream fs = new FileStream("student.xml", FileMode.Open, FileAccess.Read);
            Student student = xmlSerializer.Deserialize(fs) as Student;
            Console.WriteLine(student.gpa + " " + student.name + " " + student.password);
            fs.Close();
        }

        private static void F1()
        {
            Student student = new Student();
            student.name = "AAAA";
            student.gpa = "3.5";
            student.password = "123";

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Student));
            FileStream fs = new FileStream("student.xml", FileMode.Create, FileAccess.Write);

            xmlSerializer.Serialize(fs, student);

            fs.Close();
        }
    }
}

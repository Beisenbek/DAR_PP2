using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example2
{
    class Student
    {
        public static string UniverName;

        public static void DoIt()
        {
            UniverName = "Test";
        }

        public string name;
        public Student()
        {
            name = "default";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student();
            s.name = "AAA";
            Console.WriteLine(s.name);

            Student.UniverName = "KBTU";
            Student.DoIt();
            Console.WriteLine(Student.UniverName);
        }
    }
}

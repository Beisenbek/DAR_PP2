using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example3
{

    class Student
    {
        public string name;
        static Student instance = null;
        Student()
        {

        }
        public static Student GetStudent()
        {
            if(instance == null)
            {
                instance = new Student();
            }
            return instance;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student s1 = Student.GetStudent();
            s1.name = "AAA";
            Student s2 = Student.GetStudent();
            s2.name = "AAA";

            Console.WriteLine(s1.name);
            Console.WriteLine(s2.name);

            Console.WriteLine(s1.GetHashCode());
            Console.WriteLine(s2.GetHashCode());

            Console.WriteLine(s1 == s2);

        }
    }
}

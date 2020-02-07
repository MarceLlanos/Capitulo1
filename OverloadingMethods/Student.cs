using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capitulo1
{
    class Student
    {
        string firstName;
        string lastName;
        int grade;
        string schoolName;

        public Student()
        {

        }

        public Student(string firstName, string lastName, int grade, string schoolName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.grade = grade;
            this.schoolName = schoolName;
        }

        public Student(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public Student(int grade, string schoolName)
        {
            this.grade = grade;
            this.schoolName = schoolName;
        }

    }
}

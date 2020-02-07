using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capitulo1
{
    public abstract class Students
    {
        public abstract void outputDetails();
    }

    public class CollegeStudent : Students
    {
        public string firstName;
        public string lastName;
        public string major;
        public double GPA;

        public override void outputDetails()
        {
            Console.WriteLine("Student " + firstName + " " + lastName + " enrolled in " + major + " is has a GPA of " + GPA);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capitulo1
{
    class Person
    {
        string firstName;
        string lastName;

        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public string Address1 { get; internal set; }
        public string City { get; internal set; }
        public string State { get; internal set; }
        public string Zip { get; internal set; }

        public Person()
        {

        }

        public Person(string firstName)
        {
            if ((firstName == null) || (firstName.Length < 1))
                throw new ArgumentOutOfRangeException("firstName", firstName, "FirstName must not be null or blank.");
            this.FirstName = firstName;
        }

       

        public Person(string firstName, string lastName) : this(firstName)
        {
            if ((firstName == null) || (firstName.Length < 1))
                throw new ArgumentOutOfRangeException("firstName", firstName, "FirstName must not be null or blank.");
            if ((lastName == null) || (lastName.Length < 1))
                throw new ArgumentOutOfRangeException("lastName", lastName, "LastName must not be null or blank.");
            // Save the first and last names.
            this.FirstName = firstName;
            this.lastName = lastName;
        }

        
    }

    class Empleado : Person
    {
        public static string Results = "";
        public string departmentName { get; set; }

        public Empleado(string firstName) : base ( firstName)
        {

        }

        public Empleado(string firstName, string lastName, string departmentName) : base(firstName, lastName)
        {
            // Validate the department name.
            if ((departmentName == null) || (departmentName.Length < 1))
                throw new ArgumentOutOfRangeException( "departmentName", departmentName, "DepartmentName must not be null or blank.");
            // Save the department name.
            this.departmentName = departmentName;
        }

        public Empleado(string firstName, string lastName) : this(firstName)
        {

        }
    }
}

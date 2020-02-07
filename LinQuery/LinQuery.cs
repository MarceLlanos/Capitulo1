using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Capitulo1
{
    class LinQuery
    {
        int[] MyArray = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int[] evenNumbers = new int[5];
        int evenIndex = 0;
        List<Employee> employees;
        List<Employee> employees2;
        List<State> states;
        List<Hometown> hometowns;
        List<Person> people;

        public LinQuery()
        {
            employees = new List<Employee>()
            {
                new Employee()
                {
                    FirstName = "John",
                    LastName = "Smith",
                    StateId = 2,
                    City = "Ewing",
                    State = "NJ"
                },
                new Employee()
                {
                    FirstName = "Jane",
                    LastName = "Doe",
                    StateId = 1,
                    City = "Fort Washington",
                    State = "PA"
                },
                new Employee()
                {
                    FirstName = "Jack",
                    LastName = "Jones",
                    StateId = 2,
                    City = "Trenton",
                    State = "NJ"
                }
            };

            employees2 = new List<Employee>()
            {
                new Employee()
                {
                    FirstName = "Bill",
                    LastName = "Peters"
                },
                new Employee()
                {
                    FirstName = "Bob",
                    LastName = "Donalds"},
                new Employee()
                {
                    FirstName = "Chris",
                    LastName = "Jacobs"
                }
            };

            states = new List<State>()
            {
                new State()
                {
                    StateId = 1,
                    StateName = "PA"
                },
                new State()
                {
                    StateId = 2,
                    StateName = "NJ"
                }
            };

            hometowns = new List<Hometown>()
            {
                new Hometown() { City = "Philadelphia", State = "PA", CityCode = "9217" },
                new Hometown() { City = "Ewing", State = "NJ", CityCode = "5678" },
                new Hometown() { City = "Havertown", State = "PA", CityCode = "1234" },
                new Hometown() { City = "Fort Washington", State = "PA", CityCode = "9012" },
                new Hometown() { City = "Trenton", State = "NJ", CityCode = "5644" }
            };

            people = new List<Person>()
            {
                new Person
                {
                    FirstName = "John",
                    LastName = "Smith",
                    Address1 = "First St",
                    City = "Havertown",
                    State = "PA",
                    Zip = "19084"
                    },
                    new Person()
                    {
                    FirstName = "Jane",
                    LastName = "Doe",
                    Address1 = "Second St",
                    City = "Ewing",
                    State = "NJ",
                    Zip = "08560"
                    },
                    new Person()
                    {
                    FirstName = "Jack",
                    LastName = "Jones",
                    Address1 = "Third St",
                    City = "Ft Washington",
                    State = "PA",
                    Zip = "19034"
                    }
            };
        }

        public void EventOnArray()
        {
            foreach (var item in MyArray)
            {
                if (item % 2 == 0)
                {
                    evenNumbers[evenIndex] = item;
                    evenIndex++;
                }
            }

            foreach (var item in evenNumbers)
            {
                Console.WriteLine(item);
            }
        }

        //Lo mismo pero LINQuery

        public void EvenOnArrayWithLinQ()
        {
            var evenNumbers = from item in MyArray
                              where item % 2 == 0 && item > 5
                              select item;

            var evenNumbers1 = from item in MyArray
                               where item % 2 == 0
                               where item > 5
                               select item;

            foreach (var item in evenNumbers)
            {
                Console.WriteLine(item);
            }
        }

        public static void RetrieveEvenNumberGT5V3()
        {
            int[] myArray = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var evenNumbers = from item in myArray
                              where IsEvenAndGT5(item)
                              orderby item descending
                              select item;

            foreach (int item in evenNumbers)
            {
                Console.WriteLine(item);
            }
        }

        public static bool IsEvenAndGT5(int i)
        {
            return (i % 2 == 0 && i > 5);
        }

        public  void OrderByStateThenCity()
        {
            var orderedHometowns = from h in hometowns
                                   orderby h.State ascending, h.City ascending
                                   select h;

            foreach (Hometown hometown in orderedHometowns)
            {
                Console.WriteLine(hometown.City + ", " + hometown.State);
            }
        }

        public void Join()
        {
            var employeeByState = from e in employees
                                  join s in states
                                  on e.StateId equals s.StateId
                                  select new { e.LastName, s.StateName };

            foreach (var employee in employeeByState)
            {
                Console.WriteLine(employee.LastName + ", " + employee.StateName);
            }
        }

        public void Projection()
        {
            var lastNames = people.Select(p => p.LastName);

            foreach (string lastName in lastNames)
            {
                Console.WriteLine(lastName);
            }
        }

        public void MethodBasedProjection()
        {
            var names = people.Select(p => new { p.FirstName, p.LastName });

            var directions = people.Select(p => new {Address = p.Address1, City = p.City, State = p.State });

            foreach (var name in names)
            {
                Console.WriteLine( string.Format("{0} {1}", name.FirstName, name.LastName) );
            }

            foreach (var direction in directions)
            {
                Console.WriteLine("{0} {1} {2}", direction.Address, direction.City, direction.State);
            }
        }

        public void MethodSelectMany()
        {
            var employeeByState = employees.SelectMany(employee => states.Where(state =>  employee.StateId == state.StateId).Select( s => new { employee.LastName, s.StateName}));

            foreach (var item in employeeByState)
            {
                Console.WriteLine( "{0} {1}", item.LastName, item.StateName );
            }
        }

        public void MethodJoin()
        {
            var employeeByState = employees.Join(states, e => e.StateId, s => s.StateId, (e, s) => new {FirstName = e.FirstName, LastName = e.LastName, StateName = s.StateName});

            foreach (var employee in employeeByState)
            {
                Console.WriteLine("{0} {1} {2}" +
                    "",employee.FirstName, employee.LastName, employee.StateName);
            }
        }

        public void MethodOuterJoin()
        {
            var employeeByState = employees.GroupJoin(states, e => e.StateId, s => s.StateId, (e, employeeGroup) => employeeGroup.Select(s => new { LastName = e.LastName, StateName = s.StateName }).DefaultIfEmpty(new { LastName = e.LastName, StateName = "" })).SelectMany(employeeGroup => employeeGroup);

            foreach (var employee in employeeByState)
            {
                Console.WriteLine( "{0} {1}", employee.LastName, employee.StateName );
            }

        }

        public void MethodOuterJoinWithIntoKey()
        {
            var employeeByState = from e in employees
                                  join s in states
                                  on e.StateId equals s.StateId into employeeGroup
                                  from item in employeeGroup.DefaultIfEmpty(new State { StateId = 0, StateName = "" })
                                  select new { e.LastName, item.StateName};
        }

        public void MethodCompositeKey()
        {
            var employeeByState = employees.Join(hometowns, e => new { City = e.City, State = e.State}, h => new { City = h.City, State = h.State}, (e, h) => new { e.LastName, h.CityCode });

            foreach (var employee in employeeByState)
            {
                Console.WriteLine("{0} {1}", employee.LastName, employee.CityCode);
            }
        }

        public void MethodGroupin()
        {
            var employeesByState = employees.GroupBy(e => e.State);

            foreach (var employeeGroup in employeesByState)
            {
                Console.WriteLine("{0} : {1}", employeeGroup.Key, employeeGroup.Count());

                foreach (var employee in employeeGroup)
                {
                    Console.WriteLine("{0}, {1}", employee.LastName, employee.State);
                }
            }

            var employeeByCity = employees.GroupBy(e => new { e.City, e.State});

            foreach (var employeeGroup in employeeByCity)
            {
                Console.WriteLine("{0} {1}", employeeGroup.Key, employeeGroup.Count());

                foreach (var employee in employeeGroup)
                {
                    Console.WriteLine("{0} {1}", employee.LastName, employee.City);
                }
            }
        }

        public void MethodConcatenation()
        {
            var combinedEmployees = employees.Concat(employees2);

            foreach (var employee in combinedEmployees)
            {
                Console.WriteLine(employee.LastName);
            }

            var combinedEmployeeWithPeople = employees.Select( e => new { Name = e.FirstName}).Concat(people.Select(p => new { Name = p.FirstName}));

            foreach (var employee in combinedEmployeeWithPeople)
            {
                Console.WriteLine(employee.Name);
            }
        }

        public void MethodLINQToXML()
        {
            var xmlEmployee = new XElement("Root", from e in employees
                                                   select new XElement("Employee", new XElement("FirstName", e.FirstName),
                                                   new XElement("LastName", e.LastName)));
            Console.WriteLine(xmlEmployee);
        }

    }

    class Hometown
    {
        public string City { get; set; }
        public string State { get; set; }
        public string CityCode { get; set; }
    }

    class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StateId { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }

    class State
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
    }
}

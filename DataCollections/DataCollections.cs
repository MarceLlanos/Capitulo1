using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capitulo1
{
    class DataCollections
    {
        public DataCollections()
        {
            Persona[] original = new Persona[1];
            original[0] = new Persona() { Name = "Claudia"};

            Persona[] clone = (Persona[])original.Clone();
            clone[0].Name = "Mary";

            Console.WriteLine("Orignal name: {0}", original[0].Name);
            Console.WriteLine("Clone name: {0}", clone[0].Name);

            Persona[] originalMan = new Persona[1];
            originalMan[0] = new Persona() { Name = "Elmer" };

            Persona[] cloneMan = (Persona[])original.Clone();
            cloneMan[0] = new Persona() { Name = "Juan" };

            Console.WriteLine("Original Man Name: {0}", originalMan[0].Name);
            Console.WriteLine("clone Man Name: {0}", cloneMan[0].Name);
            
        }

    }

    public class Persona
    {
        public string Name { get; set; }
        string lastName { get; set; }
    }

}

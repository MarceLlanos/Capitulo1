using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data.SqlClient;

namespace Capitulo1
{
    class Program
    {
        static void Main(string[] args)
        {
            DataCollections person = new DataCollections();

            object[,,,] myIntArray = new object[5, 6, 1 ,8];

            Type myIntArrayType = myIntArray.GetType();
            Console.WriteLine("Array Rank: {0}", myIntArrayType.GetArrayRank());

            var beyondIf = new BeyondIfStatement();
            beyondIf.ExampleIfStament();

            Book_Struct myBook = new Book_Struct("La casa de los espiritus", "Ciencia Ficcion", "Isabel Allente", 210, 1, 81118612095, "Elena");

            Console.WriteLine(myBook.title);
            Console.WriteLine(myBook.category);
            Console.WriteLine(myBook.author);
            Console.WriteLine(myBook.numberPages);
            Console.WriteLine(myBook.currentPage);
            Console.WriteLine(myBook.ISBN);
            Console.WriteLine(myBook.coverStyle);
            myBook.nextPage();
            myBook.prevPage();

            var student = new Student();
            var student1 = new Student("Isabel ", "Lopez");
            var student2 = new Student(5, "Anglo Americano");
            var student3 = new Student("Isabel ", "Lopez", 5, "Anglo Americano");

            // Specify the data source.
            int[] scores = new int[] { 97, 92, 81, 60 };

            // Define the query expression.
            IEnumerable<int> scoreQuery =
                from score in scores
                where score > 80
                select score;

            // Execute the query.
            foreach (int i in scoreQuery)
            {
                Console.Write(i + " ");
            }

            

            var overdraftAccount = new OverdraftAccount();
            overdraftAccount.BarriersUsage();
            //overdraftAccount.RunTasksCorrected();

            //overdraftAccount.PrintPercentageResult();

            Console.ReadKey();
        }
    }
}

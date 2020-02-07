using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capitulo1
{
    public struct Book_Struct
    {
        public string title;
        public string category;
        public string author;
        public int numberPages;
        public int currentPage;
        public double ISBN;
        public string coverStyle;

        public Book_Struct(string title, string category, string author, int numPages, int currentPage, double isbn, string cover)
        {
            this.title = title;
            this.category = category;
            this.author = author;
            this.numberPages = numPages;
            this.currentPage = currentPage;
            this.ISBN = isbn;
            this.coverStyle = cover;
        }
        public void nextPage()
        {
            if (currentPage != numberPages)
            {
                currentPage++;
                Console.WriteLine("Current page is now: " + this.currentPage);
            }
            else
            {
                Console.WriteLine("At end of book.");
            }
        }
        public void prevPage()
        {
            if (currentPage != 1)
            {
                currentPage--;
                Console.WriteLine("Current page is now: " + this.currentPage);
            }
            else
            {
                Console.WriteLine("At the beginning of the book.");


            }
        }
    }
}

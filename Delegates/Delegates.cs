using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capitulo1
{
    class Delegates
    {
        delegate void MyFirstDelegateString(string s);

        static void WriteToConsoleForward(string stringToWrite)
        {
            Console.WriteLine("This is my string: {0}", stringToWrite);
        }

        MyFirstDelegateString myFirstDelegate = new MyFirstDelegateString(WriteToConsoleForward);
    }
}

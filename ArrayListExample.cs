using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capitulo1
{
    class ArrayListExample
    {
        ArrayList myList;

        public ArrayListExample()
        {
            myList = new ArrayList();

            myList.Add(new MyObject { Id = 4 });
            myList.Add(new MyObject { Id = 5 });
            myList.Add(new MyObject { Id = 3 });
            myList.Add(new MyObject { Id = 1 });
            myList.Add(new MyObject { Id = 6 });
            myList.Add(new MyObject { Id = 2 });

            myList.Sort();

        }
    }

    class MyObject :IComparable
    {
        public int Id { get; set; }

        public int CompareTo(object obj)
        {
            MyObject obj1 = obj as MyObject;

            return this.Id.CompareTo(obj1.Id);
        }
    }
}

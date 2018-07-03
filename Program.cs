using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList ArrayList = new ArrayList();

            ArrayList.Add(1);
            ArrayList.Add(2);
            ArrayList.Add(3);

            ArrayList.RemoveByIndex(0); 
            ArrayList.Print();      
        }
    }
}

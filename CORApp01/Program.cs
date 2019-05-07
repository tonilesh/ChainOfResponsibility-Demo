using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Patterns.COR;
using System.IO;

namespace CORApp01
{
    class Program
    {
        static void Main(string[] args)
        {
            Object[] myItems ={
                                  "India",
                                  72.9,
                                  "72.7",
                                  new IndexOutOfRangeException(),
                                  new FileInfo(@"c:\autoexec.bat")
                              };


          ChainManager<object> manager=new ChainManager<object>();
          ObjectCounter oc=new ObjectCounter();
          manager.Insert(oc);
          manager.Insert(new ObjectManager(ChainResult.Pass));
          manager.Insert(new NumberManager());
          manager.Insert(new StringManager());
          manager.Insert(new ObjectManager());
            

            foreach (object item in myItems)
            {
                Console.WriteLine("processing ..."+item);
                if (manager.Action(item) == ChainResult.Sucess)
                {
                    Console.WriteLine("\t{0} processed successfully", item);
                    Console.WriteLine("\t\t\tProcessed by "+manager.Processor);
                }
                else
                    Console.WriteLine("\t{0} cant be processed", item);
            }

            Console.WriteLine("total items processed is "+oc.Count);
        }
    }
}

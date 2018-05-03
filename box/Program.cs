using System;
using System.Collections.Generic;

namespace box
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> Box = new List<object>();
            Box.Add(7);
            Box.Add(28);
            Box.Add(-1);
            Box.Add(true);
            Box.Add("Chair");
            int sum = 0;
            
            foreach(var stuff in Box){
               if(stuff is int){
                   sum += (int)stuff;

                   
                   
               }
            }
                   System.Console.WriteLine(sum);

        }
    }
}

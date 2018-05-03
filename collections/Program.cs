using System;
using System.Collections.Generic;

namespace collections
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] stuff = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            string[] names = { "Tim", "Martin", "Nikki", "Sara" };
            bool[] tf = { true, false, true, false, true, false, true, false, true, false };

            int[,] arr = new int[10, 10];
            for (int i = 1; i <= 10; i++)
            {
               for(int j =1; j <=10; j++){
                   Console.Write("{0}\t", (i==0) ? i: i *j);
               }
               
               Console.WriteLine();
            }

            List<string> iceCream = new List<string>();
            iceCream.Add("Vanilla");
            iceCream.Add("Chocolate");
            iceCream.Add("Mint");
            iceCream.Add("Sherbert");
            iceCream.Add("Strawberry");
            Console.WriteLine(iceCream.Count);
            for(var idx = 0; idx < iceCream.Count; idx++){
                Console.WriteLine(iceCream[idx]);
            }
            Console.WriteLine(iceCream[2]);
            iceCream.Remove("Mint");
            Console.WriteLine(iceCream.Count);


            Dictionary<string,string> info = new Dictionary<string,string>();
            info.Add("Tim", null);
            info.Add("Martin", null);
            info.Add("Nikki", null);
            info.Add("Sara", null);
            Random favorite = new Random();

            List<string> keys = new List <string>(info.Keys);
            foreach(string key in keys){
                info[key] = iceCream[favorite.Next(0,iceCream.Count)];
                foreach(var entry in info){
                    System.Console.WriteLine(entry.Key + "-"+ entry.Value);
                }
                            

            }

        }



        

    }
}

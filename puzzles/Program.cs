using System;
using System.Collections.Generic;

namespace puzzles
{
    class Program
    {
        static void Main(string[] args)
        {
            Random();
            Flipper(40);
        }
        public static int[] Random()
        {
            int[] stuff = { 5, 6, 7, 8, 9, 10, 15, 21, 22, 23, 24, 25 };
            int max = stuff[0];
            int min = stuff[0];
            int sum = 0;

            for (int i = 0; i < stuff.Length; i++)
            {
                if (stuff[i] > max)
                {
                    max = stuff[i];
                }
                if (stuff[i] < min)
                {
                    min = stuff[i];
                }
                sum += stuff[i];
            }
            System.Console.WriteLine("the sum is {0}", sum);
            int avg = sum / stuff.Length;
            System.Console.WriteLine("The Max is {0}", max);
            System.Console.WriteLine("The Min is {0}", min);
            System.Console.WriteLine("The Avg is {0}", avg);
            return stuff;


        }

        public static string Flipper(int num)
        {
            Random Cointoss = new Random();

            string result = "";
            int countH = 0;
            int countT =0;

            while(num > 0){
                int flip = Cointoss.Next(0, 2);
                if (flip == 0)
                {
                    result = "Heads";
                    countH +=1;

                    
                }
                else
                {
                    result = "Tails";
                    countT +=1;
                }

                num--;

                System.Console.WriteLine(result);
                System.Console.WriteLine("Heads Count"+" "+countH+ ":"+"Tails Count"+" "+ countT);

            }
            return result;



        }

        public static List<string> Names(){
           string[] names = {"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};
           string[] results = {};

           List<string> newlist = new List<string>();
           Random randy = new Random();
           List<int> liststuff = new List<int>();
           
          for(int i = 0; i<names.Length; i++){
               int index = randy.Next(0,names.Length);
               if(names[i].Length > 5){
                   newlist.Add(names[i]);

               }
               if(!liststuff.Contains(index)){
                   string temp = names[i];
                   names[i] = names[index];
                   names[index] = temp;
                   
               }


           }
           return newlist;

            
        }

    }
}

using System;
using System.Collections.Generic;

namespace Human
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Human someguy = new Human("Bobby",5,200,3,4);
            System.Console.WriteLine(someguy.name);
            System.Console.WriteLine(someguy.health);
            System.Console.WriteLine(someguy.intelligence);
            System.Console.WriteLine(someguy.dexterity);
            System.Console.WriteLine(someguy.strength);

            Human anotherguy = new Human("Sammy",8,300,8,2);

           someguy.Attack(anotherguy);
        }
    }
}

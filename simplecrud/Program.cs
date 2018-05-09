using System;
using DbConnection;
using System.Collections.Generic;

namespace simplecrud
{
    class Program
    {
        static void Main(string[] args)
        {
            Showme();
             Create();
            // Update();
            // Delete();
        }

        public static void Showme()
        {
            var stuff = DbConnector.Query("SELECT* FROM users");
            for(int i = 0; i < stuff.Count; i++){
                foreach(var x in stuff[i]){
                    System.Console.WriteLine(x.Key + " " + x.Value);
                }
            }
            
        }

        public static void Create(){
            System.Console.WriteLine("Enter first name");
            string FirstName = Console.ReadLine();
            System.Console.WriteLine("Enter last name");
            string LastName = Console.ReadLine();
            System.Console.WriteLine("Enter favorite number");
            string FavoriteNumber =  Console.ReadLine();
            string create = $"INSERT INTO users (FirstName,LastName,FavoriteNumber) VALUES ('{FirstName}', '{LastName}', {FavoriteNumber})"; 
            DbConnector.Execute(create);
            Showme();

            

        }
        public static void Update(){
            System.Console.WriteLine("Enter Id to Update");
            string id = Console.ReadLine();
            System.Console.WriteLine("Enter New First Name");
            string FirstName = Console.ReadLine();
            System.Console.WriteLine("Enter New Last Name");
            string LastName = Console.ReadLine();
            System.Console.WriteLine("Enter favorite Number");
            string FavoriteNumber = Console.ReadLine();

            string update = $"UPDATE users SET FirstName= '{FirstName}', LastName = '{LastName}', FavoriteNumber = {FavoriteNumber} WHERE id ={id}";
            DbConnector.Execute(update);
            Showme();

        }
        public static void Delete(){
            System.Console.WriteLine("Enter the ID YOU WANT DELETED");
            string id = Console.ReadLine();
            string delete = $"DELETE FROM users WHERE id = {id}";
            DbConnector.Execute(delete);
            Showme();
        }
    }
}
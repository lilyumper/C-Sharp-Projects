using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            var Mtver = from artist in Artists
                where artist.Hometown == "Mount Vernon"
                select new { artist.ArtistName, artist.Age};

            //Who is the youngest artist in our collection of artists?
            var Young = from artist in Artists
            orderby artist.Age ascending
            select new { artist.ArtistName, artist.Age};

            //Display all artists with 'William' somewhere in their real name
            IEnumerable<Artist> NameList = Artists.Where( str => str.RealName.Contains("William"));

            //Display the 3 oldest artist from Atlanta
            IEnumerable<Artist> Oldmen = Artists.Where(artist => artist.Hometown == "Atlanta").OrderByDescending(age => age.Age).Take(3);

            //(Optional) Display the Group Name of all groups that have members that are not from New York City

            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
        }
    }
}

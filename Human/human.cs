namespace Human {

    public class Human{
        public string name;
        public int strength = 3;
        public int health = 100;

        public int dexterity = 3;

        public int intelligence = 3;

        public Human(string val){
            val = name;
        }

        public Human(string val1, int val2 = 3, int val3 = 100, int val4 = 3, int val5 = 3){
            name = val1;
            strength = val2;
            health = val3;
            intelligence = val4;
            dexterity = val5;


        }

        public void Attack(Human victim){
            Human enemy = victim as Human;
            if(enemy == null){
                System.Console.WriteLine("Not a Human so you failed");
            }
            else{
                int hp = victim.health -= (this.strength * 5);
                int attack = (this.strength * 5);
                System.Console.WriteLine("{0} attacked {1} and lost {2} health and who now has {3} health", this.name,victim.name,attack,hp);
                
            }
            
        }

    }
}
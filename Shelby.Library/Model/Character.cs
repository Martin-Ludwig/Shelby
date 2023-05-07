namespace Shelby.Library.Model
{
    public class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }

        public int Strength { get; set; }

        public Character(string name, int health, int strength)
        {
            Name = name;
            Health = health;
            Strength = strength;
        }

        override public string ToString()
        {
            return $"{Name} ({Health} Health, {Strength} Strength)";
        }
    }
}

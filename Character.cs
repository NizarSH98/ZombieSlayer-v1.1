using System;

namespace ZombieSlayer
{
    public class Character
    {
        // Character attributes
        public string Name { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public int X { get; set; } // X-coordinate position
        public int Y { get; set; } // Y-coordinate position

        // Constructor
        public Character(string name, int health, int mana, int x, int y)
        {
            Name = name;
            Health = health;
            Mana = mana;
            X = x;
            Y = y;
        }

        // Methods
        public void TakeDamage(int damageAmount)
        {
            Health -= damageAmount;
            Console.WriteLine($"{Name} took {damageAmount} damage!");
        }

        public void CastSpell(string spellName, int manaCost)
        {
            if (Mana >= manaCost)
            {
                Console.WriteLine($"{Name} casts {spellName}!");
                Mana -= manaCost;
            }
            else
            {
                Console.WriteLine($"Not enough mana to cast {spellName}!");
            }
        }

        public void Move(int deltaX, int deltaY)
        {
            X += deltaX;
            Y += deltaY;
            Console.WriteLine($"{Name} moved to position ({X}, {Y})");
        }
    }

}

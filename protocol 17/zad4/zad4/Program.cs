using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad4
{
    internal class Program
    {
        public abstract class Sandwich
        {
            public abstract Sandwich Clone();
        }

        public class CustomSandwich : Sandwich
        {
            public string Bread, Meat, Cheese, Veggies;
            public override Sandwich Clone() => MemberwiseClone() as Sandwich;

            public override string ToString() => $"Cloning a sandwich with: {Bread} bread, {Meat}, {Cheese}, {Veggies}";
        }

        public class SandwichMenu
        {
            private Dictionary<string, Sandwich> _sandwiches = new Dictionary<string, Sandwich>();
            public Sandwich this[string name]
            {
                get => _sandwiches[name].Clone();
                set => _sandwiches[name] = value;
            }
        }
        static void Main(string[] args)
        {
            var menu = new SandwichMenu();
            menu["BLT"] = new CustomSandwich { Bread = "White", Meat = "Bacon", Cheese = "Cheddar", Veggies = "Tomato" };
            var sandwich = menu["BLT"];
            Console.WriteLine(sandwich);
        }
    }
}

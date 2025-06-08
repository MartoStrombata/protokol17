using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad6
{
    internal class Program
    {
        public abstract class Bread
        {
            public abstract void MixIngredients();
            public abstract void Bake();
            public virtual void Slice() => Console.WriteLine("Slicing the bread...");
            public void Make()
            {
                MixIngredients();
                Bake();
                Slice();
            }
        }

        public class Sourdough : Bread
        {
            public override void MixIngredients() => Console.WriteLine("Mixing sourdough ingredients...");
            public override void Bake() => Console.WriteLine("Baking sourdough bread...");
        }

        public class WholeWheat : Bread
        {
            public override void MixIngredients() => Console.WriteLine("Mixing whole wheat ingredients...");
            public override void Bake() => Console.WriteLine("Baking whole wheat bread...");
        }
        static void Main(string[] args)
        {
            new Sourdough().Make();
            new WholeWheat().Make();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace zad1
{
    internal class Program
    {
        public class SingletonDataContainer : ISingletonContainer
        {
            private Dictionary<string, int> _capitals;
            private static SingletonDataContainer _instance = new SingletonDataContainer();

            private SingletonDataContainer()
            {
                _capitals = File.ReadAllLines("capitals.txt")
                                .Select(line => line.Split(' '))
                                .ToDictionary(parts => parts[0], parts => int.Parse(parts[1]));
            }

            public static SingletonDataContainer Instance => _instance;

            public int GetPopulation(string name) => _capitals[name];
        }
        static void Main(string[] args)
        {
            var db = SingletonDataContainer.Instance;
            var db2 = SingletonDataContainer.Instance;
            var db3 = SingletonDataContainer.Instance;
            var db4 = SingletonDataContainer.Instance;
        }
    }
}
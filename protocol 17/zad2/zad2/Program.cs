using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad2
{
    internal class Program
    {
        public class Car
        {
            public string Type, Color;
            public string Address, City;
            public int NumberOfDoors;
            public override string ToString() => $"CarType:{Type}, Color:{Color}, Number of doors:{NumberOfDoors} from {City}, {Address}";
        }

        public class CarBuilder
        {
            protected Car car = new Car();
            public CarInfoBuilder Info => new CarInfoBuilder(car);
            public CarAddressBuilder Address => new CarAddressBuilder(car);
            public Car Build() => car;
        }

        public class CarInfoBuilder : CarBuilder
        {
            public CarInfoBuilder(Car car) { this.car = car; }
            public CarInfoBuilder SetType(string type) { car.Type = type; return this; }
            public CarInfoBuilder SetColor(string color) { car.Color = color; return this; }
            public CarInfoBuilder SetNumberOfDoors(int numberOfDoors) { car.NumberOfDoors = numberOfDoors; return this; }
        }

        public class CarAddressBuilder : CarBuilder
        {
            public CarAddressBuilder(Car car) { this.car = car; }
            public CarAddressBuilder SetCity(string city) { car.City = city; return this; }
            public CarAddressBuilder SetAddress(string address) { car.Address = address; return this; }
        }
        static void Main(string[] args)
        {
            var carBuilder = new CarBuilder();
            Car car = carBuilder
                .Info.SetType("AUDI").SetColor("Red").SetNumberOfDoors(5)
                .Address.SetCity("Bavaria").SetAddress("Leipzeig 123")
                .Build();
            Console.WriteLine(car);
        }
    }
}

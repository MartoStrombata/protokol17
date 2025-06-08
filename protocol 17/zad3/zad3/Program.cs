using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad3
{
    internal class Program
    {
        public class Product
        {
            public string Name { get; set; }
            public int Price { get; set; }
            public void IncreasePrice(int amount) => Price += amount;
            public void DecreasePrice(int amount) => Price -= amount;
        }
        public enum PriceAction { Increase, Decrease }
        public class ProductCommand : ICommand
        {
            private Product _product;
            private PriceAction _action;
            private int _amount;

            public ProductCommand(Product product, PriceAction action, int amount)
            {
                _product = product;
                _action = action;
                _amount = amount;
            }

            public void ExecuteAction()
            {
                if (_action == PriceAction.Increase) _product.IncreasePrice(_amount);
                else _product.DecreasePrice(_amount);
            }

            public void UndoAction()
            {
                if (_action == PriceAction.Increase) _product.DecreasePrice(_amount);
                else _product.IncreasePrice(_amount);
            }
        }

        public class ModifyPrice
        {
            private List<ICommand> _commands = new List<ICommand>();
            public void SetCommand(ICommand command)
            {
                _commands.Add(command);
                command.ExecuteAction();
            }
        }
        static void Main(string[] args)
        {
            var product = new Product { Name = "Phone", Price = 500 };
            var modifyPrice = new ModifyPrice();
            modifyPrice.SetCommand(new ProductCommand(product, PriceAction.Increase, 100));
            modifyPrice.SetCommand(new ProductCommand(product, PriceAction.Decrease, 50));
            Console.WriteLine($"{product.Name} final price: {product.Price}");
        }
    }
}

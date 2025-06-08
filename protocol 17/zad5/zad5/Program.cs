using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace zad5
{
    internal class Program
    {
        public abstract class GiftBase
        {
            public string Name;
            public int Price;
            public GiftBase(string name, int price) { Name = name; Price = price; }
            public abstract int CalculateTotalPrice();
        }
        public interface IGiftOperations
        {
            void Add(GiftBase gift);
            void Remove(GiftBase gift);
        }
        public class CompositeGift : GiftBase, IGiftOperations
        {
            private List<GiftBase> _gifts = new List<GiftBase>();
            public CompositeGift(string name, int price) : base(name, price) { }
            public void Add(GiftBase gift) => _gifts.Add(gift);
            public void Remove(GiftBase gift) => _gifts.Remove(gift);
            public override int CalculateTotalPrice() => Price + _gifts.Sum(g => g.CalculateTotalPrice());
        }

        public class SingleGift : GiftBase
        {
            public SingleGift(string name, int price) : base(name, price) { }
            public override int CalculateTotalPrice() => Price;
        }
        static void Main(string[] args)
        {
            var phone = new SingleGift("Phone", 500);
            var headphones = new SingleGift("Headphones", 150);
            var giftBox = new CompositeGift("Gift Box", 20);
            giftBox.Add(phone);
            giftBox.Add(headphones);
            Console.WriteLine($"Total gift price: {giftBox.CalculateTotalPrice()}");
        }
    }
}

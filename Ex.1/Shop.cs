using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex._1
{
    internal class Shop
    {
        private Seller? _seller;
        private Dictionary<string, decimal> _items =
            new Dictionary<string, decimal>();

        public Shop()
        {
        }

        public Shop(Seller seller)
        {
            _seller = seller;
        }

        public Shop(Dictionary<string, decimal> items, Seller seller)
        {
            _items = items;
            _seller = seller;
        }

        public Shop(Dictionary<string, decimal> items)
        {
            _items = items;
        }

        public void Add(string nameItem, decimal priceItem)
        {
            CheckSeller();
            if (_items.ContainsKey(nameItem))
            {
                try
                {
                    throw new CustomExeption("Такой товар уже существует");
                }
                catch (CustomExeption custEx)
                {
                    Console.WriteLine(custEx.Message);
                    return;
                }
            }

            _items.Add(nameItem, priceItem);
        }

        public void Sell(string nameItem, decimal priceItem)
        {
            CheckSeller();
            if (_items.ContainsKey(nameItem))
            {
                decimal price = 0;
                _items.TryGetValue(nameItem, out price);
                if (price > priceItem)
                {
                    try
                    {
                        throw new CustomExeption("Недостаточно средств");
                    }
                    catch (CustomExeption custEx)
                    {
                        Console.WriteLine(custEx.Message);
                        return;
                    }
                }

            }
            else
            {
                Console.WriteLine("Такого товара нет");
            }

            _items.Remove(nameItem);
        }

        public void Close()
        {
            if (_items.Count > 0)
            {
                try
                {
                    throw new CustomExeption("В магазине ещё есть товары, поэтому он не может быть ликвидирован");
                }
                catch (CustomExeption custEx)
                {
                    Console.WriteLine(custEx.Message);
                    return;
                }
            }
            Console.WriteLine("Магазин ликвидирован");
        }

        private void CheckSeller()
        {
            if(_seller == null)
            {
                throw new CustomExeption("Продавец отсутствует");
            }
        }
    }
}

namespace InStock
{
    using INStock.Interfaces;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductStock : IProductStock, IEnumerable<IProduct>
    {

        private List<IProduct> productStock;


        public ProductStock()
        {
            productStock = new List<IProduct>();
        }


        public IProduct this[int index]
        {
            get
            {
                if (index >= 0 && index < productStock.Count)
                {
                    return productStock[index] as IProduct;
                }

                throw new IndexOutOfRangeException("Index was out of range!");
            }

            set
            {
                if (index < 0 && index >= productStock.Count)
                {
                    throw new IndexOutOfRangeException("Index was out of range!");
                }

                productStock.Insert(index, value);
            }
        }

        public int Count => productStock.Count;


        public void Add(IProduct product)
        {
            foreach (IProduct prod in productStock)
            {
                if (prod.CompareTo(product) == 0)
                {
                    throw new ArgumentException("Product already existing!");
                }
            }

            productStock.Add(product);
        }

        public bool Contains(IProduct product)
        {
            foreach (IProduct prod in productStock)
            {
                if (prod.CompareTo(product) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public IProduct Find(int index)
        {
            if (index >= 0 && index < productStock.Count)
            {
                return productStock[index];
            }

            throw new IndexOutOfRangeException("Index was out of range!");
        }

        public IEnumerable<IProduct> FindAllByPrice(double price)
        {
            return productStock.Where(p => decimal.ToDouble(p.Price) == price);
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            return productStock.Where(p => p.Quantity == quantity).ToList();
        }

        public IEnumerable<IProduct> FindAllInRange(double lo, double hi)
            => productStock.Where(p => decimal.ToDouble(p.Price) >= lo && decimal.ToDouble(p.Price) <= hi).OrderByDescending(p => p.Price).ToList();

        public IProduct FindByLabel(string label)
        {
            if (!productStock.Any(p => p.Label == label))
            {
                throw new ArgumentException("No such product in stock!");
            }

            return productStock.First(p => p.Label == label);
        }

        public IProduct FindMostExpensiveProduct()
            => productStock.OrderByDescending(p => p.Price).ToList().FirstOrDefault()!;

        public bool Remove(IProduct product) => productStock.Remove(product);


        public IEnumerator<IProduct> GetEnumerator()
        {
            for (int i = 0; i < productStock.Count; i++)
            {
                yield return productStock[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
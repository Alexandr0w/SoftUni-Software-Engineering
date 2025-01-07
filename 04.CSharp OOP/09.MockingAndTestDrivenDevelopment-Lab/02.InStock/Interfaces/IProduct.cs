namespace INStock.Interfaces
{
    using System;

    public interface IProduct : IComparable<IProduct>
    {
        string Label { get; }

        decimal Price { get; }

        int Quantity { get; }
    }
}
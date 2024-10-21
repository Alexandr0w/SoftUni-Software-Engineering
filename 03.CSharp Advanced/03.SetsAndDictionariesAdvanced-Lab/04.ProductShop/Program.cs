Dictionary<string, Dictionary<string, double>> productShops = new Dictionary<string, Dictionary<string, double>>();

string[] info = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

while (info[0] != "Revision")
{
    string shop = info[0];
    string product = info[1];
    double price = double.Parse(info[2]);

    if (!productShops.ContainsKey(shop))
    {
        productShops.Add(shop, new Dictionary<string, double>());
    }

    if (!productShops[shop].ContainsKey(product))
    {
        productShops[shop].Add(product, 0);
    }

    productShops[shop][product] = price;

    info = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
}

foreach (var shop in productShops.OrderBy(shop => shop.Key))
{
    Console.WriteLine($"{shop.Key}->");

    foreach (var product in shop.Value)
    {
        Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
    }
}
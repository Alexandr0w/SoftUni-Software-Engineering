string input = Console.ReadLine();

Queue<string> customer = new Queue<string>();

while (input != "End")
{
    if (input == "Paid")
    {
        while (customer.Count > 0)
        {
            Console.WriteLine(customer.Dequeue());
        }
    }
    else
    {
        customer.Enqueue(input);
    }

    input = Console.ReadLine();
}

Console.WriteLine(customer.Count + " people remaining.");
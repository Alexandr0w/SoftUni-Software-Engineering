List<int> numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

<<<<<<< HEAD
numbers = numbers.OrderByDescending(number => number)
=======
numbers = numbers.OrderByDescending(number => number) //
>>>>>>> 48d7ae599d31b28b2513dc57f8172fcb65822ad4
    .Take(3)
    .ToList();

Console.WriteLine($"{string.Join(" ", numbers)}");
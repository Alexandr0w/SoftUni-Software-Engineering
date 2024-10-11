List<int> numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

<<<<<<< HEAD
numbers = numbers.OrderByDescending(number => number) //
=======
<<<<<<< HEAD
numbers = numbers.OrderByDescending(number => number)
=======
numbers = numbers.OrderByDescending(number => number) //
>>>>>>> 48d7ae599d31b28b2513dc57f8172fcb65822ad4
>>>>>>> 17fcfae343c7893ee25c3c2474fb76d30280635d
    .Take(3)
    .ToList();

Console.WriteLine($"{string.Join(" ", numbers)}");
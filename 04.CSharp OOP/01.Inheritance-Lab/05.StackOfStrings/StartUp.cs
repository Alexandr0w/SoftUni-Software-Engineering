namespace CustomStack
{
    public class StartUp
    {
        public static void Main()
        {
            StackOfStrings stack = new StackOfStrings();

            stack.AddRange(new string[] { "1", "2", "3", "4", "5", "6" });
            stack.AddRange(new string[] { "1", "2", "3", "4", "5", "6" });
            Stack<string> stackResult = stack.AddRange(new string[] { "1", "2", "3", "4", "5", "6" });

            foreach (var item in stackResult)
            {
                Console.WriteLine(item);
            }
        }
    }
}

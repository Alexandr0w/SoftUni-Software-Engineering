namespace Shapes
{
    public class StartUp
    {
        public static void Main()
        {
            double circleRadius = double.Parse(Console.ReadLine());
            double rectangleHeight = double.Parse(Console.ReadLine());
            double rectangleWidth = double.Parse(Console.ReadLine());

            Circle circle = new Circle(circleRadius);
            Rectangle rectangle = new Rectangle(rectangleWidth, rectangleHeight);

            Console.WriteLine($"Circle Area: {circle.CalculateArea():F2}");
            Console.WriteLine($"Circle Perimeter: {circle.CalculatePerimeter():F2}");
            Console.WriteLine(circle.Draw());
            Console.WriteLine("------------------------");
            Console.WriteLine($"Rectangle Area: {rectangle.CalculateArea():F2}");
            Console.WriteLine($"Rectangle Perimeter: {rectangle.CalculatePerimeter():F2}");
            Console.WriteLine(rectangle.Draw());
        }
    }
}

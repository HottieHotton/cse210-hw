using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapesList = new List<Shape>();

        Square square = new Square("Blue", 5);
        shapesList.Add(square);

        Rectangle rectangle = new Rectangle("Purple", 8, 4);
        shapesList.Add(rectangle);

        Circle circle = new Circle("Black", 7);
        shapesList.Add(circle);

        foreach(Shape i in shapesList){
            string color = i.GetColor();
            double area = i.GetArea();
            Console.WriteLine($"The color of this shape is: {color}!");
            Console.WriteLine($"The area of this shape is: {area}!\n");
        }
    }
}
using System;
using System.Collections.Generic;

public interface IShape
{
    double Area();
    double Perimeter();
}

public interface IDrawable : IShape
{
    string Draw();
}

public class Circle : IShape
{
    public double Radius { get; }
    public Circle(double radius) => Radius = radius;

    public double Area() => Math.PI * Radius * Radius;
    public double Perimeter() => 2 * Math.PI * Radius;
}

public class Rectangle : IShape
{
    public double Width { get; }
    public double Height { get; }
    public Rectangle(double width, double height) { Width = width; Height = height; }

    public double Area() => Width * Height;
    public double Perimeter() => 2 * (Width + Height);
}

public class Triangle : IDrawable
{
    public double A { get; }
    public double B { get; }
    public double C { get; }

    public Triangle(double a, double b, double c) { A = a; B = b; C = c; }

    public double Perimeter() => A + B + C;
    public double Area()
    {
        double p = Perimeter() / 2;
        return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
    }

    public string Draw() => "   /\\\n  /  \\\n /____\\";
}

class Program
{
    static void Main()
    {
        List<IShape> shapes = new() { new Circle(5), new Rectangle(4, 6), new Triangle(3, 4, 5) };

        foreach (IShape shape in shapes)
        {
            Console.WriteLine($"{shape.GetType().Name}: S = {shape.Area():F2}, P = {shape.Perimeter():F2}");

            if (shape is IDrawable drawable)
                Console.WriteLine(drawable.Draw());
        }
    }
}
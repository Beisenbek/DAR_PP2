using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawer
{

    interface IDrawable
    {
        void Draw(string color);
    }
    interface ISquareCalculatable
    {
        double Square();
    }

    class Drawer 
    {
        List<IDrawable> drawables;
        public Drawer(List<IDrawable> drawables)
        {
            this.drawables = drawables;
        }
        public void DrawFigures()
        {
            foreach(IDrawable drawable in drawables)
            {
                drawable.Draw("red");
            }
        }
    }

    class SquareCalculator
    {
        List<ISquareCalculatable> squareCalculatables;
        public SquareCalculator(List<ISquareCalculatable> squareCalculatables)
        {
            this.squareCalculatables = squareCalculatables;
        }
        public void FindSquares()
        {
            foreach (ISquareCalculatable squareCalculatable in squareCalculatables)
            {
                Console.WriteLine(squareCalculatable.Square());
            }
        }
    }

    class Rectangle : IDrawable, ISquareCalculatable
    {
        int a, b;
        public Rectangle(int a, int b)
        {
            this.a = a;
            this.b = b;
        }
        public void Draw(string color)
        {
            Console.WriteLine(color + ": rectangle");
        }

        public double Square()
        {
            return a * b;
        }
    }

    class Circle : IDrawable,ISquareCalculatable
    {
        int r;
        public Circle(int r)
        {
            this.r = r;
        }
        public void Draw(string color)
        {
            Console.WriteLine(color + ": circle");
        }

        public double Square()
        {
            return Math.PI * r * r;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle(3);
            Rectangle rectangle = new Rectangle(3, 5);

            Drawer drawer = new Drawer(new List<IDrawable> { circle, rectangle });
            drawer.DrawFigures();

            SquareCalculator squareCalculator = new SquareCalculator(new List<ISquareCalculatable> { circle, rectangle });
            squareCalculator.FindSquares();
        }
    }
}

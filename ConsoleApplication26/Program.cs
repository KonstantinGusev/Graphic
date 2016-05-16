using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication134
{
    using System.Threading;

    class Program

    { 
        static void Main(string[] args)
        {
            
            var shapes = new List<Shape>();

                shapes.Add(new Star(5, 5, ConsoleColor.White));            
                shapes.Add(new AnyStar(5, 5, ConsoleColor.Cyan, ConsoleColor.Gray));

            while (true)
            {

                Engine.Draw(shapes);
            }
              
        }
    }

    /// <summary>
    /// Класс объединяющий методы в которых картинки для анимации, а также иные методы для работы с ними
    /// </summary>
    static class Engine
    {
        /// <summary>
        /// Метод очищает консоль
        /// </summary>
        public static void Clean()
        {
            Console.Clear();
        }

        /// <summary>
        /// Первая картинка
        /// </summary>
        /// <param name="x">координаты x</param>
        /// <param name="y">координаты y</param>
        /// <param name="color">Цвет</param>
        public static void SetPixel(int x, int y, ConsoleColor color = ConsoleColor.DarkBlue)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(@" 
            ████████████████████████████████████╔═════════════════════╗
            ███████░░░██████████████████████████║░░░░░░░░░░░░░░░░░░░░░║
            ███████░░░░███████████████████▀░░▀██║░░░░░░░░░░░░░░░░░░░░░║
            ███████▄░░░███████████████████░░░░██║░░███████░░░███████░░║
            ████████░░░░█████████████████░░░░▄██║░███░░░██░░███░░░███░║
            ████████▄░░░▀███████████████▀░░░░███║░░███████░░░███████░░║
            █████████░░░░███▀░░░██▀▀████░░░░▄███║░░░░░░░░░░░░░░░░░░░░░║
            █████████▄░░░▀██░░░░█░░░░██▀░░░░████║░░░░░░░░░░░░░░░░░░░░░║
            ██████████░░░░██░░░░█░░░░██░░░░░████║█░░░░░░░░░░░░░░░░░░░█║
            █░░░░██████░░░░█░░░░█░░░░█░░░░░█████║█░░░░░█████████░░░░░█║
            ██░░░░░██░░░░░░░░░░░░░░░░█░░░░██████║██░░█████░░░█████░░██║
            ███░░░░░░░░░░░░░░░░░░░░░░█░░░ ██████║█████░░░░░░░░░░░█████║
            ██████░░░░░░░░▄▄▄▄░░░░░░█░░░░░██████║██████░░░░█░░░░██████║
            ████████░░░░░░░░░░▀▀█▀▀░░░░░░░██████║░███████████████████░║
            █████████░░░░░░░░░░░█▄░░░░░░░███████║░███████████████████░║
            █████████▄░░░░░░░░░░░█░░░░░░████████║░░█████████████████░░║
            ██████████░░░░░░░░░░░▀░░░░░░████████║░░░███████████████░░░║
            ███████████░░░░░░░░░░░░░░░░█████████║░░░░█████████████░░░░║
            ███████████▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄██████████║░░░░░███████████░░░░░║
            ████████████████████████████████████║░░░░░░░░█████░░░░░░░░║
        ");
        }

        /// <summary>
        /// Вторая картинка для анимации
        /// </summary>
        /// <param name="x">координаты х</param>
        /// <param name="y">координаты у</param>
        /// <param name="color">цвет</param>
        public static void SetPixel2(int x, int y, ConsoleColor color = ConsoleColor.DarkBlue)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(@"                    
            ████████████████████████████████████╔═════════════════════╗
            ███████░░░██████████████████████████║░░░░░░░░░░░░░░░░░░░░░║
            ███████░░░░███████████████████▀░░▀██║░░░░░░░░░░░░░░░░░░░░░║
            ███████▄░░░███████████████████░░░░██║██████████░██████████║
            ████████░░░░█████████████████░░░░▄██║░███████████████████░║
            ████████▄░░░▀███████████████▀░░░░███║░░███████░░░███████░░║
            █████████░░░░███▀░░░██▀▀████░░░░▄███║░░░█████░░░░░█████░░░║
            █████████▄░░░▀██░░░░█░░░░██▀░░░░████║░░░░░░░░░░░░░░░░░░░░░║
            ██████████░░░░██░░░░█░░░░██░░░░░████║█░░░░░░░░░░░░░░░░░░░█║
            ███████████░░░░█░░░░█░░░░██░░░░█████║█░░░░░█████████░░░░░█║
            ████████████▀▀▀▀▀▀▀▀█░░░░█░░░░░█████║██░░█████░░░█████░░██║
            ███████████░░░░░░░░░░█░░░█░░░░▄█████║█████░░░░░░░░░░░█████║
            █████████▀░░░░▄▄▄▄░▄█░░░█░░░░░██████║██████░░░░█░░░░██████║
            ████████▀░░░░░░░░▀▀█▀▀▀▀░░░░░░██████║░███████████████████░║
            █████████░░░░░░░░░░░█▄░░░░░░░░██████║░███████████████████░║
            █████████▄░░░░░░░░░░░█░░░░░░░███████║░░█████████████████░░║
            ██████████░░░░░░░░░░░▀░░░░░░▄███████║░░░███████████████░░░║
            ███████████░░░░░░░░░░░░░░░░░████████║░░░░█████████████░░░░║
            ███████████▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄█████████║░░░░░███████████░░░░░║
            ████████████████████████████████████║░░░░░░░░█████░░░░░░░░║

        ");
        }

        /// <summary>
        /// метод очищает консоль а также переносит символы в массив List<> имеет таймер
        /// </summary>
        /// <param name="shapes"></param>
        public static void Draw(List<Shape> shapes)
        {
            Engine.Clean();
            foreach (var shape in shapes)
            {
                shape.Draw();
            }

            Thread.Sleep(100);
        }
    }

    /// <summary>
    /// абстрактный класс передающий x и у
    /// </summary>
    abstract class Shape
    {
        public abstract void Draw();

        public int X { get; set; }

        public int Y { get; set; }

        protected Shape(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    /// <summary>
    /// Класс 
    /// </summary>
    class Star : Shape
    {
        public Star(int x, int y, ConsoleColor color)
            : base(x, y)
        {
            this.Color = color;
        }

        public ConsoleColor Color { get; set; }

        public override void Draw()
        {

                Engine.SetPixel(X , Y, this.Color);
                Engine.SetPixel(X, Y , this.Color);
                Engine.SetPixel(X,  Y, this.Color);

            Thread.Sleep(500);
                Engine.Clean();
        }
    }

    /// <summary>
    /// Класс для второго метода реализации картинок
    /// </summary>
    class AnyStar : Star
    {
        /// <summary>
        /// Метод принимающий 2 цвета 
        /// </summary>
        /// <param name="x">координата х</param>
        /// <param name="y">координата н</param>
        /// <param name="color1">цвет1</param>
        /// <param name="color2">цвет2</param>
        public AnyStar(int x, int y, ConsoleColor color1, ConsoleColor color2)
            : base(x, y, color1)
        {
            this.color1 = color1;
            this.color2 = color2;
        }

        /// <summary>
        /// Реализация абстрактного класса измененный для перемены цвета а также возможно движение объекта
        /// </summary>
        public override void Draw()
        {
            this.Color = (this.i++) % 2 == 0 ? this.color1 : this.color2;
            base.Draw();
            for(int i=0;i<16;i++)
            Engine.SetPixel2(X , Y , this.Color);
            Engine.SetPixel2(X , Y , this.Color);
            Engine.SetPixel2(i + X, Y, this.Color);

            Thread.Sleep(500);
            Engine.Clean();
        }

        private int i = 0;

        private ConsoleColor color1;

        private ConsoleColor color2;
    }
}

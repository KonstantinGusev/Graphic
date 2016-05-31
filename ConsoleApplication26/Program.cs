using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApplication134
{
    using System.Threading;
    /// <summary>
    /// Первый консольный графический движок
    /// </summary>
    class Program

    {
        static void Main(string[] args)
        {

            var shapes = new List<Shape>();

            shapes.Add(new Star(5, 5, ConsoleColor.White));

            shapes.Add(new AnyStar2(5, 5, ConsoleColor.Cyan, ConsoleColor.Gray));


            Console.Clear();

            while (true)
            {

                Engine.Draw(shapes);

            }

        }
    }

    /// <summary>
    /// Класс под картинки
    /// </summary>
    public static class Picture
    {
        /// <summary>
        /// Первая картинка
        /// </summary>
        public static void Picture1()
        {
            Console.WriteLine("*");
        }
        public static void Picture2()
        {
            Console.WriteLine(@"
*********    *********    *********    *********    *
*********    *********    *********    *********    *
*********    *********    *********    *********    *
*********    *********    *********    *********    *
*********
*********
*********    *********    *********    *********    
             *********    *********    *********    *

*********
*********    ******************    ******************
*********    ******************    ******************   
*********    ******************                     *
*********    ************************************   *
*********
*********                                           *
*********    ****************************************
*********    ***************************    *********
             ***************************    *********

*********   
*********    ************************************
*********    ************************************
*********    ************************************
                                                THE END             ");
        }
        public static void Picture3()
        {
            Console.WriteLine("/|\\");

        }
        public static void Picture4()
        {
            Console.WriteLine("/\\");
        }

    }

    /// <summary>
    /// Класс для работы с картинками
    /// </summary>
    static class Engine
    {
        /// <summary>
        /// Очистка консоли
        /// </summary>
        public static void Clean()
        {
            Console.CursorVisible = false; // гасим курсор

        }

        /// <summary>
        /// Метод принимает координаты и ставит по умолчанию цвет консоли
        /// </summary>
        /// <param name="x">х</param>
        /// <param name="y">у</param>
        /// <param name="color">цвет</param>
        public static void SetPixel1(int x, int y, ConsoleColor color = ConsoleColor.DarkBlue)
        {

            if (x > 0 & y > 0)
            {
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = color;

                Picture.Picture1();
            }

            else
            {
                Console.SetCursorPosition(x = 2, y = 2);
                Console.ForegroundColor = color;
                Picture.Picture1();
                return;
            }

            Thread.Sleep(100);
        }


        public static void SetPixel2(int x, int y, ConsoleColor color = ConsoleColor.DarkBlue)
        {

            
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = color;

                Picture.Picture2();
  
            Thread.Sleep(100);
        }
        public static void SetPixel3(int x, int y, ConsoleColor color = ConsoleColor.DarkBlue)
        {
            if (x > 0 & y > 0)
            {
                Console.SetCursorPosition(x, y - 2);
                Console.ForegroundColor = color;
                Picture.Picture3();
                Engine.Clean();
            }
            else
            {
                Console.SetCursorPosition(x = 3, y = 3);
                Console.ForegroundColor = color;
                Picture.Picture3();
                return;
            }
            Thread.Sleep(100);
        }
        public static void SetPixel4(int x, int y, ConsoleColor color = ConsoleColor.DarkBlue)
        {
            if (x > 0 & y > 0)
            {
                Console.SetCursorPosition(x, y - 3);
                Console.ForegroundColor = color;
                Picture.Picture4();
                Engine.Clean();
            }
            else
            {
                Console.SetCursorPosition(x = 4, y = 4);
                Console.ForegroundColor = color;
                Picture.Picture4();
                return;
            }
        }




        /// <summary>
        /// Добавление символов в lis<>
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
    /// Абстрактный класс должен принимать Х и У
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
    /// Первый вариант реализации картинок
    /// </summary>
    class Star : Shape
    {
        public Star(int x, int y, ConsoleColor color)
            : base(x, y)
        {
            this.Color = color;
        }

        public ConsoleColor Color { get; set; }

        /// <summary>
        /// Моя реализация движение объектов на консоли
        /// </summary>
        public override void Draw()
        {
            Engine.SetPixel2(X, Y, this.Color);

            Thread.Sleep(100);
            Engine.Clean();

        }
    }


    /// <summary>
    /// Второй вариант имеет два цвета .
    /// </summary>
    class AnyStar : Star
    {
        /// <summary>
        /// Принимает координаты Х и У имеет два цвета
        /// </summary>
        /// <param name="x">х</param>
        /// <param name="y">у</param>
        /// <param name="color1">цвет1</param>
        /// <param name="color2">цветц</param>
        public AnyStar(int x, int y, ConsoleColor color1, ConsoleColor color2)
            : base(x, y, color1)
        {
            this.color1 = color1;
            this.color2 = color2;
        }

        /// <summary>
        /// Движение на консоли данных объектов
        /// </summary>
        public override void Draw()
        {
            this.Color = (this.i++) % 2 == 0 ? this.color1 : this.color2;
            base.Draw();

            Engine.SetPixel1(X, Y, this.Color);


            Thread.Sleep(100);
            Engine.Clean();
        }

        private int i = 0;

        private ConsoleColor color1;

        private ConsoleColor color2;
    }
    /// <summary>
    /// Второй вариант имеет два цвета .
    /// </summary>
    class AnyStar2 : AnyStar
    {
        ConsoleKeyInfo k;

        /// <summary>
        /// Принимает координаты Х и У имеет два цвета
        /// </summary>
        /// <param name="x">х</param>
        /// <param name="y">у</param>
        /// <param name="color1">цвет1</param>
        /// <param name="color2">цветц</param>
        public AnyStar2(int x, int y, ConsoleColor color1, ConsoleColor color2)
            : base(x, y, color1, color2)

        {
            this.color1 = color1;
            this.color2 = color2;
        }

        /// <summary>
        /// Движение на консоли данных объектов
        /// </summary>
        public override void Draw()
        {

            


                this.Color = (this.i++) % 2 == 0 ? this.color1 : this.color2;

                k = Console.ReadKey(true);


                if (k.Key == ConsoleKey.UpArrow)
                {
                    Y--;
                    Engine.SetPixel4(X + 1, Y + 1, this.Color);
                    Engine.SetPixel3(X + 1, Y - 1, this.Color);

                    Engine.SetPixel1(X + 2, Y - 4, this.Color);

                }

                else if (k.Key == ConsoleKey.DownArrow)
                {

                    Y++;
                    Engine.SetPixel4(X + 1, Y + 1, this.Color);
                    Engine.SetPixel3(X + 1, Y - 1, this.Color);

                    Engine.SetPixel1(X + 2, Y - 4, this.Color);

                }


                else if (k.Key == ConsoleKey.LeftArrow)
                {
                    X--;
                    Engine.SetPixel4(X + 1, Y + 1, this.Color);
                    Engine.SetPixel3(X + 1, Y - 1, this.Color);

                    Engine.SetPixel1(X + 2, Y - 4, this.Color);

                }
                else if (k.Key == ConsoleKey.RightArrow)
                {
                    X++;
                    Engine.SetPixel4(X + 2, Y + 1, this.Color);
                    Engine.SetPixel3(X + 1, Y - 1, this.Color);

                    Engine.SetPixel1(X + 2, Y - 4, this.Color);

                }
                Console.Clear();
            


       

        }

        private int i = 0;

        private ConsoleColor color1;

        private ConsoleColor color2;
    }
}

    

using System;

namespace SnakeGame
{   
    /* Здесь описывается структура "пикселя" в консоли
     
    */

    public readonly struct Pixel
    {

        private const char _pixelChar = '█';
        public Pixel(int x, int y, ConsoleColor color, int pixelSize = 3) //конструктор 
        {
            X = x;
            Y = y;
            Color = color;
            PixelSize = pixelSize;
        }

        public int X { get;}
        public int Y { get;}
        public ConsoleColor Color { get;}
        public int PixelSize { get; }

        
        public void Draw() //метод рисования "пикселя" в консоли
        {
            Console.ForegroundColor = Color;

            for (int x = 0; x < PixelSize; x++)
            {
                for(int y = 0; y < PixelSize; y++) {
                    Console.SetCursorPosition(X * PixelSize + x, Y * PixelSize + y); //Выставляем позицию курсора в консоли по координатам Х и У
                    Console.Write(_pixelChar);
                }
            }

            
        }

        public void Clear() //метод очистки "пикселя" в консоли
        {
            for (int x = 0; x < PixelSize; x++)
            {
                for (int y = 0; y < PixelSize; y++)
                {
                    Console.SetCursorPosition(X * PixelSize + x, Y * PixelSize + y); //Выставляем позицию курсора в консоли по координатам Х и У
                    Console.Write(' ');
                }
            }
        }
    }
}

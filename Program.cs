using System;
using System.Diagnostics;
using static System.Console;


namespace SnakeGame
{
    class Program
    {
        private const int _mapWidth = 30; //ширина игрового поля в клетках
        private const int _mapHeight = 20; //высота игрового поля в клетках

        private const int _screenWidth = _mapWidth * 3; //размер окна консоли относительно размеров игрового поля
        private const int _screenHeight = _mapHeight * 3;

        private const int _frameMs = 200; //

        private const ConsoleColor _borderColor = ConsoleColor.Gray;

        static void Main()
        {
            SetWindowSize(_screenWidth, _screenHeight); //установка размера окна консоли в символах
            SetBufferSize(_screenWidth, _screenHeight); //установка буфера по размеру окна
            CursorVisible = false; // делаем курсор внутри консоли невидимым
            
            DrawBorder(); // отрисовываем борта 

            Direction currentMovement = Direction.Right; // задаем началь

            Snake snake = new Snake(10,5,ConsoleColor.Red,ConsoleColor.Yellow); // создаем экземпляр змеи 

            Stopwatch sw = new Stopwatch(); //создает обьект таймера который после своего создания начинает отсчет в миллисекундах

            while (true)
            {
                sw.Restart(); // Останавливает измерение интервала времени, обнуляет затраченное время и начинает измерение затраченного времени.

                Direction oldMovement = currentMovement;

                while (sw.ElapsedMilliseconds <= _frameMs) //сравниваем затраченное время с установленным лимитом
                {
                    if (currentMovement == oldMovement) // если направление движения не поменялось
                    {
                        currentMovement = ReadMovement(currentMovement);
                    } 
                }
                snake.Move(currentMovement);
                
            }

            ReadKey();
        }

        static Direction ReadMovement(Direction currentDirection)
        {
            if (!KeyAvailable)      //если не нажата ни одна клавиша то направление мы не меняем
                return currentDirection;

            ConsoleKey key = ReadKey(true).Key; // получаем нажатую клавишу на клавиатуре

            currentDirection = key switch 
            {
                ConsoleKey.UpArrow when currentDirection != Direction.Down => Direction.Up,
                ConsoleKey.DownArrow when currentDirection != Direction.Up => Direction.Down,
                ConsoleKey.LeftArrow when currentDirection != Direction.Right => Direction.Left,
                ConsoleKey.RightArrow when currentDirection != Direction.Left => Direction.Right,
                _ => currentDirection
            };

            return currentDirection;
        }

        static void DrawBorder() //метод рисования бортов игрового поля
        {
            for(int i = 0; i < _mapWidth; i++)
            {
                new Pixel(i, 0, _borderColor).Draw();//рисование верхнего борта
                new Pixel(i, _mapHeight - 1, _borderColor).Draw(); // Рисование нижнего борта

            }

            for (int i = 0; i < _mapHeight; i++)
            {
                new Pixel(0, i, _borderColor).Draw();//рисование левого борта
                new Pixel(_mapWidth - 1, i, _borderColor).Draw(); // Рисование правого борта

            }
        }
    }

}
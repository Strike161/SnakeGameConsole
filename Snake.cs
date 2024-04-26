using System;

namespace SnakeGame
{
    public class Snake
    {
        private readonly ConsoleColor _headColor;
        private readonly ConsoleColor _bodyColor;

        public Snake(int initialX,int initialY, ConsoleColor headColor, ConsoleColor bodyColor, int bodyLenght = 3) {
            _headColor = headColor;
            _bodyColor = bodyColor;

            Head = new Pixel(initialX, initialY, _headColor);

            for (int i = bodyLenght; i >= 0; i--)
            {
                Body.Enqueue(new Pixel(Head.X - i - 1, initialY, _bodyColor));
            }

            Draw();
        }  
        public Pixel Head {  get; private set; }

        public Queue<Pixel> Body { get;} = new Queue<Pixel>();

        public void Move(Direction direction)
        {
            Clear(); //вызываем метод очистки пикселей змеи

            Body.Enqueue(new Pixel(Head.X, Head.Y, _bodyColor));//добавляем пиксель в конец очереди на то место где была голова(первый в теле змеи)
            Body.Dequeue();//убираем первый пиксель в очереди(последний в теле змеи)

            Head = direction switch //здесь создаем пиксел головы в зависимости от направления движения
            {
                Direction.Right => new Pixel(Head.X + 1, Head.Y, _headColor),
                Direction.Left => new Pixel(Head.X - 1, Head.Y, _headColor),
                Direction.Up => new Pixel(Head.X, Head.Y - 1, _headColor),
                Direction.Down => new Pixel(Head.X, Head.Y + 1, _headColor),
                _ => Head  // значение по умолчанию              
            };

            Draw();
        }


        public void Draw()
        {
            Head.Draw();

            foreach(Pixel pixel in Body)
            {
                pixel.Draw();
            }
        }

        public void Clear()
        {
            Head.Clear();
            foreach(Pixel pixel in Body)
            {
                pixel.Clear();
            }
        }
    }
}
//Queue - это очередь из типов данных почитать можно - https://metanit.com/sharp/tutorial/4.7.php
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Snake
{
    class GameState
    {
        Worm worm = new Worm('O');
        Food food = new Food('$');
        Wall wall = new Wall('#');
        Timer timer = new Timer(120);

        public GameState()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(40, 40);
            Console.SetBufferSize(40, 40);

            wall.Draw();
            food.Draw();
        }
        public void Start()
        {
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            worm.Clear();
            worm.Move();
            worm.Draw();
            CheckCollision();
        }

        public void ProcessKeyInfo(ConsoleKeyInfo consoleKeyInfo)
        {
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    worm.Dx = 0;
                    worm.Dy = -1;
                    break;
                case ConsoleKey.DownArrow:
                    worm.Dx = 0;
                    worm.Dy = 1;
                    break;
                case ConsoleKey.LeftArrow:
                    worm.Dx = -1;
                    worm.Dy = 0;
                    break;
                case ConsoleKey.RightArrow:
                    worm.Dx = 1;
                    worm.Dy = 0;
                    break;
            }
        }
        private void CheckCollision()
        {
            if (worm.CanEat(food.body[0]))
            {
                worm.Eat(food.body[0]);
                food.GenerateFood();
                food.Draw();
            }
        }
    }
}

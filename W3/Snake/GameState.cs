using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class GameState
    {
        Worm worm = new Worm('O');
        Food food = new Food('$');
        Wall wall = new Wall('#');

        public GameState()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(40, 40);
            Console.SetBufferSize(40, 40);

            wall.Draw();
            food.Draw();
        }

        public void Draw()
        {
            worm.Draw();
        }

        public void ProcessKeyInfo(ConsoleKeyInfo consoleKeyInfo)
        {
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    worm.Move(0, -1);
                    break;
                case ConsoleKey.DownArrow:
                    worm.Move(0, 1);
                    break;
                case ConsoleKey.LeftArrow:
                    worm.Move(-1, 0);
                    break;
                case ConsoleKey.RightArrow:
                    worm.Move(1, 0);
                    break;
            }

            CheckCollision();
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

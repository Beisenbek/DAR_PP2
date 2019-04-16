using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Food:GameObject
    {
        public Food(char sign) : base(sign)
        {
            GenerateFood();
        }

        public void GenerateFood()
        {
            body.Clear();
            Random random = new Random();
            body.Add(new Point { X = random.Next(0, 39), Y = random.Next(0, 39) });
        }
    }
}

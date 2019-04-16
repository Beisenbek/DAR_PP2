using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Worm : GameObject
    {
        public int Dx
        {
            get;
            set;
        }
        public int Dy
        {
            get;
            set;
        }
        public Worm(char sign) : base(sign)
        {
            body.Add(new Point { X = 20, Y = 20 });
            Dx = Dy = 0;
        }

        public void Move()
        {

            for(int i = body.Count - 1; i > 0; --i)
            {
                body[i].X = body[i - 1].X;
                body[i].Y = body[i - 1].Y;
            }

            body[0].X += Dx;
            body[0].Y += Dy;
        }

        public bool CanEat(Point f)
        {
            return f.X == body[0].X && f.Y == body[0].Y;
        }

        public void Eat(Point f)
        {
            body.Add(new Point { X = f.X, Y = f.Y });
        }
    }
}

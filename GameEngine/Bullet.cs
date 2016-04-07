using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    class Bullet
    {
        public int x, y, size, speed;
        public Bullet(int _x, int _y, int _size, int _speed)
        {
            x = _x;
            y = _y;
            size = _size;
            speed = _speed;
        }

        public void move(Bullet b, string direction)
        {
            if (direction == "Left")
            {
                b.x -= ch.speed;
            }

            else
            {
                b.x += ch.speed;
            }

            if (direction == "Up")
            {
                b.y -= b.speed;
             }
            else
            {
                b.y += b.speed;
            }
        }
    }
}


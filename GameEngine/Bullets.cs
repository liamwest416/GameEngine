using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    class Bullets
    {
        public int x, y, size, speed;
        public string direction;

        public Bullets(int _x, int _y, int _size, int _speed, string _direction)
        {
            x = _x;
            y = _y;
            size = _size;
            speed = _speed;
            direction = _direction;
        }

        public void move(Bullets Bs)
        {
            if (Bs.direction == "Left")
            {
               Bs.x -= Bs.speed;
            }

            if (direction == "Right")
            {
               Bs.x += Bs.speed;
            }
        }
    }
}

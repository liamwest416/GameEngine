using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    class Enemy
    {
        public int x, y, size, speed, images;
        public Image[] enemyImages = new Image[1];



        public Enemy(int _x, int _y, int _size, int _speed, Image[] _enemyImages)
        {
            x = _x;
            y = _y;
            size = _size;
            speed = _speed;
            enemyImages = _enemyImages;

        }



        public void move(Enemy En, string direction)
        {
            if (direction == "Left")
            {
                En.x -= En.speed;
            }

            else if (direction == "Right")
            {
                En.x += En.speed;
            }

            else if (direction == "Up")
            {
                En.y -= En.speed;
            }

            else
            {
                En.y += En.speed;
            }
        }
    }
}


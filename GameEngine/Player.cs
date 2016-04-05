using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameEngine
{
    class Player
    {
        public int x, y, size, speed, images;
        public Image[] playerImages = new Image[4];

        public Player(int _x, int _y, int _size, int _speed, Image[] _playerImages)
        {
            x = _x;
            y = _y;
            size = _size;
            speed = _speed;
            playerImages = _playerImages;
        }

        public void move(Player Pl, string direction)
        {
            if (direction == "Left")
            {
                Pl.x -= Pl.speed;
            }

            else
            {
                Pl.x += Pl.speed;
            }

            if (direction == "Up")
            {
                Pl.y -= Pl.speed;
            }

            else
            {
                Pl.y += Pl.speed;
            } 

        }

        public bool collision(Player Pl, Bullet b)
        {

            Rectangle PlRec = new Rectangle(Pl.x, Pl.y, Pl.size, Pl.size);
            Rectangle bRec = new Rectangle(b.x, b.y, b.size, b.size);

            if (PlRec.IntersectsWith(bRec))
            {
                return true;
            }
            else
            {
                return false;
            }


        }
    }
}



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameEngine
{
    public partial class GameScreen : UserControl
    {

        //player1 button control keys 
        Boolean leftArrowDown, downArrowDown, rightArrowDown, upArrowDown, qArrowDown, wArrowDown, spaceArrowDown;
        int direction = 0;
        Image[] playerImage = new Image[] { Properties.Resources.HeroPlayer, Properties.Resources.HeroPlayerLeft };
        Player Pl;

        List<Bullets> bullets = new List<Bullets>();
        Pen bulletsPen = new Pen(Color.DarkGoldenrod);
       

        public GameScreen()
        {
          
            InitializeComponent();

       
            Pl = new Player(100, 100, 60, 5, playerImage);


            gameTimer.Enabled = true;
            gameTimer.Start();
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //player 1 button presses
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Q:
                    qArrowDown = true;
                    break;
                case Keys.W:
                    wArrowDown = true;
                    break;
                default:
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //player 1 button releases
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Q:
                    qArrowDown = false;
                    break;
                case Keys.W:
                    wArrowDown = false;
                    break;
                case Keys.Space:

                default:
                    break;
            }
        }
        private void gameTimer_Tick(object sender, EventArgs e)
        {

            if (leftArrowDown)
            {
                Pl.move(Pl, "Left");
                direction = 1;
            }
            else if (rightArrowDown)
            {
                Pl.move(Pl, "Right");
                direction = 0;
            }
            if (upArrowDown)
            {
                Pl.move(Pl, "Up");
            }
            else if (downArrowDown)
            {
                Pl.move(Pl, "Down");
            }
            else if (spaceArrowDown)
            {
                
               
                if (direction == 0)
                {
                    Bullets Bs = new Bullets(Pl.x, Pl.y, 5, 15, "Right");
                    bullets.Add(Bs);
                   
                }

                else if (direction == 1)
                {
                    Bullets Bs = new Bullets(Pl.x, Pl.y, 5, 15, "Left");
                    bullets.Add(Bs);
                    

                }



            }

            //foreach bullet  b  -  b.move(b);
            foreach (Bullets Bs in bullets)
            {
            
                    Bs.move(Bs);
                

            }
        

            Refresh();
        }
        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(playerImage[direction], Pl.x, Pl.y, Pl.size,Pl.size);

            foreach (Bullets Bs in bullets)
            {
                e.Graphics.DrawRectangle(bulletsPen, Bs.x, Bs.y, Bs.size, Bs.size);
            }
        
        }
    }
}

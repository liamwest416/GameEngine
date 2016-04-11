using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Simple game engine that I created with the majority of the code from other programs. 
/// This game was completed on April 10, 2016.
/// Focuses on player that has movement, and the ability to fire at the programed enemy.
/// The goal of the enemy was to create a bot that could dodge bullets incoming from the player
/// and also fire towards the player.
/// </summary>

namespace GameEngine
{
    public partial class GameScreen : UserControl
    {

        //Global Variables
        Boolean leftArrowDown, downArrowDown, rightArrowDown, upArrowDown, qArrowDown, wArrowDown, spaceArrowDown;
        int direction = 0;
        int counter = 12;
        Image[] playerImage = new Image[] { Properties.Resources.HeroPlayer, Properties.Resources.HeroPlayerLeft };
        Image[] enemyImage = new Image[] { Properties.Resources.rsz_enemysforengine };
        Player Pl;
        Enemy En;
        List<Bullets> bullets = new List<Bullets>();
        Pen bulletsPen = new Pen(Color.DarkGoldenrod);
        SolidBrush bulletsBrush = new SolidBrush(Color.DarkGoldenrod);


        public GameScreen()
        {

            InitializeComponent();

            //Player attributes 
            Pl = new Player(100, 100, 60, 5, playerImage);
            En = new Enemy(550, 450, 60, 4, enemyImage);
            
            //Starting the game timer
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
                case Keys.Space:
                    spaceArrowDown = true;
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
                    spaceArrowDown = false;
                    break;
                default:
                    break;
            }
        }
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            counter--;



            // Movement for player, also changes the direction of the image
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




            // Bullet fire for the player
            if (spaceArrowDown &&  counter < 0)


                if (direction == 0)
                {
                   
                    
                        Bullets Bs = new Bullets(Pl.x, Pl.y, 5, 6, "Right");
                        bullets.Add(Bs);
                        counter = 12;

                }

                else if (direction == 1)
                {
                    
             
                        Bullets Bs = new Bullets(Pl.x, Pl.y, 5, 6, "Left");
                        bullets.Add(Bs);
                        counter = 12;



                }

            //test comment
            //test comment 2


            //foreach bullet  b  -  b.move(b);
            foreach (Bullets Bs in bullets)
            {

                Bs.move(Bs);


            }


            Refresh();
      
        }
        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //Drawing images of monster, player, and bullets
            e.Graphics.DrawImage(playerImage[direction], Pl.x, Pl.y, Pl.size, Pl.size);
            e.Graphics.DrawImage(enemyImage[direction], En.x, En.y, En.size, En.size);

            foreach (Bullets Bs in bullets)
            {
                e.Graphics.DrawRectangle(bulletsPen, Bs.x, Bs.y, Bs.size + 4, Bs.size);
                e.Graphics.FillRectangle(bulletsBrush, Bs.x, Bs.y, Bs.size + 4, Bs.size);
            }
        }
    }
}

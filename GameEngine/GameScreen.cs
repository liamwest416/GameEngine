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
        Boolean leftArrowDown, downArrowDown, rightArrowDown, upArrowDown, qArrowDown, wArrowDown;

        Player Pl = new Player(500, 400, 30, 5, new Image[] { Properties.Resources.HeroPlayer });


        public GameScreen()
        {
            InitializeComponent();
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
                default:
                    break;
            }
        }
        private void gameLoop_Tick(object sender, EventArgs e)
        {
            if (leftArrowDown)
            {
                Pl.move(Pl, "Left");
            }
            else if (rightArrowDown)
            {
                Pl.move(Pl, "Right");
            }
        }
    }
}

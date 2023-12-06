using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lbl_gameover.Visible = false;
        }

        int gravity = 5 ;
        int score = 0;
        int pipeSpeed = 5;

        //Thả phím space
        private void birdKeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = 5;
            }

            if(e.KeyCode == Keys.Enter)
            {
                Restart();
            }
        }
        private void gameEventTick(object sender, EventArgs e)
        {
            bird.Top += gravity;
            pipeTop.Left -= pipeSpeed;
            pipeBot.Left -= pipeSpeed;
            //update score label
            lbl_score.Text = "Score: " + score.ToString();

            //bring the pipe back to the game
            if(pipeTop.Left < -100)
            {
                pipeTop.Left = 800;
                //everytime you pass through 1 pipe, score will update
                score += 1;
            }

            if(pipeBot.Left < -150)
            {
                pipeBot.Left = 900;
                //everytime you pass through 1 pipe, score will update
                score += 1;
            }

            if(bird.Bounds.IntersectsWith(pipeBot.Bounds) ||
                (bird.Bounds.IntersectsWith(pipeTop.Bounds)) ||
                (bird.Bounds.IntersectsWith(ground.Bounds)))
            {
                gameTimer.Stop();
                lbl_gameover.Visible = true;
            }

            //update pipeSpeed
            if(score > 10)
            {
                pipeSpeed = 15;
            }

            if(bird.Top <  -25)
            {
                gameTimer.Stop();
                lbl_gameover.Visible = true;
            }
        }
        //Ấn phím space
        private void birdKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -5;
            }
        }

        private void Restart()
        {
            lbl_gameover.Visible = false;
            lbl_score.Text = "Score: 0";
            bird.Location = new Point(35, 263);
            pipeTop.Left = 1000;
            pipeBot.Left = 1200;

            gravity = 5;
            pipeSpeed = 5;
            score = 0;

            gameTimer.Start();
        }
    }
}

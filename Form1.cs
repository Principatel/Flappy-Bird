using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace flappy_bird_windows
{
    public partial class Form1 : Form
    {
        int pipeSpeed = 8;
        int gravity = 5;
        int score = 0;


        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            FlappyBird.Top += gravity;
            pipebottom.Left -= pipeSpeed;
            pipetop.Left -= pipeSpeed;
            Scoretext.Text = "Score: " + score;

            if(pipebottom.Left < -50)
            {
                pipebottom.Left = 300;
                score++;
            }

            if(pipetop.Left < -80)
            {
                pipetop.Left = 500;
                score++;
            }

            if(FlappyBird.Bounds.IntersectsWith(pipebottom.Bounds) ||
                FlappyBird.Bounds.IntersectsWith(pipetop.Bounds) ||
                FlappyBird.Bounds.IntersectsWith(ground.Bounds)
                )
            {
                endGame();
            }

            //speed increase after some score
            if(score > 5)
            {
                pipeSpeed = 10;
            }
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = -5;
            }
        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 5;
            }
        }

        private void endGame()
        {
            gametimer.Stop();
            Scoretext.Text += "   Game Over!!";
        }

        private void Scoretext_Click(object sender, EventArgs e)
        {

        }
    }
}

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
        int pipeSpeed =0;
        int gravity = 0;
        int score = 0;

       
        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;

            pipeBottom.Left -= pipeSpeed; // Di chuyển 2 cột trên, cột dưới về phía bên trái
            pipeTop.Left -= pipeSpeed;
            scoreText.Text = "Score: " + score; // Tính tổng số điểm

            if (pipeBottom.Left < -50) // Tạo cột trên xuất hiện liên tục 
            {
                pipeBottom.Left = 500;
                score++; //điểm +1 khi qua cột trên
            }
            if (pipeTop.Left < -80) // Tạo cột trên xuất hiện liên tục 
            {
                pipeTop.Left = 650;
                score++; //điểm +1 khi qua cột dưới
            }

            if (score > 5) // Khi được 5 điểm, độ khó tăng dần
            {
                pipeSpeed = 12; 
            }

            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) || flappyBird.Top < -25) // Điều kiện để kết thúc game: khi chạm cột trên, dưới, vùng trời, mặt đất.
            {
                endGame(); //Kết thúc game
            }
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space) // Khi dùng phím SPACE sẽ giúp chim bay lên
            {
                gravity = -10;
            }
        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space) // Khi không nhấn hoặc giữ phím SPACE chim sẽ bay xuống
            {
                gravity = 10;
            }
        }

        private void endGame() // Tạo chức năng kết thúc game
        {
            gameTimer.Stop();
            scoreText.Text += " Game Over!"; // Hiện chữ "Game over!"
        }

        private void cachChoi_Click(object sender, EventArgs e) //Tạo hướng dẫn cách chơi
        {
            MessageBox.Show(@"- Sử dụng phím 'SPACE' để điều khiển chú chim. 
- Tránh các chướng ngại vật và không chạm vùng trời, mặt đất", "Cách chơi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void start_Click(object sender, EventArgs e) // Tạo chức năng bắt đầu chơi
        {
            pipeSpeed = 8;
            gravity = 10;

        }

    }
}

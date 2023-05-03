using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Probis
{
    public partial class Formhowtoplay : Form
    {
        public Formhowtoplay()
        {
            InitializeComponent();
        }
        Bitmap bg;
        
        
        //Bitmap[] ikan;
       
        private void Formhowtoplay_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
           
            g.DrawImage(bg, 0, 0, this.Width, this.Height);
            

        }

        private void Formhowtoplay_Load(object sender, EventArgs e)
        {
            this.Size = new Size(550, 690);
            bg = new Bitmap(Resource1.bguser);
            pictureBoxI1.Image = new Bitmap(Resource1.spriteikan15);
            pictureBoxI2.Image = new Bitmap(Resource1.spriteikan25);
            pictureBoxI3.Image = new Bitmap(Resource1.spriteikan35);
            pictureBoxI4.Image = new Bitmap(Resource1.spriteikan45);
            pictureBoxI5.Image = new Bitmap(Resource1.spriteikan55);


            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit ? ", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
                new Form1().Show();
            }
        }
    }
}

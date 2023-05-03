using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyekPv
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Bitmap bguser;
        public static List<string> listuser = new List<string>();
        private void Form1_Load(object sender, EventArgs e)
        {
            // mengambil gambar dari resource
            bguser = new Bitmap(Resource1.bguser);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            // draw backgound saat login
            g.DrawImage(bguser, 0, 0, this.Width, this.Height);
        }

        private void btnplay_Click(object sender, EventArgs e)
        {
            // untuk ambil nama
            if (txtusername.Text != "")
            {
                String user = txtusername.Text;

                // menambahkan username ke list
                listuser.Add(user);
                
                
                new Form2().Show();
                
            }
            

        }
    }
}

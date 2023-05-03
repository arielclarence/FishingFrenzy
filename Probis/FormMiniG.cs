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
    public partial class FormMiniG : Form
    {
        Random rnd = new Random();
        List<Button> buttons = new List<Button>();
        int x, y;
        int waktu = 0;
        int temptambahanskor;
        

        Bitmap bguser;
        public FormMiniG()
        {
            InitializeComponent();
        }

        private void FormMiniG_Load(object sender, EventArgs e)
        {
            bguser = new Bitmap(Resource1.bguser);
            timer1.Start();
            timer2.Start();
            timer3.Start();
            timer4.Start();
            if (Form2.diff==0)
            {    
            progressBar2.Value = 300;
                progressBar2.Maximum = 300;
                progressBar1.Value = 0;
               temptambahanskor= 10;
            }
            if (Form2.diff == 1)
            {
                progressBar2.Value = 250;
                progressBar2.Maximum = 250;
                progressBar1.Value = 0;
                temptambahanskor = 15;
            }
            if (Form2.diff == 2)
            {
                progressBar2.Value = 200;
                progressBar2.Maximum = 200;
                progressBar1.Value = 0;
                temptambahanskor = 25;
            }
            if (Form2.diff == 3)
            {
                progressBar2.Value = 150;
                progressBar2.Maximum = 150;
                progressBar1.Value = 0;
                temptambahanskor = 40;
            }
            if (Form2.diff == 4)
            {
                progressBar2.Value = 100;
                progressBar2.Maximum = 100;
                progressBar1.Value = 0;
                temptambahanskor = 25;
            }
        }

        private void FormMiniG_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(bguser, 0, 0, this.Width, this.Height);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Button b = new Button();
            x = rnd.Next(0, 6);
            y = 0;
            b.Location = new Point(x * 50, y);

            Form2.posisibuttonReX.Enqueue(x * 50);
            

            b.BackColor = Color.Black;
            b.Click += Btnclick;
            b.Size = new Size(50, 50);


            
            buttons.Add(b);
            panel1.Controls.Add(b);
        }

        private void Btnclick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            int index = 0;

            for (int i = 0; i < buttons.Count; i++)
            {
                if (b == buttons[i])
                {
                    index = i;
                    Form2.indexbuttonRe.Enqueue(i);
                    Form2.waktuRe2.Enqueue(waktu);
                    
                }
            }

            panel1.Controls.Remove(buttons[index]);
            buttons.RemoveAt(index);

            

            if (progressBar1.Value <= 90)
            {
                progressBar1.Value += 10;
                
            }
            else if (progressBar1.Value == 100)
            {


                timer1.Stop();
                timer2.Stop();
                timer3.Stop();
                timer4.Stop();
                //MessageBox.Show("Fish get");
                
                Form2.indexbuttonRe.Enqueue(-1);
                Form2.waktuRe2.Enqueue(-1);
                Form2.posisibuttonReX.Enqueue(-1);
                
                if (Form2.diff==4)
                {
                    Form2.jumumpan += 2;
                }
                Form2.skor += temptambahanskor;
                Form2.jumumpan -= 1;
                Form2.cekjalan = true;
                Form2.ListIkan.RemoveAt(Form2.rem);
                Form2.ListChx.RemoveAt(Form2.rem);
                Form2.ListChy.RemoveAt(Form2.rem);
                Form2.ListSpr.RemoveAt(Form2.rem);
                Form2.ListIdxIkan.RemoveAt(Form2.rem);
                this.Close();
                
                
                
            }
        }

       

        private void timer2_Tick(object sender, EventArgs e)
        {
            btngerak();
        }

        private void btngerak()
        {
            for (int i = 0; i <  buttons.Count; i++)
            {
                Button b = (Button)panel1.Controls[i];
                b.Top += 5;
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            waktu++;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            progressBar2.Value -= 10;
            if (progressBar2.Value == 0)
            {
                Form2.indexbuttonRe.Enqueue(-1);
                Form2.waktuRe2.Enqueue(-1);
                Form2.posisibuttonReX.Enqueue(-1);                
                timer1.Stop();
                timer2.Stop();
                timer3.Stop();
                timer4.Stop();
                //MessageBox.Show("Waktu Habis");
                Form2.jumumpan -= 1;
                Form2.cekjalan = true;
                this.Close();
                
                //new Form1().Show();
            }
        }
    }
}

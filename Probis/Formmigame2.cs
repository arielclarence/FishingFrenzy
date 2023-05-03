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
    public partial class Formmigame2 : Form
    {
        
        List<Button> buttons = new List<Button>();
        int x, y;
        int waktu;
        int index;
        int temptambahanskor;
        

        Bitmap bguser;
        public Formmigame2()
        {
            InitializeComponent();
        }

        private void Formmigame2_Load(object sender, EventArgs e)
        {
            waktu = 0;
            bguser = new Bitmap(Resource1.bguser);
            timer1.Start();
            timer2.Start();
            timer3.Start();
            timer4.Start();
            timer5.Start();
            if (Form5.diff2 == 0)
            {
                progressBar2.Value = 300;
                progressBar2.Maximum = 300;
                progressBar1.Value = 0;
                temptambahanskor = 10;
            }
            if (Form5.diff2 == 1)
            {
                progressBar2.Value = 250;
                progressBar2.Maximum = 250;
                progressBar1.Value = 0;
                temptambahanskor = 15;
            }
            if (Form5.diff2 == 2)
            {
                progressBar2.Value = 200;
                progressBar2.Maximum = 200;
                progressBar1.Value = 0;
                temptambahanskor = 25;
            }
            if (Form5.diff2 == 3)
            {
                progressBar2.Value = 150;
                progressBar2.Maximum = 150;
                progressBar1.Value = 0;
                temptambahanskor = 40;
            }
            if (Form5.diff2 == 4)
            {
                progressBar2.Value = 100;
                progressBar2.Maximum = 100;
                progressBar1.Value = 0;
                temptambahanskor = 25;
            }
        }

        private void Formmigame2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(bguser, 0, 0, this.Width, this.Height);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Button b = new Button();
            if (Form5.posisibuttonReX.Peek()!=-1|| Form5.posisibuttonReX.Count>0)
            {    
                y = 0;
                b.Location = new Point(Form5.posisibuttonReX.Dequeue(), y);
                b.BackColor = Color.Black;
                b.Size = new Size(50, 50);
                buttons.Add(b);
                panel1.Controls.Add(b);
            }
           
        }

        



        private void timer2_Tick(object sender, EventArgs e)
        {
            btngerak();
        }

        private void btngerak()
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                Button b = (Button)panel1.Controls[i];
                b.Top += 5;
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            
           if (Form5.waktuRe2.Peek() == waktu && Form5.waktuRe2.Count>0)
            {
                Form5.waktuRe2.Dequeue();
                index = Form5.indexbuttonRe.Dequeue();
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
                    timer5.Stop();
                    //MessageBox.Show("Fish get");
                    Form5.posisibuttonReX.Dequeue();
                    Form5.waktuRe2.Dequeue();
                    Form5.indexbuttonRe.Dequeue();


                    if (Form5.diff2 == 4)
                    {
                        Form5.jumumpan += 2;
                    }
                    Form5.skor += temptambahanskor;
                    Form5.jumumpan -= 1;
                    Form5.cekjalan2 = true;
                    Form5.ListIkan.RemoveAt(Form5.rem2);
                    Form5.ListChx.RemoveAt(Form5.rem2);
                    Form5.ListChy.RemoveAt(Form5.rem2);
                    Form5.ListSpr.RemoveAt(Form5.rem2);
                    Form5.ListIdxIkan.RemoveAt(Form5.rem2);
                    this.Close();



                }
            }
            



           
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            waktu++;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            progressBar2.Value -= 10;
            if (progressBar2.Value == 0)
            {
                timer1.Stop();
                timer2.Stop();
                timer3.Stop();
                timer4.Stop();
                timer5.Stop();
                //MessageBox.Show("Waktu Habis");
                Form5.posisibuttonReX.Dequeue();
                Form5.waktuRe2.Dequeue();
                Form5.indexbuttonRe.Dequeue();
                
                Form5.jumumpan -= 1;
                Form5.cekjalan2 = true;
                this.Close();
                
                
            }
        }       
    }
}

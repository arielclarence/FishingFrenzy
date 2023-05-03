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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        Bitmap bg;
        Random random;
        int xikan1, yikan1;
        int xikan2, yikan2;
        int xikan3, yikan3;
        int xikan4, yikan4;
        int xikan5, yikan5;

        Bitmap[] pancing;
        Bitmap[] ikan1;
        Bitmap[] ikan2;
        Bitmap[] ikan3;
        Bitmap[] ikan4;
        Bitmap[] ikan5;
        int idx;
        int ctr;
        int ctr1;

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.DrawImage(bg, 0, 0, this.Width, this.Height);
            g.DrawImage(pancing[3], 320, -30, 200, 200);
            g.DrawImage(ikan1[idx], xikan1, yikan1, 30, 30);
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ctr == 0)
            {
                ikan1[0] = new Bitmap(Resource1.spriteikan12);
                ikan1[1] = new Bitmap(Resource1.spriteikan11);
                ikan1[2] = new Bitmap(Resource1.spriteikan13);
                ikan1[3] = new Bitmap(Resource1.spriteikan12);
                ikan1[4] = new Bitmap(Resource1.spriteikan15);
                ikan1[5] = new Bitmap(Resource1.spriteikan16);
                ikan1[6] = new Bitmap(Resource1.spriteikan14);
                ikan1[7] = new Bitmap(Resource1.spriteikan15);

                ikan2[0] = new Bitmap(Resource1.spriteikan22);
                ikan2[1] = new Bitmap(Resource1.spriteikan21);
                ikan2[2] = new Bitmap(Resource1.spriteikan23);
                ikan2[3] = new Bitmap(Resource1.spriteikan22);
                ikan2[4] = new Bitmap(Resource1.spriteikan25);
                ikan2[5] = new Bitmap(Resource1.spriteikan26);
                ikan2[6] = new Bitmap(Resource1.spriteikan24);
                ikan2[7] = new Bitmap(Resource1.spriteikan25);

                ikan3[0] = new Bitmap(Resource1.spriteikan32);
                ikan3[1] = new Bitmap(Resource1.spriteikan31);
                ikan3[2] = new Bitmap(Resource1.spriteikan33);
                ikan3[3] = new Bitmap(Resource1.spriteikan32);
                ikan3[4] = new Bitmap(Resource1.spriteikan35);
                ikan3[5] = new Bitmap(Resource1.spriteikan36);
                ikan3[6] = new Bitmap(Resource1.spriteikan34);
                ikan3[7] = new Bitmap(Resource1.spriteikan35);

                ikan4[0] = new Bitmap(Resource1.spriteikan42);
                ikan4[1] = new Bitmap(Resource1.spriteikan41);
                ikan4[2] = new Bitmap(Resource1.spriteikan43);
                ikan4[3] = new Bitmap(Resource1.spriteikan42);
                ikan4[4] = new Bitmap(Resource1.spriteikan45);
                ikan4[5] = new Bitmap(Resource1.spriteikan46);
                ikan4[6] = new Bitmap(Resource1.spriteikan44);
                ikan4[7] = new Bitmap(Resource1.spriteikan45);

                ikan5[0] = new Bitmap(Resource1.spriteikan52);
                ikan5[1] = new Bitmap(Resource1.spriteikan51);
                ikan5[2] = new Bitmap(Resource1.spriteikan53);
                ikan5[3] = new Bitmap(Resource1.spriteikan52);
                ikan5[4] = new Bitmap(Resource1.spriteikan55);
                ikan5[5] = new Bitmap(Resource1.spriteikan56);
                ikan5[6] = new Bitmap(Resource1.spriteikan54);
                ikan5[7] = new Bitmap(Resource1.spriteikan55);
                idx++;

                if (idx == 3)
                {
                    idx = 0;
                    ctr = 0;
                }
                else if (idx==7)

                {
                    idx = 4;
                }
                if (ctr1 == 0)
                {
                    xikan1 -= 4;
                    xikan2 -= 4;
                    xikan3 -= 4;
                    xikan4 -= 4;
                    xikan5 -= 4;

                }
                
                if(xikan1 ==0)
                {
                    
                    ctr1 = 1;
                    idx = 4;
                    idx++;
                }
                if (xikan1 == 720)
                {

                    ctr1 = 0;
                    idx = 0;
                    idx++;
                }
                if (ctr1 == 1)
                {
                    xikan1 += 4;
                    xikan2 += 4;
                    xikan3 += 4;
                    xikan4 += 4;
                    xikan5 += 4;
                }

            }
            this.Invalidate();

            

        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.DrawImage(bg, 0, 0, this.Width, this.Height);
            g.DrawImage(pancing[3], 320, -30, 200, 200);           
            g.DrawImage(ikan1[idx], xikan1, yikan1, 30, 30);
            g.DrawImage(ikan2[idx], xikan2, yikan2, 30, 30);
            g.DrawImage(ikan3[idx], xikan3, yikan3, 30, 30);
            g.DrawImage(ikan4[idx], xikan4, yikan4, 30, 30);
            g.DrawImage(ikan5[idx], xikan5, yikan5, 30, 30);

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            random = new Random();
            idx = 0;
            ctr = 0;
            ctr1 = 0;
            xikan1 = 180;
            yikan1 = random.Next(200,500);
            xikan2 = 180;
            yikan2 = random.Next(200, 500);
            xikan3 = 180;
            yikan3 = random.Next(200, 500);
            xikan4 = 180;
            yikan4 = random.Next(200, 500);
            xikan5 = 180;
            yikan5 = random.Next(200, 500);

            bg = new Bitmap(Resource1.bgbaru);
           
            pancing = new Bitmap[8];
            pancing[0] = new Bitmap(Resource1.pan1);
            pancing[1] = new Bitmap(Resource1.pan2);
            pancing[2] = new Bitmap(Resource1.pan3);
            pancing[3] = new Bitmap(Resource1.pan4);
            pancing[4] = new Bitmap(Resource1.pan5);
            pancing[5] = new Bitmap(Resource1.pan6);
            pancing[6] = new Bitmap(Resource1.pan7);
            pancing[7] = new Bitmap(Resource1.pan8);

            ikan1 = new Bitmap[8];
            ikan2 = new Bitmap[8];
            ikan3 = new Bitmap[8];
            ikan4 = new Bitmap[8];
            ikan5 = new Bitmap[8];
            
            ikan1[0] = new Bitmap(Resource1.spriteikan12);
            ikan2[0] = new Bitmap(Resource1.spriteikan25);
            ikan3[0] = new Bitmap(Resource1.spriteikan35);
            ikan4[0] = new Bitmap(Resource1.spriteikan45);
            ikan5[0] = new Bitmap(Resource1.spriteikan55);




            timer1.Start();
            timer1.Interval = 200;


            
            
            
        }
    }
}

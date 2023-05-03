using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Data.SqlClient;

namespace Probis
{
    public partial class Form2 : Form
    {
        string connstring = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =" + Application.StartupPath + "\\DataProyek.mdf; Integrated Security = True; Connect Timeout = 30";
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd;
        public Form2()
        {
            InitializeComponent();
        }
        

        Bitmap bg;
        Random random;
        public static List<Point> ListIkan;
        public static List<int> ListChx;
        public static List<int> ListChy;
        public static List<int> ListSpr;
        public static List<int> ListIdxIkan;
        List<Rectangle> RIkan = new List<Rectangle>();
        Queue<int> posisipancingReX = new Queue<int>();
        Queue<int> posisipancingReY = new Queue<int>();
        Queue<int> waktuRe = new Queue<int>();
        Queue<int> posisiikanReX = new Queue<int>();
        Queue<int> posisiikanReY = new Queue<int>();
        Queue<int> ListChxRe = new Queue<int>();
        Queue<int> ListChyRe = new Queue<int>();
        Queue<int> ListSprRe = new Queue<int>();
        Queue<int> ListIdxIkanRe = new Queue<int>();
        public static Queue<int> posisibuttonReX = new Queue<int>();     
        public static Queue<int> indexbuttonRe = new Queue<int>();
        public static Queue<int> waktuRe2 = new Queue<int>();




        public static int jumumpan;
        public static int skor;


        
        
        int ctrumpan;
        int IXRan;
        int XIkanran, YIkanran;
        int tempidxikan;
        int CekSentuh = -1;
        public static string NamaUser;
        public static bool anjay = false;
        public static bool cekjalan = false;
        public static int diff;
        public static int rem;

        int waktu;
        int posisi1a;
        int posisi1b;
        int posisi2a;
        int posisi2b;
        int posisi3a;
        int posisi3b;
        int posisi4a;
        int posisi4b;
        int cek1 = 0;
        Bitmap[] pancing;
        Bitmap[] umpan;
        Bitmap[] ikan1;
        Bitmap[] ikan2;
        Bitmap[] ikan3;
        Bitmap[] ikan4;
        Bitmap[] ikan5;
        public static List<string> namaBaru = new List<string>();
        public static List<int> skorAwal = new List<int>();
        List<int> idx = new List<int>();
        int idx1;
        
        private void timer3_Tick(object sender, EventArgs e)
        {
            

            timer4.Start();
            timer3.Stop();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (ctr2 == 0)
            {
                cek1 = 0;
                idx1--;
                if (idx1 == 0)
                {
                    
                    
                    
                    
                    timer4.Stop();


                }

            }
            else if (ctr2 == 1)
            {
                cek1 = 0;
                idx1--;
                if (idx1 == 4)
                {
                    
                   
                    
                    timer4.Stop();

                }

            }
            this.Invalidate();
        }

        private void lblExit_click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit ? ", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                
                
                this.Close();
                new Form1().Show();
            }
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            XIkanran = random.Next(0, 2);
            YIkanran = random.Next(250, 550);
            tempidxikan = random.Next(0, 5);
            if (XIkanran == 0)
            {
                IXRan = 20;
                ListSpr.Add(4);
                ListChx.Add(4);
                ListChy.Add(4);
                ListSprRe.Enqueue(4);
                ListChxRe.Enqueue(4);
                ListChyRe.Enqueue(4);



            }
            else if (XIkanran == 1)
            {
                IXRan = 720;
                ListSpr.Add(0);
                ListChx.Add(-4);
                ListChy.Add(-4);
                ListSprRe.Enqueue(0);
                ListChxRe.Enqueue(-4);
                ListChyRe.Enqueue(-4);
            }
            

            ListIkan.Add(new Point(IXRan, YIkanran));
            ListIdxIkan.Add(tempidxikan);
            RIkan.Add(new Rectangle(IXRan, YIkanran, 30, 30));
            posisiikanReX.Enqueue(IXRan);
            posisiikanReY.Enqueue(YIkanran);
            ListIdxIkanRe.Enqueue(tempidxikan);
            
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            
            if (cekjalan==true)
            {
                timer5.Start();
                timer6.Start();
                timer8.Start();
                ctrumpan = 3;
                labelumpan.Text = Convert.ToString(jumumpan);
                labelnilaiskor.Text = Convert.ToString(skor);
                if (jumumpan == 0)
                {
                   XmlWriterSettings xSetting = new XmlWriterSettings();
                    xSetting.Indent = true;

                    XmlWriter xWriter = XmlWriter.Create(Application.StartupPath + "\\datareplay.xml", xSetting);

                    xWriter.WriteStartDocument();

                    xWriter.WriteStartElement("replay");
                    xWriter.WriteStartElement("pancing");
                    while (posisipancingReX.Count > 0)
                    {
                        xWriter.WriteElementString("posisipancingx", posisipancingReX.Dequeue().ToString());
                        xWriter.WriteElementString("posisipancingy", posisipancingReY.Dequeue().ToString());
                        xWriter.WriteElementString("waktu", waktuRe.Dequeue().ToString());
                    }
                    xWriter.WriteEndElement();
                    xWriter.WriteStartElement("ikan");
                    while (posisiikanReX.Count > 0)
                    {
                        xWriter.WriteElementString("posisiikanReX", posisiikanReX.Dequeue().ToString());
                        xWriter.WriteElementString("posisiikanReY", posisiikanReY.Dequeue().ToString());
                        xWriter.WriteElementString("ListChxRe", ListChxRe.Dequeue().ToString());
                        xWriter.WriteElementString("ListChyRe", ListChyRe.Dequeue().ToString());
                        xWriter.WriteElementString("ListSprRe", ListSprRe.Dequeue().ToString());
                        xWriter.WriteElementString("ListIdxIkanRe", ListIdxIkanRe.Dequeue().ToString());

                    }
                    xWriter.WriteEndElement();
                    xWriter.WriteStartElement("button");
                    while (posisibuttonReX.Count > 0)
                    {                        
                        xWriter.WriteElementString("posisibuttonReX", posisibuttonReX.Dequeue().ToString());
                        
                        
                    }
                    xWriter.WriteEndElement();
                    xWriter.WriteStartElement("indexbutton");
                    while (indexbuttonRe.Count > 0)
                    {
                        xWriter.WriteElementString("indexbuttonRe", indexbuttonRe.Dequeue().ToString());
                        xWriter.WriteElementString("waktuRe2", waktuRe2.Dequeue().ToString());
                    }
                    xWriter.WriteEndElement();
                    xWriter.WriteEndElement();
                    xWriter.WriteEndDocument();
                    xWriter.Close();
                    skorAwal.Add(skor);
                    timer7.Stop();
                    MessageBox.Show("Game Over");
                    this.Close();
                    new Form1().Show();
                    //bikinXML();
                    string strskor = Convert.ToString(skor);
                    conn = new SqlConnection(connstring);
                    conn.Open();
                    cmd = new SqlCommand($"Insert into [Table] (nama,skor) values (@NamaUser, @strskor) ", conn);
                    cmd.Parameters.AddWithValue("@NamaUser", NamaUser);
                    cmd.Parameters.AddWithValue("@strskor", strskor);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                cekjalan = false;
            }
        }

        

        private void timer6_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < ListSpr.Count; i++)
            {
                ListSpr[i]++;
                if (ListSpr[i] == 3)
                {
                    ListSpr[i] = 0;


                }
                if (ListSpr[i] == 7)
                {
                    ListSpr[i] = 4;


                }
            }


            for (int i = 0; i < ListIkan.Count; i++)
            {
                if (ListIkan[i].X < 0)
                {
                    ListChx[i] = -ListChx[i];
                    ListSpr[i] = 4;

                }
                else if (ListIkan[i].X > this.Width)
                {
                    ListChx[i] = -ListChx[i];
                    ListSpr[i] = 0;
                }



                int newX = ListIkan[i].X + ListChx[i];
                int newY = ListIkan[i].Y;

                ListIkan[i] = new Point(newX, newY);
            }

            if (CekSentuh < 0)
            {
                for (int i = 0; i < ListIkan.Count; i++)
                {
                    if (RUmpan.IntersectsWith(RIkan[i]))
                    {
                        diff= ListIdxIkan[i];
                        rem = i;
                        CekSentuh = 20;
                        anjay = true;
                        if (anjay == true)
                        {
                            cek1 = 0;
                            
                            new FormMiniG().Show();
                            
                            timer5.Stop();
                            timer6.Stop();
                            timer8.Stop();

                        }
                    }

                }
            }
            else
            {
                CekSentuh--;
                anjay = false;

            }



            this.Invalidate();
        }

        
        int ctr2;
        

        Rectangle RUmpan;
        
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (ctr2 == 0)
            {
                pancing[0] = new Bitmap(Resource1.pan1);
                pancing[1] = new Bitmap(Resource1.pan2);
                pancing[2] = new Bitmap(Resource1.pan3);
                pancing[3] = new Bitmap(Resource1.pan4);
                pancing[4] = new Bitmap(Resource1.pan5);
                pancing[5] = new Bitmap(Resource1.pan6);
                pancing[6] = new Bitmap(Resource1.pan7);
                pancing[7] = new Bitmap(Resource1.pan8);
                idx1++;
                if (idx1 == 3)
                {
                    idx1 = 3;
                    timer2.Stop();
                    cek1 = 1;
                }
            }
            else if (ctr2 == 1)
            {
                idx1++;
                if (idx1 == 7)
                {
                    idx1 = 7;
                    timer2.Stop();
                    cek1 = 1;
                }

            }
            this.Invalidate();
        }

        private void Form2_MouseClick(object sender, MouseEventArgs e)
        {

            timer3.Stop();
            if (e.Y < 168)
            {
                MessageBox.Show("Harus di dalam air");
                posisipancingReX.Enqueue(e.X);
                posisipancingReY.Enqueue(e.Y);
                waktuRe.Enqueue(waktu);
            }
            else
            {
                if (e.X > 378)
                {
                    cek1 = 0;
                    ctr2 = 0;
                    idx1 = 0;

                    posisi1a = 455;
                    posisi1b = 74;
                    posisi2a = e.X;
                    posisi2b = 168;
                    posisi3a = e.X;
                    posisi3b = 168;
                    posisi4a = e.X;
                    posisi4b = e.Y;




                }

                else if (e.X < 378)
                {
                    cek1 = 0;
                    ctr2 = 1;
                    idx1 = 4;

                    posisi1a = 362;
                    posisi1b = 74;
                    posisi2a = e.X;
                    posisi2b = 168;
                    posisi3a = e.X;
                    posisi3b = 168;
                    posisi4a = e.X;
                    posisi4b = e.Y;
                }
                ctrumpan--;
                

                posisipancingReX.Enqueue(e.X);
                posisipancingReY.Enqueue(e.Y);
                waktuRe.Enqueue(waktu);

                

                timer4.Stop();
                timer2.Start();
                timer3.Start();
                this.Invalidate();
                if (ctrumpan == 0)
                {
                    jumumpan--;
                    labelumpan.Text = Convert.ToString(jumumpan);
                    if (jumumpan==0)
                    {
                        
                            XmlWriterSettings xSetting = new XmlWriterSettings();
                            xSetting.Indent = true;

                            XmlWriter xWriter = XmlWriter.Create(Application.StartupPath + "\\datareplay.xml", xSetting);

                            xWriter.WriteStartDocument();

                            xWriter.WriteStartElement("replay");
                            xWriter.WriteStartElement("pancing");
                            while (posisipancingReX.Count > 0)
                            {
                                xWriter.WriteElementString("posisipancingx", posisipancingReX.Dequeue().ToString());
                                xWriter.WriteElementString("posisipancingy", posisipancingReY.Dequeue().ToString());
                                xWriter.WriteElementString("waktu", waktuRe.Dequeue().ToString());
                            }
                            xWriter.WriteEndElement();
                            xWriter.WriteStartElement("ikan");
                            while (posisiikanReX.Count > 0)
                            {
                                xWriter.WriteElementString("posisiikanReX", posisiikanReX.Dequeue().ToString());
                                xWriter.WriteElementString("posisiikanReY", posisiikanReY.Dequeue().ToString());
                                xWriter.WriteElementString("ListChxRe", ListChxRe.Dequeue().ToString());
                                xWriter.WriteElementString("ListChyRe", ListChyRe.Dequeue().ToString());
                                xWriter.WriteElementString("ListSprRe", ListSprRe.Dequeue().ToString());
                                xWriter.WriteElementString("ListIdxIkanRe", ListIdxIkanRe.Dequeue().ToString());

                            }
                            xWriter.WriteEndElement();
                            xWriter.WriteStartElement("button");
                            while (posisibuttonReX.Count > 0)
                            {
                                xWriter.WriteElementString("posisibuttonReX", posisibuttonReX.Dequeue().ToString());
                                

                            }
                            xWriter.WriteEndElement();
                            xWriter.WriteStartElement("indexbutton");
                            while (indexbuttonRe.Count > 0)
                            {
                                xWriter.WriteElementString("indexbuttonRe", indexbuttonRe.Dequeue().ToString());
                                xWriter.WriteElementString("waktuRe2", waktuRe2.Dequeue().ToString());
                            }
                            xWriter.WriteEndElement();
                            xWriter.WriteEndElement();

                            xWriter.WriteEndDocument();

                            xWriter.Close();
                            
                        
                        
                        
                        string strskor = Convert.ToString(skor);
                        skorAwal.Add(skor);
                        MessageBox.Show("Game Over");
                        this.Close();
                        new Form1().Show();
                        //bikinXML();
                        conn = new SqlConnection(connstring);
                        conn.Open();
                        cmd = new SqlCommand($"Insert into [Table] (nama,skor) values (@NamaUser, @strskor) ", conn);
                        cmd.Parameters.AddWithValue("@NamaUser", NamaUser);
                        cmd.Parameters.AddWithValue("@strskor", strskor);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    ctrumpan = 3;
                }
            }


            
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {

        }


        

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            
            g.DrawImage(bg, 0, 0, this.Width, this.Height);
            g.DrawImage(pancing[idx1], 308, 38, 200, 200);
            g.DrawImage(umpan[0], 600, 28, 50, 50);
           
            if (cek1 == 1)
            {
                Pen pen = new Pen(Color.WhiteSmoke);
                g.DrawLine(pen, posisi1a, posisi1b, posisi2a, posisi2b);
                g.DrawLine(pen, posisi3a, posisi3b, posisi4a, posisi4b);
                g.DrawImage(umpan[0], posisi4a-15, posisi4b, 30, 30);
                RUmpan =new Rectangle(posisi4a - 15, posisi4b, 30, 30);
                g.DrawRectangle(Pens.Transparent, RUmpan);
            }
            else
            {
                RUmpan = new Rectangle(-10, -10, 30, 30);
            }
            for (int i = 0; i < ListIkan.Count; i++)
            {
                if (ListIdxIkan[i] == 0)
                {
                    g.DrawImage(ikan1[ListSpr[i]], ListIkan[i].X, ListIkan[i].Y, 30, 30);
                    RIkan[i] = new Rectangle(ListIkan[i].X, ListIkan[i].Y, 30, 30);
                    g.DrawRectangle(Pens.Transparent, RIkan[i]);
                }
                else if (ListIdxIkan[i] == 1)
                {
                    g.DrawImage(ikan2[ListSpr[i]], ListIkan[i].X, ListIkan[i].Y, 30, 30);
                    RIkan[i] = new Rectangle(ListIkan[i].X, ListIkan[i].Y, 30, 30);
                    g.DrawRectangle(Pens.Transparent, RIkan[i]);
                }
                else if (ListIdxIkan[i] == 2)
                {
                    g.DrawImage(ikan3[ListSpr[i]], ListIkan[i].X, ListIkan[i].Y, 30, 30);
                    RIkan[i] = new Rectangle(ListIkan[i].X, ListIkan[i].Y, 30, 30);
                    g.DrawRectangle(Pens.Transparent, RIkan[i]);
                }
                else if (ListIdxIkan[i] == 3)
                {
                    g.DrawImage(ikan4[ListSpr[i]], ListIkan[i].X, ListIkan[i].Y, 30, 30);
                    RIkan[i] = new Rectangle(ListIkan[i].X, ListIkan[i].Y, 30, 30);
                    g.DrawRectangle(Pens.Transparent, RIkan[i]);
                }
                else if (ListIdxIkan[i] == 4)
                {
                    g.DrawImage(ikan5[ListSpr[i]], ListIkan[i].X, ListIkan[i].Y, 30, 30);
                    RIkan[i] = new Rectangle(ListIkan[i].X, ListIkan[i].Y, 30, 30);
                    g.DrawRectangle(Pens.Transparent, RIkan[i]);
                }


            }






        }

        

        private void timer8_Tick(object sender, EventArgs e)
        {
            waktu++;
        }

        private void lblExit_MouseHover(object sender, EventArgs e)
        {
            lblExit.ForeColor = Color.Red;
        }

        private void lblExit_MouseLeave(object sender, EventArgs e)
        {
            lblExit.ForeColor = Color.Black;
        }
        int cekmute = 0;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (cekmute == 0)
            {
                Form1.player.Stop();
                cekmute = 1;
                pictureBox1.Image = new Bitmap(Resource1.mute);
            }
            else
            {
                Form1.player.Play();
                cekmute = 0;
                pictureBox1.Image = new Bitmap(Resource1.speaker_on);
            }
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BorderStyle = BorderStyle.None;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(Resource1.speaker_on);
            skor = 0;
            waktu = 0;
            this.Size = new Size(756, 693);
            random = new Random();
            ListIkan = new List<Point>();
            
            ListChx = new List<int>();
            ListChy = new List<int>();
            ListSpr = new List<int>();
            ListIdxIkan = new List<int>();
            

            
           
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
            umpan = new Bitmap[2];
            umpan[0]= new Bitmap(Resource1.umpan1);
            umpan[1] = new Bitmap(Resource1.umpan2);
            ctrumpan = 3;
            jumumpan = 5;
            label1.BackColor = Color.Transparent;
            labelumpan.Text = Convert.ToString(jumumpan);
            labelumpan.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            labelnilaiskor.BackColor = Color.Transparent;


            ikan1 = new Bitmap[8];
            ikan2 = new Bitmap[8];
            ikan3 = new Bitmap[8];
            ikan4 = new Bitmap[8];
            ikan5 = new Bitmap[8];

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



            
            timer5.Start();
            timer6.Start();
            timer7.Start();
            timer8.Start();


            
            
            
        }
    }
}

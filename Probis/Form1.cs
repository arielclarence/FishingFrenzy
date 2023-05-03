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
using System.Data;
using System.Data.SqlClient;

namespace Probis
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        
        Bitmap bguser;
        public static System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        public static List<string> listuser = new List<string>();
        int cekmute = 0;
        private void Form1_Load(object sender, EventArgs e)
        {

            
            //label5.Image = new Bitmap(Resource1.SpeakerOnv1);
            pictureBox1.Image = new Bitmap(Resource1.speaker_on);

            //System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            //player.SoundLocation = @"D:\Semester 2\Proyek PV\Proyek baru\ProyekPv\ProyekPv\bin\Debug\lagu2.wav";
            player.SoundLocation = Application.StartupPath + "\\lagu2.wav";
            player.Load();
            player.Play();
            // mengambil gambar dari resource
            bguser = new Bitmap(Resource1.bguser);
            //String nodename = "";
            //XmlReader reader = XmlReader.Create(Application.StartupPath + "\\datauser.xml");




            //while (reader.Read())
            //{
            //    if (reader.NodeType == XmlNodeType.Element)
            //    {
            //        nodename = reader.Name;
            //    }
            //    if (reader.NodeType == XmlNodeType.Text)
            //    {
            //        if (nodename == "Name")
            //        {
            //            Form3.nama.Add(reader.Value);
            //            Form2.namaBaru.Add(reader.Value);
            //        }
            //        else if (nodename == "Skor")
            //        {
            //            Form3.skor.Add(Convert.ToInt32(reader.Value));
            //            Form2.skorAwal.Add(Convert.ToInt32(reader.Value));
            //        }
            //    }
            //}
            //reader.Close();
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

                Form2.NamaUser = txtusername.Text;
                Form2.namaBaru.Add(txtusername.Text);
                //namaUser.Add(user);

                new Form2().Show();
                //bikinXML();
                //SqlCommand cmd = new SqlCommand("insert into [Table] (Nama_penerima, Nomor_Telp, Berat, Transportasi, Tgl_Masuk, Keterangan, Alamat) values (@nama, @notelp, @berat, @trans, @tglmasuk, @keterangan, @alamat)", conn);
                
                this.Hide();

            }
            else
            {
                MessageBox.Show("Username Tidak Boleh Kosong");
            }

        }

        private void btnTest_click(object sender, EventArgs e)
        {
            new Form5().Show();
            this.Hide();
        }

        private void btnHigh_click(object sender, EventArgs e)
        {
            new Form3().Show();
            this.Hide();
        }


        List<string> namaUser = new List<string>();
        List<int> skor = new List<int>();

        //private void bikinXML()
        //{
        //    XmlWriterSettings xSetting = new XmlWriterSettings();
        //    xSetting.Indent = true;

        //    XmlWriter xWriter = XmlWriter.Create(Application.StartupPath + "\\datauser.xml", xSetting);

        //    xWriter.WriteStartDocument();
        //    xWriter.WriteStartElement("List");

        //    for (int i = 0; i < namaUser.Count; i++)
        //    {
        //        xWriter.WriteStartElement("User");
        //        xWriter.WriteElementString("Name", namaUser[i]);
        //        //xWriter.WriteElementString("Skor", Convert.ToString(skor[i]));
        //        xWriter.WriteEndElement();
        //    }


        //    xWriter.WriteEndElement();
        //    xWriter.WriteEndDocument();
        //    xWriter.Close();
        //}

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void lblPlay_Click(object sender, EventArgs e)
        {
            // untuk ambil nama
            if (txtusername.Text != "")
            {
                String user = txtusername.Text;

                // menambahkan username ke list
                listuser.Add(user);

                Form2.NamaUser = txtusername.Text;
                Form2.namaBaru.Add(txtusername.Text);
                //namaUser.Add(user);

                new Form2().Show();
                //bikinXML();
                //SqlCommand cmd = new SqlCommand("insert into [Table] (Nama_penerima, Nomor_Telp, Berat, Transportasi, Tgl_Masuk, Keterangan, Alamat) values (@nama, @notelp, @berat, @trans, @tglmasuk, @keterangan, @alamat)", conn);

                this.Hide();

            }
            else
            {
                MessageBox.Show("Username Tidak Boleh Kosong");
            }
        }

        private void lblPlay_MouseHover(object sender, EventArgs e)
        {

            lblPlay.ForeColor = Color.White;
        }

        private void lblPlay_MouseLeave(object sender, EventArgs e)
        {
            lblPlay.ForeColor = Color.Black;
        }

        private void lblhighscore_Click(object sender, EventArgs e)
        {
            new Form3().Show();
            this.Hide();
        }

        private void lblhighscore_MouseHover(object sender, EventArgs e)
        {
            lblhighscore.ForeColor = Color.White;
        }

        private void lblhighscore_MouseLeave(object sender, EventArgs e)
        {
            lblhighscore.ForeColor = Color.Black;
        }

        private void lblreplay_Click(object sender, EventArgs e)
        {
            new Form5().Show();
            this.Hide();
        }

        private void lblreplay_MouseHover(object sender, EventArgs e)
        {
            lblreplay.ForeColor = Color.White;
        }

        private void lblreplay_MouseLeave(object sender, EventArgs e)
        {
            lblreplay.ForeColor = Color.Black;
        }

        

        

        

        

        

        

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (cekmute == 0)
            {
                player.Stop();
                cekmute = 1;
                pictureBox1.Image = new Bitmap(Resource1.mute);
            }
            else
            {
                player.Play();
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

        private void labelhowtoplay_Click(object sender, EventArgs e)
        {
            new Formhowtoplay().Show();
            this.Hide();
        }

        private void labelhowtoplay_MouseHover(object sender, EventArgs e)
        {
            labelhowtoplay.ForeColor = Color.White;
        }

        private void labelhowtoplay_MouseLeave(object sender, EventArgs e)
        {
            labelhowtoplay.ForeColor = Color.Black;
        }
    }
}

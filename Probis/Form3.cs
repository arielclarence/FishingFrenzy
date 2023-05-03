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
using System.Data.SqlClient;

namespace Probis
{
    public partial class Form3 : Form
    {
        int temp;
        string tempN;
        Bitmap bguser;
        string connstring = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =" + Application.StartupPath + "\\DataProyek.mdf; Integrated Security = True; Connect Timeout = 30";
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd;
        public static List<string> nama = new List<string>();
        public static List<int> skor = new List<int>();
        public Form3()
        {
            InitializeComponent();
        }

        private void btnExit_click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit ? ", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
                new Form1().Show();
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

            lbUser.Items.Clear();
            nama.Clear();
            skor.Clear();
            bguser = new Bitmap(Resource1.bguser);
            
            conn = new SqlConnection(connstring);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select Id, nama, skor from  [Table] order by skor desc", conn);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    nama.Add(reader.GetString(1));
                    //skor.Add(reader.GetString(2));
                    skor.Add(Convert.ToInt32(reader[2]));
                    
                }
            }
            conn.Close();
            //ngurutinScore();
            bikinList();




        }

        private void Form3_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(bguser, 0, 0, this.Width, this.Height);
        }

        private void bikinList()
        {
            
            int nomor = 1;
            for (int i = 0; i < 15; i++)
            {
                lbUser.Items.Add(nomor + ". " + nama[i] + " - " + skor[i]);
                nomor++;
            }
        }

        private void lbUser_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //private void ngurutinScore() 
        //{
        //    for (int i = 0; i < skor.Count; i++)
        //    {
        //        for (int j = 0; j < skor.Count; j++)
        //        {
        //            if (skor[i] < skor[j])
        //            {
        //                temp = skor[j];
        //                skor[j] = skor[i];
        //                skor[i] = temp;

        //                tempN = nama[j];
        //                nama[j] = nama[i];
        //                nama[i] = tempN;
        //            }
        //        }
        //    }
        //}
    }
}

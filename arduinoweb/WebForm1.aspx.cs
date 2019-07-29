using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Sockets;
using System.IO;
using System.Text;

namespace arduinoweb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        byte[] readData = new byte[256];
        string ip = "192.168.1.41";
        int port = 8888;

        protected void Page_Load(object sender, EventArgs e)
        {
            //apo
            int gelen = 8;
            string gel = Convert.ToString(gelen, 2);
            Timer1.Enabled = true;
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            TcpClient tcp = new TcpClient(ip, port);
            NetworkStream sn = tcp.GetStream();
            StreamWriter sw = new StreamWriter(sn);
            sw.Write("A");
            sw.Flush();
            int recv = sn.Read(readData, 0, readData.Length);                               //gelen veriyi aldık
            String s = Encoding.ASCII.GetString(readData, 0, recv);
            TextBox1.Text = s;
            tcp.Close();
            oku(s);

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TcpClient tcp = new TcpClient(ip, port);
            NetworkStream ns = tcp.GetStream();

            int recv = ns.Read(readData, 0, readData.Length);                               //gelen veriyi aldık
            String s = Encoding.ASCII.GetString(readData, 0, recv);
            TextBox1.Text = s;
            tcp.Close();
            oku(s);
        }

        public void sugeliyor()
        {
            Image1.ImageUrl = "resimler\\suvar.gif";
            Label1.Text = "Organizeden Su geliyor";
            Label2.Text = "Sorun Yok";

        }
        public void sugelmiyor()
        {
            Image1.ImageUrl = "resimler\\suyok.gif";
            Label1.Text = "Organizeden Su Gelmiyor";
            if (true)// depo seviye kontrol
            {
                Label2.Text = "Sorun Yok";
            }
            else
            {
                Label2.Text = "Arıza Meydana Gelmis";
            }


        }

        public void oku(string gelen)
        {
            /// SD | 2 | DP | 0 |
            string[] geneldurum = gelen.Split('|');
            string sudurum, depodurum;

            for (int i = 0; i < geneldurum.Count(); i++)
            {
                if (geneldurum[i]=="SD")
                {
                    sudurum = geneldurum[i + 1];
                    if (sudurum=="1")
                    {
                        sugeliyor();
                    }
                    else if (sudurum == "2")
                    {
                        sugelmiyor();
                    }
                    i = i + 2;
                }
                else if (geneldurum[i] == "DS")
                {
                    depodurum= geneldurum[i + 1];
                    sugelmiyor();
                }

            }




        }
        public void motorcalis(int motorno)
        {


        }
        public void motordurum(int deger)
        {
            /// gelen değer 
            string donusen = Convert.ToString(deger, 2);
            if (donusen.Substring(0,1)=="1")
            {
                Label4.Text = "Calisiyor";
            }
            else if (donusen.Substring(0, 1) == "0")
            {
                Label4.Text = "Calmiyor";

            }

            if (donusen.Substring(1, 1) == "1")
            {
                Label4.Text = "Calisiyor";
            }
            else if (donusen.Substring(1, 1) == "0")
            {
                Label4.Text = "Calmiyor";

            }
            if (donusen.Substring(2, 1) == "1")
            {
                Label4.Text = "Calisiyor";
            }
            else if (donusen.Substring(2, 1) == "0")
            {
                Label4.Text = "Calmiyor";

            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                Label7.Text = DateTime.Now.ToString();
                TcpClient tcp = new TcpClient(ip, port);
                NetworkStream sn = tcp.GetStream();
                StreamWriter sw = new StreamWriter(sn);
                sw.Write("A");
                sw.Flush();
                int recv = sn.Read(readData, 0, readData.Length);                               //gelen veriyi aldık
                String s = Encoding.ASCII.GetString(readData, 0, recv);
                TextBox1.Text = s;
                tcp.Close();
                oku(s);
            }
            catch (Exception)
            {

                 
            }
           
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Timer1.Enabled = true;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Timer1.Enabled = false;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Timer1.Enabled = false;
           
            TcpClient tcp = new TcpClient(ip, port);
            NetworkStream sn = tcp.GetStream();
            StreamWriter sw = new StreamWriter(sn);
            sw.Write("B");
            sw.Flush();
            int recv = sn.Read(readData, 0, readData.Length);                               //gelen veriyi aldık
            String s = Encoding.ASCII.GetString(readData, 0, recv);
            TextBox1.Text = s;
            tcp.Close();
            Timer1.Enabled = true;
        }
    }
}
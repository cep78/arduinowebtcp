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
        string ip = "192.168.1.131";
        int port = 8888;

        protected void Page_Load(object sender, EventArgs e)
        {
            int gelen = 8;
            string gel = Convert.ToString(gelen, 2);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
          
            TcpClient tcp = new TcpClient(ip,port);
            NetworkStream sn = tcp.GetStream();
            StreamWriter sw = new StreamWriter(sn);
            sw.Write("A");
            sw.Flush();
            int recv = sn.Read(readData, 0, readData.Length);                               //gelen veriyi aldık
            String s = Encoding.ASCII.GetString(readData, 0, recv);
            TextBox1.Text = s;
            tcp.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TcpClient tcp = new TcpClient(ip, port);
            NetworkStream ns = tcp.GetStream();
         
            int recv = ns.Read(readData, 0, readData.Length);                               //gelen veriyi aldık
            String s = Encoding.ASCII.GetString(readData, 0, recv);
            TextBox1.Text = s;
            tcp.Close();
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
            Label7.Text = DateTime.Now.ToString();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Timer1.Enabled = true;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Timer1.Enabled = false;
        }
    }
}
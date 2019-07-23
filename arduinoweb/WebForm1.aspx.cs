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

        }
        public void sugelmiyor()
        {

        }
        public void motorcalis(int motorno)
        {


        }
    }
}
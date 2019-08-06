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
        int sayac ;
        int samandiraakim ;
        int susayac;
        protected void Page_Load(object sender, EventArgs e)
        {
            //apo
            //int gelen = 8;
            //string gel = Convert.ToString(gelen, 2);
            Timer1.Enabled = true;
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            //TcpClient tcp = new TcpClient(ip, port);
            //NetworkStream sn = tcp.GetStream();
            //StreamWriter sw = new StreamWriter(sn);
            //sw.Write("A");
            //sw.Flush();
            //int recv = sn.Read(readData, 0, readData.Length);                               //gelen veriyi aldık
            //String s = Encoding.ASCII.GetString(readData, 0, recv);
            //TextBox1.Text = s;
            //tcp.Close();
            //oku(s);
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
            /// SD | 2 | DP | 0 | SS  | 0 |
            string[] geneldurum = gelen.Split('|');
            string sudurum, depodurum,samandiraakim;

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
                    //sugelmiyor();
                  
                }
                else if (geneldurum[i] == "SS")
                {
                    samandiraakim = geneldurum[i + 1];
                    try
                    {
                        samandiradurumoku(Convert.ToInt32(samandiraakim));
                    }
                    catch (Exception)
                    {

                        
                    }
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
                okumadurum.Text = "Bağlanti Bekleniyor";
                Okumasaati.Text = DateTime.Now.ToString();
                TcpClient tcp = new TcpClient(ip, port);
                NetworkStream sn = tcp.GetStream();
                StreamWriter sw = new StreamWriter(sn);
                sw.Write("A");
                sw.Flush();
                okumadurum.Text = "Bağlanti Sağlandı";
                int recv = sn.Read(readData, 0, readData.Length);                               //gelen veriyi aldık
                String s = Encoding.ASCII.GetString(readData, 0, recv);
                TextBox1.Text = s;
                tcp.Close();
                okumadurum.Text = "Okuma Yapildi";
                oku(s);
            }
            catch (Exception)
            {
                okumadurum.Text = "Bağlantida Hata Oluştu ";


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
           
        }
        public void samandiradurumoku(int deger)
        {
            try
            {
                if (Session["sayac"] != null)
                   sayac = Convert.ToInt32( Session["sayac"].ToString());
                if (Session["samandiraakim"] != null)
                    samandiraakim = Convert.ToInt32(Session["samandiraakim"].ToString());

            }
            catch (Exception)
            {
                 
            }
            if (sayac<6)
            {
                samandiraakim = samandiraakim + deger;
                sayac++;
                Session.Add("sayac",sayac);
                Session.Add("samandiraakim", samandiraakim);
                Label10.Text = sayac.ToString();
            }
            else
            {
                sayac = 0;
                samandiraakim++;
                Session.Add("sayac", sayac);


                if (samandiraakim / 6 < 3)
                {
                    Label8.Text = "Organizeden Su istenmiyor";
                }
                else
                {
                    Label8.Text = "Depoya Su Lazım";
                    if (Session["susayac"] != null)
                        susayac = Convert.ToInt32(Session["susayac"].ToString());
                    if (Label1.Text == "Organizeden Su Gelmiyor" && susayac<10)
                    {
                        susayac++;
                        Session.Add("susayac", susayac);

                    }
                    else if (Label1.Text == "Organizeden Su Gelmiyor" && susayac > 10)
                    {
                        susayac=0;
                        Session.Add("susayac", susayac);
                        mesajat("");

                    }
                }
                samandiraakim = 0;
                Session.Add("samandiraakim", samandiraakim);
            }


        }

        public void mesajat(string link)
        {

        }
    }
}
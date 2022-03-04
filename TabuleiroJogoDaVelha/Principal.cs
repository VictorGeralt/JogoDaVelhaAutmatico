using Microsoft.AspNetCore.Hosting;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Web.Http;
using System.Web.Http.SelfHost;
using System.Windows.Forms;

namespace TabuleiroJogoDaVelha
{
    public partial class Principal : Form
    {
        private Dictionary<string, PictureBox> tabuleiroVisivel = new Dictionary<string, PictureBox>();
        private string baseAddress = "";
        public Principal()
        {
            InitializeComponent();
        }

        private void Mapeartabuleiro()
        {
            tabuleiroVisivel.Clear();
            foreach (var item in this.Controls)
            {
                if ((item is PictureBox) && (item as Control).Name.StartsWith("pb"))
                {
                    tabuleiroVisivel.Add((item as Control).Name, (item as PictureBox));
                }
            }
        }



        private void Principal_Load(object sender, EventArgs e)
        {
            var ip = getLocalIPAddressWithNetworkInterface(NetworkInterfaceType.Wireless80211);
            baseAddress = String.Format("http://{0}:9000/", ip);
            lblURL.Text = "URL do servidor = " + baseAddress;
            Mapeartabuleiro();
            GameManager.ReiniciaTabuleiro();
            ServicoDoServidor.RunWorkerAsync();
            tmrAtualizador.Enabled = true;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            foreach (var item in tabuleiroVisivel)
                item.Value.Visible = false;
            GameManager.ReiniciaTabuleiro();
            tmrAtualizador.Enabled = true;
        }

        private void atualizaTabuleiro()
        {
            for (int l = 0; l < 3; l++)
                for (int c = 0; c < 3; c++)
                {
                    var nome = String.Format("pb{0}{1}", l, c);
                    string valor = GameManager.GetValor(l, c);
                    var celula = tabuleiroVisivel.Where(p => p.Key == nome).FirstOrDefault().Value;
                    celula.Visible = true;
                    if (valor == "X")
                        celula.Image = Properties.Resources.x_png_icon_8;
                    else if (valor == "O")
                        celula.Image = Properties.Resources.number_zero_png_5;
                    else
                        celula.Visible = false;
                }



            pictureBoxVezDoJogador.Image = GameManager.jogadorAtual == "X" ? Properties.Resources.x_png_icon_8 : Properties.Resources.number_zero_png_5;


            var vencedor = GameManager.VerificaVencedor();
            if (vencedor.Trim().Length > 0)
            {
                tmrAtualizador.Enabled = false;
                MessageBox.Show("Parabens!\n" + vencedor);
                
            }
        }

        private void IniciarServidorWeb()
        {
            try
            {
                // Inicia o host OWIN 
                //WebApp.Start<Startup>("http://localhost:9000/");
                WebApp.Start<Startup>(baseAddress);
                /*var config = new HttpSelfHostConfiguration(baseAddress);
                config.Routes.MapHttpRoute(
                    "API Default", "api/{controller}/{id}",
                    new { id = RouteParameter.Optional });
                using (HttpSelfHostServer server = new HttpSelfHostServer(config))
                {
                    server.OpenAsync().Wait();
                    Console.WriteLine("Press Enter to quit.");
                    Console.ReadLine();
                }*/

            }
            catch (Exception ex)
            {

                MessageBox.Show("Falha ao iniciar o servidor: " + ex.Message);
            }
        }

        
        private void ServicoDoServidor_DoWork(object sender, DoWorkEventArgs e)
        {
            IniciarServidorWeb();
        }

        public static string  getLocalIPAddressWithNetworkInterface(NetworkInterfaceType _type)
        {
            string output = "";
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            output = ip.Address.ToString();
                        }
                    }
                }
            }
            return output;
        }

        private void tmrAtualizador_Tick(object sender, EventArgs e)
        {
            if (GameManager.Atualizar >= DateTime.Now)
            {
                atualizaTabuleiro();
                this.Refresh();
            }
        }
    }
}

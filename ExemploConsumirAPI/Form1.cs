using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExemploConsumirAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnJogar_Click(object sender, EventArgs e)
        {
            try
            {
                string baseAddress = txtURL.Text;
                
                HttpClient client = new HttpClient();
                var response = client.GetAsync(baseAddress + "api/jogo?marcador=" + cmbMarcador.Text + "&linha=" + Convert.ToInt32(nudLinha.Value)  + "&coluna=" + Convert.ToInt32(nudColuna.Value)).Result;
                txtRetorno.Text = response.Content.ReadAsStringAsync().Result.ToString();


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

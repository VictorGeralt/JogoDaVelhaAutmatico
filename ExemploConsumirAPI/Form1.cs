using System;
using System.Net.Http;
using System.Text.Json;
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
                //URL Base de acesso a API http://localhost:9000/
                string baseAddress = txtURL.Text;

                //Instancia um objeto de requisição HTTP
                HttpClient client = new HttpClient();

                //Realiza uma requisição GET a API  http://localhost:9000/api/jogo?marcador=X&linha=0&coluna=0
                var response = client.GetAsync(baseAddress + "api/jogo?marcador=" + cmbMarcador.Text 
                    + "&linha=" + Convert.ToInt32(nudLinha.Value)  
                    + "&coluna=" + Convert.ToInt32(nudColuna.Value)).Result;

                //Pega o resultado da requisição
                var resultado = response.Content.ReadAsStringAsync().Result.ToString();

                //Exibe o retorno em uma caixa de texto
                txtRetorno.Text = resultado;

                //Converte o JSON em uma matris String
                string[][] tabuleiro = JsonSerializer.Deserialize<string[][]>(resultado);


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTabuleiro_Click(object sender, EventArgs e)
        {
            try
            {
                //URL Base de acesso a API http://localhost:9000/
                string baseAddress = txtURL.Text;

                //Instancia um objeto de requisição HTTP
                HttpClient client = new HttpClient();

                //Realiza uma requisição GET a API  http://localhost:9000/api/jogo
                var response = client.GetAsync(baseAddress + "api/jogo").Result;

                //Pega o resultado da requisição
                var resultado = response.Content.ReadAsStringAsync().Result.ToString();

                //Exibe o retorno em uma caixa de texto
                txtRetorno.Text = resultado;

                //Converte o JSON em uma matris String
                string[][] tabuleiro = JsonSerializer.Deserialize<string[][]>(resultado);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

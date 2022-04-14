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

                //Realiza uma requisição GET a API  http://localhost:9000/api/jogo
                var leitura = client.GetAsync(baseAddress + "api/jogo").Result;

                //Pega o resultado da requisição
                var resultado = leitura.Content.ReadAsStringAsync().Result.ToString();

                //Converte o JSON em uma matris String
                string[][] tabuleiro = JsonSerializer.Deserialize<string[][]>(resultado);

                int cord1=5, cord2=5;


                string antiMarcador;


                if(cmbMarcador.Text == "X")
                {
                    antiMarcador = "O";
                }
                else { antiMarcador = "X"; }

                int derrota = 0, vitoria = 0,cordV1=5,cordV2=5;


                //jogo como X
                if (cmbMarcador.Text == "X" && tabuleiro[0][0] == "")
                {
                    cord1 = 0;
                    cord2 = 0;
                }else if (cmbMarcador.Text == "X" && tabuleiro[2][2] == "")
                {
                    cord1 = 2;
                    cord2 = 2;
                }
                else if (cmbMarcador.Text == "X" && tabuleiro[2][2] == "O" && tabuleiro[0][2] == "")
                {
                    cord1 = 0;
                    cord2 = 2;
                }
                else if (cmbMarcador.Text == "X" && (tabuleiro[2][2] == "O" && tabuleiro[0][2] == "X"))
                {
                    cord1 = 2;
                    cord2 = 0;
                }

                //jogo como O

                if (cmbMarcador.Text == "O" && (tabuleiro[0][0] == "X" || tabuleiro[0][2] == "X"))
                {
                    cord1 = 0;
                    cord2 = 1;
                }else if(cmbMarcador.Text == "O" && (tabuleiro[1][1]=="X"))
                {
                    cord1 = 1;
                    cord2 = 0;
                }else if (cmbMarcador.Text == "O" && (tabuleiro[1][0] == "O")) {
                    cord1 = 2;
                    cord2 = 2;
                }

                if (cmbMarcador.Text == "O" && (tabuleiro[2][0] == "X" || tabuleiro[2][2] == "X"))
                {
                    cord1 = 2;
                    cord2 = 1;
                }
                else if (cmbMarcador.Text == "O" && (tabuleiro[1][1] == "X"))
                {
                    cord1 = 1;
                    cord2 = 0;
                }
                else if (cmbMarcador.Text == "O" && (tabuleiro[1][0] == "O"))
                {
                    cord1 = 2;
                    cord2 = 2;
                }



                //verificação das linhas

                for (int i = 0; i <=2; i++)
                {
                    for (int j = 0; j <=2; j++)
                    {
                        if (tabuleiro[i][j] == cmbMarcador.Text)
                        {
                            vitoria++;
                        }
                        if (tabuleiro[i][j] == antiMarcador)
                        {
                            derrota++;
                        }
                    }
                    if (((vitoria == 2) && (derrota == 1)) || (derrota == 2) && (vitoria == 1))
                    {
                    }
                    else if (derrota == 2)
                    {
                        for (int l = 0; l <=2 ; l++)
                        {
                            if (tabuleiro[i][l] == "")
                            {
                                cord1 = i;
                                cord2 = l;
                            }
                        }
                    }
                    else if (vitoria == 2)
                    {
                        for (int l = 0; l <= 2; l++)
                        {
                            if (tabuleiro[i][l] == "")
                            {
                                cordV1 = i;
                                cordV2 = l;
                            }
                        }
                    }
                    derrota = 0;
                    vitoria = 0;
                }

                //verificação colunas

                for (int j = 0; j <3 ; j++)
                {
                    for (int i = 0; i <3 ; i++)
                    {
                        if (tabuleiro[i][j] == cmbMarcador.Text)
                        {
                            vitoria++;
                        }
                        if (tabuleiro[i][j] == antiMarcador)
                        {
                            derrota++;
                        }
                    }
                    if (((vitoria == 2) && (derrota == 1)) || (derrota == 2) && (vitoria == 1))
                    {
                    }
                    else if (derrota == 2)
                    {
                        for (int l = 0; l <3; l++)
                        {
                            if (tabuleiro[l][j] == "")
                            {
                                cord1 = l;
                                cord2 = j;
                            }
                    }
                    }
                    else if (vitoria == 2)
                    {
                        for (int l = 0; l < 3; l++)
                        {
                            if (tabuleiro[l][j] == "")
                            {
                                cordV1 = l;
                                cordV2 = j;
                            }
                        }
                    }
                    derrota = 0;
                    vitoria = 0;
                }

                //analisando diagonais

                for (int i = 0; i <3 ; i++)
                {
                    if (tabuleiro[i][i] == cmbMarcador.Text)
                    {
                        vitoria++;
                    }
                    if (tabuleiro[i][i] == antiMarcador)
                    {
                        derrota++;
                    }
                }
                if (((vitoria == 2) && (derrota == 1)) || (derrota == 2) && (vitoria == 1))
                {
                }
                else if (derrota == 2)
                {
                    for (int l = 0; l  <3 ; l++)
                    {
                        if (tabuleiro[l][l] == "")
                        {
                            cord1 = l;
                            cord2 = l;
                        }
                    }
                }

                else if (vitoria == 2)
                {
                    for (int l = 0; l < 3; l++)
                    {
                        if (tabuleiro[l][l] == "")
                        {
                            cordV1 = l;
                            cordV2 = l;
                        }
                    }
                }
                derrota = 0;
                vitoria = 0;



                for (int i = 0; i < 3; i++)
                {
                    if (tabuleiro[i][2-i] == cmbMarcador.Text)
                    {
                        vitoria++;
                    }
                    if (tabuleiro[i][2-i] == antiMarcador)
                    {
                        derrota++;
                    }
                }
                if (((vitoria == 2) && (derrota == 1)) || (derrota == 2) && (vitoria == 1))
                {
                }

                else if (derrota == 2)
                {
                    for (int l = 0; l < 3; l++)
                    {
                        if (tabuleiro[l][2 - l] == "")
                        {
                            cord1 = l;
                            cord2 = 2-l;
                        }
                    }
                }
                else if (vitoria == 2)
                {
                    for (int l = 0; l <3; l++)
                    {
                        if (tabuleiro[l][2 - l] == "")
                        {
                            cordV1 = l;
                            cordV2 = 2-l;
                        }
                    }
                }
                derrota = 0;
                vitoria = 0;


                if (cordV1!=5)
                {
                    cord1 = cordV1;
                    cord2 = cordV2;
                }

                if (cord1 == 5 && tabuleiro[0][0]=="" || (tabuleiro[cord1][cord2]=="X" || (tabuleiro[cord1][cord2] == "O" ) && tabuleiro[0][0] == "" )) {
                    cord1 = 0;
                    cord2 = 0;
                }else if (cord1 == 5 && tabuleiro[0][2] == "" || (tabuleiro[cord1][cord2] == "X" || (tabuleiro[cord1][cord2] == "O") && tabuleiro[0][2] == ""))
                {
                    cord1 = 0;
                    cord2 = 2;
                }
                else if (cord1 == 5 && tabuleiro[2][0] == "" || (tabuleiro[cord1][cord2] == "X" || (tabuleiro[cord1][cord2] == "O") && tabuleiro[2][0] == ""))
                {
                    cord1 = 2;
                    cord2 = 0;
                }
                else if (cord1 == 5 && tabuleiro[2][2] == "" || (tabuleiro[cord1][cord2] == "X" || (tabuleiro[cord1][cord2] == "O") && tabuleiro[2][2] == ""))
                {
                    cord1 = 2;
                    cord2 = 2;
                }
                else if (cord1 == 5 && tabuleiro[0][1] == "" || (tabuleiro[cord1][cord2] == "X" || (tabuleiro[cord1][cord2] == "O") && tabuleiro[0][1] == ""))
                {
                    cord1 = 0;
                    cord2 = 1;
                }
                else if (cord1 == 5 && tabuleiro[1][0] == "" || (tabuleiro[cord1][cord2] == "X" || (tabuleiro[cord1][cord2] == "O") && tabuleiro[1][0] == ""))
                {
                    cord1 = 1;
                    cord2 = 0;
                }
                else if (cord1 == 5 && tabuleiro[1][2] == "" || (tabuleiro[cord1][cord2] == "X" || (tabuleiro[cord1][cord2] == "O") && tabuleiro[1][2] == ""))
                {
                    cord1 = 1;
                    cord2 = 2;
                }
                else if (cord1 == 5 && tabuleiro[2][1] == "" || (tabuleiro[cord1][cord2] == "X" || (tabuleiro[cord1][cord2] == "O") && tabuleiro[2][1] == ""))
                {
                    cord1 = 2;
                    cord2 = 1;
                }



                //Realiza uma requisição GET a API  http://localhost:9000/api/jogo?marcador=X&linha=0&coluna=0
                var jogada = client.GetAsync(baseAddress + "api/jogo?marcador=" + cmbMarcador.Text 
                    + "&linha=" + Convert.ToInt32(cord1)  
                    + "&coluna=" + Convert.ToInt32(cord2)).Result;

               


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTabuleiro_Click(object sender, EventArgs e)
        {
        }

        private void cmbMarcador_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

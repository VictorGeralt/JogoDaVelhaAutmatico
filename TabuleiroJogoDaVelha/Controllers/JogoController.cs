using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace TabuleiroJogoDaVelha.Controllers
{
    
    public class JogoController : ApiController
    {
        [HttpGet]
        [ActionName("Get")]
        //Exemplo de consumo http://localhost:9000/api/jogo?marcador=O&linha=0&coluna=0
        public object Get(string marcador, int linha, int coluna)
        {
            try
            {
                return GameManager.RealizarJogada(marcador, linha, coluna);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpGet]
        [ActionName("Get")]
        public object Get()
        {
            try
            {
                return GameManager.GetTabuleiro();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}

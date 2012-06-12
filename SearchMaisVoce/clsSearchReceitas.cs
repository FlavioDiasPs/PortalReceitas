using System;
using System.Collections.Generic;
using System.Text;

namespace SearchReceitas
{
    public class clsSearchReceitas
    {
        private const int qntItensPagSadia = 24;
        private const string espaco = "%20";
        private string urlParte1, urlParte2, urlParte3, urlCompleta;
        private string textoInteiro;
        private string chave;
        private PortalControls.clsStatusStrip menuStatus;


        public clsSearchReceitas(PortalControls.clsStatusStrip status)
        {
            //progresbar de status
            menuStatus = status;

            urlParte1 = "http://www.receitas.com/";
            urlParte2 = "busca/";
            urlParte3 = "/";
        }

        //destructor
        ~clsSearchReceitas()
        {
            System.GC.Collect();
        }

        public List<PortalControls.clsReceita> search(string textoBusca, PortalControls.clsTabPageConfiguracao clsConfiguracao)
        {
            //cria um objeto receita/lista
            List<PortalControls.clsReceita> listReceita = new List<PortalControls.clsReceita>();
            PortalControls.clsReceita receita;

            //Arruma a url inicial faltando a pagina
            urlCompleta = urlParte1 + urlParte2 + textoBusca.Replace(" ", espaco) + urlParte3;

            //variaveis para numero de receitas
            int qntResultados = 0;
            int cont = 1;

            //recolhe o codigo fonte da primeira pagina
            textoInteiro = new Essencials.clsEssencials().pegarCodigoFonte(urlCompleta + "1");
            qntResultados = searchQntResultados();
            if (qntResultados == 0) return null;
            if (qntResultados > clsConfiguracao.qntMaxResultadosSite) qntResultados = clsConfiguracao.qntMaxResultadosSite;

            //define o valor maximo para o progressbar / coloca quantidade de receitas encontradas nos status
            menuStatus.addMaxProgressBar(qntResultados);

            //Iniciar a procura pelas receitas
            for (int i = 0; i < qntResultados; i++)
            {
                //cria um novo objeto receita
                receita = new PortalControls.clsReceita();

                //atribui valores ao objeto
                receita.Titulo = searchTitulo();
                receita.Url = searchUrlImagem();
                receita.Link = searchLink();                                
                receita.Descricao = searchDescricao();

                //adiciona a lista
                listReceita.Add(receita);

                //a cada 10 items, procura o codigo fonte da proxima pagina
                if ((i + 1) % qntItensPagSadia == 0)
                {
                    //pega o codigo fonte
                    cont++;
                    textoInteiro = new Essencials.clsEssencials().pegarCodigoFonte(urlCompleta + cont.ToString());
                }

                menuStatus.addValueProgressBar(1);
            }


            return listReceita;
        }

        private int searchQntResultados()
        {
            chave = "numero-receitas-encontradas";
            if (textoInteiro.Contains(chave) == false) return 0;
            textoInteiro = textoInteiro.Remove(0, textoInteiro.IndexOf(chave) + chave.Length);

            chave = "Exibindo ";
            textoInteiro = textoInteiro.Remove(0, textoInteiro.IndexOf(chave) + chave.Length);

            string a = textoInteiro.Substring(0, textoInteiro.IndexOf(" ")).Replace(".", "");
            textoInteiro = textoInteiro.Remove(0, a.Length);

            if (textoInteiro.Substring(0, 2) == " a")
            {
                chave = "de ";
                textoInteiro = textoInteiro.Remove(0, textoInteiro.IndexOf(chave) + chave.Length);
                a = textoInteiro.Substring(0, textoInteiro.IndexOf(" ")).Replace(".", "");
            }

            return Convert.ToInt32(a);
        }

        private string searchTitulo()
        {
            textoInteiro = textoInteiro.Remove(0, textoInteiro.IndexOf("modulo-receita"));

            chave = "title=\"";
            if (textoInteiro.Contains(chave) == false) { return null; }
            textoInteiro = textoInteiro.Remove(0, textoInteiro.IndexOf(chave) + chave.Length);

            return textoInteiro.Substring(0, textoInteiro.IndexOf("\""));
        }

        private string searchDescricao()
        {
            chave = "description";
            if (textoInteiro.Contains(chave) == false || textoInteiro.IndexOf("src") < textoInteiro.IndexOf(chave)) 
            { return null;   }
            textoInteiro = textoInteiro.Remove(0, textoInteiro.IndexOf(chave) + (chave.Length + 2));

            string aux = textoInteiro.Substring(0, textoInteiro.IndexOf("<"));
            aux = aux.Replace("<p>", "").Replace("</p>", "");
            aux = aux.Replace("\t", "").Replace("\n", "");
            aux = aux.Replace("<strong>", "").Replace("</strong>", "");
            return aux;
        }

        private string searchUrlImagem()
        {
            chave = "src=\"";
            if (textoInteiro.Contains(chave) == false) { return null; }
            textoInteiro = textoInteiro.Remove(0, textoInteiro.IndexOf(chave) + chave.Length);

            return textoInteiro.Substring(0, textoInteiro.IndexOf("\""));
        }

        private string searchLink()
        {            
            chave = "<a href=\"";
            textoInteiro = textoInteiro.Remove(0, textoInteiro.IndexOf(chave) + chave.Length);
            return textoInteiro.Substring(0, textoInteiro.IndexOf("\""));
        }
    }
}

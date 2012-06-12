using System;
using System.Collections.Generic;
using System.Text;

namespace SearchSadia
{
    public class clsSearchSadia
    {
        private const int qntItensPagSadia = 10;
        private const string espaco = "%20";
        private string urlParte1, urlParte2, urlParte3, urlCompleta;
        private string textoInteiro;
        private string chave;
        private PortalControls.clsStatusStrip menuStatus;

        //constructor
        public clsSearchSadia(PortalControls.clsStatusStrip status)
        {
            //progresbar de status
            menuStatus = status;

            urlParte1 = "http://www.sadia.com.br/";
            urlParte2 = "busca/?q=";
            urlParte3 = "&resultados=receitas&pagina=";
        }

        //destructor
        ~clsSearchSadia()
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
                receita.Link = searchLink();
                receita.Titulo = searchTitulo();
                receita.Url = searchUrlImagem();
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
            chave = "Receitas <span>(";
            if (textoInteiro.Contains(chave) == false) return 0;
            textoInteiro = textoInteiro.Remove(0, textoInteiro.IndexOf(chave) + chave.Length);

            return Convert.ToInt32(textoInteiro.Substring(0, textoInteiro.IndexOf(")")));
        }

        private string searchTitulo()
        {
            chave = "title=\"";
            if (textoInteiro.Contains(chave) == false) { return null; }
            textoInteiro = textoInteiro.Remove(0, textoInteiro.IndexOf(chave) + chave.Length);

            return textoInteiro.Substring(0, textoInteiro.IndexOf("\""));
        }

        private string searchDescricao()
        {
            chave = "</h5>";
            if (textoInteiro.Contains(chave) == false) { return null; }
            textoInteiro = textoInteiro.Remove(0, textoInteiro.IndexOf(chave) + chave.Length);

            string aux = textoInteiro.Substring(0, textoInteiro.IndexOf("</div>"));
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

            return urlParte1 + textoInteiro.Substring(0, textoInteiro.IndexOf("\""));
        }

        private string searchLink()
        {
            chave = "lstBusca";
            if (textoInteiro.Contains(chave) == false) { return null; }
            textoInteiro = textoInteiro.Remove(0, textoInteiro.IndexOf(chave) + chave.Length);

            chave = "<a href=\"";
            textoInteiro = textoInteiro.Remove(0, textoInteiro.IndexOf(chave) + chave.Length);
            return urlParte1 + textoInteiro.Substring(0, textoInteiro.IndexOf("\""));
        }
    }
}

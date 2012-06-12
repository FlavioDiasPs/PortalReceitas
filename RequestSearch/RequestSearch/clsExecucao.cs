using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;

namespace Execute
{
    public class clsExecucao
    {
        int globalReceitasCont;
        bool Receitas = false, Sadia = false;
        PortalControls.clsStatusStrip status;
        PortalControls.clsTabControl tabControlSite;

        Thread thBuscarSadia;
        Thread thBuscarReceitas;

        
        public clsExecucao(PortalControls.clsStatusStrip fstatus, PortalControls.clsTabControl tabcontrolsite)
        {
            status = fstatus;
            tabControlSite = tabcontrolsite;            
        }

        //destructor
        ~clsExecucao()
        {
            System.GC.Collect();
        }

        private void setGlobalReceitasCont(int Cont)
        {
            globalReceitasCont += Cont;

            //coloca quantidade de receitas encontradas nos status  
            if(Receitas && Sadia)
            status.setStatusLabel("Foram encontradas " + globalReceitasCont + " receitas.");
        }

        public void startThreadBuscarReceitas(string textoBusca, PortalControls.clsTabPageConfiguracao clsConfiguracao)
        {
            //limpando controle
            if(clsConfiguracao.manterBuscasAnterioes == false)
            tabControlSite.disposeAllTabPages();

            //coloca informação nos status / coloca estilo no progressbar
            status.setStatusLabel("Requisitando dados / formando informação. . .");            
            status.setStyleProgressBar(System.Windows.Forms.ProgressBarStyle.Marquee);
         
            //zera valores
            reiniciar();

            try
            {
                if (clsConfiguracao.buscarSadia)
                {
                    //CRIA THREAD DE BUSCA EM SADIA.COM.BR
                    thBuscarSadia = new Thread(new ThreadStart(delegate { buscarReceitasSadia(textoBusca, clsConfiguracao); }));
                    thBuscarSadia.Name = "thBuscaReceitaSadia";
                    thBuscarSadia.IsBackground = false;
                    thBuscarSadia.Priority = ThreadPriority.Highest;                    
                    thBuscarSadia.Start();
                }

                if (clsConfiguracao.buscarReceitas)
                {
                    //CRIA THREAD DE BUSCA EM PORTALVITAL.COM
                    thBuscarReceitas = new Thread(new ThreadStart(delegate { buscarReceitasReceitas(textoBusca, clsConfiguracao); }));
                    thBuscarReceitas.Name = "thBuscaReceitaReceitas";
                    thBuscarReceitas.IsBackground = false;
                    thBuscarReceitas.Priority = ThreadPriority.Highest;
                    thBuscarReceitas.Start();
                }
            }
            catch (ThreadInterruptedException)
            { status.setStatusLabel("Pesquisa interrompida"); }
            catch (ThreadAbortException)
            { status.setStatusLabel("Pesquisa abortada"); }
            catch (Exception)
            { status.setStatusLabel("erro"); }
        }

        public ThreadState getThreadsState()
        {
            if (thBuscarSadia == null || thBuscarReceitas == null)
                return ThreadState.Stopped;

            if (thBuscarReceitas.ThreadState == ThreadState.Stopped && thBuscarSadia.ThreadState == ThreadState.Stopped)            
                return ThreadState.Stopped;            
            else            
                return ThreadState.Running;            
        }

        public void stopAllThreads()
        {           
            thBuscarSadia.Abort();
            thBuscarReceitas.Abort();
            System.GC.Collect();
        }

        private void reiniciar()
        {
            globalReceitasCont = 0;
            Receitas = false;
            Sadia = false;
        }

        public void buscarReceitasSadia(string textoBusca, PortalControls.clsTabPageConfiguracao clsConfiguracao)
        {            
            //declara variaveis            
            List<PortalControls.clsReceita> listReceitaSadia = new List<PortalControls.clsReceita>();           

            //busca as receitas            
            listReceitaSadia = new SearchSadia.clsSearchSadia(status).search(textoBusca, clsConfiguracao);

            //Adiciona a quantidade de receitas encontradas para a contagem global
            Sadia = true;
            if (listReceitaSadia == null)                
                    listReceitaSadia = new List<PortalControls.clsReceita>();
            setGlobalReceitasCont(listReceitaSadia.Count);

            //adiciona as paginas ao tabcontrol principal
            addReceitas(listReceitaSadia, clsConfiguracao.qntReceitasPag, "Sadia.com.br - " + textoBusca);
            
        }

        public void buscarReceitasReceitas(string textoBusca, PortalControls.clsTabPageConfiguracao clsConfiguracao)
        {
            //declara variaveis            
            List<PortalControls.clsReceita> listReceitaReceitas = new List<PortalControls.clsReceita>();           

            //busca as receitas            
            listReceitaReceitas = new SearchReceitas.clsSearchReceitas(status).search(textoBusca, clsConfiguracao);

            //Adiciona a quantidade de receitas encontradas para a contagem global
            Receitas = true;
            if (listReceitaReceitas == null)
                listReceitaReceitas = new List<PortalControls.clsReceita>();

            setGlobalReceitasCont(listReceitaReceitas.Count);

            //adiciona as paginas ao tabcontrol principal
            addReceitas(listReceitaReceitas, clsConfiguracao.qntReceitasPag, "Receitas.com - " + textoBusca);
          
        }

        private void addReceitas(List<PortalControls.clsReceita> listReceitas, int qntReceitasPag, string pageTitulo)
        {
            PortalControls.clsTabPage tabPageReceitas;
            PortalControls.clsTabPage tabPageSite = new PortalControls.clsTabPage();
            PortalControls.clsTabControl tabControlReceitas = new PortalControls.clsTabControl();            

            //coloca informações
            tabControlReceitas.Alignment = System.Windows.Forms.TabAlignment.Bottom;          

            //recolho receitas por pagina / calcula quantidade de paginas (limite do FOR)
            int ReceitasPorPag = qntReceitasPag;
            double divisao = Convert.ToDouble(listReceitas.Count) / Convert.ToDouble(ReceitasPorPag);
            int limite = Convert.ToInt32(System.Math.Ceiling(divisao));

            for (int i = 0; i < limite; i++)
            {
                //cria a tabpage
                tabPageReceitas = new PortalControls.clsTabPage();
                tabPageReceitas.Text = "Pag. " + (i + 1).ToString();
                tabPageReceitas.AutoScroll = true;

                //insere as receitas na page
                if (i == limite - 1)
                    tabPageReceitas.Controls.AddRange(listReceitas.GetRange(ReceitasPorPag * i, listReceitas.Count - ReceitasPorPag * i).ToArray());
                else
                    tabPageReceitas.Controls.AddRange(listReceitas.GetRange(ReceitasPorPag * i, ReceitasPorPag).ToArray());

                //adicionar pagina por pagina                
                tabControlReceitas.addTabPage(tabPageReceitas);
            }

            //adiciona tabcontrol receitas em na pagina de sites da sadia / adiciona tudo ao tabcontrol principal            
            tabPageSite.Text = pageTitulo + " (" + listReceitas.Count + ")";
            tabPageSite.addControl(tabControlReceitas);
            tabControlSite.addTabPage(tabPageSite);
            
            //faz pedido de coleta de lixo no sistema
            System.GC.Collect();
        }
    }
}

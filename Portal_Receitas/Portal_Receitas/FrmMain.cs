using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PortalReceitas
{
    public partial class FrmMain : Form
    {
        PortalControls.clsTabPageConfiguracao clsConfiguracao = new PortalControls.clsTabPageConfiguracao();
        Execute.clsExecucao clsExecutar;

        public FrmMain()
        {
            InitializeComponent();
            
            clsExecutar = new Execute.clsExecucao(status, tabControlSites);
            status.itemConfiguracao.Click += new EventHandler(AbrirConfiguracao);
            
            //recebe valores salvos nos settings            
            this.Size = clsConfiguracao.ultimoSizeForm;
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                //pede o recolhimento do lixo geral
                System.GC.Collect();

                //Adiciona o texto de busca na lista de autocomplete
                txtBuscar.AutoCompleteCustomSource.Add(txtBuscar.Text);

                //verifica se vai parar os threads pra inicia =r outra busca
                switch (verificarThreadState())
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        clsExecutar.stopAllThreads();
                        status.iniciar();
                        break;

                    case System.Windows.Forms.DialogResult.No:
                        return;
                }

                //declara variaveis
                Essencials.clsEssencials essencial = new Essencials.clsEssencials();

                //verifica conectividade com internet
                status.setStatusLabel("Verificando conexão com a internet. . .");
                if (essencial.verificarConexao() == false)
                {
                    status.setStatusLabel("Não há conexão com a internet.");
                    return;
                }

                //REMOVE ACENTOS
                status.setStatusLabel("Removendo caracteres inválidos do texto de busca. . .");
                txtBuscar.Text = essencial.removerAcentos(txtBuscar.Text);

                //Chama classe execução para iniciar o Thread de Busca
                clsExecutar.startThreadBuscarReceitas(txtBuscar.Text, clsConfiguracao);

            }
            catch (ArgumentNullException)
            {
                status.setStatusLabel("Foram encontradas 0 receitas.");
            }
            catch (Exception)
            {
                tabControlSites.disposeAllTabPages();
                status.setStatusLabel("Ocorreu um erro desconhecido, informe o desenvolvedor a respeito.");
            }
        }


        private void AbrirConfiguracao(object sender, EventArgs e)
        {
            if (tabControlSites.TabPages.Contains(clsConfiguracao) == false)
                tabControlSites.TabPages.Add(clsConfiguracao);

            tabControlSites.SelectedTab = clsConfiguracao;
        }

        private void notify_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //volta com o formulario amostra na tela
            this.Show();
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void FrmMain_Resize(object sender, EventArgs e)
        {
            //esconde o formulario na bandeja
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.ShowInTaskbar = false;
                notify.ShowBalloonTip(3, "Info.", "Sadia Receitas foi para a bandeja.", ToolTipIcon.Info);
            }            
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch(verificarThreadState())
            {
                case DialogResult.No:
                e.Cancel = true;
                return;

                case DialogResult.Yes:
                clsExecutar.stopAllThreads();
                break;
            }

            //salva a quantidade de receitas por pagina            
            clsConfiguracao.ultimoSizeForm = this.Size;            
        }        

        private DialogResult verificarThreadState()
        {
            if (clsExecutar.getThreadsState() == System.Threading.ThreadState.Running)
            {
                return MessageBox.Show("Ainda há buscas em andamento, deseja interromper ?", "Buscas em andamento", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);                
            }

            return DialogResult.Cancel;
        }
     
    }
}

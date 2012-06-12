using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Forms;

namespace PortalControls
{
    public class clsStatusStrip:StatusStrip
    {
        private ToolStripLabel lblStatus = new ToolStripLabel();
        private ToolStripProgressBar pgbStatus = new ToolStripProgressBar();        
        private ToolStripStatusLabel lblRotFlavioSilva = new ToolStripStatusLabel();
        private ToolStripDropDownButton btnConfiguracao = new ToolStripDropDownButton();
        public ToolStripMenuItem itemConfiguracao = new ToolStripMenuItem();

        public clsStatusStrip()
        {
            initializeComponents();
            iniciar();
            setFlavioSilva();            
        }

        //destructor
        ~clsStatusStrip()
        {
            System.GC.Collect();
        }

        private delegate void delAtualizaStatusPgb(int valor);
        public void addValueProgressBar(int valor)
        {
            if (this.InvokeRequired)
                this.BeginInvoke(new delAtualizaStatusPgb(addValueProgressBar), valor);
            else
            {
                if (pgbStatus.Value < pgbStatus.Maximum)
                    pgbStatus.Value += valor;
            }
        }
        public void addMaxProgressBar(int valor)
        {
            if (this.InvokeRequired)
                this.BeginInvoke(new delAtualizaStatusPgb(addMaxProgressBar), valor);
            else
            {
                pgbStatus.Maximum += valor;
                pgbStatus.Style = ProgressBarStyle.Continuous;            
            }
        }

        private delegate void delStyleTipoStatusPgb(System.Windows.Forms.ProgressBarStyle style);
        public void setStyleProgressBar(System.Windows.Forms.ProgressBarStyle style)
        {
            if (this.InvokeRequired)
                this.BeginInvoke(new delStyleTipoStatusPgb(setStyleProgressBar), style);
            else
            {
                pgbStatus.Style = style;
            }

        }

        private delegate void delAtualizaStatusLbl(string Status);
        public void setStatusLabel(string Status)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new delAtualizaStatusLbl(setStatusLabel), Status);
            }
            else
                lblStatus.Text = Status;
        }

        public void iniciar()
        {                                   
            this.lblStatus.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblStatus.Text = ". . .";
          
            this.pgbStatus.Style = ProgressBarStyle.Continuous;
            this.pgbStatus.Maximum = 0;
            this.pgbStatus.Value = 0;
        }

        private void initializeComponents()
        {
            // 
            // menuStrip_btnConfiguracao
            // 
            this.btnConfiguracao.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnConfiguracao.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnConfiguracao.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemConfiguracao});
            this.btnConfiguracao.Image = Properties.Resources.Config;
            this.btnConfiguracao.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConfiguracao.Name = "menuStrip_btnConfiguracao";
            this.btnConfiguracao.Size = new System.Drawing.Size(29, 20);
            this.btnConfiguracao.Text = "Configurações";
            // 
            // menuStrip_ItemConfiguracao
            // 
            this.itemConfiguracao.Name = "menuStrip_ItemConfiguracao";
            this.itemConfiguracao.Size = new System.Drawing.Size(151, 22);
            this.itemConfiguracao.Text = "Configurações";
            // 
            // lblRotFlavioSilva
            // 
            this.lblRotFlavioSilva.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lblRotFlavioSilva.ForeColor = System.Drawing.Color.Gray;
            this.lblRotFlavioSilva.Name = "lblRotFlavioSilva";
            this.lblRotFlavioSilva.Size = new System.Drawing.Size(416, 17);
            this.lblRotFlavioSilva.Spring = true;
            this.lblRotFlavioSilva.AutoToolTip = true;
            this.Items.AddRange(new ToolStripItem[] { lblStatus, pgbStatus, btnConfiguracao, lblRotFlavioSilva });
        }








        private void setFlavioSilva()
        {
            this.lblRotFlavioSilva.Text = "Flavio Silva ( Sko.Lex ) - 06/2012";
            this.lblRotFlavioSilva.ToolTipText = "Clique e conheça meu canal no Youtube !!";
            this.lblRotFlavioSilva.Click += new EventHandler(lblRotFlavioSilva_Click);
        }

        private void lblRotFlavioSilva_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.youtube.com/user/MrSkoLex");
        }
    }
}

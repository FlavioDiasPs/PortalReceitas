using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace PortalControls
{
    public partial class clsReceita : UserControl
    {
        private string descricao;
        private string titulo;
        private string urlImagem;
        private string link;


        public clsReceita()
        {
            InitializeComponent();
            
            this.Dock = DockStyle.Top;

            //click, inicia link
            this.Click += new EventHandler(startLink);
            pcbImagem.Click += new EventHandler(startLink);
            lblDescricao.Click += new EventHandler(startLink);
            lblTitulo.Click += new EventHandler(startLink);

            //mousehover mostra tooltip
            this.MouseHover += new EventHandler(showToolTip);
            pcbImagem.MouseHover += new EventHandler(showToolTip);
            lblDescricao.MouseHover += new EventHandler(showToolTip);
            lblTitulo.MouseHover += new EventHandler(showToolTip);
        }

        public void showToolTip(object sender, EventArgs e)
        {
            toolTip.Show(link, (Control)sender, 3000);
        }

        //coloco a descricao
        public string Descricao
        {
            get { return this.descricao; }
            set
            {
                this.descricao = value;
                lblDescricao.Text = descricao;
            }
        }

        //coloco o titulo
        public string Titulo
        {
            get { return this.titulo; }
            set
            {
                this.titulo = value;
                lblTitulo.Text = titulo;
            }
        }

        public string Url
        {
            get { return this.urlImagem; }
            set
            {
                this.urlImagem = value;
                pcbImagem.ImageLocation = urlImagem;
            }
        }

        public string Link
        {
            get { return this.link; }
            set
            { this.link = value; }
        }
       
        
        private void startLink(object sender, EventArgs e)
        {
            if (Link != null)
                System.Diagnostics.Process.Start(Link);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace PortalControls
{
    public class clsTabPageConfiguracao:System.Windows.Forms.TabPage
    {
        private int qntreceitaspag;
        private int qntmaxresultadossite;
        private bool buscarsadia;
        private bool buscarreceitas;
        private bool manterbuscasanteriores;
        private System.Drawing.Size ultimosizeform;


        public clsTabPageConfiguracao()
        {
            //recebe os valores do settings
            qntReceitasPag = Properties.Settings.Default.qntReceitasPag;
            qntMaxResultadosSite = Properties.Settings.Default.qntMaxResultadoSite;
            buscarSadia = Properties.Settings.Default.buscarSadia;
            buscarReceitas = Properties.Settings.Default.buscarReceitas;
            manterBuscasAnterioes = Properties.Settings.Default.manterBuscasAnteriores;
            ultimoSizeForm = Properties.Settings.Default.ultimoSizeForm;
                       
            //CRIA DESIGN
            criarDesign();

            //atribui os valores aos controles
            this.nudQntReceitasPag.Value = Convert.ToDecimal(qntReceitasPag);
            this.nudQntMaximaResultadoSite.Value = Convert.ToDecimal(qntMaxResultadosSite);
            this.ccbBuscarSadia.Checked = buscarSadia;
            this.ccbBuscarReceitas.Checked = buscarReceitas;
            this.ccbManterBuscasAnteriores.Checked = manterBuscasAnterioes;
        }

        //destructor
        ~clsTabPageConfiguracao()
        {
            System.GC.Collect();
        }

        private System.Windows.Forms.Button btnSalvar = new System.Windows.Forms.Button();
        private System.Windows.Forms.GroupBox gpbBuscas = new System.Windows.Forms.GroupBox();
        private System.Windows.Forms.CheckBox ccbBuscarReceitas = new System.Windows.Forms.CheckBox();
        private System.Windows.Forms.CheckBox ccbBuscarSadia = new System.Windows.Forms.CheckBox();
        private System.Windows.Forms.CheckBox ccbManterBuscasAnteriores = new System.Windows.Forms.CheckBox();
        private System.Windows.Forms.GroupBox gpbLimites = new System.Windows.Forms.GroupBox();
        private System.Windows.Forms.NumericUpDown nudQntReceitasPag = new System.Windows.Forms.NumericUpDown();
        private System.Windows.Forms.Label lblRotQntReceitaPag = new System.Windows.Forms.Label();
        private System.Windows.Forms.NumericUpDown nudQntMaximaResultadoSite = new System.Windows.Forms.NumericUpDown();
        private System.Windows.Forms.Label lblRotQntMaxResultadoSite = new System.Windows.Forms.Label();
        private void criarDesign()
        {            
            // 
            // this
            // 
            this.Controls.Add(this.gpbBuscas);
            this.Controls.Add(this.gpbLimites);
            this.Controls.Add(btnSalvar);
            this.Location = new System.Drawing.Point(4, 26);
            this.Name = "tabPageConfiguracao";
            this.Size = new System.Drawing.Size(476, 377);
            this.TabIndex = 0;
            this.Text = "Configurações";
            this.UseVisualStyleBackColor = true;
            //
            //btnSalvar
            //
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSalvar.Height = 50;
            this.btnSalvar.Click += new EventHandler(btnSalvar_Click);
            // 
            // ccbBuscarSadia
            // 
            this.ccbBuscarSadia.AutoSize = true;
            this.ccbBuscarSadia.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ccbBuscarSadia.ForeColor = System.Drawing.Color.Black;
            this.ccbBuscarSadia.Location = new System.Drawing.Point(6, 64);
            this.ccbBuscarSadia.Name = "ccbBuscarSadia";
            this.ccbBuscarSadia.Size = new System.Drawing.Size(224, 21);
            this.ccbBuscarSadia.TabIndex = 0;
            this.ccbBuscarSadia.Text = "Buscar resultados em Sadia.com.br";
            this.ccbBuscarSadia.UseVisualStyleBackColor = true;
            this.ccbBuscarSadia.CheckedChanged += new EventHandler(ccbBuscarSadia_CheckedChanged);
            // 
            // ccbBuscarReceitas
            // 
            this.ccbBuscarReceitas.AutoSize = true;
            this.ccbBuscarReceitas.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ccbBuscarReceitas.ForeColor = System.Drawing.Color.Black;
            this.ccbBuscarReceitas.Location = new System.Drawing.Point(6, 26);
            this.ccbBuscarReceitas.Name = "ccbBuscarReceitas";
            this.ccbBuscarReceitas.Size = new System.Drawing.Size(226, 21);
            this.ccbBuscarReceitas.TabIndex = 1;
            this.ccbBuscarReceitas.Text = "Buscar resultados em Receitas.com";
            this.ccbBuscarReceitas.UseVisualStyleBackColor = true;
            this.ccbBuscarReceitas.CheckedChanged += new EventHandler(ccbBuscarReceitas_CheckedChanged);
            //
            //ccbManterBuscasAnteriores
            //
            this.ccbManterBuscasAnteriores.AutoSize = true;
            this.ccbManterBuscasAnteriores.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ccbManterBuscasAnteriores.ForeColor = System.Drawing.Color.Black;
            this.ccbManterBuscasAnteriores.Location = new System.Drawing.Point(6, 102);
            this.ccbManterBuscasAnteriores.Name = "ccbManterBuscasAnteriores";
            this.ccbManterBuscasAnteriores.Size = new System.Drawing.Size(226, 21);
            this.ccbManterBuscasAnteriores.TabIndex = 2;
            this.ccbManterBuscasAnteriores.Text = "Manter resultado de buscas anteriores.";
            this.ccbManterBuscasAnteriores.UseVisualStyleBackColor = true;            
            // 
            // nudQntReceitasPag
            // 
            this.nudQntReceitasPag.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudQntReceitasPag.ForeColor = System.Drawing.Color.Black;
            this.nudQntReceitasPag.Location = new System.Drawing.Point(6, 52);
            this.nudQntReceitasPag.Name = "nudQntReceitasPag";
            this.nudQntReceitasPag.Size = new System.Drawing.Size(120, 24);
            this.nudQntReceitasPag.TabIndex = 3;
            this.nudQntReceitasPag.Minimum = 5;
            this.nudQntReceitasPag.Maximum = 500;            
            // 
            // gpbBuscas
            // 
            this.gpbBuscas.Controls.Add(this.ccbBuscarReceitas);
            this.gpbBuscas.Controls.Add(this.ccbBuscarSadia);
            this.gpbBuscas.Controls.Add(this.ccbManterBuscasAnteriores);
            this.gpbBuscas.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbBuscas.ForeColor = System.Drawing.Color.RoyalBlue;
            this.gpbBuscas.Location = new System.Drawing.Point(9, 12);
            this.gpbBuscas.Name = "gpbBuscas";
            this.gpbBuscas.Size = new System.Drawing.Size(460, 140);
            this.gpbBuscas.TabIndex = 5;
            this.gpbBuscas.TabStop = false;
            this.gpbBuscas.Text = "Buscas";
            // 
            // gpbLimites
            // 
            this.gpbLimites.Controls.Add(this.nudQntMaximaResultadoSite);
            this.gpbLimites.Controls.Add(this.lblRotQntMaxResultadoSite);
            this.gpbLimites.Controls.Add(this.nudQntReceitasPag);
            this.gpbLimites.Controls.Add(this.lblRotQntReceitaPag);
            this.gpbLimites.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbLimites.ForeColor = System.Drawing.Color.RoyalBlue;
            this.gpbLimites.Location = new System.Drawing.Point(11, 165);
            this.gpbLimites.Name = "gpbLimites";
            this.gpbLimites.Size = new System.Drawing.Size(457, 159);
            this.gpbLimites.TabIndex = 6;
            this.gpbLimites.TabStop = false;
            this.gpbLimites.Text = "Limites";
            // 
            // lblRotQntReceitaPag
            // 
            this.lblRotQntReceitaPag.AutoSize = true;
            this.lblRotQntReceitaPag.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRotQntReceitaPag.ForeColor = System.Drawing.Color.Black;
            this.lblRotQntReceitaPag.Location = new System.Drawing.Point(6, 32);
            this.lblRotQntReceitaPag.Name = "lblRotQntReceitaPag";
            this.lblRotQntReceitaPag.Size = new System.Drawing.Size(205, 17);
            this.lblRotQntReceitaPag.TabIndex = 5;
            this.lblRotQntReceitaPag.Text = "Quantidade de receitas por página:";
            // 
            // nudQntMaximaResultadoSite
            // 
            this.nudQntMaximaResultadoSite.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudQntMaximaResultadoSite.ForeColor = System.Drawing.Color.Black;
            this.nudQntMaximaResultadoSite.Location = new System.Drawing.Point(9, 112);
            this.nudQntMaximaResultadoSite.Name = "nudQntMaximaResultadoSite";
            this.nudQntMaximaResultadoSite.Size = new System.Drawing.Size(120, 24);
            this.nudQntMaximaResultadoSite.TabIndex = 4;
            this.nudQntMaximaResultadoSite.Minimum = 5;
            this.nudQntMaximaResultadoSite.Maximum = 100000;
            // 
            // lblRotQntMaxResultadoSite
            // 
            this.lblRotQntMaxResultadoSite.AutoSize = true;
            this.lblRotQntMaxResultadoSite.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRotQntMaxResultadoSite.ForeColor = System.Drawing.Color.Black;
            this.lblRotQntMaxResultadoSite.Location = new System.Drawing.Point(6, 95);
            this.lblRotQntMaxResultadoSite.Name = "lblRotQntMaxResultadoSite";
            this.lblRotQntMaxResultadoSite.Size = new System.Drawing.Size(246, 17);
            this.lblRotQntMaxResultadoSite.TabIndex = 8;
            this.lblRotQntMaxResultadoSite.Text = "Quantidade máxima de resultado por site: ";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {            
            this.qntReceitasPag = (Int32)nudQntReceitasPag.Value;
            this.qntMaxResultadosSite = (Int32)nudQntMaximaResultadoSite.Value;
            this.buscarSadia = this.ccbBuscarSadia.Checked;
            this.buscarReceitas = this.ccbBuscarReceitas.Checked;
            this.manterBuscasAnterioes = this.ccbManterBuscasAnteriores.Checked;
            this.Parent.Controls.Remove(this);
        }

        private void ccbBuscarSadia_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ccbBuscarSadia.Checked == false)
            {
                this.ccbBuscarReceitas.Checked = true;
            }
        }

        private void ccbBuscarReceitas_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ccbBuscarReceitas.Checked == false)
            {
                this.ccbBuscarSadia.Checked = true;
            }
        }

        public int qntReceitasPag
        {
            get { return qntreceitaspag; }
            set
            {
                qntreceitaspag = value;
                Properties.Settings.Default.qntReceitasPag = value;
                Properties.Settings.Default.Save();
            }
        }

        public int qntMaxResultadosSite
        {
            get { return qntmaxresultadossite; }
            set
            {
                qntmaxresultadossite = value;
                Properties.Settings.Default.qntMaxResultadoSite = value;
                Properties.Settings.Default.Save();
            }
        }

        public bool buscarSadia
        {
            get { return buscarsadia; }
            set
            {
                buscarsadia = value;
                Properties.Settings.Default.buscarSadia = value;
                Properties.Settings.Default.Save();
            }
        }

        public bool buscarReceitas
        {
            get { return buscarreceitas; }
            set
            {
                buscarreceitas = value; 
                Properties.Settings.Default.buscarReceitas = value;
                Properties.Settings.Default.Save();
            }
        }

        public bool manterBuscasAnterioes
        {
            get { return manterbuscasanteriores; }
            set { 
                manterbuscasanteriores = value;
                Properties.Settings.Default.manterBuscasAnteriores = value;
                Properties.Settings.Default.Save();
            }
        }

        public System.Drawing.Size ultimoSizeForm
        {
            get { return ultimosizeform; }
            set
            {
                ultimosizeform = value;
                Properties.Settings.Default.ultimoSizeForm = value;
                Properties.Settings.Default.Save();
            }
        }
    }
}

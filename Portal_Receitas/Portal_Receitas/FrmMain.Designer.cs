namespace PortalReceitas
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {            
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.notify = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnBuscar = new DevComponents.DotNetBar.ButtonX();
            this.txtBuscar = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblRotReceita = new System.Windows.Forms.Label();
            this.panelTopo = new System.Windows.Forms.Panel();
            this.status = new PortalControls.clsStatusStrip();                      
            this.tabControlSites = new PortalControls.clsTabControl();
            this.panelTopo.SuspendLayout();
            this.status.SuspendLayout();
            this.SuspendLayout();
            // 
            // notify
            // 
            this.notify.Icon = ((System.Drawing.Icon)(resources.GetObject("notify.Icon")));
            this.notify.Text = "Receitas Sadia";
            this.notify.Visible = true;
            this.notify.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notify_MouseDoubleClick);
            // 
            // btnBuscar
            // 
            this.btnBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.AntiAlias = true;
            this.btnBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnBuscar.DisabledImagesGrayScale = false;
            this.btnBuscar.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.Black;
            this.btnBuscar.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Color;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(442, 12);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(7);
            this.btnBuscar.Size = new System.Drawing.Size(133, 57);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.ThemeAware = true;
            this.btnBuscar.Tooltip = "Clique para buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtBuscar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            // 
            // 
            // 
            this.txtBuscar.Border.Class = "TextBoxBorder";
            this.txtBuscar.FocusHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtBuscar.FocusHighlightEnabled = true;
            this.txtBuscar.Location = new System.Drawing.Point(16, 41);
            this.txtBuscar.MaxLength = 50;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(420, 24);
            this.txtBuscar.TabIndex = 2;
            this.txtBuscar.WatermarkText = "Digite aqui !";
            // 
            // lblRotReceita
            // 
            this.lblRotReceita.AutoSize = true;
            this.lblRotReceita.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRotReceita.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblRotReceita.Location = new System.Drawing.Point(12, 18);
            this.lblRotReceita.Name = "lblRotReceita";
            this.lblRotReceita.Size = new System.Drawing.Size(71, 26);
            this.lblRotReceita.TabIndex = 0;
            this.lblRotReceita.Text = "Receita";
            // 
            // panelTopo
            // 
            this.panelTopo.Controls.Add(this.txtBuscar);
            this.panelTopo.Controls.Add(this.lblRotReceita);
            this.panelTopo.Controls.Add(this.btnBuscar);
            this.panelTopo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopo.Location = new System.Drawing.Point(0, 0);
            this.panelTopo.Name = "panelTopo";
            this.panelTopo.Size = new System.Drawing.Size(584, 75);
            this.panelTopo.TabIndex = 7;
            // 
            // status
            // 
            this.status.BackColor = System.Drawing.Color.White;            
            this.status.Location = new System.Drawing.Point(0, 495);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(584, 22);
            this.status.TabIndex = 9;
            this.status.Text = "clsStatusStrip1";            
            // 
            // tabControlSites
            // 
            this.tabControlSites.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSites.Location = new System.Drawing.Point(0, 75);
            this.tabControlSites.Name = "tabControlSites";
            this.tabControlSites.SelectedIndex = 0;
            this.tabControlSites.Size = new System.Drawing.Size(584, 420);
            this.tabControlSites.TabIndex = 6;
            // 
            // FrmMain
            // 
            this.AcceptButton = this.btnBuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(584, 517);
            this.Controls.Add(this.tabControlSites);
            this.Controls.Add(this.panelTopo);
            this.Controls.Add(this.status);
            this.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(600, 555);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Portal Receitas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Resize += new System.EventHandler(this.FrmMain_Resize);
            this.panelTopo.ResumeLayout(false);
            this.panelTopo.PerformLayout();
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notify;
        private DevComponents.DotNetBar.ButtonX btnBuscar;
        private DevComponents.DotNetBar.Controls.TextBoxX txtBuscar;
        private System.Windows.Forms.Label lblRotReceita;
        private System.Windows.Forms.Panel panelTopo;
        private PortalControls.clsStatusStrip status;
        private PortalControls.clsTabControl tabControlSites;
              
        
    }
}


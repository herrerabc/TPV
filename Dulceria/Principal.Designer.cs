namespace Dulceria
{
    partial class Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.tbPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tb_panelMenu = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.lnkSalir = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.seguridadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seguridadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.inventarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.respaldoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parametrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuracionBasculaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteDeVentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.venderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimirUltimoTicketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelaciónDeVentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteDeExistenciasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbPanel.SuspendLayout();
            this.tb_panelMenu.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbPanel
            // 
            this.tbPanel.ColumnCount = 1;
            this.tbPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tbPanel.Controls.Add(this.tb_panelMenu, 0, 0);
            this.tbPanel.Controls.Add(this.panel1, 0, 1);
            this.tbPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPanel.Location = new System.Drawing.Point(0, 28);
            this.tbPanel.Margin = new System.Windows.Forms.Padding(4);
            this.tbPanel.Name = "tbPanel";
            this.tbPanel.RowCount = 2;
            this.tbPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.142084F));
            this.tbPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.85792F));
            this.tbPanel.Size = new System.Drawing.Size(1344, 739);
            this.tbPanel.TabIndex = 4;
            // 
            // tb_panelMenu
            // 
            this.tb_panelMenu.ColumnCount = 5;
            this.tb_panelMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tb_panelMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tb_panelMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.06188F));
            this.tb_panelMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.85828F));
            this.tb_panelMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tb_panelMenu.Controls.Add(this.label1, 0, 0);
            this.tb_panelMenu.Controls.Add(this.lnkSalir, 4, 0);
            this.tb_panelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_panelMenu.Location = new System.Drawing.Point(4, 4);
            this.tb_panelMenu.Margin = new System.Windows.Forms.Padding(4);
            this.tb_panelMenu.Name = "tb_panelMenu";
            this.tb_panelMenu.RowCount = 1;
            this.tb_panelMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.58621F));
            this.tb_panelMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.41379F));
            this.tb_panelMenu.Size = new System.Drawing.Size(1336, 30);
            this.tb_panelMenu.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sitka Subheading", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(4, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario";
            // 
            // lnkSalir
            // 
            this.lnkSalir.AutoSize = true;
            this.lnkSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.lnkSalir.Font = new System.Drawing.Font("Sitka Subheading", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkSalir.LinkColor = System.Drawing.SystemColors.HotTrack;
            this.lnkSalir.Location = new System.Drawing.Point(1199, 0);
            this.lnkSalir.Name = "lnkSalir";
            this.lnkSalir.Size = new System.Drawing.Size(134, 30);
            this.lnkSalir.TabIndex = 2;
            this.lnkSalir.TabStop = true;
            this.lnkSalir.Text = "&Cerrar Sesión";
            this.lnkSalir.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSalir_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 42);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1336, 693);
            this.panel1.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seguridadToolStripMenuItem,
            this.administraciónToolStripMenuItem,
            this.reportesToolStripMenuItem,
            this.ventasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1344, 28);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // seguridadToolStripMenuItem
            // 
            this.seguridadToolStripMenuItem.Name = "seguridadToolStripMenuItem";
            this.seguridadToolStripMenuItem.Size = new System.Drawing.Size(12, 24);
            // 
            // administraciónToolStripMenuItem
            // 
            this.administraciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seguridadToolStripMenuItem1,
            this.inventarioToolStripMenuItem,
            this.respaldoToolStripMenuItem,
            this.parametrosToolStripMenuItem,
            this.configuracionBasculaToolStripMenuItem});
            this.administraciónToolStripMenuItem.Name = "administraciónToolStripMenuItem";
            this.administraciónToolStripMenuItem.Size = new System.Drawing.Size(121, 24);
            this.administraciónToolStripMenuItem.Text = "&Administración";
            // 
            // seguridadToolStripMenuItem1
            // 
            this.seguridadToolStripMenuItem1.Name = "seguridadToolStripMenuItem1";
            this.seguridadToolStripMenuItem1.Size = new System.Drawing.Size(231, 26);
            this.seguridadToolStripMenuItem1.Text = "Usuarios";
            this.seguridadToolStripMenuItem1.Click += new System.EventHandler(this.seguridadToolStripMenuItem1_Click);
            // 
            // inventarioToolStripMenuItem
            // 
            this.inventarioToolStripMenuItem.Name = "inventarioToolStripMenuItem";
            this.inventarioToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.inventarioToolStripMenuItem.Text = "Inventario";
            this.inventarioToolStripMenuItem.Click += new System.EventHandler(this.inventarioToolStripMenuItem_Click);
            // 
            // respaldoToolStripMenuItem
            // 
            this.respaldoToolStripMenuItem.Name = "respaldoToolStripMenuItem";
            this.respaldoToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.respaldoToolStripMenuItem.Text = "Respaldo";
            this.respaldoToolStripMenuItem.Click += new System.EventHandler(this.respaldoToolStripMenuItem_Click);
            // 
            // parametrosToolStripMenuItem
            // 
            this.parametrosToolStripMenuItem.Name = "parametrosToolStripMenuItem";
            this.parametrosToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.parametrosToolStripMenuItem.Text = "Parametros";
            this.parametrosToolStripMenuItem.Click += new System.EventHandler(this.parametrosToolStripMenuItem_Click);
            // 
            // configuracionBasculaToolStripMenuItem
            // 
            this.configuracionBasculaToolStripMenuItem.Name = "configuracionBasculaToolStripMenuItem";
            this.configuracionBasculaToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.configuracionBasculaToolStripMenuItem.Text = "Configuracion Bascula";
            this.configuracionBasculaToolStripMenuItem.Click += new System.EventHandler(this.configuracionBasculaToolStripMenuItem_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reporteDeVentasToolStripMenuItem,
            this.reporteDeExistenciasToolStripMenuItem});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(80, 24);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // reporteDeVentasToolStripMenuItem
            // 
            this.reporteDeVentasToolStripMenuItem.Name = "reporteDeVentasToolStripMenuItem";
            this.reporteDeVentasToolStripMenuItem.Size = new System.Drawing.Size(233, 26);
            this.reporteDeVentasToolStripMenuItem.Text = "Reporte de Ventas";
            this.reporteDeVentasToolStripMenuItem.Click += new System.EventHandler(this.reporteDeVentasToolStripMenuItem_Click);
            // 
            // ventasToolStripMenuItem
            // 
            this.ventasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.venderToolStripMenuItem,
            this.imprimirUltimoTicketToolStripMenuItem,
            this.cancelaciónDeVentaToolStripMenuItem});
            this.ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            this.ventasToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.ventasToolStripMenuItem.Text = "Ventas";
            // 
            // venderToolStripMenuItem
            // 
            this.venderToolStripMenuItem.Name = "venderToolStripMenuItem";
            this.venderToolStripMenuItem.Size = new System.Drawing.Size(233, 26);
            this.venderToolStripMenuItem.Text = "Vender";
            this.venderToolStripMenuItem.Click += new System.EventHandler(this.venderToolStripMenuItem_Click);
            // 
            // imprimirUltimoTicketToolStripMenuItem
            // 
            this.imprimirUltimoTicketToolStripMenuItem.Name = "imprimirUltimoTicketToolStripMenuItem";
            this.imprimirUltimoTicketToolStripMenuItem.Size = new System.Drawing.Size(233, 26);
            this.imprimirUltimoTicketToolStripMenuItem.Text = "Imprimir Ultimo Ticket";
            this.imprimirUltimoTicketToolStripMenuItem.Click += new System.EventHandler(this.imprimirUltimoTicketToolStripMenuItem_Click);
            // 
            // cancelaciónDeVentaToolStripMenuItem
            // 
            this.cancelaciónDeVentaToolStripMenuItem.Name = "cancelaciónDeVentaToolStripMenuItem";
            this.cancelaciónDeVentaToolStripMenuItem.Size = new System.Drawing.Size(233, 26);
            this.cancelaciónDeVentaToolStripMenuItem.Text = "Cancelación de venta";
            this.cancelaciónDeVentaToolStripMenuItem.Click += new System.EventHandler(this.cancelaciónDeVentaToolStripMenuItem_Click);
            // 
            // reporteDeExistenciasToolStripMenuItem
            // 
            this.reporteDeExistenciasToolStripMenuItem.Name = "reporteDeExistenciasToolStripMenuItem";
            this.reporteDeExistenciasToolStripMenuItem.Size = new System.Drawing.Size(233, 26);
            this.reporteDeExistenciasToolStripMenuItem.Text = "Reporte de Existencias";
            this.reporteDeExistenciasToolStripMenuItem.Click += new System.EventHandler(this.reporteDeExistenciasToolStripMenuItem_Click);
            // 
            // Principal
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1344, 767);
            this.Controls.Add(this.tbPanel);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Principal_Load);
            this.tbPanel.ResumeLayout(false);
            this.tbPanel.PerformLayout();
            this.tb_panelMenu.ResumeLayout(false);
            this.tb_panelMenu.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tbPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tb_panelMenu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem seguridadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administraciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seguridadToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem inventarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteDeVentasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem respaldoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parametrosToolStripMenuItem;
        private System.Windows.Forms.LinkLabel lnkSalir;
        private System.Windows.Forms.ToolStripMenuItem venderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imprimirUltimoTicketToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelaciónDeVentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuracionBasculaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteDeExistenciasToolStripMenuItem;
    }
}
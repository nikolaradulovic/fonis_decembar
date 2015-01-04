namespace Fonis_Decembar
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.opcijeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zatvoriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.predstaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opcijeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pozoristaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izmeniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.glumciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sviGlumciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.dataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.predstaveToolStripMenuItem,
            this.pozoristaToolStripMenuItem,
            this.glumciToolStripMenuItem,
            this.opcijeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(762, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // opcijeToolStripMenuItem
            // 
            this.opcijeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zatvoriToolStripMenuItem});
            this.opcijeToolStripMenuItem.Name = "opcijeToolStripMenuItem";
            this.opcijeToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.opcijeToolStripMenuItem.Text = "Opcije";
            // 
            // zatvoriToolStripMenuItem
            // 
            this.zatvoriToolStripMenuItem.Name = "zatvoriToolStripMenuItem";
            this.zatvoriToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.zatvoriToolStripMenuItem.Text = "Zatvori";
            this.zatvoriToolStripMenuItem.Click += new System.EventHandler(this.zatvoriToolStripMenuItem_Click);
            // 
            // predstaveToolStripMenuItem
            // 
            this.predstaveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcijeToolStripMenuItem1});
            this.predstaveToolStripMenuItem.Name = "predstaveToolStripMenuItem";
            this.predstaveToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.predstaveToolStripMenuItem.Text = "Predstave";
            // 
            // opcijeToolStripMenuItem1
            // 
            this.opcijeToolStripMenuItem1.Name = "opcijeToolStripMenuItem1";
            this.opcijeToolStripMenuItem1.Size = new System.Drawing.Size(94, 22);
            this.opcijeToolStripMenuItem1.Text = "Edit";
            this.opcijeToolStripMenuItem1.Click += new System.EventHandler(this.opcijeToolStripMenuItem1_Click);
            // 
            // pozoristaToolStripMenuItem
            // 
            this.pozoristaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.izmeniToolStripMenuItem});
            this.pozoristaToolStripMenuItem.Name = "pozoristaToolStripMenuItem";
            this.pozoristaToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.pozoristaToolStripMenuItem.Text = "Pozorista";
            // 
            // izmeniToolStripMenuItem
            // 
            this.izmeniToolStripMenuItem.Name = "izmeniToolStripMenuItem";
            this.izmeniToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.izmeniToolStripMenuItem.Text = "Edit";
            this.izmeniToolStripMenuItem.Click += new System.EventHandler(this.izmeniToolStripMenuItem_Click);
            // 
            // glumciToolStripMenuItem
            // 
            this.glumciToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sviGlumciToolStripMenuItem});
            this.glumciToolStripMenuItem.Name = "glumciToolStripMenuItem";
            this.glumciToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.glumciToolStripMenuItem.Text = "Glumci";
            // 
            // sviGlumciToolStripMenuItem
            // 
            this.sviGlumciToolStripMenuItem.Name = "sviGlumciToolStripMenuItem";
            this.sviGlumciToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.sviGlumciToolStripMenuItem.Text = "Edit";
            this.sviGlumciToolStripMenuItem.Click += new System.EventHandler(this.sviGlumciToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Fonis_Decembar.Properties.Resources.movie_theater;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(762, 364);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "Pozorista";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

    
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem opcijeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zatvoriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem predstaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pozoristaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izmeniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem glumciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sviGlumciToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
       
        private System.Windows.Forms.BindingSource dataSet1BindingSource;
        private System.Windows.Forms.ToolStripMenuItem opcijeToolStripMenuItem1;
    }
}


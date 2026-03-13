namespace GalleryApp
{
    partial class Main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.картиныToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.историяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выставкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сотрудникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.праваСотрудникаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.картиныToolStripMenuItem,
            this.историяToolStripMenuItem,
            this.выставкиToolStripMenuItem,
            this.сотрудникиToolStripMenuItem,
            this.отчетыToolStripMenuItem,
            this.праваСотрудникаToolStripMenuItem,
            this.отчетToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // картиныToolStripMenuItem
            // 
            this.картиныToolStripMenuItem.Name = "картиныToolStripMenuItem";
            this.картиныToolStripMenuItem.Size = new System.Drawing.Size(84, 24);
            this.картиныToolStripMenuItem.Text = "Картины";
            this.картиныToolStripMenuItem.Click += new System.EventHandler(this.картиныToolStripMenuItem_Click);
            // 
            // историяToolStripMenuItem
            // 
            this.историяToolStripMenuItem.Name = "историяToolStripMenuItem";
            this.историяToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
            this.историяToolStripMenuItem.Text = "История";
            // 
            // выставкиToolStripMenuItem
            // 
            this.выставкиToolStripMenuItem.Name = "выставкиToolStripMenuItem";
            this.выставкиToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            this.выставкиToolStripMenuItem.Text = "Выставки";
            // 
            // сотрудникиToolStripMenuItem
            // 
            this.сотрудникиToolStripMenuItem.Name = "сотрудникиToolStripMenuItem";
            this.сотрудникиToolStripMenuItem.Size = new System.Drawing.Size(105, 24);
            this.сотрудникиToolStripMenuItem.Text = "Сотрудники";
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(101, 24);
            this.отчетыToolStripMenuItem.Text = "Должности";
            this.отчетыToolStripMenuItem.Click += new System.EventHandler(this.отчетыToolStripMenuItem_Click);
            // 
            // праваСотрудникаToolStripMenuItem
            // 
            this.праваСотрудникаToolStripMenuItem.Name = "праваСотрудникаToolStripMenuItem";
            this.праваСотрудникаToolStripMenuItem.Size = new System.Drawing.Size(150, 24);
            this.праваСотрудникаToolStripMenuItem.Text = "Права сотрудника";
            // 
            // отчетToolStripMenuItem
            // 
            this.отчетToolStripMenuItem.Name = "отчетToolStripMenuItem";
            this.отчетToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.отчетToolStripMenuItem.Text = "Отчет";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(59, 96);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Main Window";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem картиныToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem историяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выставкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сотрудникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem праваСотрудникаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}
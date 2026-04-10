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
            this.должностиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.просмотретьОтчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сформироватьОтчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.авторыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.жанрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.доступыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
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
            this.должностиToolStripMenuItem,
            this.отчетToolStripMenuItem,
            this.авторыToolStripMenuItem,
            this.жанрыToolStripMenuItem,
            this.доступыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1114, 28);
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
            this.историяToolStripMenuItem.Click += new System.EventHandler(this.историяToolStripMenuItem_Click);
            // 
            // выставкиToolStripMenuItem
            // 
            this.выставкиToolStripMenuItem.Name = "выставкиToolStripMenuItem";
            this.выставкиToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            this.выставкиToolStripMenuItem.Text = "Выставки";
            this.выставкиToolStripMenuItem.Click += new System.EventHandler(this.выставкиToolStripMenuItem_Click);
            // 
            // сотрудникиToolStripMenuItem
            // 
            this.сотрудникиToolStripMenuItem.Name = "сотрудникиToolStripMenuItem";
            this.сотрудникиToolStripMenuItem.Size = new System.Drawing.Size(105, 24);
            this.сотрудникиToolStripMenuItem.Text = "Сотрудники";
            this.сотрудникиToolStripMenuItem.Click += new System.EventHandler(this.сотрудникиToolStripMenuItem_Click);
            // 
            // должностиToolStripMenuItem
            // 
            this.должностиToolStripMenuItem.Name = "должностиToolStripMenuItem";
            this.должностиToolStripMenuItem.Size = new System.Drawing.Size(101, 24);
            this.должностиToolStripMenuItem.Text = "Должности";
            this.должностиToolStripMenuItem.Click += new System.EventHandler(this.отчетыToolStripMenuItem_Click);
            // 
            // отчетToolStripMenuItem
            // 
            this.отчетToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.просмотретьОтчетыToolStripMenuItem,
            this.сформироватьОтчетToolStripMenuItem});
            this.отчетToolStripMenuItem.Name = "отчетToolStripMenuItem";
            this.отчетToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.отчетToolStripMenuItem.Text = "Отчет";
            this.отчетToolStripMenuItem.Click += new System.EventHandler(this.отчетToolStripMenuItem_Click);
            // 
            // просмотретьОтчетыToolStripMenuItem
            // 
            this.просмотретьОтчетыToolStripMenuItem.Name = "просмотретьОтчетыToolStripMenuItem";
            this.просмотретьОтчетыToolStripMenuItem.Size = new System.Drawing.Size(257, 26);
            this.просмотретьОтчетыToolStripMenuItem.Text = "Отчет по реставрациям";
            this.просмотретьОтчетыToolStripMenuItem.Click += new System.EventHandler(this.просмотретьОтчетыToolStripMenuItem_Click);
            // 
            // сформироватьОтчетToolStripMenuItem
            // 
            this.сформироватьОтчетToolStripMenuItem.Name = "сформироватьОтчетToolStripMenuItem";
            this.сформироватьОтчетToolStripMenuItem.Size = new System.Drawing.Size(257, 26);
            this.сформироватьОтчетToolStripMenuItem.Text = "Отчет по экспозициям";
            this.сформироватьОтчетToolStripMenuItem.Click += new System.EventHandler(this.сформироватьОтчетToolStripMenuItem_Click);
            // 
            // авторыToolStripMenuItem
            // 
            this.авторыToolStripMenuItem.Name = "авторыToolStripMenuItem";
            this.авторыToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.авторыToolStripMenuItem.Text = "Авторы";
            this.авторыToolStripMenuItem.Click += new System.EventHandler(this.авторыToolStripMenuItem_Click);
            // 
            // жанрыToolStripMenuItem
            // 
            this.жанрыToolStripMenuItem.Name = "жанрыToolStripMenuItem";
            this.жанрыToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.жанрыToolStripMenuItem.Text = "Жанры";
            this.жанрыToolStripMenuItem.Click += new System.EventHandler(this.жанрыToolStripMenuItem_Click);
            // 
            // доступыToolStripMenuItem
            // 
            this.доступыToolStripMenuItem.Name = "доступыToolStripMenuItem";
            this.доступыToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
            this.доступыToolStripMenuItem.Text = "Доступы";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 520);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Main Window";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem картиныToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem историяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выставкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сотрудникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem должностиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem просмотретьОтчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сформироватьОтчетToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem авторыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem жанрыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem доступыToolStripMenuItem;
    }
}
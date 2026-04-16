namespace GalleryApp
{
    partial class ListWindow
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
            this.labelList = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.comboBoxFilterBy = new System.Windows.Forms.ComboBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonClearSearch = new System.Windows.Forms.Button();
            this.labelSearch = new System.Windows.Forms.Label();
            this.labelFilter = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelList
            // 
            this.labelList.AutoSize = true;
            this.labelList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelList.Location = new System.Drawing.Point(33, 24);
            this.labelList.Name = "labelList";
            this.labelList.Size = new System.Drawing.Size(84, 25);
            this.labelList.TabIndex = 0;
            this.labelList.Text = "Список";
            this.labelList.Click += new System.EventHandler(this.labelList_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(35, 105);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(948, 458);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1013, 105);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 37);
            this.button1.TabIndex = 2;
            this.button1.Text = "Добавление";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1013, 148);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(131, 37);
            this.button2.TabIndex = 3;
            this.button2.Text = "Удаление";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1013, 191);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(131, 37);
            this.button3.TabIndex = 4;
            this.button3.Text = "Редактирование";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(91, 66);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(210, 22);
            this.textBoxSearch.TabIndex = 6;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // comboBoxFilterBy
            // 
            this.comboBoxFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFilterBy.FormattingEnabled = true;
            this.comboBoxFilterBy.Location = new System.Drawing.Point(382, 66);
            this.comboBoxFilterBy.Name = "comboBoxFilterBy";
            this.comboBoxFilterBy.Size = new System.Drawing.Size(120, 24);
            this.comboBoxFilterBy.TabIndex = 8;
            this.comboBoxFilterBy.SelectedIndexChanged += new System.EventHandler(this.comboBoxFilterBy_SelectedIndexChanged);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(508, 67);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(65, 25);
            this.buttonSearch.TabIndex = 9;
            this.buttonSearch.Text = "Найти";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonClearSearch
            // 
            this.buttonClearSearch.Location = new System.Drawing.Point(579, 67);
            this.buttonClearSearch.Name = "buttonClearSearch";
            this.buttonClearSearch.Size = new System.Drawing.Size(69, 25);
            this.buttonClearSearch.TabIndex = 10;
            this.buttonClearSearch.Text = "Сброс";
            this.buttonClearSearch.UseVisualStyleBackColor = true;
            this.buttonClearSearch.Click += new System.EventHandler(this.buttonClearSearch_Click);
            // 
            // labelSearch
            // 
            this.labelSearch.AutoSize = true;
            this.labelSearch.Location = new System.Drawing.Point(35, 69);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(50, 16);
            this.labelSearch.TabIndex = 5;
            this.labelSearch.Text = "Поиск:";
            this.labelSearch.Click += new System.EventHandler(this.labelSearch_Click);
            // 
            // labelFilter
            // 
            this.labelFilter.AutoSize = true;
            this.labelFilter.Location = new System.Drawing.Point(307, 69);
            this.labelFilter.Name = "labelFilter";
            this.labelFilter.Size = new System.Drawing.Size(69, 16);
            this.labelFilter.TabIndex = 7;
            this.labelFilter.Text = "Поиск по:";
            this.labelFilter.Click += new System.EventHandler(this.labelFilter_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(860, 66);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(91, 23);
            this.button4.TabIndex = 11;
            this.button4.Text = "Применить";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(719, 67);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(135, 24);
            this.comboBox1.TabIndex = 12;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(654, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Фильтр:";
            // 
            // ListWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 589);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.buttonClearSearch);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.comboBoxFilterBy);
            this.Controls.Add(this.labelFilter);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.labelSearch);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.labelList);
            this.Name = "ListWindow";
            this.Text = "ListWindow";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ListWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelList;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.ComboBox comboBoxFilterBy;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonClearSearch;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.Label labelFilter;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
    }
}
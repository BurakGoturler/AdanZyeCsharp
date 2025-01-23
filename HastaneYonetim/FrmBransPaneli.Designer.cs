namespace HastaneYonetim
{
    partial class FrmBransPaneli
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBransPaneli));
            this.BtnBransSil = new System.Windows.Forms.Button();
            this.BtnBransGuncelle = new System.Windows.Forms.Button();
            this.BtnBransEkle = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.TxtBrans = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnBransSil
            // 
            this.BtnBransSil.BackColor = System.Drawing.Color.LightCoral;
            this.BtnBransSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnBransSil.Location = new System.Drawing.Point(267, 154);
            this.BtnBransSil.Name = "BtnBransSil";
            this.BtnBransSil.Size = new System.Drawing.Size(98, 45);
            this.BtnBransSil.TabIndex = 3;
            this.BtnBransSil.Text = "Sil";
            this.BtnBransSil.UseVisualStyleBackColor = false;
            this.BtnBransSil.Click += new System.EventHandler(this.BtnBransSil_Click);
            // 
            // BtnBransGuncelle
            // 
            this.BtnBransGuncelle.BackColor = System.Drawing.Color.SpringGreen;
            this.BtnBransGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnBransGuncelle.Location = new System.Drawing.Point(208, 205);
            this.BtnBransGuncelle.Name = "BtnBransGuncelle";
            this.BtnBransGuncelle.Size = new System.Drawing.Size(98, 45);
            this.BtnBransGuncelle.TabIndex = 4;
            this.BtnBransGuncelle.Text = "Güncelle";
            this.BtnBransGuncelle.UseVisualStyleBackColor = false;
            this.BtnBransGuncelle.Click += new System.EventHandler(this.BtnBransGuncelle_Click);
            // 
            // BtnBransEkle
            // 
            this.BtnBransEkle.BackColor = System.Drawing.Color.CornflowerBlue;
            this.BtnBransEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnBransEkle.Location = new System.Drawing.Point(151, 154);
            this.BtnBransEkle.Name = "BtnBransEkle";
            this.BtnBransEkle.Size = new System.Drawing.Size(98, 45);
            this.BtnBransEkle.TabIndex = 2;
            this.BtnBransEkle.Text = "Ekle";
            this.BtnBransEkle.UseVisualStyleBackColor = false;
            this.BtnBransEkle.Click += new System.EventHandler(this.BtnBransEkle_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(385, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(581, 277);
            this.dataGridView1.TabIndex = 35;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // TxtBrans
            // 
            this.TxtBrans.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtBrans.Location = new System.Drawing.Point(149, 101);
            this.TxtBrans.Name = "TxtBrans";
            this.TxtBrans.Size = new System.Drawing.Size(216, 30);
            this.TxtBrans.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(42, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 25);
            this.label2.TabIndex = 28;
            this.label2.Text = "Branş Ad:";
            // 
            // TxtId
            // 
            this.TxtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtId.Location = new System.Drawing.Point(149, 59);
            this.TxtId.Name = "TxtId";
            this.TxtId.Size = new System.Drawing.Size(216, 30);
            this.TxtId.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(53, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 25);
            this.label1.TabIndex = 26;
            this.label1.Text = "Branş Id:";
            // 
            // FrmBransPaneli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(978, 339);
            this.Controls.Add(this.BtnBransSil);
            this.Controls.Add(this.BtnBransGuncelle);
            this.Controls.Add(this.BtnBransEkle);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.TxtBrans);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtId);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "FrmBransPaneli";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Branş Paneli";
            this.Load += new System.EventHandler(this.FrmBransPaneli_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnBransSil;
        private System.Windows.Forms.Button BtnBransGuncelle;
        private System.Windows.Forms.Button BtnBransEkle;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox TxtBrans;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtId;
        private System.Windows.Forms.Label label1;
    }
}
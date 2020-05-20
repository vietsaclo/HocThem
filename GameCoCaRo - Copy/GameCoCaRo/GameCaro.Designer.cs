namespace GameCoCaRo
{
    partial class GameCaro
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNguoiChoiA = new System.Windows.Forms.TextBox();
            this.tbNguoiChoiB = new System.Windows.Forms.TextBox();
            this.btnBatDau = new System.Windows.Forms.Button();
            this.btnChoiLai = new System.Windows.Forms.Button();
            this.pnBanCo = new System.Windows.Forms.Panel();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nguoi Choi A:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nguoi Choi B:";
            // 
            // tbNguoiChoiA
            // 
            this.tbNguoiChoiA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNguoiChoiA.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.tbNguoiChoiA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNguoiChoiA.ForeColor = System.Drawing.SystemColors.InfoText;
            this.tbNguoiChoiA.Location = new System.Drawing.Point(110, 17);
            this.tbNguoiChoiA.Name = "tbNguoiChoiA";
            this.tbNguoiChoiA.Size = new System.Drawing.Size(329, 20);
            this.tbNguoiChoiA.TabIndex = 1;
            this.tbNguoiChoiA.Text = "Nguoi Choi A";
            // 
            // tbNguoiChoiB
            // 
            this.tbNguoiChoiB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNguoiChoiB.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.tbNguoiChoiB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNguoiChoiB.ForeColor = System.Drawing.SystemColors.InfoText;
            this.tbNguoiChoiB.Location = new System.Drawing.Point(110, 42);
            this.tbNguoiChoiB.Name = "tbNguoiChoiB";
            this.tbNguoiChoiB.Size = new System.Drawing.Size(329, 20);
            this.tbNguoiChoiB.TabIndex = 3;
            this.tbNguoiChoiB.Text = "Nguoi Choi B";
            // 
            // btnBatDau
            // 
            this.btnBatDau.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatDau.Location = new System.Drawing.Point(445, 17);
            this.btnBatDau.Name = "btnBatDau";
            this.btnBatDau.Size = new System.Drawing.Size(75, 45);
            this.btnBatDau.TabIndex = 4;
            this.btnBatDau.Text = "Bat Dau";
            this.btnBatDau.UseVisualStyleBackColor = true;
            this.btnBatDau.Click += new System.EventHandler(this.btnBatDau_Click);
            // 
            // btnChoiLai
            // 
            this.btnChoiLai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChoiLai.Enabled = false;
            this.btnChoiLai.Location = new System.Drawing.Point(526, 17);
            this.btnChoiLai.Name = "btnChoiLai";
            this.btnChoiLai.Size = new System.Drawing.Size(75, 45);
            this.btnChoiLai.TabIndex = 5;
            this.btnChoiLai.Text = "Choi Lai";
            this.btnChoiLai.UseVisualStyleBackColor = true;
            this.btnChoiLai.Click += new System.EventHandler(this.btnChoiLai_Click);
            // 
            // pnBanCo
            // 
            this.pnBanCo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnBanCo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnBanCo.Location = new System.Drawing.Point(24, 81);
            this.pnBanCo.Name = "pnBanCo";
            this.pnBanCo.Size = new System.Drawing.Size(573, 282);
            this.pnBanCo.TabIndex = 6;
            // 
            // progress
            // 
            this.progress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progress.Location = new System.Drawing.Point(24, 370);
            this.progress.Maximum = 30;
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(573, 23);
            this.progress.Step = 1;
            this.progress.TabIndex = 7;
            // 
            // GameCaro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 404);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.pnBanCo);
            this.Controls.Add(this.btnChoiLai);
            this.Controls.Add(this.btnBatDau);
            this.Controls.Add(this.tbNguoiChoiB);
            this.Controls.Add(this.tbNguoiChoiA);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "GameCaro";
            this.Text = "Game Caro";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNguoiChoiA;
        private System.Windows.Forms.TextBox tbNguoiChoiB;
        private System.Windows.Forms.Button btnBatDau;
        private System.Windows.Forms.Button btnChoiLai;
        private System.Windows.Forms.Panel pnBanCo;
        private System.Windows.Forms.ProgressBar progress;
    }
}


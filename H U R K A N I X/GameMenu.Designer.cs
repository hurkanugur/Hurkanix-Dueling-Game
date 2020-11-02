namespace H_U_R_K_A_N_I_X
{
    partial class GameMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameMenu));
            this.Oyun_Butonu_1 = new System.Windows.Forms.Button();
            this.Exit_Yazi = new System.Windows.Forms.Label();
            this.Exit_Button = new System.Windows.Forms.PictureBox();
            this.Renk_Timer = new System.Windows.Forms.Timer(this.components);
            this.Oyun_Butonu_2 = new System.Windows.Forms.Button();
            this.Useful_Yazi = new System.Windows.Forms.Label();
            this.Useful_Button = new System.Windows.Forms.PictureBox();
            this.Oyuncu1_TextBox = new System.Windows.Forms.TextBox();
            this.Oyuncu2_TextBox = new System.Windows.Forms.TextBox();
            this.Start_Button = new System.Windows.Forms.Button();
            this.WMP1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.Oyun_Turu_Label = new System.Windows.Forms.Label();
            this.Sol_Yan = new System.Windows.Forms.Label();
            this.Sag_Yan = new System.Windows.Forms.Label();
            this.Tavan = new System.Windows.Forms.Label();
            this.Taban = new System.Windows.Forms.Label();
            this.Uyari = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Exit_Button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Useful_Button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WMP1)).BeginInit();
            this.SuspendLayout();
            // 
            // Oyun_Butonu_1
            // 
            this.Oyun_Butonu_1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Oyun_Butonu_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Oyun_Butonu_1.Font = new System.Drawing.Font("Arial Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Oyun_Butonu_1.ForeColor = System.Drawing.Color.Aqua;
            this.Oyun_Butonu_1.Location = new System.Drawing.Point(89, 101);
            this.Oyun_Butonu_1.Margin = new System.Windows.Forms.Padding(4);
            this.Oyun_Butonu_1.Name = "Oyun_Butonu_1";
            this.Oyun_Butonu_1.Size = new System.Drawing.Size(253, 43);
            this.Oyun_Butonu_1.TabIndex = 0;
            this.Oyun_Butonu_1.Text = "Player   vs   Player";
            this.Oyun_Butonu_1.UseVisualStyleBackColor = false;
            this.Oyun_Butonu_1.Click += new System.EventHandler(this.Oyun_Butonu_1_Click);
            // 
            // Exit_Yazi
            // 
            this.Exit_Yazi.AutoSize = true;
            this.Exit_Yazi.Cursor = System.Windows.Forms.Cursors.PanNW;
            this.Exit_Yazi.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Exit_Yazi.ForeColor = System.Drawing.Color.Aqua;
            this.Exit_Yazi.Location = new System.Drawing.Point(365, 60);
            this.Exit_Yazi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Exit_Yazi.Name = "Exit_Yazi";
            this.Exit_Yazi.Size = new System.Drawing.Size(65, 22);
            this.Exit_Yazi.TabIndex = 155;
            this.Exit_Yazi.Text = "E X I T";
            // 
            // Exit_Button
            // 
            this.Exit_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Exit_Button.Location = new System.Drawing.Point(362, 10);
            this.Exit_Button.Margin = new System.Windows.Forms.Padding(4);
            this.Exit_Button.Name = "Exit_Button";
            this.Exit_Button.Size = new System.Drawing.Size(55, 48);
            this.Exit_Button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Exit_Button.TabIndex = 154;
            this.Exit_Button.TabStop = false;
            this.Exit_Button.Click += new System.EventHandler(this.Exit_Buton_Click);
            // 
            // Renk_Timer
            // 
            this.Renk_Timer.Interval = 50;
            this.Renk_Timer.Tick += new System.EventHandler(this.Renk_Timer_Yeri);
            // 
            // Oyun_Butonu_2
            // 
            this.Oyun_Butonu_2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Oyun_Butonu_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Oyun_Butonu_2.Font = new System.Drawing.Font("Arial Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Oyun_Butonu_2.ForeColor = System.Drawing.Color.Aqua;
            this.Oyun_Butonu_2.Location = new System.Drawing.Point(89, 170);
            this.Oyun_Butonu_2.Margin = new System.Windows.Forms.Padding(4);
            this.Oyun_Butonu_2.Name = "Oyun_Butonu_2";
            this.Oyun_Butonu_2.Size = new System.Drawing.Size(253, 43);
            this.Oyun_Butonu_2.TabIndex = 156;
            this.Oyun_Butonu_2.Text = " Player   vs      AI     ";
            this.Oyun_Butonu_2.UseVisualStyleBackColor = false;
            this.Oyun_Butonu_2.Click += new System.EventHandler(this.Oyun_Butonu_2_Click);
            // 
            // Useful_Yazi
            // 
            this.Useful_Yazi.AutoSize = true;
            this.Useful_Yazi.Cursor = System.Windows.Forms.Cursors.PanNW;
            this.Useful_Yazi.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Useful_Yazi.ForeColor = System.Drawing.Color.Aqua;
            this.Useful_Yazi.Location = new System.Drawing.Point(14, 60);
            this.Useful_Yazi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Useful_Yazi.Name = "Useful_Yazi";
            this.Useful_Yazi.Size = new System.Drawing.Size(70, 22);
            this.Useful_Yazi.TabIndex = 158;
            this.Useful_Yazi.Text = "H E L P";
            // 
            // Useful_Button
            // 
            this.Useful_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Useful_Button.Location = new System.Drawing.Point(8, 10);
            this.Useful_Button.Margin = new System.Windows.Forms.Padding(4);
            this.Useful_Button.Name = "Useful_Button";
            this.Useful_Button.Size = new System.Drawing.Size(68, 52);
            this.Useful_Button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Useful_Button.TabIndex = 157;
            this.Useful_Button.TabStop = false;
            this.Useful_Button.Click += new System.EventHandler(this.Useful_Button_Yeri);
            // 
            // Oyuncu1_TextBox
            // 
            this.Oyuncu1_TextBox.BackColor = System.Drawing.Color.Navy;
            this.Oyuncu1_TextBox.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Oyuncu1_TextBox.ForeColor = System.Drawing.Color.Aqua;
            this.Oyuncu1_TextBox.Location = new System.Drawing.Point(89, 101);
            this.Oyuncu1_TextBox.Margin = new System.Windows.Forms.Padding(4);
            this.Oyuncu1_TextBox.MaxLength = 10;
            this.Oyuncu1_TextBox.Name = "Oyuncu1_TextBox";
            this.Oyuncu1_TextBox.Size = new System.Drawing.Size(252, 36);
            this.Oyuncu1_TextBox.TabIndex = 159;
            this.Oyuncu1_TextBox.Text = "KULLANICI ADI [1]";
            this.Oyuncu1_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Oyuncu1_TextBox.Visible = false;
            this.Oyuncu1_TextBox.Click += new System.EventHandler(this.Oyuncu1_TextBox_Click);
            // 
            // Oyuncu2_TextBox
            // 
            this.Oyuncu2_TextBox.BackColor = System.Drawing.Color.Navy;
            this.Oyuncu2_TextBox.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Oyuncu2_TextBox.ForeColor = System.Drawing.Color.Aqua;
            this.Oyuncu2_TextBox.Location = new System.Drawing.Point(89, 170);
            this.Oyuncu2_TextBox.Margin = new System.Windows.Forms.Padding(4);
            this.Oyuncu2_TextBox.MaxLength = 10;
            this.Oyuncu2_TextBox.Name = "Oyuncu2_TextBox";
            this.Oyuncu2_TextBox.Size = new System.Drawing.Size(252, 36);
            this.Oyuncu2_TextBox.TabIndex = 160;
            this.Oyuncu2_TextBox.Text = "KULLANICI ADI [2]";
            this.Oyuncu2_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Oyuncu2_TextBox.Visible = false;
            this.Oyuncu2_TextBox.Click += new System.EventHandler(this.Oyuncu2_TextBox_Click);
            // 
            // Start_Button
            // 
            this.Start_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Start_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Start_Button.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Start_Button.ForeColor = System.Drawing.Color.Aqua;
            this.Start_Button.Location = new System.Drawing.Point(137, 235);
            this.Start_Button.Margin = new System.Windows.Forms.Padding(4);
            this.Start_Button.Name = "Start_Button";
            this.Start_Button.Size = new System.Drawing.Size(154, 43);
            this.Start_Button.TabIndex = 161;
            this.Start_Button.Text = "S T A R T";
            this.Start_Button.UseVisualStyleBackColor = false;
            this.Start_Button.Visible = false;
            this.Start_Button.Click += new System.EventHandler(this.Start_Button_Click);
            // 
            // WMP1
            // 
            this.WMP1.Enabled = true;
            this.WMP1.Location = new System.Drawing.Point(11, 168);
            this.WMP1.Margin = new System.Windows.Forms.Padding(4);
            this.WMP1.Name = "WMP1";
            this.WMP1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("WMP1.OcxState")));
            this.WMP1.Size = new System.Drawing.Size(38, 36);
            this.WMP1.TabIndex = 162;
            this.WMP1.Visible = false;
            // 
            // Oyun_Turu_Label
            // 
            this.Oyun_Turu_Label.Cursor = System.Windows.Forms.Cursors.PanNW;
            this.Oyun_Turu_Label.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Oyun_Turu_Label.ForeColor = System.Drawing.Color.Aqua;
            this.Oyun_Turu_Label.Location = new System.Drawing.Point(85, 12);
            this.Oyun_Turu_Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Oyun_Turu_Label.Name = "Oyun_Turu_Label";
            this.Oyun_Turu_Label.Size = new System.Drawing.Size(260, 47);
            this.Oyun_Turu_Label.TabIndex = 163;
            this.Oyun_Turu_Label.Text = "Oyun Turu";
            this.Oyun_Turu_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Oyun_Turu_Label.Visible = false;
            // 
            // Sol_Yan
            // 
            this.Sol_Yan.BackColor = System.Drawing.Color.Aqua;
            this.Sol_Yan.ForeColor = System.Drawing.Color.Aqua;
            this.Sol_Yan.Location = new System.Drawing.Point(0, 0);
            this.Sol_Yan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Sol_Yan.Name = "Sol_Yan";
            this.Sol_Yan.Size = new System.Drawing.Size(9, 294);
            this.Sol_Yan.TabIndex = 167;
            // 
            // Sag_Yan
            // 
            this.Sag_Yan.BackColor = System.Drawing.Color.Aqua;
            this.Sag_Yan.ForeColor = System.Drawing.Color.Aqua;
            this.Sag_Yan.Location = new System.Drawing.Point(417, 0);
            this.Sag_Yan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Sag_Yan.Name = "Sag_Yan";
            this.Sag_Yan.Size = new System.Drawing.Size(9, 294);
            this.Sag_Yan.TabIndex = 168;
            // 
            // Tavan
            // 
            this.Tavan.BackColor = System.Drawing.Color.Aqua;
            this.Tavan.ForeColor = System.Drawing.Color.Aqua;
            this.Tavan.Location = new System.Drawing.Point(0, 0);
            this.Tavan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Tavan.Name = "Tavan";
            this.Tavan.Size = new System.Drawing.Size(426, 9);
            this.Tavan.TabIndex = 169;
            // 
            // Taban
            // 
            this.Taban.BackColor = System.Drawing.Color.Aqua;
            this.Taban.ForeColor = System.Drawing.Color.Aqua;
            this.Taban.Location = new System.Drawing.Point(0, 283);
            this.Taban.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Taban.Name = "Taban";
            this.Taban.Size = new System.Drawing.Size(426, 9);
            this.Taban.TabIndex = 170;
            // 
            // Uyari
            // 
            this.Uyari.Cursor = System.Windows.Forms.Cursors.PanNW;
            this.Uyari.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Uyari.ForeColor = System.Drawing.Color.Red;
            this.Uyari.Location = new System.Drawing.Point(85, 10);
            this.Uyari.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Uyari.Name = "Uyari";
            this.Uyari.Size = new System.Drawing.Size(260, 88);
            this.Uyari.TabIndex = 171;
            this.Uyari.Text = "UYARI MESAJI";
            this.Uyari.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Uyari.Visible = false;
            // 
            // GameMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(426, 292);
            this.ControlBox = false;
            this.Controls.Add(this.Uyari);
            this.Controls.Add(this.Taban);
            this.Controls.Add(this.Tavan);
            this.Controls.Add(this.Sag_Yan);
            this.Controls.Add(this.Sol_Yan);
            this.Controls.Add(this.Oyun_Turu_Label);
            this.Controls.Add(this.WMP1);
            this.Controls.Add(this.Start_Button);
            this.Controls.Add(this.Oyuncu2_TextBox);
            this.Controls.Add(this.Oyuncu1_TextBox);
            this.Controls.Add(this.Useful_Yazi);
            this.Controls.Add(this.Useful_Button);
            this.Controls.Add(this.Oyun_Butonu_2);
            this.Controls.Add(this.Exit_Yazi);
            this.Controls.Add(this.Exit_Button);
            this.Controls.Add(this.Oyun_Butonu_1);
            this.Cursor = System.Windows.Forms.Cursors.PanNW;
            this.Font = new System.Drawing.Font("Arial Black", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "H U R K A N I X";
            this.Load += new System.EventHandler(this.GameMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Exit_Button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Useful_Button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WMP1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Oyun_Butonu_1;
        private System.Windows.Forms.Label Exit_Yazi;
        private System.Windows.Forms.PictureBox Exit_Button;
        private System.Windows.Forms.Timer Renk_Timer;
        private System.Windows.Forms.Button Oyun_Butonu_2;
        private System.Windows.Forms.Label Useful_Yazi;
        private System.Windows.Forms.PictureBox Useful_Button;
        private System.Windows.Forms.TextBox Oyuncu1_TextBox;
        private System.Windows.Forms.TextBox Oyuncu2_TextBox;
        private System.Windows.Forms.Button Start_Button;
        private AxWMPLib.AxWindowsMediaPlayer WMP1;
        public System.Windows.Forms.Label Oyun_Turu_Label;
        private System.Windows.Forms.Label Sol_Yan;
        private System.Windows.Forms.Label Sag_Yan;
        private System.Windows.Forms.Label Tavan;
        private System.Windows.Forms.Label Taban;
        public System.Windows.Forms.Label Uyari;
    }
}
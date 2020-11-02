namespace H_U_R_K_A_N_I_X
{
    partial class GameHelp
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
            this.Close_Button = new System.Windows.Forms.Button();
            this.How_To_Play = new System.Windows.Forms.PictureBox();
            this.Sag_Yan = new System.Windows.Forms.Label();
            this.Sol_Yan = new System.Windows.Forms.Label();
            this.Taban = new System.Windows.Forms.Label();
            this.Tavan = new System.Windows.Forms.Label();
            this.Renk_Timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.How_To_Play)).BeginInit();
            this.SuspendLayout();
            // 
            // Close_Button
            // 
            this.Close_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Close_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Close_Button.Font = new System.Drawing.Font("Arial Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Close_Button.ForeColor = System.Drawing.Color.Aqua;
            this.Close_Button.Location = new System.Drawing.Point(429, 23);
            this.Close_Button.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.Close_Button.Name = "Close_Button";
            this.Close_Button.Size = new System.Drawing.Size(253, 43);
            this.Close_Button.TabIndex = 2;
            this.Close_Button.Text = "C L O S E";
            this.Close_Button.UseVisualStyleBackColor = false;
            this.Close_Button.Click += new System.EventHandler(this.Close_Button_Click);
            // 
            // How_To_Play
            // 
            this.How_To_Play.Location = new System.Drawing.Point(12, 73);
            this.How_To_Play.Name = "How_To_Play";
            this.How_To_Play.Size = new System.Drawing.Size(1086, 461);
            this.How_To_Play.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.How_To_Play.TabIndex = 3;
            this.How_To_Play.TabStop = false;
            // 
            // Sag_Yan
            // 
            this.Sag_Yan.BackColor = System.Drawing.Color.Aqua;
            this.Sag_Yan.ForeColor = System.Drawing.Color.Aqua;
            this.Sag_Yan.Location = new System.Drawing.Point(1101, 0);
            this.Sag_Yan.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Sag_Yan.Name = "Sag_Yan";
            this.Sag_Yan.Size = new System.Drawing.Size(9, 546);
            this.Sag_Yan.TabIndex = 169;
            // 
            // Sol_Yan
            // 
            this.Sol_Yan.BackColor = System.Drawing.Color.Aqua;
            this.Sol_Yan.ForeColor = System.Drawing.Color.Aqua;
            this.Sol_Yan.Location = new System.Drawing.Point(0, 0);
            this.Sol_Yan.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Sol_Yan.Name = "Sol_Yan";
            this.Sol_Yan.Size = new System.Drawing.Size(9, 546);
            this.Sol_Yan.TabIndex = 170;
            // 
            // Taban
            // 
            this.Taban.BackColor = System.Drawing.Color.Aqua;
            this.Taban.ForeColor = System.Drawing.Color.Aqua;
            this.Taban.Location = new System.Drawing.Point(0, 537);
            this.Taban.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Taban.Name = "Taban";
            this.Taban.Size = new System.Drawing.Size(1110, 9);
            this.Taban.TabIndex = 171;
            // 
            // Tavan
            // 
            this.Tavan.BackColor = System.Drawing.Color.Aqua;
            this.Tavan.ForeColor = System.Drawing.Color.Aqua;
            this.Tavan.Location = new System.Drawing.Point(0, 0);
            this.Tavan.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Tavan.Name = "Tavan";
            this.Tavan.Size = new System.Drawing.Size(1110, 9);
            this.Tavan.TabIndex = 172;
            // 
            // Renk_Timer
            // 
            this.Renk_Timer.Enabled = true;
            this.Renk_Timer.Interval = 50;
            this.Renk_Timer.Tick += new System.EventHandler(this.Renk_Timer_Tick);
            // 
            // GameHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Navy;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1110, 546);
            this.Controls.Add(this.Tavan);
            this.Controls.Add(this.Taban);
            this.Controls.Add(this.Sol_Yan);
            this.Controls.Add(this.Sag_Yan);
            this.Controls.Add(this.How_To_Play);
            this.Controls.Add(this.Close_Button);
            this.Cursor = System.Windows.Forms.Cursors.PanNW;
            this.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameHelp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "H U R K A N I X";
            this.Load += new System.EventHandler(this.GameHelp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.How_To_Play)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Close_Button;
        private System.Windows.Forms.PictureBox How_To_Play;
        private System.Windows.Forms.Label Sag_Yan;
        private System.Windows.Forms.Label Sol_Yan;
        private System.Windows.Forms.Label Taban;
        private System.Windows.Forms.Label Tavan;
        private System.Windows.Forms.Timer Renk_Timer;
    }
}
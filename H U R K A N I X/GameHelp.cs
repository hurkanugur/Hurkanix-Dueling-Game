using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace H_U_R_K_A_N_I_X
{
    public partial class GameHelp : Form
    {
        public GameHelp()
        {
            InitializeComponent();
        }

        private void GameHelp_Load(object sender, EventArgs e)
        {
            How_To_Play.ImageLocation = "Hurkanix Settings//Help.png";
            How_To_Play.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Icon = Icon.ExtractAssociatedIcon("Hurkanix Settings//Hurkanix.ico");
        }

        private Random Rengarenk = new Random();
        private void Renk_Timer_Tick(object sender, EventArgs e)
        {
            Close_Button.ForeColor = Tavan.BackColor = Sag_Yan.BackColor = Taban.BackColor = Sol_Yan.BackColor = Color.FromArgb(Rengarenk.Next(0, 256), Rengarenk.Next(0, 256), Rengarenk.Next(0, 256));
        }

        private void Close_Button_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Renk_Timer.Enabled = false;
        }
    }
}

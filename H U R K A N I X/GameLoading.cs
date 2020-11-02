using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace H_U_R_K_A_N_I_X
{
    public partial class GameLoading : Form
    {
        public GameLoading()
        {
            KeyPreview = true;
            InitializeComponent();
        }

        private void GameLoading_Load(object sender, EventArgs e)
        {
            Renk_Timer.Enabled = true;
            this.Icon = Icon.ExtractAssociatedIcon("Hurkanix Settings//Hurkanix.ico");
        }

        private Random Rengarenk = new Random();
        private void Renk_Timer_Tick(object sender, EventArgs e)
        {
            Game_Loading_Bar.ForeColor = Tavan.BackColor = Sag_Yan.BackColor = Taban.BackColor = Sol_Yan.BackColor = Color.FromArgb(Rengarenk.Next(0, 256), Rengarenk.Next(0, 256), Rengarenk.Next(0, 256));
            if (Game_Loading_Bar.Value != 100)
            {
                if (Game_Loading_Bar.Value <= 96)
                    Game_Loading_Bar.Value += 4;
                else
                    Game_Loading_Bar.Value = 100;
            }
            else if (Game_Loading_Bar.Value == 100)
            {
                GameMenu YeniOyun = new GameMenu();
                //Buraya Dispose Yerine Hide Dedik Cunku Ana Ekran Bu !!!
                this.Hide();
                Renk_Timer.Enabled = false;
                YeniOyun.Show();
            }
        }
    }
}

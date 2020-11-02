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
    public partial class GameOver : Form
    {
        public GameOver()
        {
            KeyPreview = true;
            InitializeComponent();
        }

        private void GameOver_Load(object sender, EventArgs e)
        {
            Renk_Timer.Enabled = true;
            this.Icon = Icon.ExtractAssociatedIcon("Hurkanix Settings//Hurkanix.ico");
        }

        private Random Rengarenk = new Random();
        private void Renk_Timer_Tick(object sender, EventArgs e)
        {
            Oyun_Sonu_Raporu.ForeColor = Play_Again_Button.ForeColor = Menu_Button.ForeColor = Exit_Button.ForeColor = Tavan.BackColor = Sag_Yan.BackColor = Taban.BackColor = Sol_Yan.BackColor = Color.FromArgb(Rengarenk.Next(0, 256), Rengarenk.Next(0, 256), Rengarenk.Next(0, 256));
        }

        private void Play_Again_Button_Click(object sender, EventArgs e)
        {
            if (Play_Again_Button.Text == "P L A Y   A G A I N")
            {
                if (GameMenu.Oyun_Turu_Erisim_String == "Player vs Player")
                {
                    GameMode1.GameMode1_Hide = true;
                    GameMode1 YeniOyun = new GameMode1();
                    this.Dispose();
                    Renk_Timer.Enabled = false;
                    YeniOyun.Show();
                }
                else if (GameMenu.Oyun_Turu_Erisim_String == "Dolores Umbridge")
                {
                    GameMode2.GameMode2_Hide = true;
                    GameMode2 YeniOyun = new GameMode2();
                    this.Dispose();
                    Renk_Timer.Enabled = false;
                    YeniOyun.Show();
                }
                else if (GameMenu.Oyun_Turu_Erisim_String == "Lord Voldemort")
                {
                    GameMode3.GameMode3_Hide = true;
                    GameMode3 YeniOyun = new GameMode3();
                    this.Dispose();
                    Renk_Timer.Enabled = false;
                    YeniOyun.Show();
                }
            }
            else if (Play_Again_Button.Text == "R E S U M E")
            {
                if (GameMenu.Oyun_Turu_Erisim_String == "Player vs Player")
                    GameMode1.Game_Paused = false;
                else if (GameMenu.Oyun_Turu_Erisim_String == "Dolores Umbridge")
                    GameMode2.Game_Paused = false;
                else if (GameMenu.Oyun_Turu_Erisim_String == "Lord Voldemort")
                    GameMode3.Game_Paused = false;
                this.Dispose();
            }
        }

        private void Menu_Button_Click(object sender, EventArgs e)
        {
            GameMenu YeniOyun = new GameMenu();
            this.Dispose();
            Renk_Timer.Enabled = false;
            YeniOyun.Show();

            if (GameMenu.Oyun_Turu_Erisim_String == "Player vs Player")
                GameMode1.GameMode1_Hide = true;
            if (GameMenu.Oyun_Turu_Erisim_String == "Dolores Umbridge")
                GameMode2.GameMode2_Hide = true;
            if (GameMenu.Oyun_Turu_Erisim_String == "Lord Voldemort")
                GameMode3.GameMode3_Hide = true;
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

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
    public partial class GameMenu : Form
    {
        public GameMenu()
        {
            KeyPreview = true;
            InitializeComponent();
        }

        public static string KullaniciAdi_Belirle_1 = "Kullanici Adi 1";
        public static string KullaniciAdi_Belirle_2 = "Kullanici Adi 2";
        private void GameMenu_Load(object sender, EventArgs e)
        {
            Renk_Timer.Enabled = true;
            WMP1.settings.volume = 100;
            WMP1.URL = "Hurkanix Settings//GameMenu.mp3";
            Exit_Button.ImageLocation = "Hurkanix Settings//Exit_Button.png";
            Useful_Button.ImageLocation = "Hurkanix Settings//Help_Button.png";
            this.Icon = Icon.ExtractAssociatedIcon("Hurkanix Settings//Hurkanix.ico");
        }

        private Random Rengarenk = new Random();
        public static string Oyun_Turu_Erisim_String;
        private void Renk_Timer_Yeri(object sender, EventArgs e)
        {
            //Renk Ayarlari
            WMP1.Ctlcontrols.play();
            Oyun_Butonu_1.ForeColor = Oyun_Butonu_2.ForeColor = Exit_Yazi.ForeColor = Tavan.BackColor = Sag_Yan.BackColor = Taban.BackColor = Sol_Yan.BackColor = Useful_Yazi.ForeColor = Oyuncu1_TextBox.ForeColor = Oyuncu2_TextBox.ForeColor = Start_Button.ForeColor = Color.FromArgb(Rengarenk.Next(0, 256), Rengarenk.Next(0, 256), Rengarenk.Next(0, 256));
            Oyun_Turu_Erisim_String = Oyun_Turu_Label.Text;

            //Oyuncu Ad Belirleme Yeri
            KullaniciAdi_Belirle_1 = Oyuncu1_TextBox.Text;
            KullaniciAdi_Belirle_2 = Oyuncu2_TextBox.Text;

            if (KullaniciAdi_Belirle_1 == "" || KullaniciAdi_Belirle_2 == "")
            {
                Uyari.Visible = true;
                Uyari.Text = "Lutfen Kullanici Adinizi Giriniz (En fazla 10 karakter icerebilir)";
            }
            else if (KullaniciAdi_Belirle_1 == KullaniciAdi_Belirle_2)
            {
                Uyari.Visible = true;
                Uyari.Text = "Lutfen Farkli Kullanici Adlari Seciniz !";
            }
            else if (Oyuncu1_TextBox.Text.ToLower().Contains('ç') || Oyuncu1_TextBox.Text.ToLower().Contains('ğ') || Oyuncu1_TextBox.Text.Contains('ı') || Oyuncu1_TextBox.Text.Contains('İ') || Oyuncu1_TextBox.Text.ToLower().Contains('ş') || Oyuncu1_TextBox.Text.ToLower().Contains('ö') || Oyuncu1_TextBox.Text.ToLower().Contains('ü') || Oyuncu2_TextBox.Text.ToLower().Contains('ç') || Oyuncu2_TextBox.Text.ToLower().Contains('ğ') || Oyuncu2_TextBox.Text.Contains('ı') || Oyuncu2_TextBox.Text.Contains('İ') || Oyuncu2_TextBox.Text.ToLower().Contains('ş') || Oyuncu2_TextBox.Text.ToLower().Contains('ö') || Oyuncu2_TextBox.Text.ToLower().Contains('ü'))
            {
                Uyari.Visible = true;
                Uyari.Text = "Lutfen Turkce Karakterler Kullanmayiniz !";
            }
            else if (Oyuncu1_TextBox.Text.StartsWith(" ") || Oyuncu2_TextBox.Text.StartsWith(" "))
            {
                Uyari.Visible = true;
                Uyari.Text = "Oyuncularin isimleri bosluk karakteriyle baslayamaz !";
            }
            else if (Oyuncu1_TextBox.Text.EndsWith(" ") || Oyuncu2_TextBox.Text.EndsWith(" "))
            {
                Uyari.Visible = true;
                Uyari.Text = "Oyuncularin isimleri bosluk karakteriyle bitemez !";
            }
            else
            {
                Uyari.Text = "";
                Uyari.Visible = false;
            }

        }

        private void Exit_Buton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Oyuncu1_TextBox_Click(object sender, EventArgs e)
        {
            if (Oyuncu1_TextBox.Text == "KULLANICI ADI [1]" || Oyuncu1_TextBox.Text == "KULLANICI ADI")
            {
                Oyuncu1_TextBox.Text = "";
            }
        }

        private void Oyuncu2_TextBox_Click(object sender, EventArgs e)
        {
            if (Oyuncu2_TextBox.Text == "KULLANICI ADI [2]")
            {
                Oyuncu2_TextBox.Text = "";
            }
        }


        private void Useful_Button_Yeri(object sender, EventArgs e)
        {
            if (Useful_Yazi.Text == "H E L P")
            {
                GameHelp Yardim = new GameHelp();
                Yardim.Show();
            }
            else if (Useful_Yazi.Text == "B A C K" && Oyuncu1_TextBox.Visible == true && Oyuncu2_TextBox.Visible == true)
            {
                Useful_Button.Location = new Point(8, 10);
                Useful_Button.ImageLocation = "Hurkanix Settings//Help_Button.png";
                Useful_Yazi.Text = "H E L P";

                KullaniciAdi_Belirle_1 = Oyuncu1_TextBox.Text = "Kullanici Adi 1";
                KullaniciAdi_Belirle_2 = Oyuncu2_TextBox.Text = "Kullanici Adi 2";

                Start_Button.Visible = false;

                Oyun_Butonu_1.Visible = true;
                Oyun_Butonu_2.Visible = true;

                Oyuncu1_TextBox.Visible = false;
                Oyuncu2_TextBox.Visible = false;
            }
            else if (Useful_Yazi.Text == "B A C K" && Oyun_Butonu_1.Visible == true && Oyun_Butonu_2.Visible == true)
            {
                Useful_Button.Location = new Point(8, 10);
                Useful_Button.ImageLocation = "Hurkanix Settings//Help_Button.png";

                Useful_Yazi.Text = "H E L P";
                Oyun_Butonu_1.Text = "Player   vs   Player";
                Oyun_Butonu_2.Text = " Player   vs      AI     ";
            }
            else if (Useful_Yazi.Text == "B A C K" && Oyuncu1_TextBox.Visible == true && Oyuncu2_TextBox.Visible == false)
            {
                Useful_Button.Location = new Point(6, 7);
                Useful_Button.ImageLocation = "Hurkanix Settings//Back_Button.png";
                Useful_Yazi.Text = "B A C K";

                KullaniciAdi_Belirle_1 = Oyuncu1_TextBox.Text = "Kullanici Adi";

                Oyuncu1_TextBox.Location = new Point(59, 85);
                Start_Button.Location = new Point(92, 135);
                Start_Button.Visible = false;

                Oyun_Butonu_1.Visible = true;
                Oyun_Butonu_2.Visible = true;

                Oyuncu1_TextBox.Visible = false;
            }
        }

        private void Oyun_Butonu_1_Click(object sender, EventArgs e)
        {
            if (Oyun_Butonu_1.Text == "Player   vs   Player")
            {
                Useful_Button.Location = new Point(6, 7);
                Useful_Button.ImageLocation = "Hurkanix Settings//Back_Button.png";
                Useful_Yazi.Text = "B A C K";

                Oyun_Turu_Label.Text = "Player vs Player";

                KullaniciAdi_Belirle_1 = Oyuncu1_TextBox.Text = "KULLANICI ADI [1]";
                KullaniciAdi_Belirle_2 = Oyuncu2_TextBox.Text = "KULLANICI ADI [2]";

                Oyuncu1_TextBox.Location = new Point(89, 101);
                Start_Button.Location = new Point(137, 235);
                Start_Button.Visible = true;

                Oyun_Butonu_1.Visible = false;
                Oyun_Butonu_2.Visible = false;

                Oyuncu1_TextBox.Visible = true;
                Oyuncu2_TextBox.Visible = true;
            }
            else if (Oyun_Butonu_1.Text == "Dolores Umbridge")
            {
                Useful_Button.Location = new Point(6, 7);
                Useful_Button.ImageLocation = "Hurkanix Settings//Back_Button.png";
                Useful_Yazi.Text = "B A C K";

                Oyun_Turu_Label.Text = "Dolores Umbridge";

                KullaniciAdi_Belirle_1 = Oyuncu1_TextBox.Text = "KULLANICI ADI";

                Oyuncu1_TextBox.Location = new Point(89, 115);
                Start_Button.Location = new Point(137, 184);
                Start_Button.Visible = true;

                Oyun_Butonu_1.Visible = false;
                Oyun_Butonu_2.Visible = false;

                Oyuncu1_TextBox.Visible = true;
            }
        }

        private void Oyun_Butonu_2_Click(object sender, EventArgs e)
        {
            if (Oyun_Butonu_2.Text == " Player   vs      AI     ")
            {
                Useful_Button.Location = new Point(6, 7);
                Useful_Button.ImageLocation = "Hurkanix Settings//Back_Button.png";
                Useful_Yazi.Text = "B A C K";

                Oyun_Butonu_1.Text = "Dolores Umbridge";
                Oyun_Butonu_2.Text = "Lord Voldemort";

            }
            else if (Oyun_Butonu_2.Text == "Lord Voldemort")
            {
                Useful_Button.Location = new Point(6, 7);
                Useful_Button.ImageLocation = "Hurkanix Settings//Back_Button.png";
                Useful_Yazi.Text = "B A C K";

                Oyun_Turu_Label.Text = "Lord Voldemort";

                KullaniciAdi_Belirle_1 = Oyuncu1_TextBox.Text = "KULLANICI ADI";

                Oyuncu1_TextBox.Location = new Point(89, 115);
                Start_Button.Location = new Point(137, 184);
                Start_Button.Visible = true;

                Oyun_Butonu_1.Visible = false;
                Oyun_Butonu_2.Visible = false;

                Oyuncu1_TextBox.Visible = true;
            }
        }

        private void Start_Button_Click(object sender, EventArgs e)
        {
            if (Uyari.Visible == false)
            {
                if (Oyuncu1_TextBox.Text == "KULLANICI ADI [1]")
                {
                    Oyuncu1_TextBox.Text = "P L A Y E R  [ 1 ]";
                }
                if (Oyuncu1_TextBox.Text == "KULLANICI ADI")
                {
                    Oyuncu1_TextBox.Text = "P L A Y E R";
                }
                if (Oyuncu2_TextBox.Text == "KULLANICI ADI [2]")
                {
                    Oyuncu2_TextBox.Text = "P L A Y E R  [ 2 ]";
                }
                if (Oyuncu2_TextBox.Text == "KULLANICI ADI")
                {
                    Oyuncu2_TextBox.Text = "P L A Y E R";
                }

                KullaniciAdi_Belirle_1 = Oyuncu1_TextBox.Text;
                KullaniciAdi_Belirle_2 = Oyuncu2_TextBox.Text;

                if (Oyuncu1_TextBox.Visible == true && Oyuncu2_TextBox.Visible == true)
                {
                    if (Oyun_Turu_Label.Text == "Player vs Player")
                    {
                        GameMode1 PvP = new GameMode1();
                        Renk_Timer.Enabled = false;
                        WMP1.Ctlcontrols.stop();
                        this.Dispose();
                        PvP.Show();
                    }
                }
                else if (Oyuncu1_TextBox.Visible == true && Oyuncu2_TextBox.Visible == false)
                {
                    if (Oyun_Turu_Label.Text == "Dolores Umbridge")
                    {
                        GameMode2 PlayerVsDoloresUmbridge = new GameMode2();
                        Renk_Timer.Enabled = false;
                        WMP1.Ctlcontrols.stop();
                        this.Dispose();
                        PlayerVsDoloresUmbridge.Show();
                    }
                    else if (Oyun_Turu_Label.Text == "Lord Voldemort")
                    {
                        GameMode3 PlayerVsLordVoldemort = new GameMode3();
                        Renk_Timer.Enabled = false;
                        WMP1.Ctlcontrols.stop();
                        this.Dispose();
                        PlayerVsLordVoldemort.Show();
                    }
                }
            }
        }
    }
}

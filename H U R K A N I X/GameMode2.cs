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
    public partial class GameMode2 : Form
    {
        public GameMode2()
        {
            KeyPreview = true;
            InitializeComponent();
        }


        private bool YapayZeka_Saldiriyor_Mu = false;
        private bool Oyuncu_Saldiriyor_Mu = false;
        private bool YapayZeka_Korunuyor_Mu = false;
        private bool Oyuncu_Korunuyor_Mu = false;
        private bool YapayZeka_Ozel_Guc_Mevcut_Mu = false;
        private bool Oyuncu_Ozel_Guc_Mevcut_Mu = false;
        private bool YapayZeka_Rp_Load_First = false;
        private bool YapayZeka_Rp_Load_Second = false;
        private bool Oyuncu_Rp_Load_First = false;
        private bool Oyuncu_Rp_Load_Second = false;
        private bool YapayZeka_Rp_Consume = false;
        private bool Oyuncu_Rp_Consume = false;
        private int Oyuncu_Anlik_Hp_Miktari;
        private int YapayZeka_Anlik_Hp_Miktari;
        private int Oyuncu_Anlik_Mp_Miktari;
        private int YapayZeka_Anlik_Mp_Miktari;
        private bool Oyuncu_Aktif_Kalkan_Bozuluyor_Mu = false;
        private bool YapayZeka_Aktif_Kalkan_Bozuluyor_Mu = false;
        private int Oyuncu_Aktif_Kalkan_Bozulma_Sayaci = 0;
        private int YapayZeka_Aktif_Kalkan_Bozulma_Sayaci = 0;
        private bool Oyun_Sonu = false;

        private bool ItemShop_Aktif_Mi = false;

        private int Saniye = 0;
        private int Dakika = 0;

        private int Oyuncu_Gold_Miktari = 0;

        private void GameMode2_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon("Hurkanix Settings//Hurkanix.ico");
            YapayZeka_Kalkan.ImageLocation = "Hurkanix Settings//Kalkan2.gif";
            Oyuncu_Kalkan.ImageLocation = "Hurkanix Settings//Kalkan1.gif";
            YapayZeka.ImageLocation = "Hurkanix Settings//Dolores_Umbridge_2.gif";
            Oyuncu.ImageLocation = "Hurkanix Settings//Oyuncu1.gif";
            YapayZeka_Buyu.ImageLocation = "Hurkanix Settings//Saldiri2.gif";
            Oyuncu_Buyu.ImageLocation = "Hurkanix Settings//Saldiri1.gif";
            Bulut_1.ImageLocation = Bulut_2.ImageLocation = Bulut_3.ImageLocation = Bulut_4.ImageLocation = "Hurkanix Settings//Bulut.gif";
            this.Icon = Icon.ExtractAssociatedIcon("Hurkanix Settings//Hurkanix.ico");

            Oyuncu_Item_A.ImageLocation = "Hurkanix Settings//Armor.png";
            Oyuncu_Item_B.ImageLocation = "Hurkanix Settings//Curse.png";
            Oyuncu_Item_C.ImageLocation = "Hurkanix Settings//Bless.png";
            YapayZeka_Item_A.ImageLocation = "Hurkanix Settings//Revive.png";
            YapayZeka_Item_B.ImageLocation = "Hurkanix Settings//Hex.png";
            YapayZeka_Item_C.ImageLocation = "Hurkanix Settings//Priest.png";

            Oyuncu_Cheat_Haber_PictureBox.ImageLocation = "Hurkanix Settings//Lord_Voldemort_2.gif";
            YapayZeka_Cheat_Haber_PictureBox.ImageLocation = "Hurkanix Settings//Lord_Voldemort_2.gif";

            Oyuncu_Isim.Text = GameMenu.KullaniciAdi_Belirle_1;
            YapayZeka_Isim.Text = "Dolores Umbridge";

            Exit_Button.ImageLocation = "Hurkanix Settings//Exit_Button.png";
            Settings_Button.ImageLocation = "Hurkanix Settings//Settings_Button.gif";

            Buyu_Akisi_Timer.Enabled = true;
            Hp_Mp_Timer.Enabled = true;
            YapayZeka_Davranis_Timer.Enabled = true;
            Renk_Timer.Enabled = true;
            YapayZeka_Cheats_Timer.Enabled = true;

            WMP1.settings.volume = 100;
            WMP2.settings.volume = 100;
            WMP3.settings.volume = 100;
            WMP4.settings.volume = 100;
            WMP5.settings.volume = 100;
            WMP6.settings.volume = 100;

            Oyuncu_Anlik_Hp_Miktari = Oyuncu_Hp_Bar.Value;
            YapayZeka_Anlik_Hp_Miktari = YapayZeka_Hp_Bar.Value;
            Oyuncu_Anlik_Mp_Miktari = Oyuncu_Mp_Bar.Value;
            YapayZeka_Anlik_Mp_Miktari = YapayZeka_Mp_Bar.Value;

            Game_Paused = false;
            Buyu_Akisi_Timer.Enabled = true;
            Hp_Mp_Timer.Enabled = true;
            Renk_Timer.Enabled = true;
            Oyuncu_Cheats_Timer.Enabled = true;
            YapayZeka_Cheats_Timer.Enabled = true;
            Oyun_Zamanlayici_Timer.Enabled = true;
            Para_Timer.Enabled = true;
            Exit_Button.Enabled = true;
            Settings_Button.Enabled = true;
            End_Timer.Enabled = false;
            ItemShop_Aktif_Mi = false;
            ItemShop.ForeColor = Oyuncu_ItemShop_Isim.ForeColor = YapayZeka_ItemShop_Isim.ForeColor = Oyuncu_Gold_Etiketi.ForeColor = Oyuncu_Gold_Gostergesi.ForeColor = YapayZeka_Gold_Gostergesi.ForeColor = Oyuncu_Item_A_Fiyat.ForeColor = Oyuncu_Item_B_Fiyat.ForeColor = Oyuncu_Item_C_Fiyat.ForeColor = YapayZeka_Item_A_Fiyat.ForeColor = YapayZeka_Item_B_Fiyat.ForeColor = YapayZeka_Item_C_Fiyat.ForeColor = Color.DarkRed;
            WMP1.URL = "Hurkanix Settings//GameMode2.mp3";
        }

        //TUSA BASMA EVENTI
        private void Tus_Basmak(object sender, KeyEventArgs e)
        {
            //ITEMSHOP ACIP KAPATMA TUSLARI
            if (e.KeyCode == Keys.Enter && Game_Paused == false && ItemShop_Aktif_Mi == false && End_Timer.Enabled == false && Oyuncu_is_Cheating == false && YapayZeka_is_Cheating == false && Oyuncu_Kalkan_Tukeniyor_Mu == false && YapayZeka_Revive_Aktiflestirici == false)
            {
                Buyu_Akisi_Timer.Enabled = false;
                Hp_Mp_Timer.Enabled = false;
                Oyuncu_Cheats_Timer.Enabled = false;
                YapayZeka_Cheats_Timer.Enabled = false;
                Para_Timer.Enabled = false;
                ItemShop.ForeColor = Oyuncu_ItemShop_Isim.ForeColor = YapayZeka_ItemShop_Isim.ForeColor = Oyuncu_Gold_Etiketi.ForeColor = Oyuncu_Gold_Gostergesi.ForeColor = YapayZeka_Gold_Gostergesi.ForeColor = Color.Aqua;
                Oyuncu_Item_A_Fiyat.ForeColor = Oyuncu_Item_B_Fiyat.ForeColor = Oyuncu_Item_C_Fiyat.ForeColor = YapayZeka_Item_A_Fiyat.ForeColor = YapayZeka_Item_B_Fiyat.ForeColor = YapayZeka_Item_C_Fiyat.ForeColor = Color.Red;
                ItemShop_Aktif_Mi = true;
            }
            if (e.KeyCode == Keys.Back && Game_Paused == false && ItemShop_Aktif_Mi == true && End_Timer.Enabled == false)
            {
                ItemShop_Aktif_Mi = false;
                ItemShop.ForeColor = Oyuncu_ItemShop_Isim.ForeColor = YapayZeka_ItemShop_Isim.ForeColor = Oyuncu_Gold_Etiketi.ForeColor = Oyuncu_Gold_Gostergesi.ForeColor = YapayZeka_Gold_Gostergesi.ForeColor = Oyuncu_Item_A_Fiyat.ForeColor = Oyuncu_Item_B_Fiyat.ForeColor = Oyuncu_Item_C_Fiyat.ForeColor = YapayZeka_Item_A_Fiyat.ForeColor = YapayZeka_Item_B_Fiyat.ForeColor = YapayZeka_Item_C_Fiyat.ForeColor = Color.DarkRed;
                Buyu_Akisi_Timer.Enabled = true;
                Hp_Mp_Timer.Enabled = true;
                Oyuncu_Cheats_Timer.Enabled = true;
                YapayZeka_Cheats_Timer.Enabled = true;
                Para_Timer.Enabled = true;
            }

            //Imkansiz Tus Basma Olayi (Bu Olayla Ilgili Ekranda Cikan Yaziyi Silen Kodlar Renk_Timer Kisminda
            if (e.KeyCode == Keys.Enter && ItemShop_Aktif_Mi == false && (Oyuncu_is_Cheating == true || YapayZeka_is_Cheating == true || Oyuncu_Cheat_Bar.ForeColor == Color.DarkRed || YapayZeka_Cheat_Bar.ForeColor == Color.DarkRed || YapayZeka_Revive_Aktiflestirici == true))
            {
                if (Pasif_Yetenekler_Aciklama.Text.Contains("[WARNING]\nOfke Yuku harcaniyorken herhangi bir aktif yetenek gerceklestiremezsiniz !") == false)
                    Pasif_Yetenekler_Aciklama.Text = "[WARNING]\nHerhangi bir pasif yetenek kullanilirken Item Shop'a giris yapamazsiniz !";
                else
                    Pasif_Yetenekler_Aciklama.Text = "[WARNING]\nHerhangi bir pasif yetenek kullanilirken Item Shop'a giris yapamazsiniz !\n\n[WARNING]\nOfke Yuku harcaniyorken herhangi bir aktif yetenek gerceklestiremezsiniz !";
                Pasif_Yetenekler_Aciklama.Visible = true;
            }
            if (Oyuncu_Rp_Consume == true && ItemShop_Aktif_Mi == false && (e.KeyCode == Keys.Q || e.KeyCode == Keys.W))
            {
                if (Pasif_Yetenekler_Aciklama.Text.Contains("[WARNING]\nHerhangi bir pasif yetenek kullanilirken Item Shop'a giris yapamazsiniz !") == false)
                    Pasif_Yetenekler_Aciklama.Text = "[WARNING]\nOfke Yuku harcaniyorken herhangi bir aktif yetenek gerceklestiremezsiniz !";
                else
                    Pasif_Yetenekler_Aciklama.Text = "[WARNING]\nHerhangi bir pasif yetenek kullanilirken Item Shop'a giris yapamazsiniz !\n\n[WARNING]\nOfke Yuku harcaniyorken herhangi bir aktif yetenek gerceklestiremezsiniz !";

                Pasif_Yetenekler_Aciklama.Visible = true;
            }

            //Oyuncu icin Saldiri Tusu
            if (e.KeyCode == Keys.Q && Game_Paused == false && End_Timer.Enabled == false)
            {
                if ((Oyuncu_Rp_Bar.Value == 100) && (Oyuncu_Buyu.Visible == false) && YapayZeka_Revive_Aktiflestirici == false && (Oyuncu_Rp_Consume == false) && (Oyuncu_Saldiriyor_Mu == false) && YapayZeka_is_Cheating == false && ItemShop_Aktif_Mi == false && ((Oyuncu_is_Cheating == false && Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false) || (Oyuncu_is_Cheating == true && Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false) || (Oyuncu_is_Cheating == false && Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == true)))
                {
                    Oyuncu_Kalkan.Visible = false;
                    Oyuncu_Buyu.ImageLocation = "Hurkanix Settings//SuperPower1.gif";
                    Oyuncu_Ozel_Guc_Mevcut_Mu = true;
                    Oyuncu.Visible = true;
                    Oyuncu_Buyu.Visible = true;
                    Oyuncu_Korunuyor_Mu = false;
                    Oyuncu_Saldiriyor_Mu = true;
                    Oyuncu_Rp_Consume = true;
                }
                else if ((Oyuncu_Rp_Bar.Value != 100) && (Oyuncu_Buyu.Visible == false) && YapayZeka_Revive_Aktiflestirici == false && (Oyuncu_Rp_Consume == false) && (Oyuncu_Saldiriyor_Mu == false) && YapayZeka_is_Cheating == false && ItemShop_Aktif_Mi == false && ((Oyuncu_is_Cheating == false && Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false) || (Oyuncu_is_Cheating == true && Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false) || (Oyuncu_is_Cheating == false && Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == true)))
                {
                    if (Oyuncu_Mp_Bar.Value >= 20)
                    {
                        Oyuncu_Kalkan.Visible = false;
                        Oyuncu_Buyu.ImageLocation = "Hurkanix Settings//Saldiri1.gif";
                        Oyuncu_Ozel_Guc_Mevcut_Mu = false;
                        Oyuncu_Mp_Bar.Value -= 20;
                        Oyuncu_Mp_Yuzdelik.Text = "[MP]: %" + Oyuncu_Mp_Bar.Value;
                        Oyuncu.Visible = true;
                        Oyuncu_Buyu.Visible = true;
                        Oyuncu_Korunuyor_Mu = false;
                        Oyuncu_Saldiriyor_Mu = true;

                    }
                    else
                    {
                        Oyuncu_Kalkan.Visible = false;
                        Oyuncu_Ozel_Guc_Mevcut_Mu = false;
                        Oyuncu.Visible = true;
                        Oyuncu_Buyu.Visible = false;
                        Oyuncu_Korunuyor_Mu = false;
                        Oyuncu_Saldiriyor_Mu = false;
                    }
                }

            }

            //Oyuncu icin Kalkan Tusu
            if (e.KeyCode == Keys.W && Game_Paused == false && End_Timer.Enabled == false)
            {
                if ((Oyuncu_Kalkan.Visible == false) && (Oyuncu_Rp_Bar.Value != 100) && YapayZeka_Revive_Aktiflestirici == false && (Oyuncu_Rp_Consume == false) && (Oyuncu_Korunuyor_Mu == false) && YapayZeka_is_Cheating == false && ItemShop_Aktif_Mi == false && ((Oyuncu_is_Cheating == false && Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false) || (Oyuncu_is_Cheating == true && Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false) || (Oyuncu_is_Cheating == false && Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == true)))
                {
                    if (Oyuncu_Mp_Bar.Value >= 40)
                    {
                        Oyuncu.Visible = false;
                        Oyuncu_Kalkan.ImageLocation = "Hurkanix Settings//Kalkan1.gif";
                        Oyuncu_Kalkan.Visible = true;
                        Oyuncu_Korunuyor_Mu = true;
                        Oyuncu_Ozel_Guc_Mevcut_Mu = false;
                        Oyuncu_Mp_Bar.Value -= 40;
                        Oyuncu_Mp_Yuzdelik.Text = "[MP]: %" + Oyuncu_Mp_Bar.Value;
                    }
                    else
                    {
                        Oyuncu_Kalkan.Visible = false;
                        Oyuncu_Kalkan.ImageLocation = "Hurkanix Settings//Kalkan1.gif";
                        Oyuncu.Visible = true;
                        Oyuncu_Korunuyor_Mu = false;
                    }

                }
                else if (Oyuncu_Rp_Bar.Value == 100 && (Oyuncu_Rp_Consume == false) && YapayZeka_Revive_Aktiflestirici == false && YapayZeka_is_Cheating == false && ItemShop_Aktif_Mi == false && ((Oyuncu_is_Cheating == false && Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false) || (Oyuncu_is_Cheating == true && Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false) || (Oyuncu_is_Cheating == false && Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == true)))
                {
                    Oyuncu_Ozel_Guc_Mevcut_Mu = true;
                    Oyuncu.Visible = false;
                    Oyuncu_Kalkan.ImageLocation = "Hurkanix Settings//Heal.gif";
                    Oyuncu_Kalkan.Visible = true;
                    Oyuncu_Korunuyor_Mu = true;
                    Oyuncu_Rp_Consume = true;
                }
            }
        }


        //Yapay Zeka Saldiri/Korunma Hareketleri
        private void YapayZeka_Davranis_Timer_Yeri(object sender, EventArgs e)
        {
            //Eger Oyuncu Saldirmiyorsa Bos Yere YapayZeka'nin Kalkan Yapmasini Engelledik
            if (Game_Paused == false && End_Timer.Enabled == false && (Oyuncu_Saldiriyor_Mu == false || Oyuncu_Buyu.Visible == false) && YapayZeka_Revive_Aktiflestirici == false && YapayZeka_Rp_Consume == false && YapayZeka_is_Cheating == false && YapayZeka_Revive_Aktiflestirici == false && ItemShop_Aktif_Mi == false && ((Oyuncu_is_Cheating == false && Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false) || (Oyuncu_is_Cheating == true && Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false) || (Oyuncu_is_Cheating == false && Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == true)))
            {
                YapayZeka_Kalkan.Visible = false;
                YapayZeka_Kalkan.ImageLocation = "Hurkanix Settings//Kalkan2.gif";
                YapayZeka.Visible = true;
                YapayZeka_Korunuyor_Mu = false;
            }
            //YapayZeka icin Kalkan Tusu
            if (Game_Paused == false && End_Timer.Enabled == false && ItemShop_Aktif_Mi == false && YapayZeka_Revive_Aktiflestirici == false && ((((Oyuncu_Saldiriyor_Mu == true || Oyuncu_Buyu.Visible == true) && YapayZeka_Rp_Bar.Value != 100 && YapayZeka_Mp_Bar.Value >= 40) || (YapayZeka_Hp_Bar.Value <= 40 && YapayZeka_Rp_Bar.Value == 100) || (YapayZeka_Mp_Bar.Value <= 8 && YapayZeka_Rp_Bar.Value == 100)) && YapayZeka_is_Cheating == false) && ((Oyuncu_is_Cheating == false && Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false) || (Oyuncu_is_Cheating == true && Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false) || (Oyuncu_is_Cheating == false && Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == true)))
            {
                if ((YapayZeka_Rp_Bar.Value != 100) && (YapayZeka_Kalkan.Visible == false) && (YapayZeka_Rp_Consume == false) && (YapayZeka_Korunuyor_Mu == false))
                {
                    if (YapayZeka_Mp_Bar.Value >= 40)
                    {
                        YapayZeka.Visible = false;
                        YapayZeka_Kalkan.ImageLocation = "Hurkanix Settings//Kalkan2.gif";
                        YapayZeka_Kalkan.Visible = true;
                        YapayZeka_Korunuyor_Mu = true;
                        YapayZeka_Ozel_Guc_Mevcut_Mu = false;
                        YapayZeka_Mp_Bar.Value -= 40;
                        YapayZeka_Mp_Yuzdelik.Text = "[MP]: %" + YapayZeka_Mp_Bar.Value;
                    }
                    else
                    {
                        YapayZeka_Kalkan.Visible = false;
                        YapayZeka_Kalkan.ImageLocation = "Hurkanix Settings//Kalkan2.gif";
                        YapayZeka.Visible = true;
                        YapayZeka_Korunuyor_Mu = false;
                    }
                }
                else if (YapayZeka_Rp_Bar.Value == 100 && (YapayZeka_Rp_Consume == false) && (YapayZeka_is_Cheating == false))
                {
                    YapayZeka_Ozel_Guc_Mevcut_Mu = true;
                    YapayZeka.Visible = false;
                    YapayZeka_Kalkan.ImageLocation = "Hurkanix Settings//Heal.gif";
                    YapayZeka_Kalkan.Visible = true;
                    YapayZeka_Korunuyor_Mu = true;
                    YapayZeka_Rp_Consume = true;
                }
            }
            //YapayZeka icin Saldiri
            else if (Game_Paused == false && End_Timer.Enabled == false && ((Oyuncu_Korunuyor_Mu == true && Oyuncu_Rp_Consume == false) || (Oyuncu_Korunuyor_Mu == false)) && YapayZeka_Revive_Aktiflestirici == false && ((YapayZeka_Korunuyor_Mu == true && (Oyuncu_Saldiriyor_Mu == false || Oyuncu_Buyu.Visible == false)) || (YapayZeka_Korunuyor_Mu == false && (Oyuncu_Saldiriyor_Mu == true || Oyuncu_Buyu.Visible == true)) || (YapayZeka_Korunuyor_Mu == false && (Oyuncu_Saldiriyor_Mu == false || Oyuncu_Buyu.Visible == false))) && YapayZeka_is_Cheating == false && ItemShop_Aktif_Mi == false && ((Oyuncu_is_Cheating == false && Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false) || (Oyuncu_is_Cheating == true && Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false) || (Oyuncu_is_Cheating == false && Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == true)))
            {
                if ((YapayZeka_Rp_Bar.Value == 100) && (YapayZeka_Buyu.Visible == false) && (YapayZeka_Rp_Consume == false) && (YapayZeka_Saldiriyor_Mu == false))
                {
                    YapayZeka_Kalkan.Visible = false;
                    YapayZeka_Buyu.ImageLocation = "Hurkanix Settings//SuperPower2.gif";
                    YapayZeka_Ozel_Guc_Mevcut_Mu = true;
                    YapayZeka.Visible = true;
                    YapayZeka_Buyu.Visible = true;
                    YapayZeka_Korunuyor_Mu = false;
                    YapayZeka_Saldiriyor_Mu = true;
                    YapayZeka_Rp_Consume = true;
                }
                else if ((YapayZeka_Rp_Bar.Value != 100) && (YapayZeka_Buyu.Visible == false) && (YapayZeka_Rp_Consume == false) && (YapayZeka_Saldiriyor_Mu == false) && (YapayZeka_is_Cheating == false))
                {
                    if (YapayZeka_Mp_Bar.Value >= 20)
                    {
                        YapayZeka_Kalkan.Visible = false;
                        YapayZeka_Buyu.ImageLocation = "Hurkanix Settings//Saldiri2.gif";
                        YapayZeka_Ozel_Guc_Mevcut_Mu = false;
                        YapayZeka_Mp_Bar.Value -= 20;
                        YapayZeka_Mp_Yuzdelik.Text = "[MP]: %" + YapayZeka_Mp_Bar.Value;
                        YapayZeka.Visible = true;
                        YapayZeka_Buyu.Visible = true;
                        YapayZeka_Korunuyor_Mu = false;
                        YapayZeka_Saldiriyor_Mu = true;
                    }
                    else
                    {
                        YapayZeka_Ozel_Guc_Mevcut_Mu = false;
                        YapayZeka_Kalkan.Visible = false;
                        YapayZeka.Visible = true;
                        YapayZeka_Buyu.Visible = false;
                        YapayZeka_Korunuyor_Mu = false;
                        YapayZeka_Saldiriyor_Mu = false;
                    }
                }
            }
        }

        //Saldiri Hareket Eventi Baslangici
        private void Buyu_Akisi_Timer_Yeri(object sender, EventArgs e)
        {
            WMP1.Ctlcontrols.play();

            //YapayZeka icin Rp yuku biriktirici (Saldirma ile birikir)
            if ((YapayZeka_Rp_Load_First == true) && (YapayZeka_Rp_Bar.Value < 50) && (YapayZeka_Rp_Consume == false))
            {
                if (YapayZeka_Rp_Bar.Value <= 45)
                    YapayZeka_Rp_Bar.Value += 5;
                else
                    YapayZeka_Rp_Bar.Value = 50;

                YapayZeka_Rp_Yuzdelik.Text = "[RP]: %" + YapayZeka_Rp_Bar.Value;

                if (YapayZeka_Rp_Bar.Value == 50)
                    YapayZeka_Rp_Load_First = false;
            }
            if ((YapayZeka_Rp_Load_Second == true) && (YapayZeka_Rp_Bar.Value < 100) && (YapayZeka_Rp_Consume == false))
            {
                if (YapayZeka_Rp_Bar.Value <= 95)
                    YapayZeka_Rp_Bar.Value += 5;
                else
                    YapayZeka_Rp_Bar.Value = 100;

                YapayZeka_Rp_Yuzdelik.Text = "[RP]: %" + YapayZeka_Rp_Bar.Value;
                if (YapayZeka_Rp_Bar.Value == 100)
                {
                    YapayZeka_Rp_Load_Second = false;
                }

            }

            //Oyuncu icin Rp yuku biriktirici (Saldirma ile birikir)
            if ((Oyuncu_Rp_Load_First == true) && (Oyuncu_Rp_Bar.Value < 50) && (Oyuncu_Rp_Consume == false))
            {
                if (Oyuncu_Rp_Bar.Value <= 45)
                    Oyuncu_Rp_Bar.Value += 5;
                else
                    Oyuncu_Rp_Bar.Value = 50;

                Oyuncu_Rp_Yuzdelik.Text = "[RP]: %" + Oyuncu_Rp_Bar.Value;

                if (Oyuncu_Rp_Bar.Value == 50)
                    Oyuncu_Rp_Load_First = false;
            }
            if ((Oyuncu_Rp_Load_Second == true) && (Oyuncu_Rp_Bar.Value < 100) && (Oyuncu_Rp_Consume == false))
            {
                if (Oyuncu_Rp_Bar.Value <= 95)
                    Oyuncu_Rp_Bar.Value += 5;
                else
                    Oyuncu_Rp_Bar.Value = 100;

                Oyuncu_Rp_Yuzdelik.Text = "[RP]: %" + Oyuncu_Rp_Bar.Value;
                if (Oyuncu_Rp_Bar.Value == 100)
                {
                    Oyuncu_Rp_Load_Second = false;
                }
            }



            //YapayZeka icin Rp yuku tuketici (Hem kalkan icin hem saldiri icin)
            if ((YapayZeka_Rp_Consume == true) && (YapayZeka_Rp_Bar.Value > 0))
            {

                if (YapayZeka_Rp_Bar.Value >= 3)
                    YapayZeka_Rp_Bar.Value -= 3;
                else
                    YapayZeka_Rp_Bar.Value = 0;

                YapayZeka_Rp_Yuzdelik.Text = "[RP]: %" + YapayZeka_Rp_Bar.Value;

                if (YapayZeka_Korunuyor_Mu == true)
                {
                    //Oyuncunun Hp si artar
                    if (YapayZeka_Hp_Bar.Value != 100)
                        YapayZeka_Hp_Bar.Value += 1;

                    //Oyuncunun Mp si artar
                    if (YapayZeka_Mp_Bar.Value != 100)
                        YapayZeka_Mp_Bar.Value += 1;

                    YapayZeka_Hp_Yuzdelik.Text = "[HP]: %" + YapayZeka_Hp_Bar.Value;
                    YapayZeka_Mp_Yuzdelik.Text = "[MP]: %" + YapayZeka_Mp_Bar.Value;
                }


                if (YapayZeka_Rp_Bar.Value == 0)
                {
                    YapayZeka_Rp_Consume = false;
                    YapayZeka_Kalkan.Visible = false;
                    YapayZeka_Kalkan.ImageLocation = "Hurkanix Settings//Kalkan2.gif";
                    YapayZeka.Visible = true;
                    YapayZeka_Korunuyor_Mu = false;
                    YapayZeka_Ozel_Guc_Mevcut_Mu = false;
                }
            }

            //Oyuncu icin Rp yuku tuketici (Hem kalkan icin hem saldiri icin)
            if ((Oyuncu_Rp_Consume == true) && (Oyuncu_Rp_Bar.Value > 0))
            {
                if (Oyuncu_Rp_Bar.Value >= 3)
                    Oyuncu_Rp_Bar.Value -= 3;
                else
                    Oyuncu_Rp_Bar.Value = 0;

                Oyuncu_Rp_Yuzdelik.Text = "[RP]: %" + Oyuncu_Rp_Bar.Value;

                if (Oyuncu_Korunuyor_Mu == true)
                {
                    //Oyuncunun Hp si artar
                    if (Oyuncu_Hp_Bar.Value != 100)
                        Oyuncu_Hp_Bar.Value += 1;

                    //Oyuncunun Mp si artar
                    if (Oyuncu_Mp_Bar.Value != 100)
                        Oyuncu_Mp_Bar.Value += 1;

                    Oyuncu_Hp_Yuzdelik.Text = "[HP]: %" + Oyuncu_Hp_Bar.Value;
                    Oyuncu_Mp_Yuzdelik.Text = "[MP]: %" + Oyuncu_Mp_Bar.Value;
                }


                if (Oyuncu_Rp_Bar.Value == 0)
                {
                    Oyuncu_Rp_Consume = false;
                    Oyuncu_Kalkan.Visible = false;
                    Oyuncu_Kalkan.ImageLocation = "Hurkanix Settings//Kalkan1.gif";
                    Oyuncu.Visible = true;
                    Oyuncu_Korunuyor_Mu = false;
                    Oyuncu_Ozel_Guc_Mevcut_Mu = false;
                }
            }


            //YapayZeka Saldirirsa
            if (YapayZeka_Saldiriyor_Mu == true)
            {
                YapayZeka_Buyu.Visible = true;
                Point YapayZeka_Hareket_Konumu = new Point();
                if (YapayZeka_Buyu.Location.X >= 315 && YapayZeka_Buyu.Location.Y <= 340)
                {
                    YapayZeka_Hareket_Konumu.X = YapayZeka_Buyu.Location.X - 16;
                    YapayZeka_Hareket_Konumu.Y = YapayZeka_Buyu.Location.Y + 4;
                    YapayZeka_Buyu.Location = YapayZeka_Hareket_Konumu;
                }
                else
                {
                    if (Oyuncu_Korunuyor_Mu == false)
                    {

                        //Saldirinin rakibe ulasmasi halinde Rp yuku biriktirme onayi buradan veriliyor
                        if ((YapayZeka_Rp_Bar.Value < 50) && (YapayZeka_Rp_Bar.Value != 100) && (YapayZeka_Ozel_Guc_Mevcut_Mu == false) && (YapayZeka_Rp_Consume == false))
                        {
                            YapayZeka_Rp_Load_First = true;
                        }
                        if ((YapayZeka_Rp_Bar.Value >= 50) && (YapayZeka_Rp_Bar.Value != 100) && (YapayZeka_Ozel_Guc_Mevcut_Mu == false) && (YapayZeka_Rp_Consume == false))
                        {
                            YapayZeka_Rp_Load_Second = true;
                        }


                        //Eger super power aktifse 40 hp hasar verecek eger aktif degilse 20 hp hasar verecek
                        if (YapayZeka_Ozel_Guc_Mevcut_Mu == true && ((Oyuncu_Cheat_Hazir_Mi == false && Oyuncu_Pasif_Kalkan_Satin_Almis_Mi == true) || (Oyuncu_Pasif_Kalkan_Satin_Almis_Mi == false)))
                        {
                            if (Oyuncu_Hp_Bar.Value <= 40)
                                Oyuncu_Hp_Bar.Value = 0;
                            else
                                Oyuncu_Hp_Bar.Value -= 40;
                        }
                        else if (YapayZeka_Ozel_Guc_Mevcut_Mu == false && ((Oyuncu_Cheat_Hazir_Mi == false && Oyuncu_Pasif_Kalkan_Satin_Almis_Mi == true) || (Oyuncu_Pasif_Kalkan_Satin_Almis_Mi == false)))
                        {
                            if (Oyuncu_Hp_Bar.Value <= 20)
                                Oyuncu_Hp_Bar.Value = 0;
                            else
                                Oyuncu_Hp_Bar.Value -= 20;
                        }
                        else if (Oyuncu_Cheat_Hazir_Mi == true && Oyuncu_Pasif_Kalkan_Satin_Almis_Mi == true) //Pasif Kalkanin olmasi durumunda 1 kereligine hicbir sekilde hasar alamaz olacaktir
                        {
                            YapayZeka_Buyu.Visible = false;
                            YapayZeka_Hareket_Konumu.X = 769;
                            YapayZeka_Hareket_Konumu.Y = 183;
                            YapayZeka_Buyu.Location = YapayZeka_Hareket_Konumu;
                            YapayZeka_Saldiriyor_Mu = false;
                            Oyuncu_Kalkan_Tukeniyor_Mu = true;
                        }

                        Oyuncu_Hp_Yuzdelik.Text = "[HP]: %" + Oyuncu_Hp_Bar.Value;
                        YapayZeka_Buyu.Visible = false;
                        YapayZeka_Hareket_Konumu.X = 769;
                        YapayZeka_Hareket_Konumu.Y = 183;
                        YapayZeka_Buyu.Location = YapayZeka_Hareket_Konumu;
                        YapayZeka_Saldiriyor_Mu = false;

                    }
                    else
                    {
                        YapayZeka_Buyu.Visible = false;
                        YapayZeka_Hareket_Konumu.X = 769;
                        YapayZeka_Hareket_Konumu.Y = 183;
                        YapayZeka_Buyu.Location = YapayZeka_Hareket_Konumu;
                        YapayZeka_Saldiriyor_Mu = false;

                        if (Oyuncu_Ozel_Guc_Mevcut_Mu == false)
                        {
                            Oyuncu_Aktif_Kalkan_Bozuluyor_Mu = true;
                        }
                    }
                }
            }




            //Oyuncu Saldirirsa
            if (Oyuncu_Saldiriyor_Mu == true)
            {
                Oyuncu_Buyu.Visible = true;
                Point Oyuncu_Hareket_Konumu = new Point();
                if (Oyuncu_Buyu.Location.X <= 769 && Oyuncu_Buyu.Location.Y >= 183)
                {
                    Oyuncu_Hareket_Konumu.X = Oyuncu_Buyu.Location.X + 16;
                    Oyuncu_Hareket_Konumu.Y = Oyuncu_Buyu.Location.Y - 4;
                    Oyuncu_Buyu.Location = Oyuncu_Hareket_Konumu;
                }
                else
                {
                    if (YapayZeka_Korunuyor_Mu == false)
                    {

                        //Saldirinin rakibe ulasmasi halinde Rp yuku biriktirme onayi buradan veriliyor
                        if ((Oyuncu_Rp_Bar.Value < 50) && (Oyuncu_Rp_Bar.Value != 100) && (Oyuncu_Ozel_Guc_Mevcut_Mu == false) && (Oyuncu_Rp_Consume == false))
                        {
                            Oyuncu_Rp_Load_First = true;
                        }
                        if ((Oyuncu_Rp_Bar.Value >= 50) && (Oyuncu_Rp_Bar.Value != 100) && (Oyuncu_Ozel_Guc_Mevcut_Mu == false) && (Oyuncu_Rp_Consume == false))
                        {
                            Oyuncu_Rp_Load_Second = true;
                        }


                        //Eger super power aktifse 40 hp hasar verecek eger aktif degilse 20 hp hasar verecek
                        if (Oyuncu_Ozel_Guc_Mevcut_Mu == true)
                            if (YapayZeka_Hp_Bar.Value <= 40)
                                YapayZeka_Hp_Bar.Value = 0;
                            else
                                YapayZeka_Hp_Bar.Value -= 40;
                        else
                            if (YapayZeka_Hp_Bar.Value <= 20)
                            YapayZeka_Hp_Bar.Value = 0;
                        else
                            YapayZeka_Hp_Bar.Value -= 20;

                        //Oyuncu verdigi hasar sonucu gold kazanacaktir
                        if (Oyuncu_Ozel_Guc_Mevcut_Mu == true)
                            Oyuncu_Gold_Miktari += 40;
                        else if (Oyuncu_Ozel_Guc_Mevcut_Mu == false)
                            Oyuncu_Gold_Miktari += 20;

                        YapayZeka_Hp_Yuzdelik.Text = "[HP]: %" + YapayZeka_Hp_Bar.Value;
                        Oyuncu_Buyu.Visible = false;
                        Oyuncu_Hareket_Konumu.X = 315;
                        Oyuncu_Hareket_Konumu.Y = 340;
                        Oyuncu_Buyu.Location = Oyuncu_Hareket_Konumu;
                        Oyuncu_Saldiriyor_Mu = false;
                    }
                    else
                    {
                        Oyuncu_Buyu.Visible = false;
                        Oyuncu_Hareket_Konumu.X = 315;
                        Oyuncu_Hareket_Konumu.Y = 340;
                        Oyuncu_Buyu.Location = Oyuncu_Hareket_Konumu;
                        Oyuncu_Saldiriyor_Mu = false;

                        if (YapayZeka_Ozel_Guc_Mevcut_Mu == false)
                        {
                            YapayZeka_Aktif_Kalkan_Bozuluyor_Mu = true;
                        }
                    }
                }
            }



            //Oyunun Bitisi
            if ((YapayZeka_Hp_Bar.Value == 0) && (Oyuncu_Hp_Bar.Value == 0))
            {
                if (YapayZeka_Revive_Mevcut_Mu == true)
                {
                    YapayZeka_Hp_Bar.Value = 0;
                    YapayZeka_Mp_Bar.Value = 0;

                    Oyuncu_Hp_Bar.Value = 0;
                    Oyuncu_Mp_Bar.Value = 0;

                    Oyuncu_Rp_Bar.Value = 0;
                    Oyuncu_Cheat_Bar.Value = 0;

                    Oyuncu_Cheat_Haber_PictureBox.ImageLocation = "Hurkanix Settings//Lord_Voldemort_1.gif";

                    Oyuncu_Kalkan.Visible = false;
                    Oyuncu.Visible = true;
                    Oyuncu.Location = new Point(15, 295);
                    Oyuncu.Size = new Size(200, 131);
                    Oyuncu.ImageLocation = "Hurkanix Settings//Rip.png";

                    YapayZeka_Hp_Yuzdelik.Text = "[HP]: %" + YapayZeka_Hp_Bar.Value;
                    YapayZeka_Mp_Yuzdelik.Text = "[MP]: %" + YapayZeka_Mp_Bar.Value;

                    Oyuncu_Hp_Yuzdelik.Text = "[HP]: %" + Oyuncu_Hp_Bar.Value;
                    Oyuncu_Mp_Yuzdelik.Text = "[MP]: %" + Oyuncu_Mp_Bar.Value;
                    Oyuncu_Rp_Yuzdelik.Text = "[RP]: %" + Oyuncu_Rp_Bar.Value;

                    YapayZeka_A_CheckBox.Visible = true;
                    YapayZeka_B_CheckBox.Visible = false;
                    YapayZeka_C_CheckBox.Visible = false;
                    YapayZeka_Revive_Aktiflestirici = true;
                }
                else
                {
                    Oyun_Sonu = true;
                    WMP1.Ctlcontrols.stop();
                    WMP2.Ctlcontrols.stop();
                    WMP3.Ctlcontrols.stop();
                    WMP5.Ctlcontrols.stop();
                    WMP6.Ctlcontrols.stop();
                    Oyuncu_Cheat_Haber_PictureBox.ImageLocation = "Hurkanix Settings//Lord_Voldemort_1.gif";
                    YapayZeka_Cheat_Haber_PictureBox.ImageLocation = "Hurkanix Settings//Lord_Voldemort_1.gif";
                    Para_Timer.Enabled = false;
                    Buyu_Akisi_Timer.Enabled = false;
                    Oyun_Zamanlayici_Timer.Enabled = false;
                    Hp_Mp_Timer.Enabled = false;
                    YapayZeka_Davranis_Timer.Enabled = false;
                    YapayZeka_Cheats_Timer.Enabled = false;
                    Oyuncu_Cheats_Timer.Enabled = false;

                    Oyuncu_Kalkan.Visible = false;
                    Oyuncu.Visible = true;
                    Oyuncu.Location = new Point(15, 295);
                    Oyuncu.Size = new Size(200, 131);
                    Oyuncu.ImageLocation = "Hurkanix Settings//Rip.png";
                    YapayZeka_Kalkan.Visible = false;
                    YapayZeka.Visible = true;
                    YapayZeka.Location = new Point(930, 192);
                    YapayZeka.Size = new Size(200, 131);
                    YapayZeka.ImageLocation = "Hurkanix Settings//Rip.png";

                    YapayZeka_Hp_Bar.Value = 0;
                    Oyuncu_Hp_Bar.Value = 0;

                    YapayZeka_Mp_Bar.Value = 0;
                    Oyuncu_Mp_Bar.Value = 0;

                    Oyuncu_Rp_Bar.Value = 0;
                    Oyuncu_Cheat_Bar.Value = 0;

                    YapayZeka_Rp_Bar.Value = 0;
                    YapayZeka_Cheat_Bar.Value = 0;

                    Oyuncu_Rp_Bar.ForeColor = Color.Gold;
                    Oyuncu_Rp_Yuzdelik.BackColor = Color.Gold;
                    Oyuncu_Cheat_Bar.ForeColor = Color.White;
                    YapayZeka_Rp_Bar.ForeColor = Color.Gold;
                    YapayZeka_Rp_Yuzdelik.BackColor = Color.Gold;
                    YapayZeka_Cheat_Bar.ForeColor = Color.White;

                    Oyuncu_Hp_Bar.ForeColor = Color.DarkRed;
                    Oyuncu_Mp_Bar.ForeColor = Color.MidnightBlue;
                    Oyuncu_Hp_Yuzdelik.BackColor = Color.Red;
                    Oyuncu_Mp_Yuzdelik.BackColor = Color.RoyalBlue;

                    YapayZeka_Hp_Bar.ForeColor = Color.DarkRed;
                    YapayZeka_Hp_Yuzdelik.BackColor = Color.Red;
                    YapayZeka_Mp_Bar.ForeColor = Color.MidnightBlue;
                    YapayZeka_Mp_Yuzdelik.BackColor = Color.RoyalBlue;

                    YapayZeka_Hp_Yuzdelik.Text = "[HP]: %0";
                    Oyuncu_Hp_Yuzdelik.Text = "[HP]: %0";
                    YapayZeka_Mp_Yuzdelik.Text = "[MP]: %0";
                    Oyuncu_Mp_Yuzdelik.Text = "[MP]: %0";

                    Oyuncu_Rp_Yuzdelik.Text = "[RP]: %0";
                    YapayZeka_Rp_Yuzdelik.Text = "[RP]: %0";

                    WMP4.URL = "Hurkanix Settings//They_Never_Learn.mp3";

                    //Oyun Sonu Ekrani Aciliyor
                    GameOver End = new GameOver();
                    End.Oyun_Sonu_Raporu.Text = "Buyucu savasi berabere bitti ve savas " + Dakika + " dakika " + Saniye + " saniyede sonuclandi !";
                    End.Play_Again_Button.Text = "P L A Y   A G A I N";
                    End.Show();
                    GameMode2_Hide = false;
                    End_Timer.Enabled = true;
                }

            }
            else if (YapayZeka_Hp_Bar.Value == 0)
            {
                if (YapayZeka_Revive_Mevcut_Mu == true)
                {
                    YapayZeka_Hp_Bar.Value = 0;
                    YapayZeka_Mp_Bar.Value = 0;
                    YapayZeka_Hp_Yuzdelik.Text = "[HP]: %" + YapayZeka_Hp_Bar.Value;
                    YapayZeka_Mp_Yuzdelik.Text = "[MP]: %" + YapayZeka_Mp_Bar.Value;
                    YapayZeka_A_CheckBox.Visible = true;
                    YapayZeka_B_CheckBox.Visible = false;
                    YapayZeka_C_CheckBox.Visible = false;
                    YapayZeka_Revive_Aktiflestirici = true;
                }
                else
                {
                    Oyun_Sonu = true;
                    WMP1.Ctlcontrols.stop();
                    WMP2.Ctlcontrols.stop();
                    WMP3.Ctlcontrols.stop();
                    WMP5.Ctlcontrols.stop();
                    WMP6.Ctlcontrols.stop();
                    YapayZeka_Cheat_Haber_PictureBox.ImageLocation = "Hurkanix Settings//Lord_Voldemort_1.gif";
                    Para_Timer.Enabled = false;
                    Buyu_Akisi_Timer.Enabled = false;
                    Oyun_Zamanlayici_Timer.Enabled = false;
                    Hp_Mp_Timer.Enabled = false;
                    YapayZeka_Davranis_Timer.Enabled = false;
                    YapayZeka_Cheats_Timer.Enabled = false;
                    Oyuncu_Cheats_Timer.Enabled = false;

                    YapayZeka_Kalkan.Visible = false;
                    YapayZeka.Visible = true;
                    YapayZeka.Location = new Point(930, 192);
                    YapayZeka.Size = new Size(200, 131);
                    YapayZeka.ImageLocation = "Hurkanix Settings//Rip.png";

                    YapayZeka_Hp_Bar.Value = 0;
                    YapayZeka_Mp_Bar.Value = 0;

                    YapayZeka_Rp_Bar.Value = 0;
                    YapayZeka_Cheat_Bar.Value = 0;

                    YapayZeka_Rp_Bar.ForeColor = Color.Gold;
                    YapayZeka_Rp_Yuzdelik.BackColor = Color.Gold;
                    YapayZeka_Cheat_Bar.ForeColor = Color.White;

                    Oyuncu_Hp_Bar.ForeColor = Color.DarkRed;
                    Oyuncu_Mp_Bar.ForeColor = Color.MidnightBlue;
                    Oyuncu_Hp_Yuzdelik.BackColor = Color.Red;
                    Oyuncu_Mp_Yuzdelik.BackColor = Color.RoyalBlue;

                    YapayZeka_Hp_Bar.ForeColor = Color.DarkRed;
                    YapayZeka_Hp_Yuzdelik.BackColor = Color.Red;
                    YapayZeka_Mp_Bar.ForeColor = Color.MidnightBlue;
                    YapayZeka_Mp_Yuzdelik.BackColor = Color.RoyalBlue;

                    YapayZeka_Hp_Yuzdelik.Text = "[HP]: %0";
                    YapayZeka_Mp_Yuzdelik.Text = "[MP]: %0";
                    YapayZeka_Rp_Yuzdelik.Text = "[RP]: %0";

                    WMP4.URL = "Hurkanix Settings//They_Never_Learn.mp3";

                    //Oyun Sonu Ekrani Aciliyor
                    GameOver End = new GameOver();
                    End.Oyun_Sonu_Raporu.Text = "Buyucu savasini " + Oyuncu_Isim.Text + " kazandi ve savas " + Dakika + " dakika " + Saniye + " saniyede sonuclandi !";
                    End.Play_Again_Button.Text = "P L A Y   A G A I N";
                    End.Show();
                    GameMode2_Hide = false;
                    End_Timer.Enabled = true;
                }
            }
            else if (Oyuncu_Hp_Bar.Value == 0)
            {
                Oyun_Sonu = true;
                WMP1.Ctlcontrols.stop();
                WMP2.Ctlcontrols.stop();
                WMP3.Ctlcontrols.stop();
                WMP5.Ctlcontrols.stop();
                WMP6.Ctlcontrols.stop();
                Oyuncu_Cheat_Haber_PictureBox.ImageLocation = "Hurkanix Settings//Lord_Voldemort_1.gif";
                Para_Timer.Enabled = false;
                Buyu_Akisi_Timer.Enabled = false;
                Oyun_Zamanlayici_Timer.Enabled = false;
                Hp_Mp_Timer.Enabled = false;
                YapayZeka_Davranis_Timer.Enabled = false;
                YapayZeka_Cheats_Timer.Enabled = false;
                Oyuncu_Cheats_Timer.Enabled = false;

                Oyuncu_Kalkan.Visible = false;
                Oyuncu.Visible = true;
                Oyuncu.Location = new Point(15, 295);
                Oyuncu.Size = new Size(200, 131);
                Oyuncu.ImageLocation = "Hurkanix Settings//Rip.png";

                Oyuncu_Hp_Bar.Value = 0;
                Oyuncu_Mp_Bar.Value = 0;

                Oyuncu_Rp_Bar.Value = 0;
                Oyuncu_Cheat_Bar.Value = 0;

                Oyuncu_Rp_Bar.ForeColor = Color.Gold;
                Oyuncu_Rp_Yuzdelik.BackColor = Color.Gold;
                Oyuncu_Cheat_Bar.ForeColor = Color.White;

                Oyuncu_Hp_Bar.ForeColor = Color.DarkRed;
                Oyuncu_Mp_Bar.ForeColor = Color.MidnightBlue;
                Oyuncu_Hp_Yuzdelik.BackColor = Color.Red;
                Oyuncu_Mp_Yuzdelik.BackColor = Color.RoyalBlue;

                YapayZeka_Hp_Bar.ForeColor = Color.DarkRed;
                YapayZeka_Hp_Yuzdelik.BackColor = Color.Red;
                YapayZeka_Mp_Bar.ForeColor = Color.MidnightBlue;
                YapayZeka_Mp_Yuzdelik.BackColor = Color.RoyalBlue;

                Oyuncu_Hp_Yuzdelik.Text = "[HP]: %0";
                Oyuncu_Mp_Yuzdelik.Text = "[MP]: %0";
                Oyuncu_Rp_Yuzdelik.Text = "[RP]: %0";
                WMP4.URL = "Hurkanix Settings//They_Never_Learn.mp3";

                //Oyun Sonu Ekrani Aciliyor
                GameOver End = new GameOver();
                End.Oyun_Sonu_Raporu.Text = "Buyucu savasini " + YapayZeka_Isim.Text + " kazandi ve savas " + Dakika + " dakika " + Saniye + " saniyede sonuclandi !";
                End.Play_Again_Button.Text = "P L A Y   A G A I N";
                End.Show();
                GameMode2_Hide = false;
                End_Timer.Enabled = true;
            }

        }


        //HP VE MP ARTIRMA EVENTI
        private static int Enough_Zamani = 0;
        private void HP_ve_MP_Timer_Yeri(object sender, EventArgs e)
        {
            //Oyun Biterse Zamani Durdur
            if (Oyun_Sonu == true)
                Hp_Mp_Timer.Enabled = false;

            if (Enough_Zamani % 10 == 0)
                WMP2.URL = "Hurkanix Settings//Enough_Woods.mp3";
            Enough_Zamani++;

            //Oyuncularin Manasi Yenilenir
            if ((YapayZeka_Mp_Bar.Value != 100) && (YapayZeka_Hp_Bar.Value != 0))
            {
                if (YapayZeka_Mp_Bar.Value == 99)
                    YapayZeka_Mp_Bar.Value += 1;
                else
                    YapayZeka_Mp_Bar.Value += 2;

                YapayZeka_Mp_Yuzdelik.Text = "[MP]: %" + YapayZeka_Mp_Bar.Value;
            }
            if ((Oyuncu_Mp_Bar.Value != 100) && (Oyuncu_Hp_Bar.Value != 0))
            {
                if (Oyuncu_Mp_Bar.Value == 99)
                    Oyuncu_Mp_Bar.Value += 1;
                else
                    Oyuncu_Mp_Bar.Value += 2;
                Oyuncu_Mp_Yuzdelik.Text = "[MP]: %" + Oyuncu_Mp_Bar.Value;
            }


            //Oyuncularin Canlari Yenilenir
            if ((YapayZeka_Hp_Bar.Value != 100) && (YapayZeka_Hp_Bar.Value != 0))
            {
                if (YapayZeka_Hp_Bar.Value == 99)
                    YapayZeka_Hp_Bar.Value += 1;
                else
                    YapayZeka_Hp_Bar.Value += 2;
                YapayZeka_Hp_Yuzdelik.Text = "[HP]: %" + YapayZeka_Hp_Bar.Value;
            }
            if ((Oyuncu_Hp_Bar.Value != 100) && (Oyuncu_Hp_Bar.Value != 0))
            {
                if (Oyuncu_Hp_Bar.Value == 99)
                    Oyuncu_Hp_Bar.Value += 1;
                else
                    Oyuncu_Hp_Bar.Value += 2;
                Oyuncu_Hp_Yuzdelik.Text = "[HP]: %" + Oyuncu_Hp_Bar.Value;
            }
        }



        //Renkli Zaman Yeri
        private Random renk = new Random();
        private void Renk_Timer_Yeri(object sender, EventArgs e)
        {

            //IMKANSIZ TUS BASMA DURUMUNDAKI EKRANDAKI YAZIYI SILME KODU
            if (Oyuncu_Rp_Consume == false)
            {
                if (Pasif_Yetenekler_Aciklama.Text == "[WARNING]\nOfke Yuku harcaniyorken herhangi bir aktif yetenek gerceklestiremezsiniz !")
                {
                    Pasif_Yetenekler_Aciklama.Visible = false;
                    Pasif_Yetenekler_Aciklama.Text = "";
                }
                else if (Pasif_Yetenekler_Aciklama.Text == "[WARNING]\nHerhangi bir pasif yetenek kullanilirken Item Shop'a giris yapamazsiniz !\n\n[WARNING]\nOfke Yuku harcaniyorken herhangi bir aktif yetenek gerceklestiremezsiniz !")
                {
                    Pasif_Yetenekler_Aciklama.Text = "[WARNING]\nHerhangi bir pasif yetenek kullanilirken Item Shop'a giris yapamazsiniz !";
                }
            }
            if (Oyuncu_is_Cheating == false && Oyuncu_Cheat_Bar.ForeColor != Color.DarkRed && YapayZeka_Cheat_Bar.ForeColor != Color.DarkRed && YapayZeka_is_Cheating == false && YapayZeka_Revive_Aktiflestirici == false && Pasif_Yetenekler_Aciklama.Text.Contains("[WARNING]\nHerhangi bir pasif yetenek kullanilirken Item Shop'a giris yapamazsiniz !") == true)
            {
                if (Pasif_Yetenekler_Aciklama.Text == "[WARNING]\nHerhangi bir pasif yetenek kullanilirken Item Shop'a giris yapamazsiniz !")
                {
                    Pasif_Yetenekler_Aciklama.Visible = false;
                    Pasif_Yetenekler_Aciklama.Text = "";
                }
                else if (Pasif_Yetenekler_Aciklama.Text == "[WARNING]\nHerhangi bir pasif yetenek kullanilirken Item Shop'a giris yapamazsiniz !\n\n[WARNING]\nOfke Yuku harcaniyorken herhangi bir aktif yetenek gerceklestiremezsiniz !")
                {
                    Pasif_Yetenekler_Aciklama.Text = "Ofke Yuku harcaniyorken herhangi bir aktif yetenek gerceklestiremezsiniz !";
                }
            }


            //Oyun Durdurulduktan Sonra Yeniden Baslatildiginda Bunu Yap
            if (Game_Paused == false && End_Timer.Enabled == true && Oyun_Sonu == false)
            {
                if (ItemShop_Aktif_Mi == false)
                {
                    Oyuncu_Cheats_Timer.Enabled = true;
                    YapayZeka_Cheats_Timer.Enabled = true;
                    Buyu_Akisi_Timer.Enabled = true;
                    Hp_Mp_Timer.Enabled = true;
                    Para_Timer.Enabled = true;
                    ItemShop.ForeColor = Oyuncu_ItemShop_Isim.ForeColor = YapayZeka_ItemShop_Isim.ForeColor = Oyuncu_Gold_Etiketi.ForeColor = Oyuncu_Gold_Gostergesi.ForeColor = YapayZeka_Gold_Gostergesi.ForeColor = Oyuncu_Item_A_Fiyat.ForeColor = Oyuncu_Item_B_Fiyat.ForeColor = Oyuncu_Item_C_Fiyat.ForeColor = YapayZeka_Item_A_Fiyat.ForeColor = YapayZeka_Item_B_Fiyat.ForeColor = YapayZeka_Item_C_Fiyat.ForeColor = Color.DarkRed;
                }
                Exit_Button.Enabled = true;
                Settings_Button.Enabled = true;
                Oyun_Zamanlayici_Timer.Enabled = true;
                End_Timer.Enabled = false;
            }

            //Oyuncularin ve Exit Butonunun Rengini Ayarladik
            Timer_Yazi.ForeColor = Exit_Yazi.ForeColor = Color.FromArgb(renk.Next(0, 256), renk.Next(0, 256), renk.Next(0, 256));
            Pasif_Yetenekler_Aciklama.ForeColor = Exit_Yazi.ForeColor;
            if (ItemShop_Aktif_Mi == false)
            {
                Timer_Saat_Gosterici.ForeColor = Color.Aqua;
                Tavan.BackColor = Sag_Yan.BackColor = Taban.BackColor = Sol_Yan.BackColor = Oyuncu_Isim.ForeColor = YapayZeka_Isim.ForeColor = Exit_Yazi.ForeColor;
            }
            else
            {
                Tavan.BackColor = Sag_Yan.BackColor = Taban.BackColor = Sol_Yan.BackColor = Oyuncu_Isim.ForeColor = YapayZeka_Isim.ForeColor = Timer_Saat_Gosterici.ForeColor = Color.DarkRed;
            }


            //Oyuncu ve YapayZekanin Hp ve Mp degeri ekrana yazilir
            YapayZeka_Hp_Yuzdelik.Text = "[HP]: %" + YapayZeka_Hp_Bar.Value;
            YapayZeka_Mp_Yuzdelik.Text = "[MP]: %" + YapayZeka_Mp_Bar.Value;
            Oyuncu_Hp_Yuzdelik.Text = "[HP]: %" + Oyuncu_Hp_Bar.Value;
            Oyuncu_Mp_Yuzdelik.Text = "[MP]: %" + Oyuncu_Mp_Bar.Value;
            YapayZeka_Hp_Bar.Value = YapayZeka_Hp_Bar.Value;
            YapayZeka_Mp_Bar.Value = YapayZeka_Mp_Bar.Value;
            Oyuncu_Hp_Bar.Value = Oyuncu_Hp_Bar.Value;
            Oyuncu_Mp_Bar.Value = Oyuncu_Mp_Bar.Value;


            //RP Bar'lari 100 olunca rengarenk olacaklar
            if (YapayZeka_Rp_Bar.Value == 100)
                YapayZeka_Rp_Bar.ForeColor = YapayZeka_Rp_Yuzdelik.BackColor = Exit_Yazi.ForeColor;
            else if (YapayZeka_Hp_Bar.Value == 0 && YapayZeka_Revive_Mevcut_Mu == false)
                YapayZeka_Rp_Yuzdelik.BackColor = Color.Gold;
            else if (YapayZeka_Rp_Bar.Value < 100 && YapayZeka_Rp_Consume == false)
                YapayZeka_Rp_Bar.ForeColor = YapayZeka_Rp_Yuzdelik.BackColor = Color.Gold;
            else if (YapayZeka_Rp_Bar.Value <= 100 && YapayZeka_Rp_Consume == true)
                YapayZeka_Rp_Bar.ForeColor = YapayZeka_Rp_Yuzdelik.BackColor = Color.DarkRed;

            if (Oyuncu_Rp_Bar.Value == 100)
                Oyuncu_Rp_Bar.ForeColor = Oyuncu_Rp_Yuzdelik.BackColor = Exit_Yazi.ForeColor;
            else if (Oyuncu_Hp_Bar.Value == 0)
                Oyuncu_Rp_Yuzdelik.BackColor = Color.Gold;
            else if (Oyuncu_Rp_Bar.Value < 100 && Oyuncu_Rp_Consume == false)
                Oyuncu_Rp_Bar.ForeColor = Oyuncu_Rp_Yuzdelik.BackColor = Color.Gold;
            else if (Oyuncu_Rp_Bar.Value <= 100 && Oyuncu_Rp_Consume == true)
                Oyuncu_Rp_Bar.ForeColor = Oyuncu_Rp_Yuzdelik.BackColor = Color.DarkRed;


            //YapayZeka'nin Cheat Bar Rengini Ayarladik
            if (YapayZeka_Cheat_Bar.Value == 100 && YapayZeka_Cheat_Hazir_Mi == true)
                YapayZeka_Cheat_Bar.ForeColor = Exit_Yazi.ForeColor;
            else if (YapayZeka_Cheat_Bar.Value <= 100 && YapayZeka_Cheat_Hazir_Mi == false)
                YapayZeka_Cheat_Bar.ForeColor = Color.White;


            //Oyuncu'nun Cheat Bar Rengini Ayarladik
            if (Oyuncu_Cheat_Bar.Value == 100 && Oyuncu_Cheat_Hazir_Mi == true)
                Oyuncu_Cheat_Bar.ForeColor = Exit_Yazi.ForeColor;
            else if (Oyuncu_Cheat_Bar.Value <= 100 && Oyuncu_Cheat_Hazir_Mi == false)
                Oyuncu_Cheat_Bar.ForeColor = Color.White;


            //YAPAY ZEKA SKILL SECIMI YAPIYOR
            if (YapayZeka_Hp_Bar.Value >= 60 && YapayZeka_is_Cheating == false && YapayZeka_Revive_Aktiflestirici == false)
            {
                YapayZeka_A_CheckBox.Visible = false;
                YapayZeka_C_CheckBox.Visible = false;
                YapayZeka_B_CheckBox.Visible = true;
            }
            if ((YapayZeka_Hp_Bar.Value != 0 && YapayZeka_Hp_Bar.Value < 60) && YapayZeka_is_Cheating == false && YapayZeka_Revive_Aktiflestirici == false)
            {
                YapayZeka_A_CheckBox.Visible = false;
                YapayZeka_B_CheckBox.Visible = false;
                YapayZeka_C_CheckBox.Visible = true;
            }
            if (YapayZeka_Hp_Bar.Value == 0 && YapayZeka_Revive_Mevcut_Mu == true && YapayZeka_Revive_Aktiflestirici == false)
            {
                YapayZeka_B_CheckBox.Visible = false;
                YapayZeka_C_CheckBox.Visible = false;
                YapayZeka_A_CheckBox.Visible = true;
            }



            //YAPAYZEKA HEX ILE OYUNCUNUN BAR RENKLERINI DEGISTIRDI
            if (YapayZeka_Hex_Ekran_Rengi_Degistir == true)
            {
                Oyuncu_Hp_Bar.ForeColor = Oyuncu_Hp_Yuzdelik.BackColor = Oyuncu_Mp_Bar.ForeColor = Oyuncu_Mp_Yuzdelik.BackColor = Color.Black;
                if (YapayZeka_Hex_Ekran_Rengi_Degisim_Suresi_Sayaci < 30)
                    YapayZeka_Hex_Ekran_Rengi_Degisim_Suresi_Sayaci++;
                if (YapayZeka_Hex_Ekran_Rengi_Degisim_Suresi_Sayaci == 30)
                {
                    Oyuncu_Hp_Bar.ForeColor = Color.DarkRed;
                    Oyuncu_Hp_Yuzdelik.BackColor = Color.Red;
                    Oyuncu_Mp_Bar.ForeColor = Color.MidnightBlue;
                    Oyuncu_Mp_Yuzdelik.BackColor = Color.RoyalBlue;
                    YapayZeka_Hex_Ekran_Rengi_Degistir = false;
                    YapayZeka_Hex_Ekran_Rengi_Degisim_Suresi_Sayaci = 0;
                }
            }

            //Oyuncu ve YapayZeka ItemShop Renk Ayarlari
            if (ItemShop_Aktif_Mi == true)
            {
                //Oyuncu ItemShop Renk Ayarlari
                Oyuncu_Gold_Gostergesi.ForeColor = Exit_Yazi.ForeColor;

                if (Oyuncu_Gold_Miktari >= 200)
                    Oyuncu_Item_A_Fiyat.ForeColor = Exit_Yazi.ForeColor;
                else
                    Oyuncu_Item_A_Fiyat.ForeColor = Color.Red;
                if (Oyuncu_Gold_Miktari >= 400)
                    Oyuncu_Item_B_Fiyat.ForeColor = Exit_Yazi.ForeColor;
                else
                    Oyuncu_Item_B_Fiyat.ForeColor = Color.Red;
                if (Oyuncu_Gold_Miktari >= 600)
                    Oyuncu_Item_C_Fiyat.ForeColor = Exit_Yazi.ForeColor;
                else
                    Oyuncu_Item_C_Fiyat.ForeColor = Color.Red;

                //Oyuncu2 ItemShop Renk Ayarlari
                YapayZeka_Gold_Gostergesi.ForeColor = YapayZeka_Item_A_Fiyat.ForeColor = YapayZeka_Item_B_Fiyat.ForeColor = YapayZeka_Item_C_Fiyat.ForeColor = Exit_Yazi.ForeColor;
            }
            else
                ItemShop.ForeColor = Color.DarkRed;



            //CheckBox'larin rengini ayarladik
            if (ItemShop_Aktif_Mi == true)
                Oyuncu_A_CheckBox.BackColor = Oyuncu_B_CheckBox.BackColor = Oyuncu_C_CheckBox.BackColor = YapayZeka_A_CheckBox.BackColor = YapayZeka_B_CheckBox.BackColor = YapayZeka_C_CheckBox.BackColor = Exit_Yazi.ForeColor;
            else
                Oyuncu_A_CheckBox.BackColor = Oyuncu_B_CheckBox.BackColor = Oyuncu_C_CheckBox.BackColor = YapayZeka_A_CheckBox.BackColor = YapayZeka_B_CheckBox.BackColor = YapayZeka_C_CheckBox.BackColor = Color.DarkRed;



            //ItemShop Yazisinin Rengini Ayarladik
            if (ItemShop_Aktif_Mi == true)
                ItemShop.ForeColor = Exit_Yazi.ForeColor;
            else
                ItemShop.ForeColor = Color.DarkRed;


            //Oyuncu B Pasif Skilli Alirsa Onlar Icin Gerekli Hesaplamalar
            if (((Oyuncu_is_Cheating == false && Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == true) || (Oyuncu_is_Cheating == false && Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false) || (Oyuncu_is_Cheating == true && Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false)) && (YapayZeka_is_Cheating == false || YapayZeka_is_Cheating == true))
            {
                Oyuncu_Anlik_Hp_Miktari = Oyuncu_Hp_Bar.Value;
                YapayZeka_Anlik_Hp_Miktari = YapayZeka_Hp_Bar.Value;
                Oyuncu_Anlik_Mp_Miktari = Oyuncu_Mp_Bar.Value;
                YapayZeka_Anlik_Mp_Miktari = YapayZeka_Mp_Bar.Value;
            }


            //Oyuncu Aktif Kalkan Bozulmasi
            if (Oyuncu_Aktif_Kalkan_Bozuluyor_Mu == true)
            {
                Oyuncu_Aktif_Kalkan_Bozulma_Sayaci++;

                if (Oyuncu_Aktif_Kalkan_Bozulma_Sayaci == 3)
                {
                    Oyuncu_Aktif_Kalkan_Bozulma_Sayaci = 0;
                    Oyuncu_Kalkan.Visible = false;
                    Oyuncu_Kalkan.ImageLocation = "Hurkanix Settings//Kalkan1.gif";
                    Oyuncu.Visible = true;
                    Oyuncu_Korunuyor_Mu = false;
                    Oyuncu_Aktif_Kalkan_Bozuluyor_Mu = false;
                }
            }

            //YapayZeka Aktif Kalkan Bozulmasi
            if (YapayZeka_Aktif_Kalkan_Bozuluyor_Mu == true)
            {
                YapayZeka_Aktif_Kalkan_Bozulma_Sayaci++;

                if (YapayZeka_Aktif_Kalkan_Bozulma_Sayaci == 3)
                {
                    YapayZeka_Aktif_Kalkan_Bozulma_Sayaci = 0;
                    YapayZeka_Kalkan.Visible = false;
                    YapayZeka_Kalkan.ImageLocation = "Hurkanix Settings//Kalkan2.gif";
                    YapayZeka.Visible = true;
                    YapayZeka_Korunuyor_Mu = false;
                    YapayZeka_Aktif_Kalkan_Bozuluyor_Mu = false;
                }
            }


            //Oyuncu'nun Gold Miktarina Bagli Olarak Item Cursor Seklini Ayarladik
            if (Oyuncu_Gold_Miktari >= 200 && ItemShop_Aktif_Mi == true)
                Oyuncu_Item_A.Cursor = Cursors.Hand;
            else
                Oyuncu_Item_A.Cursor = Cursors.No;
            if (Oyuncu_Gold_Miktari >= 400 && ItemShop_Aktif_Mi == true)
                Oyuncu_Item_B.Cursor = Cursors.Hand;
            else
                Oyuncu_Item_B.Cursor = Cursors.No;
            if (Oyuncu_Gold_Miktari >= 600 && ItemShop_Aktif_Mi == true)
                Oyuncu_Item_C.Cursor = Cursors.Hand;
            else
                Oyuncu_Item_C.Cursor = Cursors.No;

        }


        //Umbridge Sesi
        private void Ekrandan_Mouse_Ayrilmasi(object sender, EventArgs e)
        {
            if (Oyun_Sonu != true)
                WMP3.URL = "Hurkanix Settings//Enough_Class.mp3";
        }


        private bool YapayZeka_is_Cheating = false;
        private bool YapayZeka_Cheat_Hazir_Mi = true;
        private bool YapayZeka_Revive_Mevcut_Mu = true;
        private bool YapayZeka_Revive_Aktiflestirici = false;
        private bool YapayZeka_Hex_Ekran_Rengi_Degistir = false;
        private int YapayZeka_Hex_Ekran_Rengi_Degisim_Suresi_Sayaci = 0;
        private void YapayZeka_Cheats_Timer_Yeri(object sender, EventArgs e)
        {

            //YAPAYZEKA CHEAT BAR DOLDURMA YERI
            if (YapayZeka_Cheat_Hazir_Mi == false)
            {
                YapayZeka_Cheats_Timer.Interval = 300; //Pasif skill'in dolma hizi

                if (YapayZeka_Cheat_Bar.Value <= 98)
                    YapayZeka_Cheat_Bar.Value += 2;
                else
                    YapayZeka_Cheat_Bar.Value = 100;

                if (YapayZeka_Cheat_Bar.Value == 100)
                {
                    YapayZeka_Cheat_Hazir_Mi = true;
                    YapayZeka_Cheat_Haber_PictureBox.ImageLocation = "Hurkanix Settings//Lord_Voldemort_2.gif";
                    YapayZeka_Cheats_Timer.Interval = 100; //Pasif Hp ve Mp nin dolma hizi
                }

            }


            //YAPAYZEKA CAN & MANA YENILEME SKILL
            if ((YapayZeka_Hp_Bar.Value <= 40 && YapayZeka_Hp_Bar.Value > 0 && YapayZeka_Revive_Aktiflestirici == false) && YapayZeka_C_CheckBox.Visible == true && YapayZeka_Rp_Bar.Value != 100 && YapayZeka_Cheat_Hazir_Mi == true && ((YapayZeka_Korunuyor_Mu == false && YapayZeka_Rp_Consume == true) || (YapayZeka_Korunuyor_Mu == true && YapayZeka_Rp_Consume == false) || (YapayZeka_Korunuyor_Mu == false && YapayZeka_Rp_Consume == false)) || (YapayZeka_is_Cheating == true))
            {
                YapayZeka_Cheats_Timer.Interval = 100; //Pasif Skill Hp ve Mp nin dolma hizi

                YapayZeka_is_Cheating = true;
                Buyu_Akisi_Timer.Enabled = false;
                Hp_Mp_Timer.Enabled = false;
                YapayZeka_Davranis_Timer.Enabled = false;
                Oyuncu_Cheats_Timer.Enabled = false;
                Para_Timer.Enabled = false;

                //Yapay Zekanin cheat yaptiginin haberini veren resmi gorunur yaptik ve ses cikartmasini sagladik
                if (YapayZeka_Cheat_Bar.Value == 100 && YapayZeka_is_Cheating == true)
                {
                    WMP5.URL = "Hurkanix Settings//Teemo_Laugh.mp3";
                }

                //Yapay zekanin hp ve mp bari rengarenk oluyor
                YapayZeka_Hp_Bar.ForeColor = YapayZeka_Mp_Bar.ForeColor = YapayZeka_Hp_Yuzdelik.BackColor = YapayZeka_Mp_Yuzdelik.BackColor = Exit_Yazi.ForeColor;
                YapayZeka_Cheat_Bar.ForeColor = Color.DarkRed;

                if (YapayZeka_Hp_Bar.Value != 100)
                {
                    if (YapayZeka_Hp_Bar.Value == 99)
                        YapayZeka_Hp_Bar.Value += 1;
                    else
                        YapayZeka_Hp_Bar.Value += 2;
                    YapayZeka_Hp_Yuzdelik.Text = "[HP]: %" + YapayZeka_Hp_Bar.Value;
                }


                if (YapayZeka_Mp_Bar.Value != 100)
                {
                    if (YapayZeka_Mp_Bar.Value == 99)
                        YapayZeka_Mp_Bar.Value += 1;
                    else
                        YapayZeka_Mp_Bar.Value += 2;
                    YapayZeka_Mp_Yuzdelik.Text = "[MP]: %" + YapayZeka_Mp_Bar.Value;
                }


                if (YapayZeka_Cheat_Bar.Value != 0)
                    if (YapayZeka_Cheat_Bar.Value >= 5)
                        YapayZeka_Cheat_Bar.Value -= 5;
                    else
                        YapayZeka_Cheat_Bar.Value = 0;


                if (YapayZeka_Hp_Bar.Value == 100 && YapayZeka_Mp_Bar.Value == 100 && YapayZeka_Cheat_Bar.Value == 0)
                {
                    if (Oyuncu_Pasif_Lanet_Satin_Almis_Mi == true && Oyuncu_is_Cheating == true)
                    {
                        YapayZeka_Hp_Bar.ForeColor = YapayZeka_Hp_Yuzdelik.BackColor = Color.Black;
                        YapayZeka_Mp_Bar.ForeColor = YapayZeka_Mp_Yuzdelik.BackColor = Color.Black;
                    }
                    else
                    {
                        YapayZeka_Hp_Bar.ForeColor = Color.DarkRed;
                        YapayZeka_Mp_Bar.ForeColor = Color.MidnightBlue;
                        YapayZeka_Hp_Yuzdelik.BackColor = Color.Red;
                        YapayZeka_Mp_Yuzdelik.BackColor = Color.RoyalBlue;
                    }

                    Buyu_Akisi_Timer.Enabled = true;
                    Hp_Mp_Timer.Enabled = true;
                    Para_Timer.Enabled = true;
                    YapayZeka_Davranis_Timer.Enabled = true;
                    Oyuncu_Cheats_Timer.Enabled = true;
                    YapayZeka_is_Cheating = false;
                    YapayZeka_Cheat_Bar.ForeColor = Color.White;
                    YapayZeka_Cheat_Hazir_Mi = false;
                    YapayZeka_Cheat_Haber_PictureBox.ImageLocation = "Hurkanix Settings//Lord_Voldemort_1.gif";
                    YapayZeka_Cheats_Timer.Interval = 300; //Pasif skill dolma hizi
                }
                else
                    YapayZeka_is_Cheating = true;
            }


            //YAPAYZEKA HEX AKTIFLESME YERI
            if (YapayZeka_B_CheckBox.Visible == true && YapayZeka_Revive_Aktiflestirici == false && YapayZeka_Cheat_Hazir_Mi == true && YapayZeka_is_Cheating == false && ((Oyuncu_is_Cheating == true && Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false) || (Oyuncu_is_Cheating == false && Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == true) || (Oyuncu_is_Cheating == false && Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false)))
            {
                //YapayZeka Cheat Giris Hizi
                YapayZeka_Cheats_Timer.Interval = 100;

                //Yapay Zekanin cheat yaptiginin haberini veren resmi gorunur yaptik ve ses cikartmasini sagladik
                if (YapayZeka_Cheat_Bar.Value == 100)
                {
                    WMP5.URL = "Hurkanix Settings//Teemo_Laugh.mp3";
                }

                YapayZeka_Hex_Ekran_Rengi_Degistir = true;
                YapayZeka_Cheat_Bar.ForeColor = Color.DarkRed;
                Oyuncu_Hp_Bar.Value = (int)(Oyuncu_Hp_Bar.Value / 2);
                Oyuncu_Mp_Bar.Value = (int)(Oyuncu_Mp_Bar.Value / 2);
                Oyuncu_Hp_Yuzdelik.Text = "[HP]: %" + Oyuncu_Hp_Bar.Value;
                Oyuncu_Mp_Yuzdelik.Text = "[MP]: %" + Oyuncu_Mp_Bar.Value;
                YapayZeka_Cheat_Bar.Value = 0;
                YapayZeka_Cheat_Haber_PictureBox.ImageLocation = "Hurkanix Settings//Lord_Voldemort_1.gif";
                YapayZeka_Cheat_Bar.ForeColor = Color.White;
                YapayZeka_Cheat_Hazir_Mi = false;

                //YapayZeka Cheat Cikis Hizi
                YapayZeka_Cheats_Timer.Interval = 300;
            }

            //YAPAYZEKA REVIVE AKTIFLESME YERI
            if (YapayZeka_Revive_Mevcut_Mu == true && YapayZeka_Revive_Aktiflestirici == true && YapayZeka_A_CheckBox.Visible == true)
            {
                //Revive Hizi
                YapayZeka_Cheats_Timer.Interval = 100;

                YapayZeka.Visible = true;
                YapayZeka.Location = new Point(885, 159);
                YapayZeka.Size = new Size(266, 170);
                if (YapayZeka.ImageLocation != "Hurkanix Settings//Angel.gif")
                    YapayZeka.ImageLocation = "Hurkanix Settings//Angel.gif";

                //Boyle yaparak 300 salisede dolduran cheat bar doldurucuyu onlemis olduk ^^
                YapayZeka_Cheat_Hazir_Mi = true;

                Buyu_Akisi_Timer.Enabled = false;
                Hp_Mp_Timer.Enabled = false;
                YapayZeka_Davranis_Timer.Enabled = false;
                Oyuncu_Cheats_Timer.Enabled = false;
                Para_Timer.Enabled = false;

                YapayZeka_Cheat_Bar.ForeColor = Color.White;

                if (YapayZeka_Cheat_Bar.Value != 100 && YapayZeka_Hp_Bar.Value == 0 && YapayZeka_Mp_Bar.Value == 0)
                {
                    if (YapayZeka_Cheat_Bar.Value > 90)
                        YapayZeka_Cheat_Bar.Value = 100;
                    else
                        YapayZeka_Cheat_Bar.Value += 10;
                    if (YapayZeka_Cheat_Bar.Value == 100)
                        YapayZeka_Cheat_Haber_PictureBox.ImageLocation = "Hurkanix Settings//Lord_Voldemort_2.gif";
                }
                else
                {
                    YapayZeka_Hp_Bar.ForeColor = YapayZeka_Mp_Bar.ForeColor = YapayZeka_Hp_Yuzdelik.BackColor = YapayZeka_Mp_Yuzdelik.BackColor = Exit_Yazi.ForeColor;
                    YapayZeka_Cheat_Bar.ForeColor = Color.DarkRed;

                    if (YapayZeka_Hp_Bar.Value != 100)
                    {
                        if (YapayZeka_Hp_Bar.Value == 99)
                            YapayZeka_Hp_Bar.Value += 1;
                        else
                            YapayZeka_Hp_Bar.Value += 2;
                    }


                    if (YapayZeka_Mp_Bar.Value != 100)
                    {
                        if (YapayZeka_Mp_Bar.Value == 99)
                            YapayZeka_Mp_Bar.Value += 1;
                        else
                            YapayZeka_Mp_Bar.Value += 2;
                    }


                    YapayZeka_Hp_Yuzdelik.Text = "[HP]: %" + YapayZeka_Hp_Bar.Value;
                    YapayZeka_Mp_Yuzdelik.Text = "[MP]: %" + YapayZeka_Mp_Bar.Value;

                    //Cheat Bar'i harcadigimiz icin ses cikaracak
                    if (YapayZeka_Cheat_Bar.Value == 100)
                    {
                        WMP5.URL = "Hurkanix Settings//Teemo_Laugh.mp3";
                    }

                    if (YapayZeka_Cheat_Bar.Value != 0)
                    {
                        if (YapayZeka_Cheat_Bar.Value >= 5)
                            YapayZeka_Cheat_Bar.Value -= 5;
                        else
                            YapayZeka_Cheat_Bar.Value = 0;
                    }

                    if (YapayZeka_Hp_Bar.Value == 100 && YapayZeka_Mp_Bar.Value == 100 && YapayZeka_Cheat_Bar.Value == 0)
                    {
                        //YapayZeka cheat hizini eskiye dondurduk
                        YapayZeka_Cheats_Timer.Interval = 300;

                        YapayZeka.Visible = true;
                        YapayZeka.ImageLocation = "Hurkanix Settings//Dolores_Umbridge_2.gif";
                        YapayZeka.Location = new Point(872, 159);
                        YapayZeka.Size = new Size(298, 170);

                        YapayZeka_Hp_Bar.ForeColor = Color.DarkRed;
                        YapayZeka_Mp_Bar.ForeColor = Color.MidnightBlue;
                        YapayZeka_Hp_Yuzdelik.BackColor = Color.Red;
                        YapayZeka_Mp_Yuzdelik.BackColor = Color.RoyalBlue;
                        YapayZeka_Revive_Aktiflestirici = false;
                        YapayZeka_Revive_Mevcut_Mu = false;
                        YapayZeka_A_CheckBox.Visible = false;
                        YapayZeka_Cheat_Haber_PictureBox.ImageLocation = "Hurkanix Settings//Lord_Voldemort_1.gif";


                        //YapayZeka'nin Yeteneklerinin Konumlari Degisiyor
                        YapayZeka_A_CheckBox.Visible = false;
                        YapayZeka_Item_A.Visible = false;
                        YapayZeka_Item_A_Fiyat.Visible = false;
                        YapayZeka_A_CheckBox.Visible = false;
                        YapayZeka_Item_B.Location = new Point(156, 73);
                        YapayZeka_B_CheckBox.Location = new Point(191, 102);
                        YapayZeka_Item_B_Fiyat.Location = new Point(153, 115);
                        YapayZeka_Item_C.Location = new Point(227, 73);
                        YapayZeka_C_CheckBox.Location = new Point(262, 102);
                        YapayZeka_Item_C_Fiyat.Location = new Point(225, 115);


                        YapayZeka_Cheat_Bar.ForeColor = Color.White;
                        YapayZeka_Cheat_Hazir_Mi = false;

                        if (Oyuncu_Hp_Bar.Value > 0)
                        {
                            Buyu_Akisi_Timer.Enabled = true;
                            Hp_Mp_Timer.Enabled = true;
                            YapayZeka_Davranis_Timer.Enabled = true;
                            Oyuncu_Cheats_Timer.Enabled = true;
                            Para_Timer.Enabled = true;
                        }
                        else
                        {
                            Oyun_Sonu = true;
                            WMP1.Ctlcontrols.stop();
                            WMP2.Ctlcontrols.stop();
                            WMP3.Ctlcontrols.stop();
                            WMP5.Ctlcontrols.stop();
                            WMP6.Ctlcontrols.stop();
                            Oyuncu_Cheat_Haber_PictureBox.ImageLocation = "Hurkanix Settings//Lord_Voldemort_1.gif";
                            Para_Timer.Enabled = false;
                            Buyu_Akisi_Timer.Enabled = false;
                            Oyun_Zamanlayici_Timer.Enabled = false;
                            Hp_Mp_Timer.Enabled = false;
                            YapayZeka_Davranis_Timer.Enabled = false;
                            YapayZeka_Cheats_Timer.Enabled = false;
                            Oyuncu_Cheats_Timer.Enabled = false;

                            Oyuncu_Kalkan.Visible = false;
                            Oyuncu.Visible = true;
                            Oyuncu.Location = new Point(15, 295);
                            Oyuncu.Size = new Size(200, 131);
                            Oyuncu.ImageLocation = "Hurkanix Settings//Rip.png";

                            Oyuncu_Hp_Bar.Value = 0;
                            Oyuncu_Mp_Bar.Value = 0;

                            Oyuncu_Rp_Bar.Value = 0;
                            Oyuncu_Cheat_Bar.Value = 0;

                            Oyuncu_Rp_Bar.ForeColor = Color.Gold;
                            Oyuncu_Rp_Yuzdelik.BackColor = Color.Gold;
                            Oyuncu_Cheat_Bar.ForeColor = Color.White;

                            Oyuncu_Hp_Bar.ForeColor = Color.DarkRed;
                            Oyuncu_Mp_Bar.ForeColor = Color.MidnightBlue;
                            Oyuncu_Hp_Yuzdelik.BackColor = Color.Red;
                            Oyuncu_Mp_Yuzdelik.BackColor = Color.RoyalBlue;

                            YapayZeka_Hp_Bar.ForeColor = Color.DarkRed;
                            YapayZeka_Mp_Bar.ForeColor = Color.MidnightBlue;
                            YapayZeka_Hp_Yuzdelik.BackColor = Color.Red;
                            YapayZeka_Mp_Yuzdelik.BackColor = Color.RoyalBlue;

                            Oyuncu_Hp_Yuzdelik.Text = "[HP]: %0";
                            Oyuncu_Mp_Yuzdelik.Text = "[MP]: %0";
                            Oyuncu_Rp_Yuzdelik.Text = "[RP]: %0";
                            WMP4.URL = "Hurkanix Settings//They_Never_Learn.mp3";

                            //Oyun Sonu Ekrani Aciliyor
                            GameOver End = new GameOver();
                            End.Oyun_Sonu_Raporu.Text = "Buyucu savasini " + YapayZeka_Isim.Text + " kazandi ve savas " + Dakika + " dakika " + Saniye + " saniyede sonuclandi !";
                            End.Play_Again_Button.Text = "P L A Y   A G A I N";
                            End.Show();
                            GameMode2_Hide = false;
                            End_Timer.Enabled = true;
                        }
                    }
                }

            }
        }


        private bool Oyuncu_Pasif_Kalkan_Satin_Almis_Mi = true;
        private bool Oyuncu_Cheat_Hazir_Mi = true;
        private bool Oyuncu_Kalkan_Tukeniyor_Mu = false;

        private bool Oyuncu_Pasif_Lanet_Satin_Almis_Mi = false;
        private int Oyuncu_Lanet_Vurus_Sayisi = 0;

        private bool Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi = false;
        private bool Oyuncu_is_Cheating = false;
        private void Oyuncu_Cheats_Timer_Yeri(object sender, EventArgs e)
        {

            //OYUNCU CHEAT BAR DOLDURMA YERI
            if (Oyuncu_Cheat_Hazir_Mi == false)
            {
                Oyuncu_Cheats_Timer.Interval = 300; //Pasif skill dolma hizi

                if (Oyuncu_Cheat_Bar.Value <= 98)
                    Oyuncu_Cheat_Bar.Value += 2;
                else
                    Oyuncu_Cheat_Bar.Value = 100;

                if (Oyuncu_Cheat_Bar.Value == 100)
                {
                    Oyuncu_Cheat_Hazir_Mi = true;
                    Oyuncu_Cheat_Haber_PictureBox.ImageLocation = "Hurkanix Settings//Lord_Voldemort_2.gif";
                    Oyuncu_Cheats_Timer.Interval = 100; //Pasif skill sifirlanma hizi
                }

            }


            //EGER PASIF YETENEGIMIZ KALKAN ISE
            if (Oyuncu_Pasif_Kalkan_Satin_Almis_Mi == true && Oyuncu_Kalkan_Tukeniyor_Mu == true && YapayZeka_Revive_Aktiflestirici == false)
            {
                Oyuncu_Cheats_Timer.Interval = 100; //Pasif skill sifirlanma hizi

                //Oyuncunun cheat yaptiginin haberini veren resmi gorunur yaptik ve ses cikartmasini sagladik
                if (Oyuncu_Cheat_Bar.Value == 100)
                {
                    WMP6.URL = "Hurkanix Settings//Teemo_Laugh.mp3";
                }

                Oyuncu_Cheat_Bar.ForeColor = Color.DarkRed;


                if (Oyuncu_Cheat_Bar.Value != 0)
                    if (Oyuncu_Cheat_Bar.Value >= 10)
                        Oyuncu_Cheat_Bar.Value -= 10;
                    else
                        Oyuncu_Cheat_Bar.Value = 0;


                if (Oyuncu_Cheat_Bar.Value == 0)
                {
                    Oyuncu_Cheat_Bar.ForeColor = Color.White;
                    Oyuncu_Cheat_Hazir_Mi = false;
                    Oyuncu_Kalkan_Tukeniyor_Mu = false;
                    Oyuncu_Cheat_Haber_PictureBox.ImageLocation = "Hurkanix Settings//Lord_Voldemort_1.gif";
                    Oyuncu_Cheats_Timer.Interval = 300; //Pasif skill dolma hizi
                }

            }




            //EGER PASIF YETENEGIMIZ LANET ISE
            if (Oyuncu_Pasif_Lanet_Satin_Almis_Mi == true && YapayZeka_Revive_Aktiflestirici == false && Oyuncu_Cheat_Hazir_Mi == true && (YapayZeka_is_Cheating == false || YapayZeka_is_Cheating == true) || (Oyuncu_is_Cheating == true && Oyuncu_Pasif_Lanet_Satin_Almis_Mi == true))
            {
                Oyuncu_is_Cheating = true;
                Oyuncu_Cheats_Timer.Interval = 1000; //Pasif Skill Lanet'in uygulanma hizi

                //Oyuncu'nun cheat yaptiginin haberini veren ses cikartmasini sagladik
                if (Oyuncu_Cheat_Bar.Value == 100)
                {
                    WMP6.URL = "Hurkanix Settings//Teemo_Laugh.mp3";
                }

                //Oyuncu'nun Hp ve Mp Azalmasi Durumunda Renkleri Degisecektir
                YapayZeka_Hp_Bar.ForeColor = YapayZeka_Hp_Yuzdelik.BackColor = Color.Black;
                YapayZeka_Mp_Bar.ForeColor = YapayZeka_Mp_Yuzdelik.BackColor = Color.Black;
                Oyuncu_Cheat_Bar.ForeColor = Color.DarkRed;

                if (Oyuncu_Lanet_Vurus_Sayisi < 5)
                {
                    if (YapayZeka_Hp_Bar.Value > 0)
                        if (YapayZeka_Hp_Bar.Value < 10)
                            YapayZeka_Hp_Bar.Value = 0;
                        else
                            YapayZeka_Hp_Bar.Value -= 10;
                    if (YapayZeka_Mp_Bar.Value > 0)
                        if (YapayZeka_Mp_Bar.Value < 10)
                            YapayZeka_Mp_Bar.Value = 0;
                        else
                            YapayZeka_Mp_Bar.Value -= 10;

                    YapayZeka_Hp_Yuzdelik.Text = "[HP]: %" + YapayZeka_Hp_Bar.Value;
                    YapayZeka_Mp_Yuzdelik.Text = "[MP]: %" + YapayZeka_Mp_Bar.Value;

                }

                if (Oyuncu_Lanet_Vurus_Sayisi < 5)
                    Oyuncu_Lanet_Vurus_Sayisi++;

                if (Oyuncu_Cheat_Bar.Value != 0)
                    if (Oyuncu_Cheat_Bar.Value <= 20)
                        Oyuncu_Cheat_Bar.Value = 0;
                    else
                        Oyuncu_Cheat_Bar.Value -= 20;


                if (Oyuncu_Lanet_Vurus_Sayisi == 5)
                {
                    YapayZeka_Hp_Bar.ForeColor = Color.DarkRed;
                    YapayZeka_Mp_Bar.ForeColor = Color.MidnightBlue;
                    YapayZeka_Hp_Yuzdelik.BackColor = Color.Red;
                    YapayZeka_Mp_Yuzdelik.BackColor = Color.RoyalBlue;
                    Oyuncu_Lanet_Vurus_Sayisi = 0;
                    Oyuncu_is_Cheating = false;
                    Oyuncu_Cheat_Bar.ForeColor = Color.White;
                    Oyuncu_Cheat_Hazir_Mi = false;
                    Oyuncu_Cheat_Haber_PictureBox.ImageLocation = "Hurkanix Settings//Lord_Voldemort_1.gif";
                    Oyuncu_Cheats_Timer.Interval = 300;  //Pasif Skill dolma hizi
                }

            }



            // EGER PASIF YETENEGIMIZ OYUNCULAR ARASI HP VE MP DEGISIMI ISE
            if (Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == true && YapayZeka_Revive_Aktiflestirici == false && (Oyuncu_Anlik_Hp_Miktari <= 40 && ((Oyuncu_Anlik_Hp_Miktari < YapayZeka_Anlik_Hp_Miktari) || (Oyuncu_Anlik_Mp_Miktari < YapayZeka_Anlik_Mp_Miktari))) && Oyuncu_Cheat_Hazir_Mi == true && ((YapayZeka_is_Cheating == false) || (YapayZeka_is_Cheating == true)) && ((Oyuncu_Korunuyor_Mu == false && Oyuncu_Rp_Consume == true) || (Oyuncu_Korunuyor_Mu == true && Oyuncu_Rp_Consume == false) || (Oyuncu_Korunuyor_Mu == false && Oyuncu_Rp_Consume == false)) || (Oyuncu_is_Cheating == true && Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == true))
            {
                Oyuncu_Cheats_Timer.Interval = 100; //Pasif Skill Hp ve Mp nin dolma hizi

                Oyuncu_is_Cheating = true;

                Buyu_Akisi_Timer.Enabled = false;
                Hp_Mp_Timer.Enabled = false;
                YapayZeka_Cheats_Timer.Enabled = false;
                Para_Timer.Enabled = false;


                //Oyuncu'nun cheat yaptiginin haberini veren ses cikartmasini sagladik
                if (Oyuncu_Cheat_Bar.Value == 100 && Oyuncu_is_Cheating == true)
                {
                    WMP6.URL = "Hurkanix Settings//Teemo_Laugh.mp3";
                }

                //Oyuncularin hp ve mp bari rengarenk oluyor
                Oyuncu_Hp_Bar.ForeColor = Oyuncu_Mp_Bar.ForeColor = Oyuncu_Hp_Yuzdelik.BackColor = Oyuncu_Mp_Yuzdelik.BackColor = Exit_Yazi.ForeColor;
                YapayZeka_Hp_Bar.ForeColor = YapayZeka_Mp_Bar.ForeColor = YapayZeka_Hp_Yuzdelik.BackColor = YapayZeka_Mp_Yuzdelik.BackColor = Color.Black;
                Oyuncu_Cheat_Bar.ForeColor = Color.DarkRed;

                if ((Oyuncu_Hp_Bar.Value != YapayZeka_Anlik_Hp_Miktari) && (Oyuncu_Hp_Bar.Value < YapayZeka_Anlik_Hp_Miktari))
                {
                    //Oyuncu'nun Hp si artiyor
                    if (Oyuncu_Hp_Bar.Value == 99)
                        Oyuncu_Hp_Bar.Value += 1;
                    else
                        Oyuncu_Hp_Bar.Value += 2;
                    if (Oyuncu_Hp_Bar.Value > YapayZeka_Anlik_Hp_Miktari)
                        Oyuncu_Hp_Bar.Value = YapayZeka_Anlik_Hp_Miktari;

                    //YapayZeka'nin Hp si azaliyor
                    if (YapayZeka_Hp_Bar.Value == 1)
                        YapayZeka_Hp_Bar.Value -= 1;
                    else
                        YapayZeka_Hp_Bar.Value -= 2;
                    if (YapayZeka_Hp_Bar.Value < Oyuncu_Anlik_Hp_Miktari)
                        YapayZeka_Hp_Bar.Value = Oyuncu_Anlik_Hp_Miktari;

                    YapayZeka_Hp_Yuzdelik.Text = "[HP]: %" + YapayZeka_Hp_Bar.Value;
                    Oyuncu_Hp_Yuzdelik.Text = "[HP]: %" + Oyuncu_Hp_Bar.Value;
                }


                if ((Oyuncu_Mp_Bar.Value != YapayZeka_Anlik_Mp_Miktari) && (Oyuncu_Mp_Bar.Value < YapayZeka_Anlik_Mp_Miktari))
                {
                    //Oyuncu'nun Mp si artiyor
                    if (Oyuncu_Mp_Bar.Value == 99)
                        Oyuncu_Mp_Bar.Value += 1;
                    else
                        Oyuncu_Mp_Bar.Value += 2;
                    if (Oyuncu_Mp_Bar.Value > YapayZeka_Anlik_Mp_Miktari)
                        Oyuncu_Mp_Bar.Value = YapayZeka_Anlik_Mp_Miktari;

                    //YapayZeka'nin Mp si azaliyor
                    if (YapayZeka_Mp_Bar.Value == 1)
                        YapayZeka_Mp_Bar.Value -= 1;
                    else
                        YapayZeka_Mp_Bar.Value -= 2;
                    if (YapayZeka_Mp_Bar.Value < Oyuncu_Anlik_Mp_Miktari)
                        YapayZeka_Mp_Bar.Value = Oyuncu_Anlik_Mp_Miktari;

                    YapayZeka_Mp_Yuzdelik.Text = "[MP]: %" + YapayZeka_Mp_Bar.Value;
                    Oyuncu_Mp_Yuzdelik.Text = "[MP]: %" + Oyuncu_Mp_Bar.Value;
                }


                if (Oyuncu_Cheat_Bar.Value != 0)
                    if (Oyuncu_Cheat_Bar.Value >= 5)
                        Oyuncu_Cheat_Bar.Value -= 5;
                    else
                        Oyuncu_Cheat_Bar.Value = 0;


                if ((Oyuncu_Hp_Bar.Value >= YapayZeka_Anlik_Hp_Miktari) && (Oyuncu_Mp_Bar.Value >= YapayZeka_Anlik_Mp_Miktari) && Oyuncu_Cheat_Bar.Value == 0)
                {
                    Oyuncu_Hp_Bar.ForeColor = YapayZeka_Hp_Bar.ForeColor = Color.DarkRed;
                    Oyuncu_Mp_Bar.ForeColor = YapayZeka_Mp_Bar.ForeColor = Color.MidnightBlue;
                    Oyuncu_Hp_Yuzdelik.BackColor = YapayZeka_Hp_Yuzdelik.BackColor = Color.Red;
                    Oyuncu_Mp_Yuzdelik.BackColor = YapayZeka_Mp_Yuzdelik.BackColor = Color.RoyalBlue;
                    Buyu_Akisi_Timer.Enabled = true;
                    Hp_Mp_Timer.Enabled = true;
                    Para_Timer.Enabled = true;
                    YapayZeka_Cheats_Timer.Enabled = true;
                    Oyuncu_is_Cheating = false;
                    Oyuncu_Cheat_Bar.ForeColor = Color.White;
                    Oyuncu_Cheat_Hazir_Mi = false;
                    Oyuncu_Cheat_Haber_PictureBox.ImageLocation = "Hurkanix Settings//Lord_Voldemort_1.gif";
                    Oyuncu_Cheats_Timer.Interval = 300; //Pasif skill dolma hizi
                }
                else
                    Oyuncu_is_Cheating = true;
            }

        }

        private void Exit_Buton_Tikla(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Oyun_Zamanlayici_Timer_Tick(object sender, EventArgs e)
        {
            if (ItemShop_Aktif_Mi == false)
            {
                if (Saniye < 60)
                    Saniye++;
                if (Saniye == 60)
                {
                    Saniye = 0;
                    Dakika++;
                }


                if (Dakika < 10 && Saniye < 10)
                    Timer_Saat_Gosterici.Text = " 0" + (Dakika) + " : 0" + (Saniye);
                if (Dakika < 10 && Saniye >= 10)
                    Timer_Saat_Gosterici.Text = " 0" + (Dakika) + " : " + (Saniye);
                if (Dakika >= 10 && Saniye < 10)
                    Timer_Saat_Gosterici.Text = " " + (Dakika) + " : 0" + (Saniye);
                if (Dakika >= 10 && Saniye >= 10)
                    Timer_Saat_Gosterici.Text = " " + (Dakika) + " : " + (Saniye);
            }
        }

        private void Para_Timer_Yeri(object sender, EventArgs e)
        {
            if (Oyuncu_Gold_Miktari < 1000)
                Oyuncu_Gold_Miktari += 5;
            if (Oyuncu_Gold_Miktari >= 1000)
                Oyuncu_Gold_Miktari = 1000;

            Oyuncu_Gold_Gostergesi.Text = Oyuncu_Gold_Miktari.ToString();
        }
        private void Oyuncu_Item_A_DoubleClick(object sender, EventArgs e)
        {
            if (End_Timer.Enabled == false && Oyuncu_Gold_Miktari >= 200 && ItemShop_Aktif_Mi == true && Oyuncu_Pasif_Kalkan_Satin_Almis_Mi == false)
            {
                Oyuncu_Gold_Miktari -= 200;
                Oyuncu_A_CheckBox.Visible = true;
                Oyuncu_B_CheckBox.Visible = false;
                Oyuncu_C_CheckBox.Visible = false;
                Oyuncu_Gold_Gostergesi.Text = Oyuncu_Gold_Miktari.ToString();
                Oyuncu_Pasif_Lanet_Satin_Almis_Mi = false;
                Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi = false;
                Oyuncu_Pasif_Kalkan_Satin_Almis_Mi = true;
            }
        }
        private void Oyuncu_Item_B_DoubleClick(object sender, EventArgs e)
        {
            if (End_Timer.Enabled == false && Oyuncu_Gold_Miktari >= 400 && ItemShop_Aktif_Mi == true && Oyuncu_Pasif_Lanet_Satin_Almis_Mi == false)
            {
                Oyuncu_Gold_Miktari -= 400;
                Oyuncu_A_CheckBox.Visible = false;
                Oyuncu_B_CheckBox.Visible = true;
                Oyuncu_C_CheckBox.Visible = false;
                Oyuncu_Gold_Gostergesi.Text = Oyuncu_Gold_Miktari.ToString();
                Oyuncu_Pasif_Kalkan_Satin_Almis_Mi = false;
                Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi = false;
                Oyuncu_Pasif_Lanet_Satin_Almis_Mi = true;

            }
        }
        private void Oyuncu_Item_C_DoubleClick(object sender, EventArgs e)
        {
            if (End_Timer.Enabled == false && Oyuncu_Gold_Miktari >= 600 && ItemShop_Aktif_Mi == true && Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false)
            {
                Oyuncu_Gold_Miktari -= 600;
                Oyuncu_A_CheckBox.Visible = false;
                Oyuncu_B_CheckBox.Visible = false;
                Oyuncu_C_CheckBox.Visible = true;
                Oyuncu_Gold_Gostergesi.Text = Oyuncu_Gold_Miktari.ToString();
                Oyuncu_Pasif_Kalkan_Satin_Almis_Mi = false;
                Oyuncu_Pasif_Lanet_Satin_Almis_Mi = false;
                Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi = true;
            }
        }

        private void Oyuncu_Item_A_Aciklama_MouseEnter(object sender, EventArgs e)
        {
            if (End_Timer.Enabled == false)
            {
                Pasif_Yetenekler_Aciklama.Text = "[PASSIVE]\nRakibin bir sonraki saldirisindan oyuncunun hasar almasini engeller. Bu yetenek oyuncunun aktif kalkani varken etkinlesemez !";
                Pasif_Yetenekler_Aciklama.Visible = true;
            }
        }

        private void Oyuncu_Item_B_Aciklama_MouseEnter(object sender, EventArgs e)
        {
            if (End_Timer.Enabled == false)
            {
                Pasif_Yetenekler_Aciklama.Text = "[PASSIVE]\nRakibe 5 saniye boyunca\netkin olacak bir lanet uygulayarak her saniye basina rakibin HP ve MP degerinin\n10'ar 10'ar azalmasini saglar.";
                Pasif_Yetenekler_Aciklama.Visible = true;
            }
        }

        private void Oyuncu_Item_C_Aciklama_MouseEnter(object sender, EventArgs e)
        {
            if (End_Timer.Enabled == false)
            {
                Pasif_Yetenekler_Aciklama.Text = "[PASSIVE]\nOyuncunun HP degeri 40'in altina duserse ve rakibin HP degeri oyuncununkinden yuksekse HP degerleri birbiriyle degisir.\nEger rakibin MP degeri oyuncununkinden yuksekse MP degerleri de birbiriyle degisir !";
                Pasif_Yetenekler_Aciklama.Visible = true;
            }
        }

        private void YapayZeka_Item_A_Aciklama_MouseEnter(object sender, EventArgs e)
        {
            if (End_Timer.Enabled == false)
            {
                Pasif_Yetenekler_Aciklama.Text = "[PASSIVE]\nEger oyuncu olumcul bir darbe alirsa pasif skill kutusunu full olana kadar doldurur ve kendisini dirilterek HP ve MP degerini yeniler. Bu yetenek oyun boyunca yalnizca 1 kere kullanilabilir !";
                Pasif_Yetenekler_Aciklama.Visible = true;
            }
        }

        private void YapayZeka_Item_B_Aciklama_MouseEnter(object sender, EventArgs e)
        {
            if (End_Timer.Enabled == false)
            {
                Pasif_Yetenekler_Aciklama.Text = "[PASSIVE]\nRakibin anlik HP ve MP degerini aniden %50 azaltan\ninanilmaz bir lanet uygular.";
                Pasif_Yetenekler_Aciklama.Visible = true;
            }
        }

        private void YapayZeka_Item_C_Aciklama_MouseEnter(object sender, EventArgs e)
        {
            if (End_Timer.Enabled == false)
            {
                Pasif_Yetenekler_Aciklama.Text = "[PASSIVE]\nOyuncunun HP degeri 40'in altina duserse HP ve MP degerini inanilmaz bir sekilde yeniler.";
                Pasif_Yetenekler_Aciklama.Visible = true;
            }
        }

        private void Oyuncu_ve_YapayZeka_Item_ABC_Aciklama_MouseLeave(object sender, EventArgs e)
        {
            Pasif_Yetenekler_Aciklama.Visible = false;
        }

        public static bool Game_Paused = false;
        private void Settings_Button_Click(object sender, EventArgs e)
        {
            Game_Paused = true;
            Buyu_Akisi_Timer.Enabled = false;
            Hp_Mp_Timer.Enabled = false;
            Oyuncu_Cheats_Timer.Enabled = false;
            YapayZeka_Cheats_Timer.Enabled = false;
            Oyun_Zamanlayici_Timer.Enabled = false;
            Para_Timer.Enabled = false;
            Exit_Button.Enabled = false;
            Settings_Button.Enabled = false;
            End_Timer.Enabled = true;

            GameOver Settings = new GameOver();
            Settings.Oyun_Sonu_Raporu.Text = "Oyun Durduruldu";
            Settings.Play_Again_Button.Text = "R E S U M E";
            Settings.Show();
            GameMode2_Hide = false;
        }

        public static bool GameMode2_Hide = false;
        private void End_Timer_Yeri(object sender, EventArgs e)
        {
            //Ekrana Tiklanmasini Engeller
            Exit_Button.Enabled = false;
            Settings_Button.Enabled = false;
            if (GameMode2_Hide == true)
            {
                this.Dispose();
            }
        }
    }
}
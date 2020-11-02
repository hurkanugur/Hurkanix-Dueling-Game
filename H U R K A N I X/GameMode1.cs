using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace H_U_R_K_A_N_I_X
{
    public partial class GameMode1 : Form
    {
        public GameMode1()
        {
            KeyPreview = true;
            InitializeComponent();
        }

        private bool Oyuncu1_Saldiriyor_Mu = false;
        private bool Oyuncu2_Saldiriyor_Mu = false;
        private bool Oyuncu1_Korunuyor_Mu = false;
        private bool Oyuncu2_Korunuyor_Mu = false;
        private bool Oyuncu1_Ozel_Guc_Mevcut_Mu = false;
        private bool Oyuncu2_Ozel_Guc_Mevcut_Mu = false;
        private bool Oyuncu1_Rp_Load_First = false;
        private bool Oyuncu1_Rp_Load_Second = false;
        private bool Oyuncu2_Rp_Load_First = false;
        private bool Oyuncu2_Rp_Load_Second = false;
        private bool Oyuncu1_Rp_Consume = false;
        private bool Oyuncu2_Rp_Consume = false;
        private int Oyuncu1_Anlik_Hp_Miktari;
        private int Oyuncu2_Anlik_Hp_Miktari;
        private int Oyuncu1_Anlik_Mp_Miktari;
        private int Oyuncu2_Anlik_Mp_Miktari;
        private bool Oyuncu1_Aktif_Kalkan_Bozuluyor_Mu = false;
        private bool Oyuncu2_Aktif_Kalkan_Bozuluyor_Mu = false;
        private int Oyuncu1_Aktif_Kalkan_Bozulma_Sayaci = 0;
        private int Oyuncu2_Aktif_Kalkan_Bozulma_Sayaci = 0;
        private bool Oyun_Sonu = false;

        public string KullaniciAdi_1;
        public string KullaniciAdi_2;

        private bool ItemShop_Aktif_Mi = false;

        private int Saniye = 0;
        private int Dakika = 0;

        private int Oyuncu1_Gold_Miktari = 0;
        private int Oyuncu2_Gold_Miktari = 0;


        private void GameMode1_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon("Hurkanix Settings//Hurkanix.ico");
            Oyuncu1_Kalkan.ImageLocation = "Hurkanix Settings//Kalkan1.gif";
            Oyuncu2_Kalkan.ImageLocation = "Hurkanix Settings//Kalkan2.gif";
            Oyuncu1.ImageLocation = "Hurkanix Settings//Oyuncu1.gif";
            Oyuncu2.ImageLocation = "Hurkanix Settings//Oyuncu2.gif";
            Oyuncu1_Buyu.ImageLocation = "Hurkanix Settings//Saldiri1.gif";
            Oyuncu2_Buyu.ImageLocation = "Hurkanix Settings//Saldiri2.gif";
            Bulut_1.ImageLocation = Bulut_2.ImageLocation = Bulut_3.ImageLocation = Bulut_4.ImageLocation = "Hurkanix Settings//Bulut.gif";
            this.Icon = Icon.ExtractAssociatedIcon("Hurkanix Settings//Hurkanix.ico");

            Oyuncu1_Cheat_Haber_PictureBox.ImageLocation = "Hurkanix Settings//Dolores_Umbridge_3.gif";
            Oyuncu2_Cheat_Haber_PictureBox.ImageLocation = "Hurkanix Settings//Lord_Voldemort_2.gif";

            Oyuncu1_Item_A.ImageLocation = Oyuncu2_Item_A.ImageLocation = "Hurkanix Settings//Armor.png";
            Oyuncu1_Item_B.ImageLocation = Oyuncu2_Item_B.ImageLocation = "Hurkanix Settings//Curse.png";
            Oyuncu1_Item_C.ImageLocation = Oyuncu2_Item_C.ImageLocation = "Hurkanix Settings//Bless.png";

            Exit_Button.ImageLocation = "Hurkanix Settings//Exit_Button.png";
            Settings_Button.ImageLocation = "Hurkanix Settings//Settings_Button.gif";

            Oyuncu1_Isim.Text = KullaniciAdi_1 = GameMenu.KullaniciAdi_Belirle_1;
            Oyuncu2_Isim.Text = KullaniciAdi_2 = GameMenu.KullaniciAdi_Belirle_2;

            WMP1.settings.volume = 100;
            WMP2.settings.volume = 100;
            WMP3.settings.volume = 100;
            WMP4.settings.volume = 100;
            WMP5.settings.volume = 100;
            WMP6.settings.volume = 100;

            Oyuncu1_Anlik_Hp_Miktari = Oyuncu1_Hp_Bar.Value;
            Oyuncu2_Anlik_Hp_Miktari = Oyuncu2_Hp_Bar.Value;
            Oyuncu1_Anlik_Mp_Miktari = Oyuncu1_Mp_Bar.Value;
            Oyuncu2_Anlik_Mp_Miktari = Oyuncu2_Mp_Bar.Value;



            Game_Paused = false;
            Buyu_Akisi_Timer.Enabled = true;
            Hp_Mp_Timer.Enabled = true;
            Renk_Timer.Enabled = true;
            Oyuncu1_Cheats_Timer.Enabled = true;
            Oyuncu2_Cheats_Timer.Enabled = true;
            Oyun_Zamanlayici_Timer.Enabled = true;
            Para_Timer.Enabled = true;
            Exit_Button.Enabled = true;
            Settings_Button.Enabled = true;
            End_Timer.Enabled = false;
            ItemShop_Aktif_Mi = false;
            ItemShop.ForeColor = Oyuncu1_ItemShop_Isim.ForeColor = Oyuncu2_ItemShop_Isim.ForeColor = Oyuncu1_Gold_Etiketi.ForeColor = Oyuncu2_Gold_Etiketi.ForeColor = Oyuncu1_Gold_Gostergesi.ForeColor = Oyuncu2_Gold_Gostergesi.ForeColor = Oyuncu1_Item_A_Fiyat.ForeColor = Oyuncu1_Item_B_Fiyat.ForeColor = Oyuncu1_Item_C_Fiyat.ForeColor = Oyuncu2_Item_A_Fiyat.ForeColor = Oyuncu2_Item_B_Fiyat.ForeColor = Oyuncu2_Item_C_Fiyat.ForeColor = Color.DarkRed;
            WMP1.URL = "Hurkanix Settings//GameMode1.mp3";
        }



        //TUSA BASMA EVENTI
        private void Tus_Basmak(object sender, KeyEventArgs e)
        {

            //ITEMSHOP ACIP KAPATMA TUSLARI
            if (e.KeyCode == Keys.Enter && ItemShop_Aktif_Mi == false && Game_Paused == false && End_Timer.Enabled == false && Oyuncu1_is_Cheating == false && Oyuncu2_is_Cheating == false && Oyuncu1_Kalkan_Tukeniyor_Mu == false && Oyuncu2_Kalkan_Tukeniyor_Mu == false)
            {
                Buyu_Akisi_Timer.Enabled = false;
                Hp_Mp_Timer.Enabled = false;
                Oyuncu1_Cheats_Timer.Enabled = false;
                Oyuncu2_Cheats_Timer.Enabled = false;
                Para_Timer.Enabled = false;
                ItemShop.ForeColor = Oyuncu1_ItemShop_Isim.ForeColor = Oyuncu2_ItemShop_Isim.ForeColor = Oyuncu1_Gold_Etiketi.ForeColor = Oyuncu2_Gold_Etiketi.ForeColor = Oyuncu1_Gold_Gostergesi.ForeColor = Oyuncu2_Gold_Gostergesi.ForeColor = Color.Aqua;
                Oyuncu1_Item_A_Fiyat.ForeColor = Oyuncu1_Item_B_Fiyat.ForeColor = Oyuncu1_Item_C_Fiyat.ForeColor = Oyuncu2_Item_A_Fiyat.ForeColor = Oyuncu2_Item_B_Fiyat.ForeColor = Oyuncu2_Item_C_Fiyat.ForeColor = Color.Red;
                ItemShop_Aktif_Mi = true;
            }
            if (e.KeyCode == Keys.Back && ItemShop_Aktif_Mi == true && Game_Paused == false && End_Timer.Enabled == false)
            {
                ItemShop_Aktif_Mi = false;
                ItemShop.ForeColor = Oyuncu1_ItemShop_Isim.ForeColor = Oyuncu2_ItemShop_Isim.ForeColor = Oyuncu1_Gold_Etiketi.ForeColor = Oyuncu2_Gold_Etiketi.ForeColor = Oyuncu1_Gold_Gostergesi.ForeColor = Oyuncu2_Gold_Gostergesi.ForeColor = Oyuncu1_Item_A_Fiyat.ForeColor = Oyuncu1_Item_B_Fiyat.ForeColor = Oyuncu1_Item_C_Fiyat.ForeColor = Oyuncu2_Item_A_Fiyat.ForeColor = Oyuncu2_Item_B_Fiyat.ForeColor = Oyuncu2_Item_C_Fiyat.ForeColor = Color.DarkRed;
                Buyu_Akisi_Timer.Enabled = true;
                Hp_Mp_Timer.Enabled = true;
                Oyuncu1_Cheats_Timer.Enabled = true;
                Oyuncu2_Cheats_Timer.Enabled = true;
                Para_Timer.Enabled = true;
            }

            //Imkansiz Tus Basma Olayi (Bu Olayla Ilgili Ekranda Cikan Yaziyi Silen Kodlar Renk_Timer Kisminda
            if (e.KeyCode == Keys.Enter && ItemShop_Aktif_Mi == false && (Oyuncu1_is_Cheating == true || Oyuncu2_is_Cheating == true || Oyuncu1_Cheat_Bar.ForeColor == Color.DarkRed || Oyuncu2_Cheat_Bar.ForeColor == Color.DarkRed))
            {
                if (Pasif_Yetenekler_Aciklama.Text.Contains("[WARNING]\nOfke Yuku harcaniyorken herhangi bir aktif yetenek gerceklestiremezsiniz !") == false)
                    Pasif_Yetenekler_Aciklama.Text = "[WARNING]\nHerhangi bir pasif yetenek kullanilirken Item Shop'a giris yapamazsiniz !";
                else
                    Pasif_Yetenekler_Aciklama.Text = "[WARNING]\nHerhangi bir pasif yetenek kullanilirken Item Shop'a giris yapamazsiniz !\n\n[WARNING]\nOfke Yuku harcaniyorken herhangi bir aktif yetenek gerceklestiremezsiniz !";
                Pasif_Yetenekler_Aciklama.Visible = true;
            }
            if ((Oyuncu1_Rp_Consume == true && ItemShop_Aktif_Mi == false && (e.KeyCode == Keys.Q || e.KeyCode == Keys.W)) || (Oyuncu2_Rp_Consume == true && ItemShop_Aktif_Mi == false && (e.KeyCode == Keys.O || e.KeyCode == Keys.P)))
            {
                if (Pasif_Yetenekler_Aciklama.Text.Contains("[WARNING]\nHerhangi bir pasif yetenek kullanilirken Item Shop'a giris yapamazsiniz !") == false)
                    Pasif_Yetenekler_Aciklama.Text = "[WARNING]\nOfke Yuku harcaniyorken herhangi bir aktif yetenek gerceklestiremezsiniz !";
                else
                    Pasif_Yetenekler_Aciklama.Text = "[WARNING]\nHerhangi bir pasif yetenek kullanilirken Item Shop'a giris yapamazsiniz !\n\n[WARNING]\nOfke Yuku harcaniyorken herhangi bir aktif yetenek gerceklestiremezsiniz !";

                Pasif_Yetenekler_Aciklama.Visible = true;
            }



            //Oyuncu1 icin Saldiri Tusu
            if (e.KeyCode == Keys.Q && ItemShop_Aktif_Mi == false && Game_Paused == false && End_Timer.Enabled == false)
            {
                if ((Oyuncu1_Rp_Bar.Value == 100) && (Oyuncu1_Buyu.Visible == false) && (Oyuncu1_Rp_Consume == false) && (Oyuncu1_Saldiriyor_Mu == false) && ((Oyuncu1_is_Cheating == false && Oyuncu1_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == true) || (Oyuncu1_is_Cheating == false && Oyuncu1_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false) || (Oyuncu1_is_Cheating == false && Oyuncu1_Pasif_Lanet_Satin_Almis_Mi == true) || (Oyuncu1_is_Cheating == true && Oyuncu1_Pasif_Lanet_Satin_Almis_Mi == true) || (Oyuncu1_is_Cheating == false && Oyuncu1_Pasif_Lanet_Satin_Almis_Mi == false)) && ((Oyuncu2_is_Cheating == false && Oyuncu2_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == true) || (Oyuncu2_is_Cheating == false && Oyuncu2_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false) || (Oyuncu2_is_Cheating == false && Oyuncu2_Pasif_Lanet_Satin_Almis_Mi == true) || (Oyuncu2_is_Cheating == true && Oyuncu2_Pasif_Lanet_Satin_Almis_Mi == true) || (Oyuncu2_is_Cheating == false && Oyuncu2_Pasif_Lanet_Satin_Almis_Mi == false)))
                {
                    Oyuncu1_Kalkan.Visible = false;
                    Oyuncu1_Buyu.ImageLocation = "Hurkanix Settings//SuperPower1.gif";
                    Oyuncu1_Ozel_Guc_Mevcut_Mu = true;
                    Oyuncu1.Visible = true;
                    Oyuncu1_Buyu.Visible = true;
                    Oyuncu1_Korunuyor_Mu = false;
                    Oyuncu1_Saldiriyor_Mu = true;
                    Oyuncu1_Rp_Consume = true;
                }
                else if ((Oyuncu1_Rp_Bar.Value != 100) && (Oyuncu1_Buyu.Visible == false) && (Oyuncu1_Rp_Consume == false) && (Oyuncu1_Saldiriyor_Mu == false) && ((Oyuncu1_is_Cheating == false && Oyuncu1_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == true) || (Oyuncu1_is_Cheating == false && Oyuncu1_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false) || (Oyuncu1_is_Cheating == false && Oyuncu1_Pasif_Lanet_Satin_Almis_Mi == true) || (Oyuncu1_is_Cheating == true && Oyuncu1_Pasif_Lanet_Satin_Almis_Mi == true) || (Oyuncu1_is_Cheating == false && Oyuncu1_Pasif_Lanet_Satin_Almis_Mi == false)) && ((Oyuncu2_is_Cheating == false && Oyuncu2_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == true) || (Oyuncu2_is_Cheating == false && Oyuncu2_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false) || (Oyuncu2_is_Cheating == false && Oyuncu2_Pasif_Lanet_Satin_Almis_Mi == true) || (Oyuncu2_is_Cheating == true && Oyuncu2_Pasif_Lanet_Satin_Almis_Mi == true) || (Oyuncu2_is_Cheating == false && Oyuncu2_Pasif_Lanet_Satin_Almis_Mi == false)))
                {
                    if (Oyuncu1_Mp_Bar.Value >= 20)
                    {
                        Oyuncu1_Kalkan.Visible = false;
                        Oyuncu1_Buyu.ImageLocation = "Hurkanix Settings//Saldiri1.gif";
                        Oyuncu1_Ozel_Guc_Mevcut_Mu = false;
                        Oyuncu1_Mp_Bar.Value -= 20;
                        Oyuncu1_Mp_Yuzdelik.Text = "[MP]: %" + Oyuncu1_Mp_Bar.Value;
                        Oyuncu1.Visible = true;
                        Oyuncu1_Buyu.Visible = true;
                        Oyuncu1_Korunuyor_Mu = false;
                        Oyuncu1_Saldiriyor_Mu = true;
                    }
                    else
                    {
                        Oyuncu1_Kalkan.Visible = false;
                        Oyuncu1_Ozel_Guc_Mevcut_Mu = false;
                        Oyuncu1.Visible = true;
                        Oyuncu1_Buyu.Visible = false;
                        Oyuncu1_Korunuyor_Mu = false;
                        Oyuncu1_Saldiriyor_Mu = false;
                    }
                }
            }

            //Oyuncu1 icin Kalkan Tusu
            if (e.KeyCode == Keys.W && End_Timer.Enabled == false && ItemShop_Aktif_Mi == false && Game_Paused == false)
            {
                if ((Oyuncu1_Rp_Bar.Value != 100) && (Oyuncu1_Kalkan.Visible == false) && (Oyuncu1_Rp_Consume == false) && (Oyuncu1_Korunuyor_Mu == false) && ((Oyuncu1_is_Cheating == false && Oyuncu1_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == true) || (Oyuncu1_is_Cheating == false && Oyuncu1_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false) || (Oyuncu1_is_Cheating == false && Oyuncu1_Pasif_Lanet_Satin_Almis_Mi == true) || (Oyuncu1_is_Cheating == true && Oyuncu1_Pasif_Lanet_Satin_Almis_Mi == true) || (Oyuncu1_is_Cheating == false && Oyuncu1_Pasif_Lanet_Satin_Almis_Mi == false)) && ((Oyuncu2_is_Cheating == false && Oyuncu2_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == true) || (Oyuncu2_is_Cheating == false && Oyuncu2_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false) || (Oyuncu2_is_Cheating == false && Oyuncu2_Pasif_Lanet_Satin_Almis_Mi == true) || (Oyuncu2_is_Cheating == true && Oyuncu2_Pasif_Lanet_Satin_Almis_Mi == true) || (Oyuncu2_is_Cheating == false && Oyuncu2_Pasif_Lanet_Satin_Almis_Mi == false)))
                {
                    if (Oyuncu1_Mp_Bar.Value >= 40)
                    {
                        Oyuncu1.Visible = false;
                        Oyuncu1_Kalkan.ImageLocation = "Hurkanix Settings//Kalkan1.gif";
                        Oyuncu1_Kalkan.Visible = true;
                        Oyuncu1_Korunuyor_Mu = true;
                        Oyuncu1_Ozel_Guc_Mevcut_Mu = false;
                        Oyuncu1_Mp_Bar.Value -= 40;
                        Oyuncu1_Mp_Yuzdelik.Text = "[MP]: %" + Oyuncu1_Mp_Bar.Value;
                    }
                    else
                    {
                        Oyuncu1_Kalkan.Visible = false;
                        Oyuncu1_Kalkan.ImageLocation = "Hurkanix Settings//Kalkan1.gif";
                        Oyuncu1.Visible = true;
                        Oyuncu1_Korunuyor_Mu = false;
                    }
                }
                else if (Oyuncu1_Rp_Bar.Value == 100 && (Oyuncu1_Rp_Consume == false) && ((Oyuncu1_is_Cheating == false && Oyuncu1_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == true) || (Oyuncu1_is_Cheating == false && Oyuncu1_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false) || (Oyuncu1_is_Cheating == false && Oyuncu1_Pasif_Lanet_Satin_Almis_Mi == true) || (Oyuncu1_is_Cheating == true && Oyuncu1_Pasif_Lanet_Satin_Almis_Mi == true) || (Oyuncu1_is_Cheating == false && Oyuncu1_Pasif_Lanet_Satin_Almis_Mi == false)) && ((Oyuncu2_is_Cheating == false && Oyuncu2_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == true) || (Oyuncu2_is_Cheating == false && Oyuncu2_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false) || (Oyuncu2_is_Cheating == false && Oyuncu2_Pasif_Lanet_Satin_Almis_Mi == true) || (Oyuncu2_is_Cheating == true && Oyuncu2_Pasif_Lanet_Satin_Almis_Mi == true) || (Oyuncu2_is_Cheating == false && Oyuncu2_Pasif_Lanet_Satin_Almis_Mi == false)))
                {
                    Oyuncu1_Ozel_Guc_Mevcut_Mu = true;
                    Oyuncu1.Visible = false;
                    Oyuncu1_Kalkan.ImageLocation = "Hurkanix Settings//Heal.gif";
                    Oyuncu1_Kalkan.Visible = true;
                    Oyuncu1_Korunuyor_Mu = true;
                    Oyuncu1_Rp_Consume = true;
                }
            }



            //Oyuncu2 icin Saldiri Tusu
            if (e.KeyCode == Keys.O && End_Timer.Enabled == false && ItemShop_Aktif_Mi == false && Game_Paused == false)
            {
                if ((Oyuncu2_Rp_Bar.Value == 100) && (Oyuncu2_Buyu.Visible == false) && (Oyuncu2_Rp_Consume == false) && (Oyuncu2_Saldiriyor_Mu == false) && ((Oyuncu1_is_Cheating == false && Oyuncu1_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == true) || (Oyuncu1_is_Cheating == false && Oyuncu1_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false) || (Oyuncu1_is_Cheating == false && Oyuncu1_Pasif_Lanet_Satin_Almis_Mi == true) || (Oyuncu1_is_Cheating == true && Oyuncu1_Pasif_Lanet_Satin_Almis_Mi == true) || (Oyuncu1_is_Cheating == false && Oyuncu1_Pasif_Lanet_Satin_Almis_Mi == false)) && ((Oyuncu2_is_Cheating == false && Oyuncu2_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == true) || (Oyuncu2_is_Cheating == false && Oyuncu2_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false) || (Oyuncu2_is_Cheating == false && Oyuncu2_Pasif_Lanet_Satin_Almis_Mi == true) || (Oyuncu2_is_Cheating == true && Oyuncu2_Pasif_Lanet_Satin_Almis_Mi == true) || (Oyuncu2_is_Cheating == false && Oyuncu2_Pasif_Lanet_Satin_Almis_Mi == false)))
                {
                    Oyuncu2_Kalkan.Visible = false;
                    Oyuncu2_Buyu.ImageLocation = "Hurkanix Settings//SuperPower2.gif";
                    Oyuncu2_Ozel_Guc_Mevcut_Mu = true;
                    Oyuncu2.Visible = true;
                    Oyuncu2_Buyu.Visible = true;
                    Oyuncu2_Korunuyor_Mu = false;
                    Oyuncu2_Saldiriyor_Mu = true;
                    Oyuncu2_Rp_Consume = true;
                }
                else if ((Oyuncu2_Rp_Bar.Value != 100) && (Oyuncu2_Buyu.Visible == false) && (Oyuncu2_Rp_Consume == false) && (Oyuncu2_Saldiriyor_Mu == false) && ((Oyuncu1_is_Cheating == false && Oyuncu1_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == true) || (Oyuncu1_is_Cheating == false && Oyuncu1_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false) || (Oyuncu1_is_Cheating == false && Oyuncu1_Pasif_Lanet_Satin_Almis_Mi == true) || (Oyuncu1_is_Cheating == true && Oyuncu1_Pasif_Lanet_Satin_Almis_Mi == true) || (Oyuncu1_is_Cheating == false && Oyuncu1_Pasif_Lanet_Satin_Almis_Mi == false)) && ((Oyuncu2_is_Cheating == false && Oyuncu2_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == true) || (Oyuncu2_is_Cheating == false && Oyuncu2_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false) || (Oyuncu2_is_Cheating == false && Oyuncu2_Pasif_Lanet_Satin_Almis_Mi == true) || (Oyuncu2_is_Cheating == true && Oyuncu2_Pasif_Lanet_Satin_Almis_Mi == true) || (Oyuncu2_is_Cheating == false && Oyuncu2_Pasif_Lanet_Satin_Almis_Mi == false)))
                {
                    if (Oyuncu2_Mp_Bar.Value >= 20)
                    {
                        Oyuncu2_Kalkan.Visible = false;
                        Oyuncu2_Buyu.ImageLocation = "Hurkanix Settings//Saldiri2.gif";
                        Oyuncu2_Ozel_Guc_Mevcut_Mu = false;
                        Oyuncu2_Mp_Bar.Value -= 20;
                        Oyuncu2_Mp_Yuzdelik.Text = "[MP]: %" + Oyuncu2_Mp_Bar.Value;
                        Oyuncu2.Visible = true;
                        Oyuncu2_Buyu.Visible = true;
                        Oyuncu2_Korunuyor_Mu = false;
                        Oyuncu2_Saldiriyor_Mu = true;
                    }
                    else
                    {
                        Oyuncu2_Ozel_Guc_Mevcut_Mu = false;
                        Oyuncu2.Visible = true;
                        Oyuncu2_Kalkan.Visible = false;
                        Oyuncu2_Buyu.Visible = false;
                        Oyuncu2_Korunuyor_Mu = false;
                        Oyuncu2_Saldiriyor_Mu = false;
                    }
                }
            }

            //Oyuncu2 icin Kalkan Tusu
            if (e.KeyCode == Keys.P && End_Timer.Enabled == false && ItemShop_Aktif_Mi == false && Game_Paused == false)
            {
                if ((Oyuncu2_Rp_Bar.Value != 100) && (Oyuncu2_Kalkan.Visible == false) && (Oyuncu2_Rp_Consume == false) && (Oyuncu2_Korunuyor_Mu == false) && ((Oyuncu1_is_Cheating == false && Oyuncu1_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == true) || (Oyuncu1_is_Cheating == false && Oyuncu1_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false) || (Oyuncu1_is_Cheating == false && Oyuncu1_Pasif_Lanet_Satin_Almis_Mi == true) || (Oyuncu1_is_Cheating == true && Oyuncu1_Pasif_Lanet_Satin_Almis_Mi == true) || (Oyuncu1_is_Cheating == false && Oyuncu1_Pasif_Lanet_Satin_Almis_Mi == false)) && ((Oyuncu2_is_Cheating == false && Oyuncu2_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == true) || (Oyuncu2_is_Cheating == false && Oyuncu2_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false) || (Oyuncu2_is_Cheating == false && Oyuncu2_Pasif_Lanet_Satin_Almis_Mi == true) || (Oyuncu2_is_Cheating == true && Oyuncu2_Pasif_Lanet_Satin_Almis_Mi == true) || (Oyuncu2_is_Cheating == false && Oyuncu2_Pasif_Lanet_Satin_Almis_Mi == false)))
                {
                    if (Oyuncu2_Mp_Bar.Value >= 40)
                    {
                        Oyuncu2.Visible = false;
                        Oyuncu2_Kalkan.ImageLocation = "Hurkanix Settings//Kalkan2.gif";
                        Oyuncu2_Kalkan.Visible = true;
                        Oyuncu2_Korunuyor_Mu = true;
                        Oyuncu2_Ozel_Guc_Mevcut_Mu = false;
                        Oyuncu2_Mp_Bar.Value -= 40;
                        Oyuncu2_Mp_Yuzdelik.Text = "[MP]: %" + Oyuncu2_Mp_Bar.Value;
                    }
                    else
                    {
                        Oyuncu2_Kalkan.Visible = false;
                        Oyuncu2_Kalkan.ImageLocation = "Hurkanix Settings//Kalkan2.gif";
                        Oyuncu2.Visible = true;
                        Oyuncu2_Korunuyor_Mu = false;
                    }
                }
                else if (Oyuncu2_Rp_Bar.Value == 100 && (Oyuncu2_Rp_Consume == false) && ((Oyuncu1_is_Cheating == false && Oyuncu1_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == true) || (Oyuncu1_is_Cheating == false && Oyuncu1_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false) || (Oyuncu1_is_Cheating == false && Oyuncu1_Pasif_Lanet_Satin_Almis_Mi == true) || (Oyuncu1_is_Cheating == true && Oyuncu1_Pasif_Lanet_Satin_Almis_Mi == true) || (Oyuncu1_is_Cheating == false && Oyuncu1_Pasif_Lanet_Satin_Almis_Mi == false)) && ((Oyuncu2_is_Cheating == false && Oyuncu2_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == true) || (Oyuncu2_is_Cheating == false && Oyuncu2_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false) || (Oyuncu2_is_Cheating == false && Oyuncu2_Pasif_Lanet_Satin_Almis_Mi == true) || (Oyuncu2_is_Cheating == true && Oyuncu2_Pasif_Lanet_Satin_Almis_Mi == true) || (Oyuncu2_is_Cheating == false && Oyuncu2_Pasif_Lanet_Satin_Almis_Mi == false)))
                {
                    Oyuncu2_Ozel_Guc_Mevcut_Mu = true;
                    Oyuncu2.Visible = false;
                    Oyuncu2_Kalkan.ImageLocation = "Hurkanix Settings//Heal.gif";
                    Oyuncu2_Kalkan.Visible = true;
                    Oyuncu2_Korunuyor_Mu = true;
                    Oyuncu2_Rp_Consume = true;
                }
            }
        }


        //Saldiri Hareket Eventi Baslangici
        private void Buyu_Akisi_Timer_Yeri(object sender, EventArgs e)
        {
            WMP1.Ctlcontrols.play();

            //Oyuncu 1 icin Rp yuku biriktirici (Saldirma ile birikir)
            if ((Oyuncu1_Rp_Load_First == true) && (Oyuncu1_Rp_Bar.Value < 50) && (Oyuncu1_Rp_Consume == false))
            {
                if (Oyuncu1_Rp_Bar.Value <= 45)
                    Oyuncu1_Rp_Bar.Value += 5;
                else
                    Oyuncu1_Rp_Bar.Value = 50;

                Oyuncu1_Rp_Yuzdelik.Text = "[RP]: %" + Oyuncu1_Rp_Bar.Value;

                if (Oyuncu1_Rp_Bar.Value == 50)
                    Oyuncu1_Rp_Load_First = false;
            }
            if ((Oyuncu1_Rp_Load_Second == true) && (Oyuncu1_Rp_Bar.Value < 100) && (Oyuncu1_Rp_Consume == false))
            {
                if (Oyuncu1_Rp_Bar.Value <= 95)
                    Oyuncu1_Rp_Bar.Value += 5;
                else
                    Oyuncu1_Rp_Bar.Value = 100;

                Oyuncu1_Rp_Yuzdelik.Text = "[RP]: %" + Oyuncu1_Rp_Bar.Value;
                if (Oyuncu1_Rp_Bar.Value == 100)
                {
                    Oyuncu1_Rp_Load_Second = false;
                }

            }

            //Oyuncu 2 icin Rp yuku biriktirici (Saldirma ile birikir)
            if ((Oyuncu2_Rp_Load_First == true) && (Oyuncu2_Rp_Bar.Value < 50) && (Oyuncu2_Rp_Consume == false))
            {
                if (Oyuncu2_Rp_Bar.Value <= 45)
                    Oyuncu2_Rp_Bar.Value += 5;
                else
                    Oyuncu2_Rp_Bar.Value = 50;

                Oyuncu2_Rp_Yuzdelik.Text = "[RP]: %" + Oyuncu2_Rp_Bar.Value;

                if (Oyuncu2_Rp_Bar.Value == 50)
                    Oyuncu2_Rp_Load_First = false;
            }
            if ((Oyuncu2_Rp_Load_Second == true) && (Oyuncu2_Rp_Bar.Value < 100) && (Oyuncu2_Rp_Consume == false))
            {
                if (Oyuncu2_Rp_Bar.Value <= 95)
                    Oyuncu2_Rp_Bar.Value += 5;
                else
                    Oyuncu2_Rp_Bar.Value = 100;

                Oyuncu2_Rp_Yuzdelik.Text = "[RP]: %" + Oyuncu2_Rp_Bar.Value;
                if (Oyuncu2_Rp_Bar.Value == 100)
                {
                    Oyuncu2_Rp_Load_Second = false;
                }
            }



            //Oyuncu 1 icin Rp yuku tuketici (Hem kalkan icin hem saldiri icin)
            if ((Oyuncu1_Rp_Consume == true) && (Oyuncu1_Rp_Bar.Value > 0))
            {
                if (Oyuncu1_Rp_Bar.Value >= 3)
                    Oyuncu1_Rp_Bar.Value -= 3;
                else
                    Oyuncu1_Rp_Bar.Value = 0;

                Oyuncu1_Rp_Yuzdelik.Text = "[RP]: %" + Oyuncu1_Rp_Bar.Value;

                if (Oyuncu1_Korunuyor_Mu == true)
                {
                    //Oyuncunun Hp si artar
                    if (Oyuncu1_Hp_Bar.Value != 100)
                        Oyuncu1_Hp_Bar.Value += 1;

                    //Oyuncunun Mp si artar
                    if (Oyuncu1_Mp_Bar.Value != 100)
                        Oyuncu1_Mp_Bar.Value += 1;

                    Oyuncu1_Hp_Yuzdelik.Text = "[HP]: %" + Oyuncu1_Hp_Bar.Value;
                    Oyuncu1_Mp_Yuzdelik.Text = "[MP]: %" + Oyuncu1_Mp_Bar.Value;
                }


                if (Oyuncu1_Rp_Bar.Value == 0)
                {
                    Oyuncu1_Rp_Consume = false;
                    Oyuncu1_Kalkan.Visible = false;
                    Oyuncu1_Kalkan.ImageLocation = "Hurkanix Settings//Kalkan1.gif";
                    Oyuncu1.Visible = true;
                    Oyuncu1_Korunuyor_Mu = false;
                    Oyuncu1_Ozel_Guc_Mevcut_Mu = false;
                }
            }

            //Oyuncu 2 icin Rp yuku tuketici (Hem kalkan icin hem saldiri icin)
            if ((Oyuncu2_Rp_Consume == true) && (Oyuncu2_Rp_Bar.Value > 0))
            {
                if (Oyuncu2_Rp_Bar.Value >= 3)
                    Oyuncu2_Rp_Bar.Value -= 3;
                else
                    Oyuncu2_Rp_Bar.Value = 0;

                Oyuncu2_Rp_Yuzdelik.Text = "[RP]: %" + Oyuncu2_Rp_Bar.Value;

                if (Oyuncu2_Korunuyor_Mu == true)
                {
                    //Oyuncunun Hp si artar
                    if (Oyuncu2_Hp_Bar.Value != 100)
                        Oyuncu2_Hp_Bar.Value += 1;

                    //Oyuncunun Mp si artar
                    if (Oyuncu2_Mp_Bar.Value != 100)
                        Oyuncu2_Mp_Bar.Value += 1;

                    Oyuncu2_Hp_Yuzdelik.Text = "[HP]: %" + Oyuncu2_Hp_Bar.Value;
                    Oyuncu2_Mp_Yuzdelik.Text = "[MP]: %" + Oyuncu2_Mp_Bar.Value;
                }


                if (Oyuncu2_Rp_Bar.Value == 0)
                {
                    Oyuncu2_Rp_Consume = false;
                    Oyuncu2_Kalkan.Visible = false;
                    Oyuncu2_Kalkan.ImageLocation = "Hurkanix Settings//Kalkan2.gif";
                    Oyuncu2.Visible = true;
                    Oyuncu2_Korunuyor_Mu = false;
                    Oyuncu2_Ozel_Guc_Mevcut_Mu = false;
                }
            }

            //Oyuncu1 Saldirirsa
            if (Oyuncu1_Saldiriyor_Mu == true)
            {
                Oyuncu1_Buyu.Visible = true;
                Point Saldiri1_Hareket_Konumu = new Point();
                if (Oyuncu1_Buyu.Location.X <= 740 && Oyuncu1_Buyu.Location.Y >= 168)
                {
                    Saldiri1_Hareket_Konumu.X = Oyuncu1_Buyu.Location.X + 16;
                    Saldiri1_Hareket_Konumu.Y = Oyuncu1_Buyu.Location.Y - 4;
                    Oyuncu1_Buyu.Location = Saldiri1_Hareket_Konumu;
                }
                else
                {
                    if (Oyuncu2_Korunuyor_Mu == false)
                    {

                        //Saldirinin rakibe ulasmasi halinde Rp yuku biriktirme onayi buradan veriliyor
                        if ((Oyuncu1_Rp_Bar.Value < 50) && (Oyuncu1_Rp_Bar.Value != 100) && (Oyuncu1_Ozel_Guc_Mevcut_Mu == false) && (Oyuncu1_Rp_Consume == false))
                        {
                            Oyuncu1_Rp_Load_First = true;
                        }
                        if ((Oyuncu1_Rp_Bar.Value >= 50) && (Oyuncu1_Rp_Bar.Value != 100) && (Oyuncu1_Ozel_Guc_Mevcut_Mu == false) && (Oyuncu1_Rp_Consume == false))
                        {
                            Oyuncu1_Rp_Load_Second = true;
                        }


                        //Eger super power aktifse 40 hp hasar verecek eger aktif degilse 20 hp hasar verecek
                        if (Oyuncu1_Ozel_Guc_Mevcut_Mu == true && ((Oyuncu2_Cheat_Hazir_Mi == false && Oyuncu2_Pasif_Kalkan_Satin_Almis_Mi == true) || (Oyuncu2_Pasif_Kalkan_Satin_Almis_Mi == false)))
                        {
                            if (Oyuncu2_Hp_Bar.Value <= 40)
                                Oyuncu2_Hp_Bar.Value = 0;
                            else
                                Oyuncu2_Hp_Bar.Value -= 40;

                            //Basarili ozel guc vurusu ile oyuncunun gold degeri 40 artar
                            Oyuncu1_Gold_Miktari += 40;
                        }
                        else if (Oyuncu1_Ozel_Guc_Mevcut_Mu == false && ((Oyuncu2_Cheat_Hazir_Mi == false && Oyuncu2_Pasif_Kalkan_Satin_Almis_Mi == true) || (Oyuncu2_Pasif_Kalkan_Satin_Almis_Mi == false)))
                        {
                            if (Oyuncu2_Hp_Bar.Value <= 20)
                                Oyuncu2_Hp_Bar.Value = 0;
                            else
                                Oyuncu2_Hp_Bar.Value -= 20;

                            //Basarili normal vurus ile oyuncunun gold degeri 20 artar
                            Oyuncu1_Gold_Miktari += 20;
                        }
                        else if (Oyuncu2_Cheat_Hazir_Mi == true && Oyuncu2_Pasif_Kalkan_Satin_Almis_Mi == true) //Pasif Kalkanin olmasi durumunda 1 kereligine hicbir sekilde hasar alamaz olacaktir
                        {
                            //Oyuncu1'in hasari onlense de saldirisi basarili oldugundan dolayi altin miktari artacaktir
                            if (Oyuncu1_Ozel_Guc_Mevcut_Mu == true)
                                Oyuncu1_Gold_Miktari += 40;
                            else if (Oyuncu1_Ozel_Guc_Mevcut_Mu == false)
                                Oyuncu1_Gold_Miktari += 20;

                            Oyuncu1_Buyu.Visible = false;
                            Saldiri1_Hareket_Konumu.X = 295;
                            Saldiri1_Hareket_Konumu.Y = 322;
                            Oyuncu1_Buyu.Location = Saldiri1_Hareket_Konumu;
                            Oyuncu1_Saldiriyor_Mu = false;
                            Oyuncu2_Kalkan_Tukeniyor_Mu = true;
                        }

                        Oyuncu2_Hp_Yuzdelik.Text = "[HP]: %" + Oyuncu2_Hp_Bar.Value;
                        Oyuncu1_Buyu.Visible = false;
                        Saldiri1_Hareket_Konumu.X = 295;
                        Saldiri1_Hareket_Konumu.Y = 322;
                        Oyuncu1_Buyu.Location = Saldiri1_Hareket_Konumu;
                        Oyuncu1_Saldiriyor_Mu = false;
                    }
                    else
                    {

                        Oyuncu1_Buyu.Visible = false;
                        Saldiri1_Hareket_Konumu.X = 295;
                        Saldiri1_Hareket_Konumu.Y = 322;
                        Oyuncu1_Buyu.Location = Saldiri1_Hareket_Konumu;
                        Oyuncu1_Saldiriyor_Mu = false;

                        if (Oyuncu2_Ozel_Guc_Mevcut_Mu == false)
                        {
                            Oyuncu2_Aktif_Kalkan_Bozuluyor_Mu = true;
                        }
                    }
                }
            }




            //Oyuncu2 Saldirirsa
            if (Oyuncu2_Saldiriyor_Mu == true)
            {
                Oyuncu2_Buyu.Visible = true;
                Point Saldiri2_Hareket_Konumu = new Point();
                if (Oyuncu2_Buyu.Location.X >= 295 && Oyuncu2_Buyu.Location.Y <= 322)
                {
                    Saldiri2_Hareket_Konumu.X = Oyuncu2_Buyu.Location.X - 16;
                    Saldiri2_Hareket_Konumu.Y = Oyuncu2_Buyu.Location.Y + 4;
                    Oyuncu2_Buyu.Location = Saldiri2_Hareket_Konumu;
                }
                else
                {
                    if (Oyuncu1_Korunuyor_Mu == false)
                    {

                        //Saldirinin rakibe ulasmasi halinde Rp yuku biriktirme onayi buradan veriliyor
                        if ((Oyuncu2_Rp_Bar.Value < 50) && (Oyuncu2_Rp_Bar.Value != 100) && (Oyuncu2_Ozel_Guc_Mevcut_Mu == false) && (Oyuncu2_Rp_Consume == false))
                        {
                            Oyuncu2_Rp_Load_First = true;
                        }
                        if ((Oyuncu2_Rp_Bar.Value >= 50) && (Oyuncu2_Rp_Bar.Value != 100) && (Oyuncu2_Ozel_Guc_Mevcut_Mu == false) && (Oyuncu2_Rp_Consume == false))
                        {
                            Oyuncu2_Rp_Load_Second = true;
                        }


                        //Eger super power aktifse 40 hp hasar verecek eger aktif degilse 20 hp hasar verecek
                        if (Oyuncu2_Ozel_Guc_Mevcut_Mu == true && ((Oyuncu1_Cheat_Hazir_Mi == false && Oyuncu1_Pasif_Kalkan_Satin_Almis_Mi == true) || (Oyuncu1_Pasif_Kalkan_Satin_Almis_Mi == false)))
                        {
                            if (Oyuncu1_Hp_Bar.Value <= 40)
                                Oyuncu1_Hp_Bar.Value = 0;
                            else
                                Oyuncu1_Hp_Bar.Value -= 40;

                            //Basarili ozel guc vurusu ile oyuncunun gold degeri 40 artar
                            Oyuncu2_Gold_Miktari += 40;
                        }
                        else if (Oyuncu2_Ozel_Guc_Mevcut_Mu == false && ((Oyuncu1_Cheat_Hazir_Mi == false && Oyuncu1_Pasif_Kalkan_Satin_Almis_Mi == true) || (Oyuncu1_Pasif_Kalkan_Satin_Almis_Mi == false)))
                        {
                            if (Oyuncu1_Hp_Bar.Value <= 20)
                                Oyuncu1_Hp_Bar.Value = 0;
                            else
                                Oyuncu1_Hp_Bar.Value -= 20;

                            //Basarili normal vurus ile oyuncunun gold degeri 20 artar
                            Oyuncu2_Gold_Miktari += 20;
                        }
                        else if (Oyuncu1_Cheat_Hazir_Mi == true && Oyuncu1_Pasif_Kalkan_Satin_Almis_Mi == true) //Pasif Kalkanin olmasi durumunda 1 kereligine hicbir sekilde hasar alamaz olacaktir
                        {
                            //Oyuncu2'in hasari onlense de saldirisi basarili oldugundan dolayi altin miktari artacaktir
                            if (Oyuncu2_Ozel_Guc_Mevcut_Mu == true)
                                Oyuncu2_Gold_Miktari += 40;
                            else if (Oyuncu2_Ozel_Guc_Mevcut_Mu == false)
                                Oyuncu2_Gold_Miktari += 20;

                            Oyuncu2_Buyu.Visible = false;
                            Saldiri2_Hareket_Konumu.X = 740;
                            Saldiri2_Hareket_Konumu.Y = 168;
                            Oyuncu2_Buyu.Location = Saldiri2_Hareket_Konumu;
                            Oyuncu2_Saldiriyor_Mu = false;
                            Oyuncu1_Kalkan_Tukeniyor_Mu = true;
                        }

                        Oyuncu1_Hp_Yuzdelik.Text = "[HP]: %" + Oyuncu1_Hp_Bar.Value;
                        Oyuncu2_Buyu.Visible = false;
                        Saldiri2_Hareket_Konumu.X = 740;
                        Saldiri2_Hareket_Konumu.Y = 168;
                        Oyuncu2_Buyu.Location = Saldiri2_Hareket_Konumu;
                        Oyuncu2_Saldiriyor_Mu = false;
                    }
                    else
                    {
                        Oyuncu2_Buyu.Visible = false;
                        Saldiri2_Hareket_Konumu.X = 745;
                        Saldiri2_Hareket_Konumu.Y = 168;
                        Oyuncu2_Buyu.Location = Saldiri2_Hareket_Konumu;
                        Oyuncu2_Saldiriyor_Mu = false;

                        if (Oyuncu1_Ozel_Guc_Mevcut_Mu == false)
                        {
                            Oyuncu1_Aktif_Kalkan_Bozuluyor_Mu = true;
                        }
                    }
                }
            }



            //Oyunun Bitisi
            if ((Oyuncu1_Hp_Bar.Value == 0) && (Oyuncu2_Hp_Bar.Value == 0))
            {
                Oyun_Sonu = true;
                WMP1.Ctlcontrols.stop();
                WMP2.Ctlcontrols.stop();
                WMP3.Ctlcontrols.stop();
                WMP5.Ctlcontrols.stop();
                WMP6.Ctlcontrols.stop();
                Oyuncu1_Cheat_Haber_PictureBox.ImageLocation = "Hurkanix Settings//Dolores_Umbridge_1.gif";
                Oyuncu2_Cheat_Haber_PictureBox.ImageLocation = "Hurkanix Settings//Lord_Voldemort_1.gif";
                Para_Timer.Enabled = false;
                Buyu_Akisi_Timer.Enabled = false;
                Oyun_Zamanlayici_Timer.Enabled = false;
                Hp_Mp_Timer.Enabled = false;
                Oyuncu1_Cheats_Timer.Enabled = false;
                Oyuncu2_Cheats_Timer.Enabled = false;

                Oyuncu1_Kalkan.Visible = false;
                Oyuncu1.Visible = true;
                Oyuncu1.Location = new Point(10, 265);
                Oyuncu1.Size = new Size(200, 131);
                Oyuncu1.ImageLocation = "Hurkanix Settings//Rip.png";
                Oyuncu2_Kalkan.Visible = false;
                Oyuncu2.Visible = true;
                Oyuncu2.Location = new Point(908, 160);
                Oyuncu2.Size = new Size(200, 131);
                Oyuncu2.ImageLocation = "Hurkanix Settings//Rip.png";

                Oyuncu1_Hp_Bar.Value = 0;
                Oyuncu2_Hp_Bar.Value = 0;
                Oyuncu1_Mp_Bar.Value = 0;
                Oyuncu2_Mp_Bar.Value = 0;

                Oyuncu1_Rp_Bar.Value = 0;
                Oyuncu1_Cheat_Bar.Value = 0;
                Oyuncu2_Rp_Bar.Value = 0;
                Oyuncu2_Cheat_Bar.Value = 0;


                Oyuncu1_Rp_Bar.ForeColor = Color.Gold;
                Oyuncu1_Rp_Yuzdelik.BackColor = Color.Gold;
                Oyuncu1_Cheat_Bar.ForeColor = Color.White;
                Oyuncu2_Rp_Bar.ForeColor = Color.Gold;
                Oyuncu2_Rp_Yuzdelik.BackColor = Color.Gold;
                Oyuncu2_Cheat_Bar.ForeColor = Color.White;

                Oyuncu1_Hp_Bar.ForeColor = Color.DarkRed;
                Oyuncu1_Mp_Bar.ForeColor = Color.MidnightBlue;
                Oyuncu1_Hp_Yuzdelik.BackColor = Color.Red;
                Oyuncu1_Mp_Yuzdelik.BackColor = Color.RoyalBlue;

                Oyuncu2_Hp_Bar.ForeColor = Color.DarkRed;
                Oyuncu2_Mp_Bar.ForeColor = Color.MidnightBlue;
                Oyuncu2_Hp_Yuzdelik.BackColor = Color.Red;
                Oyuncu2_Mp_Yuzdelik.BackColor = Color.RoyalBlue;

                Oyuncu1_Hp_Yuzdelik.Text = "[HP]: %0";
                Oyuncu2_Hp_Yuzdelik.Text = "[HP]: %0";
                Oyuncu1_Mp_Yuzdelik.Text = "[MP]: %0";
                Oyuncu2_Mp_Yuzdelik.Text = "[MP]: %0";

                Oyuncu1_Rp_Yuzdelik.Text = "[RP]: %0";
                Oyuncu2_Rp_Yuzdelik.Text = "[RP]: %0";

                WMP4.URL = "Hurkanix Settings//They_Never_Learn.mp3";

                //Oyun Sonu Ekrani Aciliyor
                GameOver End = new GameOver();
                End.Oyun_Sonu_Raporu.Text = "Buyucu savasi berabere bitti ve savas " + Dakika + " dakika " + Saniye + " saniyede sonuclandi !";
                End.Play_Again_Button.Text = "P L A Y   A G A I N";
                End.Show();
                GameMode1_Hide = false;
                End_Timer.Enabled = true;
            }
            else if (Oyuncu1_Hp_Bar.Value == 0)
            {
                Oyun_Sonu = true;
                WMP1.Ctlcontrols.stop();
                WMP2.Ctlcontrols.stop();
                WMP3.Ctlcontrols.stop();
                WMP5.Ctlcontrols.stop();
                WMP6.Ctlcontrols.stop();
                Oyuncu1_Cheat_Haber_PictureBox.ImageLocation = "Hurkanix Settings//Dolores_Umbridge_1.gif";
                Para_Timer.Enabled = false;
                Buyu_Akisi_Timer.Enabled = false;
                Oyun_Zamanlayici_Timer.Enabled = false;
                Hp_Mp_Timer.Enabled = false;
                Oyuncu1_Cheats_Timer.Enabled = false;
                Oyuncu2_Cheats_Timer.Enabled = false;

                Oyuncu1_Kalkan.Visible = false;
                Oyuncu1.Visible = true;
                Oyuncu1.Location = new Point(10, 265);
                Oyuncu1.Size = new Size(200, 131);
                Oyuncu1.ImageLocation = "Hurkanix Settings//Rip.png";

                Oyuncu1_Hp_Bar.Value = 0;
                Oyuncu1_Mp_Bar.Value = 0;

                Oyuncu1_Rp_Bar.Value = 0;
                Oyuncu1_Cheat_Bar.Value = 0;

                Oyuncu1_Rp_Bar.ForeColor = Color.Gold;
                Oyuncu1_Rp_Yuzdelik.BackColor = Color.Gold;
                Oyuncu1_Cheat_Bar.ForeColor = Color.White;

                Oyuncu1_Hp_Bar.ForeColor = Color.DarkRed;
                Oyuncu1_Mp_Bar.ForeColor = Color.MidnightBlue;
                Oyuncu1_Hp_Yuzdelik.BackColor = Color.Red;
                Oyuncu1_Mp_Yuzdelik.BackColor = Color.RoyalBlue;

                Oyuncu2_Hp_Bar.ForeColor = Color.DarkRed;
                Oyuncu2_Mp_Bar.ForeColor = Color.MidnightBlue;
                Oyuncu2_Hp_Yuzdelik.BackColor = Color.Red;
                Oyuncu2_Mp_Yuzdelik.BackColor = Color.RoyalBlue;

                Oyuncu1_Hp_Yuzdelik.Text = "[HP]: %0";
                Oyuncu1_Mp_Yuzdelik.Text = "[MP]: %0";
                Oyuncu1_Rp_Yuzdelik.Text = "[RP]: %0";

                WMP4.URL = "Hurkanix Settings//They_Never_Learn.mp3";

                //Oyun Sonu Ekrani Aciliyor
                GameOver End = new GameOver();
                End.Oyun_Sonu_Raporu.Text = "Buyucu savasini " + Oyuncu2_Isim.Text + " kazandi ve savas " + Dakika + " dakika " + Saniye + " saniyede sonuclandi !";
                End.Play_Again_Button.Text = "P L A Y   A G A I N";
                End.Show();
                GameMode1_Hide = false;
                End_Timer.Enabled = true;
            }
            else if (Oyuncu2_Hp_Bar.Value == 0)
            {
                Oyun_Sonu = true;
                WMP1.Ctlcontrols.stop();
                WMP2.Ctlcontrols.stop();
                WMP3.Ctlcontrols.stop();
                WMP5.Ctlcontrols.stop();
                WMP6.Ctlcontrols.stop();
                Oyuncu2_Cheat_Haber_PictureBox.ImageLocation = "Hurkanix Settings//Lord_Voldemort_1.gif";
                Para_Timer.Enabled = false;
                Buyu_Akisi_Timer.Enabled = false;
                Oyun_Zamanlayici_Timer.Enabled = false;
                Hp_Mp_Timer.Enabled = false;
                Oyuncu1_Cheats_Timer.Enabled = false;
                Oyuncu2_Cheats_Timer.Enabled = false;

                Oyuncu2_Kalkan.Visible = false;
                Oyuncu2.Visible = true;
                Oyuncu2.Location = new Point(908, 160);
                Oyuncu2.Size = new Size(200, 131);
                Oyuncu2.ImageLocation = "Hurkanix Settings//Rip.png";

                Oyuncu2_Hp_Bar.Value = 0;
                Oyuncu2_Mp_Bar.Value = 0;

                Oyuncu2_Rp_Bar.Value = 0;
                Oyuncu2_Cheat_Bar.Value = 0;

                Oyuncu2_Rp_Bar.ForeColor = Color.Gold;
                Oyuncu2_Rp_Yuzdelik.BackColor = Color.Gold;
                Oyuncu2_Cheat_Bar.ForeColor = Color.White;

                Oyuncu1_Hp_Bar.ForeColor = Color.DarkRed;
                Oyuncu1_Mp_Bar.ForeColor = Color.MidnightBlue;
                Oyuncu1_Hp_Yuzdelik.BackColor = Color.Red;
                Oyuncu1_Mp_Yuzdelik.BackColor = Color.RoyalBlue;

                Oyuncu2_Hp_Bar.ForeColor = Color.DarkRed;
                Oyuncu2_Mp_Bar.ForeColor = Color.MidnightBlue;
                Oyuncu2_Hp_Yuzdelik.BackColor = Color.Red;
                Oyuncu2_Mp_Yuzdelik.BackColor = Color.RoyalBlue;

                Oyuncu2_Hp_Yuzdelik.Text = "[HP]: %0";
                Oyuncu2_Mp_Yuzdelik.Text = "[MP]: %0";
                Oyuncu2_Rp_Yuzdelik.Text = "[RP]: %0";

                WMP4.URL = "Hurkanix Settings//They_Never_Learn.mp3";

                //Oyun Sonu Ekrani Aciliyor
                GameOver End = new GameOver();
                End.Oyun_Sonu_Raporu.Text = "Buyucu savasini " + Oyuncu1_Isim.Text + " kazandi ve savas " + Dakika + " dakika " + Saniye + " saniyede sonuclandi !";
                End.Play_Again_Button.Text = "P L A Y   A G A I N";
                End.Show();
                GameMode1_Hide = false;
                End_Timer.Enabled = true;
            }

        }


        //HP VE MP ARTIRMA EVENTI
        private static int Enough_Zamani = 0;
        private void Hp_Mp_Timer_Yeri(object sender, EventArgs e)
        {
            //Oyun Biterse Zamani Durdur
            if (Oyun_Sonu == true)
                Hp_Mp_Timer.Enabled = false;

            if (Enough_Zamani % 10 == 0)
                WMP2.URL = "Hurkanix Settings//Enough_Woods.mp3";
            Enough_Zamani++;

            //Oyuncularin Manasi Yenilenir
            if ((Oyuncu1_Mp_Bar.Value != 100) && (Oyuncu1_Hp_Bar.Value != 0))
            {
                if (Oyuncu1_Mp_Bar.Value != 100)
                    if (Oyuncu1_Mp_Bar.Value == 99)
                        Oyuncu1_Mp_Bar.Value += 1;
                    else
                        Oyuncu1_Mp_Bar.Value += 2;

                Oyuncu1_Mp_Yuzdelik.Text = "[MP]: %" + Oyuncu1_Mp_Bar.Value;
            }
            if ((Oyuncu2_Mp_Bar.Value != 100) && (Oyuncu2_Hp_Bar.Value != 0))
            {
                if (Oyuncu2_Mp_Bar.Value != 100)
                    if (Oyuncu2_Mp_Bar.Value == 99)
                        Oyuncu2_Mp_Bar.Value += 1;
                    else
                        Oyuncu2_Mp_Bar.Value += 2;

                Oyuncu2_Mp_Yuzdelik.Text = "[MP]: %" + Oyuncu2_Mp_Bar.Value;
            }


            //Oyuncularin Canlari Yenilenir
            if ((Oyuncu1_Hp_Bar.Value != 100) && (Oyuncu1_Hp_Bar.Value != 0))
            {
                if (Oyuncu1_Hp_Bar.Value != 100)
                    if (Oyuncu1_Hp_Bar.Value == 99)
                        Oyuncu1_Hp_Bar.Value += 1;
                    else
                        Oyuncu1_Hp_Bar.Value += 2;

                Oyuncu1_Hp_Yuzdelik.Text = "[HP]: %" + Oyuncu1_Hp_Bar.Value;
            }
            if ((Oyuncu2_Hp_Bar.Value != 100) && (Oyuncu2_Hp_Bar.Value != 0))
            {
                if (Oyuncu2_Hp_Bar.Value != 100)
                    if (Oyuncu2_Hp_Bar.Value == 99)
                        Oyuncu2_Hp_Bar.Value += 1;
                    else
                        Oyuncu2_Hp_Bar.Value += 2;

                Oyuncu2_Hp_Yuzdelik.Text = "[HP]: %" + Oyuncu2_Hp_Bar.Value;
            }

        }



        //Renkli Zaman Yeri
        private Random renk = new Random();
        private void Renk_Timer_Yeri(object sender, EventArgs e)
        {
            //IMKANSIZ TUS BASMA DURUMUNDAKI EKRANDAKI YAZIYI SILME KODU
            if (Oyuncu1_Rp_Consume == false && Oyuncu2_Rp_Consume == false)
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
            if (Oyuncu1_is_Cheating == false && Oyuncu2_is_Cheating == false && Oyuncu1_Cheat_Bar.ForeColor != Color.DarkRed && Oyuncu2_Cheat_Bar.ForeColor != Color.DarkRed && Pasif_Yetenekler_Aciklama.Text.Contains("[WARNING]\nHerhangi bir pasif yetenek kullanilirken Item Shop'a giris yapamazsiniz !") == true)
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
                    Oyuncu1_Cheats_Timer.Enabled = true;
                    Oyuncu2_Cheats_Timer.Enabled = true;
                    Buyu_Akisi_Timer.Enabled = true;
                    Hp_Mp_Timer.Enabled = true;
                    Para_Timer.Enabled = true;
                    ItemShop.ForeColor = Oyuncu1_ItemShop_Isim.ForeColor = Oyuncu2_ItemShop_Isim.ForeColor = Oyuncu1_Gold_Etiketi.ForeColor = Oyuncu2_Gold_Etiketi.ForeColor = Oyuncu1_Gold_Gostergesi.ForeColor = Oyuncu2_Gold_Gostergesi.ForeColor = Oyuncu1_Item_A_Fiyat.ForeColor = Oyuncu1_Item_B_Fiyat.ForeColor = Oyuncu1_Item_C_Fiyat.ForeColor = Oyuncu2_Item_A_Fiyat.ForeColor = Oyuncu2_Item_B_Fiyat.ForeColor = Oyuncu2_Item_C_Fiyat.ForeColor = Color.DarkRed;
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
                Tavan.BackColor = Sag_Yan.BackColor = Taban.BackColor = Sol_Yan.BackColor = Oyuncu1_Isim.ForeColor = Oyuncu2_Isim.ForeColor = Exit_Yazi.ForeColor;
            }
            else
            {
                Tavan.BackColor = Sag_Yan.BackColor = Taban.BackColor = Sol_Yan.BackColor = Oyuncu1_Isim.ForeColor = Oyuncu2_Isim.ForeColor = Timer_Saat_Gosterici.ForeColor = Color.DarkRed;
            }


            //Oyuncu1 ve Oyuncu2'nin Hp ve Mp degeri ekrana yazilir
            Oyuncu1_Hp_Yuzdelik.Text = "[HP]: %" + Oyuncu1_Hp_Bar.Value;
            Oyuncu1_Mp_Yuzdelik.Text = "[MP]: %" + Oyuncu1_Mp_Bar.Value;
            Oyuncu2_Hp_Yuzdelik.Text = "[HP]: %" + Oyuncu2_Hp_Bar.Value;
            Oyuncu2_Mp_Yuzdelik.Text = "[MP]: %" + Oyuncu2_Mp_Bar.Value;
            Oyuncu1_Hp_Bar.Value = Oyuncu1_Hp_Bar.Value;
            Oyuncu1_Mp_Bar.Value = Oyuncu1_Mp_Bar.Value;
            Oyuncu2_Hp_Bar.Value = Oyuncu2_Hp_Bar.Value;
            Oyuncu2_Mp_Bar.Value = Oyuncu2_Mp_Bar.Value;



            //RP Bar'lari 100 olunca rengarenk olacaklar
            if (Oyuncu1_Rp_Bar.Value == 100)
                Oyuncu1_Rp_Bar.ForeColor = Oyuncu1_Rp_Yuzdelik.BackColor = Exit_Yazi.ForeColor;
            else if (Oyuncu1_Hp_Bar.Value == 0)
                Oyuncu1_Rp_Yuzdelik.BackColor = Color.Gold;
            else if (Oyuncu1_Rp_Bar.Value < 100 && Oyuncu1_Rp_Consume == false)
                Oyuncu1_Rp_Bar.ForeColor = Oyuncu1_Rp_Yuzdelik.BackColor = Color.Gold;
            else if (Oyuncu1_Rp_Bar.Value <= 100 && Oyuncu1_Rp_Consume == true)
                Oyuncu1_Rp_Bar.ForeColor = Oyuncu1_Rp_Yuzdelik.BackColor = Color.DarkRed;

            if (Oyuncu2_Rp_Bar.Value == 100)
                Oyuncu2_Rp_Bar.ForeColor = Oyuncu2_Rp_Yuzdelik.BackColor = Exit_Yazi.ForeColor;
            else if (Oyuncu2_Hp_Bar.Value == 0)
                Oyuncu2_Rp_Yuzdelik.BackColor = Color.Gold;
            else if (Oyuncu2_Rp_Bar.Value < 100 && Oyuncu2_Rp_Consume == false)
                Oyuncu2_Rp_Bar.ForeColor = Oyuncu2_Rp_Yuzdelik.BackColor = Color.Gold;
            else if (Oyuncu2_Rp_Bar.Value <= 100 && Oyuncu2_Rp_Consume == true)
                Oyuncu2_Rp_Bar.ForeColor = Oyuncu2_Rp_Yuzdelik.BackColor = Color.DarkRed;



            //Oyuncu1'in Cheat Bar Rengini Ayarladik
            if (Oyuncu1_Cheat_Bar.Value == 100 && Oyuncu1_Cheat_Hazir_Mi == true)
                Oyuncu1_Cheat_Bar.ForeColor = Exit_Yazi.ForeColor;
            else if (Oyuncu1_Cheat_Bar.Value <= 100 && Oyuncu1_Cheat_Hazir_Mi == false)
                Oyuncu1_Cheat_Bar.ForeColor = Color.White;


            //Oyuncu2'nin Cheat Bar Rengini Ayarladik
            if (Oyuncu2_Cheat_Bar.Value == 100 && Oyuncu2_Cheat_Hazir_Mi == true)
                Oyuncu2_Cheat_Bar.ForeColor = Exit_Yazi.ForeColor;
            else if (Oyuncu2_Cheat_Bar.Value <= 100 && Oyuncu2_Cheat_Hazir_Mi == false)
                Oyuncu2_Cheat_Bar.ForeColor = Color.White;



            //Oyuncu1 ve Oyuncu2 ItemShop Renk Ayarlari
            if (ItemShop_Aktif_Mi == true)
            {
                //Oyuncu1 ItemShop Renk Ayarlari
                Oyuncu1_Gold_Gostergesi.ForeColor = Exit_Yazi.ForeColor;

                if (Oyuncu1_Gold_Miktari >= 200)
                    Oyuncu1_Item_A_Fiyat.ForeColor = Exit_Yazi.ForeColor;
                else
                    Oyuncu1_Item_A_Fiyat.ForeColor = Color.Red;
                if (Oyuncu1_Gold_Miktari >= 400)
                    Oyuncu1_Item_B_Fiyat.ForeColor = Exit_Yazi.ForeColor;
                else
                    Oyuncu1_Item_B_Fiyat.ForeColor = Color.Red;
                if (Oyuncu1_Gold_Miktari >= 600)
                    Oyuncu1_Item_C_Fiyat.ForeColor = Exit_Yazi.ForeColor;
                else
                    Oyuncu1_Item_C_Fiyat.ForeColor = Color.Red;


                //Oyuncu2 ItemShop Renk Ayarlari
                Oyuncu2_Gold_Gostergesi.ForeColor = Exit_Yazi.ForeColor;

                if (Oyuncu2_Gold_Miktari >= 200)
                    Oyuncu2_Item_A_Fiyat.ForeColor = Exit_Yazi.ForeColor;
                else
                    Oyuncu2_Item_A_Fiyat.ForeColor = Color.Red;
                if (Oyuncu2_Gold_Miktari >= 400)
                    Oyuncu2_Item_B_Fiyat.ForeColor = Exit_Yazi.ForeColor;
                else
                    Oyuncu2_Item_B_Fiyat.ForeColor = Color.Red;
                if (Oyuncu2_Gold_Miktari >= 600)
                    Oyuncu2_Item_C_Fiyat.ForeColor = Exit_Yazi.ForeColor;
                else
                    Oyuncu2_Item_C_Fiyat.ForeColor = Color.Red;
            }
            else
                ItemShop.ForeColor = Color.DarkRed;


            //CheckBox'larin rengini ayarladik
            if (ItemShop_Aktif_Mi == true)
                Oyuncu1_A_CheckBox.BackColor = Oyuncu1_B_CheckBox.BackColor = Oyuncu1_C_CheckBox.BackColor = Oyuncu2_A_CheckBox.BackColor = Oyuncu2_B_CheckBox.BackColor = Oyuncu2_C_CheckBox.BackColor = Exit_Yazi.ForeColor;
            else
                Oyuncu1_A_CheckBox.BackColor = Oyuncu1_B_CheckBox.BackColor = Oyuncu1_C_CheckBox.BackColor = Oyuncu2_A_CheckBox.BackColor = Oyuncu2_B_CheckBox.BackColor = Oyuncu2_C_CheckBox.BackColor = Color.DarkRed;


            //ItemShop Yazisinin Rengini Ayarladik
            if (ItemShop_Aktif_Mi == true)
                ItemShop.ForeColor = Exit_Yazi.ForeColor;
            else
                ItemShop.ForeColor = Color.DarkRed;


            //Oyuncular B Pasif Skilli Alirsa Onlar Icin Gerekli Hesaplamalar
            if (((Oyuncu1_is_Cheating == false && Oyuncu1_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == true) || (Oyuncu1_is_Cheating == false && Oyuncu1_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false) || (Oyuncu1_is_Cheating == true && Oyuncu1_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false)) && ((Oyuncu2_is_Cheating == false && Oyuncu2_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == true) || (Oyuncu2_is_Cheating == false && Oyuncu2_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false) || (Oyuncu2_is_Cheating == true && Oyuncu2_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false)))
            {
                Oyuncu1_Anlik_Hp_Miktari = Oyuncu1_Hp_Bar.Value;
                Oyuncu2_Anlik_Hp_Miktari = Oyuncu2_Hp_Bar.Value;
                Oyuncu1_Anlik_Mp_Miktari = Oyuncu1_Mp_Bar.Value;
                Oyuncu2_Anlik_Mp_Miktari = Oyuncu2_Mp_Bar.Value;
            }


            //Oyuncu1 Aktif Kalkan Bozulmasi
            if (Oyuncu1_Aktif_Kalkan_Bozuluyor_Mu == true)
            {
                Oyuncu1_Aktif_Kalkan_Bozulma_Sayaci++;

                if (Oyuncu1_Aktif_Kalkan_Bozulma_Sayaci == 3)
                {
                    Oyuncu1_Aktif_Kalkan_Bozulma_Sayaci = 0;
                    Oyuncu1_Kalkan.Visible = false;
                    Oyuncu1_Kalkan.ImageLocation = "Hurkanix Settings//Kalkan1.gif";
                    Oyuncu1.Visible = true;
                    Oyuncu1_Korunuyor_Mu = false;
                    Oyuncu1_Aktif_Kalkan_Bozuluyor_Mu = false;
                }
            }

            //Oyuncu2 Aktif Kalkan Bozulmasi
            if (Oyuncu2_Aktif_Kalkan_Bozuluyor_Mu == true)
            {
                Oyuncu2_Aktif_Kalkan_Bozulma_Sayaci++;

                if (Oyuncu2_Aktif_Kalkan_Bozulma_Sayaci == 3)
                {
                    Oyuncu2_Aktif_Kalkan_Bozulma_Sayaci = 0;
                    Oyuncu2_Kalkan.Visible = false;
                    Oyuncu2_Kalkan.ImageLocation = "Hurkanix Settings//Kalkan2.gif";
                    Oyuncu2.Visible = true;
                    Oyuncu2_Korunuyor_Mu = false;
                    Oyuncu2_Aktif_Kalkan_Bozuluyor_Mu = false;
                }
            }


            //Oyuncu1'in Gold Miktarina Bagli Olarak Item Cursor Seklini Ayarladik
            if (Oyuncu1_Gold_Miktari >= 200 && ItemShop_Aktif_Mi == true)
                Oyuncu1_Item_A.Cursor = Cursors.Hand;
            else
                Oyuncu1_Item_A.Cursor = Cursors.No;
            if (Oyuncu1_Gold_Miktari >= 400 && ItemShop_Aktif_Mi == true)
                Oyuncu1_Item_B.Cursor = Cursors.Hand;
            else
                Oyuncu1_Item_B.Cursor = Cursors.No;
            if (Oyuncu1_Gold_Miktari >= 600 && ItemShop_Aktif_Mi == true)
                Oyuncu1_Item_C.Cursor = Cursors.Hand;
            else
                Oyuncu1_Item_C.Cursor = Cursors.No;

            //Oyuncu2'in Gold Miktarina Bagli Olarak Item Cursor Seklini Ayarladik
            if (Oyuncu2_Gold_Miktari >= 200 && ItemShop_Aktif_Mi == true)
                Oyuncu2_Item_A.Cursor = Cursors.Hand;
            else
                Oyuncu2_Item_A.Cursor = Cursors.No;
            if (Oyuncu2_Gold_Miktari >= 400 && ItemShop_Aktif_Mi == true)
                Oyuncu2_Item_B.Cursor = Cursors.Hand;
            else
                Oyuncu2_Item_B.Cursor = Cursors.No;
            if (Oyuncu2_Gold_Miktari >= 600 && ItemShop_Aktif_Mi == true)
                Oyuncu2_Item_C.Cursor = Cursors.Hand;
            else
                Oyuncu2_Item_C.Cursor = Cursors.No;


        }

        //Umbridge Sesi
        private void Ekrandan_Mouse_Ayrilmasi(object sender, EventArgs e)
        {
            if (Oyun_Sonu != true)
                WMP3.URL = "Hurkanix Settings//Enough_Class.mp3";
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }




        private bool Oyuncu1_Pasif_Kalkan_Satin_Almis_Mi = true;
        private bool Oyuncu1_Cheat_Hazir_Mi = true;
        private bool Oyuncu1_Kalkan_Tukeniyor_Mu = false;

        private bool Oyuncu1_Pasif_Lanet_Satin_Almis_Mi = false;
        private int Oyuncu1_Lanet_Vurus_Sayisi = 0;

        private bool Oyuncu1_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi = false;
        private bool Oyuncu1_is_Cheating = false;
        private void Oyuncu1_Cheats_Timer_Yeri(object sender, EventArgs e)
        {
            //OYUNCU1 CHEAT BAR DOLDURMA YERI
            if (Oyuncu1_Cheat_Hazir_Mi == false)
            {
                Oyuncu1_Cheats_Timer.Interval = 300; //Pasif skill dolma hizi

                if (Oyuncu1_Cheat_Bar.Value <= 98)
                    Oyuncu1_Cheat_Bar.Value += 2;
                else
                    Oyuncu1_Cheat_Bar.Value = 100;

                if (Oyuncu1_Cheat_Bar.Value == 100)
                {
                    Oyuncu1_Cheat_Hazir_Mi = true;
                    Oyuncu1_Cheat_Haber_PictureBox.ImageLocation = "Hurkanix Settings//Dolores_Umbridge_3.gif";
                    Oyuncu1_Cheats_Timer.Interval = 100; //Pasif skill sifirlanma hizi
                }

            }



            //EGER PASIF SKILL KALKAN ISE
            if (Oyuncu1_Pasif_Kalkan_Satin_Almis_Mi == true && Oyuncu1_Kalkan_Tukeniyor_Mu == true)
            {
                Oyuncu1_Cheats_Timer.Interval = 100; //Pasif skill sifirlanma hizi
                Oyuncu1_Cheat_Bar.ForeColor = Color.DarkRed;
                //Oyuncu1'in cheat yaptiginin haberini veren ses cikartmasini sagladik
                if (Oyuncu1_Cheat_Bar.Value == 100 && Oyuncu1_Kalkan_Tukeniyor_Mu == true)
                {
                    WMP5.URL = "Hurkanix Settings//Teemo_Laugh.mp3";
                }

                if (Oyuncu1_Cheat_Bar.Value != 0)
                    if (Oyuncu1_Cheat_Bar.Value >= 10)
                        Oyuncu1_Cheat_Bar.Value -= 10;
                    else
                        Oyuncu1_Cheat_Bar.Value = 0;

                if (Oyuncu1_Cheat_Bar.Value == 0)
                {
                    Oyuncu1_Cheat_Hazir_Mi = false;
                    Oyuncu1_Cheat_Bar.ForeColor = Color.White;
                    Oyuncu1_Kalkan_Tukeniyor_Mu = false;
                    Oyuncu1_Cheat_Haber_PictureBox.ImageLocation = "Hurkanix Settings//Dolores_Umbridge_1.gif";
                    Oyuncu1_Cheats_Timer.Interval = 300; //Pasif skill dolma hizi
                }
            }



            //EGER PASIF YETENEGIMIZ LANET ISE
            if (Oyuncu1_Pasif_Lanet_Satin_Almis_Mi == true && Oyuncu1_Cheat_Hazir_Mi == true && ((Oyuncu2_is_Cheating == false && Oyuncu2_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == true) || (Oyuncu2_is_Cheating == false && Oyuncu2_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false) || (Oyuncu2_is_Cheating == true && Oyuncu2_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false)) || (Oyuncu1_is_Cheating == true && Oyuncu1_Pasif_Lanet_Satin_Almis_Mi == true))
            {
                Oyuncu1_is_Cheating = true;
                Oyuncu1_Cheats_Timer.Interval = 1000; //Pasif Skill Lanet'in uygulanma hizi
                Oyuncu1_Cheat_Bar.ForeColor = Color.DarkRed;
                //Oyuncu1'in cheat yaptiginin haberini veren ses cikartmasini sagladik
                if (Oyuncu1_Cheat_Bar.Value == 100)
                {
                    WMP5.URL = "Hurkanix Settings//Teemo_Laugh.mp3";
                }

                //Oyuncu2'in Hp ve Mp Azalmasi Durumunda Renkleri Degisecektir
                Oyuncu2_Hp_Bar.ForeColor = Oyuncu2_Hp_Yuzdelik.BackColor = Color.Black;
                Oyuncu2_Mp_Bar.ForeColor = Oyuncu2_Mp_Yuzdelik.BackColor = Color.Black;

                if (Oyuncu1_Lanet_Vurus_Sayisi < 5)
                {
                    if (Oyuncu2_Hp_Bar.Value > 0)
                        if (Oyuncu2_Hp_Bar.Value < 10)
                            Oyuncu2_Hp_Bar.Value = 0;
                        else
                            Oyuncu2_Hp_Bar.Value -= 10;
                    if (Oyuncu2_Mp_Bar.Value > 0)
                        if (Oyuncu2_Mp_Bar.Value < 10)
                            Oyuncu2_Mp_Bar.Value = 0;
                        else
                            Oyuncu2_Mp_Bar.Value -= 10;

                    Oyuncu2_Hp_Yuzdelik.Text = "[HP]: %" + Oyuncu2_Hp_Bar.Value;
                    Oyuncu2_Mp_Yuzdelik.Text = "[MP]: %" + Oyuncu2_Mp_Bar.Value;

                }

                if (Oyuncu1_Lanet_Vurus_Sayisi < 5)
                    Oyuncu1_Lanet_Vurus_Sayisi++;

                if (Oyuncu1_Cheat_Bar.Value != 0)
                    if (Oyuncu1_Cheat_Bar.Value <= 20)
                        Oyuncu1_Cheat_Bar.Value = 0;
                    else
                        Oyuncu1_Cheat_Bar.Value -= 20;


                if (Oyuncu1_Lanet_Vurus_Sayisi == 5)
                {
                    Oyuncu2_Hp_Bar.ForeColor = Color.DarkRed;
                    Oyuncu2_Mp_Bar.ForeColor = Color.MidnightBlue;
                    Oyuncu2_Hp_Yuzdelik.BackColor = Color.Red;
                    Oyuncu2_Mp_Yuzdelik.BackColor = Color.RoyalBlue;
                    Oyuncu1_Lanet_Vurus_Sayisi = 0;
                    Oyuncu1_is_Cheating = false;
                    Oyuncu1_Cheat_Hazir_Mi = false;
                    Oyuncu1_Cheat_Bar.ForeColor = Color.White;
                    Oyuncu1_Cheat_Haber_PictureBox.ImageLocation = "Hurkanix Settings//Dolores_Umbridge_1.gif";
                    Oyuncu1_Cheats_Timer.Interval = 300;  //Pasif Skill dolma hizi
                }

            }




            // EGER PASIF YETENEGIMIZ OYUNCULAR ARASI HP VE MP DEGISIMI ISE
            if (Oyuncu1_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == true && (Oyuncu1_Anlik_Hp_Miktari <= 40 && ((Oyuncu1_Anlik_Hp_Miktari < Oyuncu2_Anlik_Hp_Miktari) || (Oyuncu1_Anlik_Mp_Miktari < Oyuncu2_Anlik_Mp_Miktari))) && Oyuncu1_Cheat_Hazir_Mi == true && ((Oyuncu2_is_Cheating == false && Oyuncu2_Pasif_Lanet_Satin_Almis_Mi == true) || (Oyuncu2_is_Cheating == false && Oyuncu2_Pasif_Lanet_Satin_Almis_Mi == false) || (Oyuncu2_is_Cheating == true && Oyuncu2_Pasif_Lanet_Satin_Almis_Mi == true)) && ((Oyuncu1_Korunuyor_Mu == false && Oyuncu1_Rp_Consume == true) || (Oyuncu1_Korunuyor_Mu == true && Oyuncu1_Rp_Consume == false) || (Oyuncu1_Korunuyor_Mu == false && Oyuncu1_Rp_Consume == false)) || (Oyuncu1_is_Cheating == true && Oyuncu1_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == true))
            {
                Oyuncu1_Cheats_Timer.Interval = 100; //Pasif Skill Hp ve Mp nin dolma hizi             
                Oyuncu1_is_Cheating = true;

                Buyu_Akisi_Timer.Enabled = false;
                Hp_Mp_Timer.Enabled = false;
                Oyuncu2_Cheats_Timer.Enabled = false;
                Para_Timer.Enabled = false;

                Oyuncu1_Cheat_Bar.ForeColor = Color.DarkRed;

                //Oyuncu1'in cheat yaptiginin haberini veren ses cikartmasini sagladik
                if (Oyuncu1_Cheat_Bar.Value == 100 && Oyuncu1_is_Cheating == true)
                {
                    WMP5.URL = "Hurkanix Settings//Teemo_Laugh.mp3";
                }

                //Oyuncu1 hp ve mp bari rengarenk oluyor
                Oyuncu1_Hp_Bar.ForeColor = Oyuncu1_Mp_Bar.ForeColor = Oyuncu1_Hp_Yuzdelik.BackColor = Oyuncu1_Mp_Yuzdelik.BackColor = Exit_Yazi.ForeColor;
                Oyuncu2_Hp_Bar.ForeColor = Oyuncu2_Mp_Bar.ForeColor = Oyuncu2_Hp_Yuzdelik.BackColor = Oyuncu2_Mp_Yuzdelik.BackColor = Color.Black;


                if ((Oyuncu1_Hp_Bar.Value != Oyuncu2_Anlik_Hp_Miktari) && (Oyuncu1_Hp_Bar.Value < Oyuncu2_Anlik_Hp_Miktari))
                {
                    //Oyuncu1'nin Hp si artiyor
                    if (Oyuncu1_Hp_Bar.Value == 99)
                        Oyuncu1_Hp_Bar.Value += 1;
                    else
                        Oyuncu1_Hp_Bar.Value += 2;
                    if (Oyuncu1_Hp_Bar.Value > Oyuncu2_Anlik_Hp_Miktari)
                        Oyuncu1_Hp_Bar.Value = Oyuncu2_Anlik_Hp_Miktari;

                    //Oyuncu2'nin Hp si azaliyor
                    if (Oyuncu2_Hp_Bar.Value == 1)
                        Oyuncu2_Hp_Bar.Value -= 1;
                    else
                        Oyuncu2_Hp_Bar.Value -= 2;
                    if (Oyuncu2_Hp_Bar.Value < Oyuncu1_Anlik_Hp_Miktari)
                        Oyuncu2_Hp_Bar.Value = Oyuncu1_Anlik_Hp_Miktari;

                    Oyuncu2_Hp_Yuzdelik.Text = "[HP]: %" + Oyuncu2_Hp_Bar.Value;
                    Oyuncu1_Hp_Yuzdelik.Text = "[HP]: %" + Oyuncu1_Hp_Bar.Value;
                }


                if ((Oyuncu1_Mp_Bar.Value != Oyuncu2_Anlik_Mp_Miktari) && (Oyuncu1_Mp_Bar.Value < Oyuncu2_Anlik_Mp_Miktari))
                {
                    //Oyuncu1'nin Mp si artiyor
                    if (Oyuncu1_Mp_Bar.Value == 99)
                        Oyuncu1_Mp_Bar.Value += 1;
                    else
                        Oyuncu1_Mp_Bar.Value += 2;
                    if (Oyuncu1_Mp_Bar.Value > Oyuncu2_Anlik_Mp_Miktari)
                        Oyuncu1_Mp_Bar.Value = Oyuncu2_Anlik_Mp_Miktari;

                    //Oyuncu2'in Mp si azaliyor
                    if (Oyuncu2_Mp_Bar.Value == 1)
                        Oyuncu2_Mp_Bar.Value -= 1;
                    else
                        Oyuncu2_Mp_Bar.Value -= 2;
                    if (Oyuncu2_Mp_Bar.Value < Oyuncu1_Anlik_Mp_Miktari)
                        Oyuncu2_Mp_Bar.Value = Oyuncu1_Anlik_Mp_Miktari;

                    Oyuncu2_Mp_Yuzdelik.Text = "[MP]: %" + Oyuncu2_Mp_Bar.Value;
                    Oyuncu1_Mp_Yuzdelik.Text = "[MP]: %" + Oyuncu1_Mp_Bar.Value;
                }


                if (Oyuncu1_Cheat_Bar.Value != 0)
                    if (Oyuncu1_Cheat_Bar.Value >= 5)
                        Oyuncu1_Cheat_Bar.Value -= 5;
                    else
                        Oyuncu1_Cheat_Bar.Value = 0;


                if ((Oyuncu1_Hp_Bar.Value >= Oyuncu2_Anlik_Hp_Miktari) && (Oyuncu1_Mp_Bar.Value >= Oyuncu2_Anlik_Mp_Miktari) && Oyuncu1_Cheat_Bar.Value == 0)
                {
                    if (Oyuncu2_Pasif_Lanet_Satin_Almis_Mi == true && Oyuncu2_is_Cheating == true)
                    {
                        //Oyuncu2 eger onceden lanet uygulamissa ve oyuncu1 laneti yarida kesip heal cheati yapmissa renkleri lanete gore hazirla cikista
                        Oyuncu1_Hp_Bar.ForeColor = Oyuncu1_Hp_Yuzdelik.BackColor = Color.Black;
                        Oyuncu1_Mp_Bar.ForeColor = Oyuncu1_Mp_Yuzdelik.BackColor = Color.Black;
                        Oyuncu2_Hp_Bar.ForeColor = Color.DarkRed;
                        Oyuncu2_Mp_Bar.ForeColor = Color.MidnightBlue;
                        Oyuncu2_Hp_Yuzdelik.BackColor = Color.Red;
                        Oyuncu2_Mp_Yuzdelik.BackColor = Color.RoyalBlue;
                    }
                    else
                    {
                        Oyuncu1_Hp_Bar.ForeColor = Oyuncu2_Hp_Bar.ForeColor = Color.DarkRed;
                        Oyuncu1_Mp_Bar.ForeColor = Oyuncu2_Mp_Bar.ForeColor = Color.MidnightBlue;
                        Oyuncu1_Hp_Yuzdelik.BackColor = Oyuncu2_Hp_Yuzdelik.BackColor = Color.Red;
                        Oyuncu1_Mp_Yuzdelik.BackColor = Oyuncu2_Mp_Yuzdelik.BackColor = Color.RoyalBlue;
                    }

                    Buyu_Akisi_Timer.Enabled = true;
                    Hp_Mp_Timer.Enabled = true;
                    Para_Timer.Enabled = true;
                    Oyuncu2_Cheats_Timer.Enabled = true;
                    Oyuncu1_is_Cheating = false;
                    Oyuncu1_Cheat_Hazir_Mi = false;
                    Oyuncu1_Cheat_Bar.ForeColor = Color.White;
                    Oyuncu1_Cheat_Haber_PictureBox.ImageLocation = "Hurkanix Settings//Dolores_Umbridge_1.gif";
                    Oyuncu1_Cheats_Timer.Interval = 300; //Pasif skill dolma hizi
                }
                else
                    Oyuncu1_is_Cheating = true;
            }
        }




        private bool Oyuncu2_Pasif_Kalkan_Satin_Almis_Mi = true;
        private bool Oyuncu2_Cheat_Hazir_Mi = true;
        private bool Oyuncu2_Kalkan_Tukeniyor_Mu = false;

        private bool Oyuncu2_Pasif_Lanet_Satin_Almis_Mi = false;
        private int Oyuncu2_Lanet_Vurus_Sayisi = 0;

        private bool Oyuncu2_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi = false;
        private bool Oyuncu2_is_Cheating = false;
        private void Oyuncu2_Cheats_Timer_Yeri(object sender, EventArgs e)
        {
            //OYUNCU2 CHEAT BAR DOLDURMA YERI
            if (Oyuncu2_Cheat_Hazir_Mi == false)
            {
                Oyuncu2_Cheats_Timer.Interval = 300; //Pasif skill dolma hizi

                if (Oyuncu2_Cheat_Bar.Value <= 98)
                    Oyuncu2_Cheat_Bar.Value += 2;
                else
                    Oyuncu2_Cheat_Bar.Value = 100;

                if (Oyuncu2_Cheat_Bar.Value == 100)
                {
                    Oyuncu2_Cheat_Hazir_Mi = true;
                    Oyuncu2_Cheat_Haber_PictureBox.ImageLocation = "Hurkanix Settings//Lord_Voldemort_2.gif";
                    Oyuncu2_Cheats_Timer.Interval = 100; //Pasif skill sifirlanma hizi
                }

            }


            //EGER PASIF YETENEGIMIZ KALKAN ISE
            if (Oyuncu2_Pasif_Kalkan_Satin_Almis_Mi == true && Oyuncu2_Kalkan_Tukeniyor_Mu == true)
            {
                Oyuncu2_Cheats_Timer.Interval = 100; //Pasif skill sifirlanma hizi

                Oyuncu2_Cheat_Bar.ForeColor = Color.DarkRed;

                //Oyuncu2'nin cheat yaptiginin haberini veren ses cikartmasini sagladik
                if (Oyuncu2_Cheat_Bar.Value == 100 && Oyuncu2_Kalkan_Tukeniyor_Mu == true)
                {
                    WMP6.URL = "Hurkanix Settings//Teemo_Laugh.mp3";
                }

                if (Oyuncu2_Cheat_Bar.Value != 0)
                    if (Oyuncu2_Cheat_Bar.Value >= 10)
                        Oyuncu2_Cheat_Bar.Value -= 10;
                    else
                        Oyuncu2_Cheat_Bar.Value = 0;

                if (Oyuncu2_Cheat_Bar.Value == 0)
                {
                    Oyuncu2_Cheat_Hazir_Mi = false;
                    Oyuncu2_Kalkan_Tukeniyor_Mu = false;
                    Oyuncu2_Cheat_Bar.ForeColor = Color.White;
                    Oyuncu2_Cheat_Haber_PictureBox.ImageLocation = "Hurkanix Settings//Lord_Voldemort_1.gif";
                    Oyuncu2_Cheats_Timer.Interval = 300; //Pasif skill dolma hizi
                }

            }



            //EGER PASIF YETENEGIMIZ LANET ISE
            if (Oyuncu2_Pasif_Lanet_Satin_Almis_Mi == true && Oyuncu2_Cheat_Hazir_Mi == true && ((Oyuncu1_is_Cheating == false && Oyuncu1_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == true) || (Oyuncu1_is_Cheating == false && Oyuncu1_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false) || (Oyuncu1_is_Cheating == true && Oyuncu1_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false)) || (Oyuncu2_is_Cheating == true && Oyuncu2_Pasif_Lanet_Satin_Almis_Mi == true))
            {
                Oyuncu2_is_Cheating = true;
                Oyuncu2_Cheats_Timer.Interval = 1000; //Pasif Skill Lanet'in uygulanma hizi

                Oyuncu2_Cheat_Bar.ForeColor = Color.DarkRed;

                //Oyuncu2'nin cheat yaptiginin haberini veren ses cikartmasini sagladik
                if (Oyuncu2_Cheat_Bar.Value == 100)
                {
                    WMP6.URL = "Hurkanix Settings//Teemo_Laugh.mp3";
                }

                //Oyuncu1'in Hp ve Mp Azalmasi Durumunda Renkleri Degisecektir
                Oyuncu1_Hp_Bar.ForeColor = Color.Black;
                Oyuncu1_Mp_Bar.ForeColor = Color.Black;
                Oyuncu1_Hp_Yuzdelik.BackColor = Color.Black;
                Oyuncu1_Mp_Yuzdelik.BackColor = Color.Black;

                if (Oyuncu2_Lanet_Vurus_Sayisi < 5)
                {
                    if (Oyuncu1_Hp_Bar.Value > 0)
                        if (Oyuncu1_Hp_Bar.Value < 10)
                            Oyuncu1_Hp_Bar.Value = 0;
                        else
                            Oyuncu1_Hp_Bar.Value -= 10;
                    if (Oyuncu1_Mp_Bar.Value > 0)
                        if (Oyuncu1_Mp_Bar.Value < 10)
                            Oyuncu1_Mp_Bar.Value = 0;
                        else
                            Oyuncu1_Mp_Bar.Value -= 10;

                    Oyuncu1_Hp_Yuzdelik.Text = "[HP]: %" + Oyuncu1_Hp_Bar.Value;
                    Oyuncu1_Mp_Yuzdelik.Text = "[MP]: %" + Oyuncu1_Mp_Bar.Value;

                }

                if (Oyuncu2_Lanet_Vurus_Sayisi < 5)
                    Oyuncu2_Lanet_Vurus_Sayisi++;

                if (Oyuncu2_Cheat_Bar.Value != 0)
                    if (Oyuncu2_Cheat_Bar.Value <= 20)
                        Oyuncu2_Cheat_Bar.Value = 0;
                    else
                        Oyuncu2_Cheat_Bar.Value -= 20;


                if (Oyuncu2_Lanet_Vurus_Sayisi == 5)
                {
                    Oyuncu1_Hp_Bar.ForeColor = Color.DarkRed;
                    Oyuncu1_Mp_Bar.ForeColor = Color.MidnightBlue;
                    Oyuncu1_Hp_Yuzdelik.BackColor = Color.Red;
                    Oyuncu1_Mp_Yuzdelik.BackColor = Color.RoyalBlue;
                    Oyuncu2_Lanet_Vurus_Sayisi = 0;
                    Oyuncu2_is_Cheating = false;
                    Oyuncu2_Cheat_Hazir_Mi = false;
                    Oyuncu2_Cheat_Bar.ForeColor = Color.White;
                    Oyuncu2_Cheat_Haber_PictureBox.ImageLocation = "Hurkanix Settings//Lord_Voldemort_1.gif";
                    Oyuncu2_Cheats_Timer.Interval = 300;  //Pasif Skill dolma hizi
                }

            }



            // EGER PASIF YETENEGIMIZ OYUNCULAR ARASI HP VE MP DEGISIMI ISE
            if (Oyuncu2_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == true && (Oyuncu2_Anlik_Hp_Miktari <= 40 && ((Oyuncu2_Anlik_Hp_Miktari < Oyuncu1_Anlik_Hp_Miktari) || (Oyuncu2_Anlik_Mp_Miktari < Oyuncu1_Anlik_Mp_Miktari))) && Oyuncu2_Cheat_Hazir_Mi == true && ((Oyuncu1_is_Cheating == false && Oyuncu1_Pasif_Lanet_Satin_Almis_Mi == true) || (Oyuncu1_is_Cheating == false && Oyuncu1_Pasif_Lanet_Satin_Almis_Mi == false) || (Oyuncu1_is_Cheating == true && Oyuncu1_Pasif_Lanet_Satin_Almis_Mi == true)) && ((Oyuncu2_Korunuyor_Mu == false && Oyuncu2_Rp_Consume == true) || (Oyuncu2_Korunuyor_Mu == true && Oyuncu2_Rp_Consume == false) || (Oyuncu2_Korunuyor_Mu == false && Oyuncu2_Rp_Consume == false)) || (Oyuncu2_is_Cheating == true && Oyuncu2_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == true))
            {
                Oyuncu2_Cheats_Timer.Interval = 100; //Pasif Skill Hp ve Mp nin dolma hizi

                Oyuncu2_is_Cheating = true;

                Buyu_Akisi_Timer.Enabled = false;
                Hp_Mp_Timer.Enabled = false;
                Oyuncu1_Cheats_Timer.Enabled = false;
                Para_Timer.Enabled = false;


                Oyuncu2_Cheat_Bar.ForeColor = Color.DarkRed;

                //Oyuncu2'nin cheat yaptiginin haberini veren ses cikartmasini sagladik
                if (Oyuncu2_Cheat_Bar.Value == 100 && Oyuncu2_is_Cheating == true)
                {
                    WMP6.URL = "Hurkanix Settings//Teemo_Laugh.mp3";
                }

                //Oyuncu2 hp ve mp bari rengarenk oluyor
                Oyuncu2_Hp_Bar.ForeColor = Oyuncu2_Mp_Bar.ForeColor = Oyuncu2_Hp_Yuzdelik.BackColor = Oyuncu2_Mp_Yuzdelik.BackColor = Exit_Yazi.ForeColor;
                Oyuncu1_Hp_Bar.ForeColor = Oyuncu1_Mp_Bar.ForeColor = Oyuncu1_Hp_Yuzdelik.BackColor = Oyuncu1_Mp_Yuzdelik.BackColor = Color.Black;

                if ((Oyuncu2_Hp_Bar.Value != Oyuncu1_Anlik_Hp_Miktari) && (Oyuncu2_Hp_Bar.Value < Oyuncu1_Anlik_Hp_Miktari))
                {
                    //Oyuncu2'nin Hp si artiyor
                    if (Oyuncu2_Hp_Bar.Value == 99)
                        Oyuncu2_Hp_Bar.Value += 1;
                    else
                        Oyuncu2_Hp_Bar.Value += 2;
                    if (Oyuncu2_Hp_Bar.Value > Oyuncu1_Anlik_Hp_Miktari)
                        Oyuncu2_Hp_Bar.Value = Oyuncu1_Anlik_Hp_Miktari;

                    //Oyuncu1'in Hp si azaliyor
                    if (Oyuncu1_Hp_Bar.Value == 1)
                        Oyuncu1_Hp_Bar.Value -= 1;
                    else
                        Oyuncu1_Hp_Bar.Value -= 2;
                    if (Oyuncu1_Hp_Bar.Value < Oyuncu2_Anlik_Hp_Miktari)
                        Oyuncu1_Hp_Bar.Value = Oyuncu2_Anlik_Hp_Miktari;

                    Oyuncu1_Hp_Yuzdelik.Text = "[HP]: %" + Oyuncu1_Hp_Bar.Value;
                    Oyuncu2_Hp_Yuzdelik.Text = "[HP]: %" + Oyuncu2_Hp_Bar.Value;
                }


                if ((Oyuncu2_Mp_Bar.Value != Oyuncu1_Anlik_Mp_Miktari) && (Oyuncu2_Mp_Bar.Value < Oyuncu1_Anlik_Mp_Miktari))
                {
                    //Oyuncu2'nin Mp si artiyor
                    if (Oyuncu2_Mp_Bar.Value == 99)
                        Oyuncu2_Mp_Bar.Value += 1;
                    else
                        Oyuncu2_Mp_Bar.Value += 2;
                    if (Oyuncu2_Mp_Bar.Value > Oyuncu1_Anlik_Mp_Miktari)
                        Oyuncu2_Mp_Bar.Value = Oyuncu1_Anlik_Mp_Miktari;

                    //Oyuncu1'in Mp si azaliyor
                    if (Oyuncu1_Mp_Bar.Value == 1)
                        Oyuncu1_Mp_Bar.Value -= 1;
                    else
                        Oyuncu1_Mp_Bar.Value -= 2;
                    if (Oyuncu1_Mp_Bar.Value < Oyuncu2_Anlik_Mp_Miktari)
                        Oyuncu1_Mp_Bar.Value = Oyuncu2_Anlik_Mp_Miktari;

                    Oyuncu1_Mp_Yuzdelik.Text = "[MP]: %" + Oyuncu1_Mp_Bar.Value;
                    Oyuncu2_Mp_Yuzdelik.Text = "[MP]: %" + Oyuncu2_Mp_Bar.Value;
                }


                if (Oyuncu2_Cheat_Bar.Value != 0)
                    if (Oyuncu2_Cheat_Bar.Value >= 5)
                        Oyuncu2_Cheat_Bar.Value -= 5;
                    else
                        Oyuncu2_Cheat_Bar.Value = 0;

                if ((Oyuncu2_Hp_Bar.Value >= Oyuncu1_Anlik_Hp_Miktari) && (Oyuncu2_Mp_Bar.Value >= Oyuncu1_Anlik_Mp_Miktari) && Oyuncu2_Cheat_Bar.Value == 0)
                {
                    if (Oyuncu2_Pasif_Lanet_Satin_Almis_Mi == true && Oyuncu2_is_Cheating == true)
                    {
                        //Oyuncu1 eger onceden lanet uygulamissa ve oyuncu2 laneti yarida kesip heal cheati yapmissa renkleri lanete gore hazirla cikista
                        Oyuncu2_Hp_Bar.ForeColor = Oyuncu2_Hp_Yuzdelik.BackColor = Color.Black;
                        Oyuncu2_Mp_Bar.ForeColor = Oyuncu2_Mp_Yuzdelik.BackColor = Color.Black;
                        Oyuncu1_Hp_Bar.ForeColor = Color.DarkRed;
                        Oyuncu1_Mp_Bar.ForeColor = Color.MidnightBlue;
                        Oyuncu1_Hp_Yuzdelik.BackColor = Color.Red;
                        Oyuncu1_Mp_Yuzdelik.BackColor = Color.RoyalBlue;
                    }
                    else
                    {
                        Oyuncu1_Hp_Bar.ForeColor = Oyuncu2_Hp_Bar.ForeColor = Color.DarkRed;
                        Oyuncu1_Hp_Yuzdelik.BackColor = Oyuncu2_Hp_Yuzdelik.BackColor = Color.Red;
                        Oyuncu1_Mp_Bar.ForeColor = Oyuncu2_Mp_Bar.ForeColor = Color.MidnightBlue;
                        Oyuncu1_Mp_Yuzdelik.BackColor = Oyuncu2_Mp_Yuzdelik.BackColor = Color.RoyalBlue;
                    }
                    Buyu_Akisi_Timer.Enabled = true;
                    Hp_Mp_Timer.Enabled = true;
                    Para_Timer.Enabled = true;
                    Oyuncu1_Cheats_Timer.Enabled = true;
                    Oyuncu2_is_Cheating = false;
                    Oyuncu2_Cheat_Hazir_Mi = false;
                    Oyuncu2_Cheat_Bar.ForeColor = Color.White;
                    Oyuncu2_Cheat_Haber_PictureBox.ImageLocation = "Hurkanix Settings//Lord_Voldemort_1.gif";
                    Oyuncu2_Cheats_Timer.Interval = 300; //Pasif skill dolma hizi
                }
                else
                    Oyuncu2_is_Cheating = true;
            }

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
            if (Oyuncu1_Gold_Miktari < 1000)
                Oyuncu1_Gold_Miktari += 5;
            if (Oyuncu1_Gold_Miktari >= 1000)
                Oyuncu1_Gold_Miktari = 1000;

            if (Oyuncu2_Gold_Miktari < 1000)
                Oyuncu2_Gold_Miktari += 5;
            if (Oyuncu2_Gold_Miktari >= 1000)
                Oyuncu2_Gold_Miktari = 1000;

            Oyuncu1_Gold_Gostergesi.Text = Oyuncu1_Gold_Miktari.ToString();
            Oyuncu2_Gold_Gostergesi.Text = Oyuncu2_Gold_Miktari.ToString();
        }

        private void Oyuncu1_Item_A_DoubleClick(object sender, EventArgs e)
        {
            if (End_Timer.Enabled == false && Oyuncu1_Gold_Miktari >= 200 && ItemShop_Aktif_Mi == true && Oyuncu1_Pasif_Kalkan_Satin_Almis_Mi == false)
            {
                Oyuncu1_Gold_Miktari -= 200;
                Oyuncu1_A_CheckBox.Visible = true;
                Oyuncu1_B_CheckBox.Visible = false;
                Oyuncu1_C_CheckBox.Visible = false;
                Oyuncu1_Gold_Gostergesi.Text = Oyuncu1_Gold_Miktari.ToString();
                Oyuncu1_Pasif_Lanet_Satin_Almis_Mi = false;
                Oyuncu1_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi = false;
                Oyuncu1_Pasif_Kalkan_Satin_Almis_Mi = true;
            }
        }

        private void Oyuncu2_Item_A_DoubleClick(object sender, EventArgs e)
        {
            if (End_Timer.Enabled == false && Oyuncu2_Gold_Miktari >= 200 && ItemShop_Aktif_Mi == true && Oyuncu2_Pasif_Kalkan_Satin_Almis_Mi == false)
            {
                Oyuncu2_Gold_Miktari -= 200;
                Oyuncu2_A_CheckBox.Visible = true;
                Oyuncu2_B_CheckBox.Visible = false;
                Oyuncu2_C_CheckBox.Visible = false;
                Oyuncu2_Gold_Gostergesi.Text = Oyuncu2_Gold_Miktari.ToString();
                Oyuncu2_Pasif_Lanet_Satin_Almis_Mi = false;
                Oyuncu2_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi = false;
                Oyuncu2_Pasif_Kalkan_Satin_Almis_Mi = true;
            }
        }

        private void Oyuncu1_Item_B_DoubleClick(object sender, EventArgs e)
        {
            if (End_Timer.Enabled == false && Oyuncu1_Gold_Miktari >= 400 && ItemShop_Aktif_Mi == true && Oyuncu1_Pasif_Lanet_Satin_Almis_Mi == false)
            {
                Oyuncu1_Gold_Miktari -= 400;
                Oyuncu1_A_CheckBox.Visible = false;
                Oyuncu1_B_CheckBox.Visible = true;
                Oyuncu1_C_CheckBox.Visible = false;
                Oyuncu1_Gold_Gostergesi.Text = Oyuncu1_Gold_Miktari.ToString();
                Oyuncu1_Pasif_Kalkan_Satin_Almis_Mi = false;
                Oyuncu1_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi = false;
                Oyuncu1_Pasif_Lanet_Satin_Almis_Mi = true;

            }
        }

        private void Oyuncu2_Item_B_DoubleClick(object sender, EventArgs e)
        {
            if (End_Timer.Enabled == false && Oyuncu2_Gold_Miktari >= 400 && ItemShop_Aktif_Mi == true && Oyuncu2_Pasif_Lanet_Satin_Almis_Mi == false)
            {
                Oyuncu2_Gold_Miktari -= 400;
                Oyuncu2_A_CheckBox.Visible = false;
                Oyuncu2_B_CheckBox.Visible = true;
                Oyuncu2_C_CheckBox.Visible = false;
                Oyuncu2_Gold_Gostergesi.Text = Oyuncu2_Gold_Miktari.ToString();
                Oyuncu2_Pasif_Kalkan_Satin_Almis_Mi = false;
                Oyuncu2_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi = false;
                Oyuncu2_Pasif_Lanet_Satin_Almis_Mi = true;

            }
        }

        private void Oyuncu1_Item_C_DoubleClick(object sender, EventArgs e)
        {
            if (End_Timer.Enabled == false && Oyuncu1_Gold_Miktari >= 600 && ItemShop_Aktif_Mi == true && Oyuncu1_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false)
            {
                Oyuncu1_Gold_Miktari -= 600;
                Oyuncu1_A_CheckBox.Visible = false;
                Oyuncu1_B_CheckBox.Visible = false;
                Oyuncu1_C_CheckBox.Visible = true;
                Oyuncu1_Gold_Gostergesi.Text = Oyuncu1_Gold_Miktari.ToString();
                Oyuncu1_Pasif_Kalkan_Satin_Almis_Mi = false;
                Oyuncu1_Pasif_Lanet_Satin_Almis_Mi = false;
                Oyuncu1_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi = true;
            }
        }

        private void Oyuncu2_Item_C_DoubleClick(object sender, EventArgs e)
        {
            if (End_Timer.Enabled == false && Oyuncu2_Gold_Miktari >= 600 && ItemShop_Aktif_Mi == true && Oyuncu2_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false)
            {

                Oyuncu2_Gold_Miktari -= 600;
                Oyuncu2_A_CheckBox.Visible = false;
                Oyuncu2_B_CheckBox.Visible = false;
                Oyuncu2_C_CheckBox.Visible = true;
                Oyuncu2_Gold_Gostergesi.Text = Oyuncu2_Gold_Miktari.ToString();
                Oyuncu2_Pasif_Kalkan_Satin_Almis_Mi = false;
                Oyuncu2_Pasif_Lanet_Satin_Almis_Mi = false;
                Oyuncu2_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi = true;
            }
        }

        private void Oyuncular_Item_A_Aciklama_MouseEnter(object sender, EventArgs e)
        {
            if (End_Timer.Enabled == false)
            {
                Pasif_Yetenekler_Aciklama.Text = "[PASSIVE]\nRakibin bir sonraki saldirisindan oyuncunun hasar almasini engeller. Bu yetenek oyuncunun aktif kalkani varken etkinlesemez !";
                Pasif_Yetenekler_Aciklama.Visible = true;
            }
        }
        private void Oyuncular_Item_B_Aciklama_MouseEnter(object sender, EventArgs e)
        {
            if (End_Timer.Enabled == false)
            {
                Pasif_Yetenekler_Aciklama.Text = "[PASSIVE]\nRakibe 5 saniye boyunca\netkin olacak bir lanet uygulayarak her saniye basina rakibin HP ve MP degerinin\n10'ar 10'ar azalmasini saglar.";
                Pasif_Yetenekler_Aciklama.Visible = true;
            }
        }
        private void Oyuncular_Item_C_Aciklama_MouseEnter(object sender, EventArgs e)
        {
            if (End_Timer.Enabled == false)
            {
                Pasif_Yetenekler_Aciklama.Text = "[PASSIVE]\nOyuncunun HP degeri 40'in altina duserse ve rakibin HP degeri oyuncununkinden yuksekse HP degerleri birbiriyle degisir.\nEger rakibin MP degeri oyuncununkinden yuksekse MP degerleri de birbiriyle degisir !";
                Pasif_Yetenekler_Aciklama.Visible = true;
            }
        }
        private void Oyuncular_Item_ABC_Aciklama_MouseLeave(object sender, EventArgs e)
        {
            Pasif_Yetenekler_Aciklama.Visible = false;
        }

        public static bool Game_Paused = false;
        private void Settings_Button_Click(object sender, EventArgs e)
        {
            Game_Paused = true;
            Buyu_Akisi_Timer.Enabled = false;
            Hp_Mp_Timer.Enabled = false;
            Oyuncu1_Cheats_Timer.Enabled = false;
            Oyuncu2_Cheats_Timer.Enabled = false;
            Oyun_Zamanlayici_Timer.Enabled = false;
            Para_Timer.Enabled = false;
            Exit_Button.Enabled = false;
            Settings_Button.Enabled = false;
            End_Timer.Enabled = true;

            GameOver Settings = new GameOver();
            Settings.Oyun_Sonu_Raporu.Text = "Oyun Durduruldu";
            Settings.Play_Again_Button.Text = "R E S U M E";
            Settings.Show();
            GameMode1_Hide = false;
        }

        public static bool GameMode1_Hide = false;
        private void End_Timer_Yeri(object sender, EventArgs e)
        {
            //Ekrana Tiklanmasini Engeller
            Exit_Button.Enabled = false;
            Settings_Button.Enabled = false;

            if (GameMode1_Hide == true)
            {
                this.Dispose();
            }
        }
    }
}
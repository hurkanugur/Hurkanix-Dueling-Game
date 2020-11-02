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
    public partial class GameMode3 : Form
    {
        public GameMode3()
        {
            KeyPreview = true;
            InitializeComponent();
        }


        private bool YapayZeka_Saldiriyor_Mu = false;
        private bool Oyuncu_Saldiriyor_Mu = false;
        private bool YapayZeka_Korunuyor_Mu = false;
        private bool Oyuncu_Korunuyor_Mu = false;
        private bool YapayZeka_Rp_Kullanimi_Aktif_Mi = false;
        private bool Oyuncu_Rp_Kullanimi_Aktif_Mi = false;
        private int Oyuncu_Anlik_Hp_Miktari;
        private int YapayZeka_Anlik_Hp_Miktari;
        private int Oyuncu_Anlik_Mp_Miktari;
        private int YapayZeka_Anlik_Mp_Miktari;
        private bool Oyun_Sonu = false;
        private bool YapayZeka_Stun_Aktif_Mi = false;
        private bool Oyuncu_Stunlandi_Mi = false;
        private int YapayZeka_Stun_Sayaci = 0;

        private bool ItemShop_Aktif_Mi = false;

        private int Saniye = 0;
        private int Dakika = 1;

        private void GameMode3_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon("Hurkanix Settings//Hurkanix.ico");
            Oyuncu_Kalkan.ImageLocation = "Hurkanix Settings//Heal.gif";
            YapayZeka.ImageLocation = "Hurkanix Settings//Lord_Voldemort.gif";
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
            Sleep_Effect_Picture.ImageLocation = "Hurkanix Settings//Sleep_Effect.png";
            Upgrade_PictureBox1.ImageLocation = Upgrade_PictureBox2.ImageLocation = Upgrade_PictureBox3.ImageLocation = Upgrade_PictureBox4.ImageLocation = Upgrade_PictureBox5.ImageLocation = Upgrade_PictureBox6.ImageLocation = "Hurkanix Settings//Upgrade.png";

            Oyuncu_Cheat_Haber_PictureBox.ImageLocation = "Hurkanix Settings//Dolores_Umbridge_3.gif";
            YapayZeka_Cheat_Haber_PictureBox.ImageLocation = "Hurkanix Settings//Dolores_Umbridge_4.gif";

            Oyuncu_Isim.Text = GameMenu.KullaniciAdi_Belirle_1;
            YapayZeka_Isim.Text = "Lord Voldemort";

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
            Exit_Button.Enabled = true;
            Settings_Button.Enabled = true;
            End_Timer.Enabled = false;
            ItemShop_Aktif_Mi = false;
            ItemShop.ForeColor = Oyuncu_ItemShop_Isim.ForeColor = YapayZeka_ItemShop_Isim.ForeColor = Oyuncu_Gold_Gostergesi.ForeColor = YapayZeka_Gold_Gostergesi.ForeColor = Oyuncu_Item_A_Fiyat.ForeColor = Oyuncu_Item_B_Fiyat.ForeColor = Oyuncu_Item_C_Fiyat.ForeColor = YapayZeka_Item_A_Fiyat.ForeColor = YapayZeka_Item_B_Fiyat.ForeColor = YapayZeka_Item_C_Fiyat.ForeColor = Color.DarkRed;

            WMP1.URL = "Hurkanix Settings//GameMode3.mp3";
        }

        //TUSA BASMA EVENTI
        private void Tus_Basmak(object sender, KeyEventArgs e)
        {
            //ITEMSHOP ACIP KAPATMA TUSLARI
            if (e.KeyCode == Keys.Enter && ItemShop_Aktif_Mi == false && Game_Paused == false && End_Timer.Enabled == false && Oyuncu_is_Cheating == false && YapayZeka_is_Cheating == false && Oyuncu_Kalkan_Tukeniyor_Mu == false && YapayZeka_Revive_Aktiflestirici == false)
            {
                Buyu_Akisi_Timer.Enabled = false;
                Hp_Mp_Timer.Enabled = false;
                Oyuncu_Cheats_Timer.Enabled = false;
                YapayZeka_Cheats_Timer.Enabled = false;
                ItemShop.ForeColor = Oyuncu_ItemShop_Isim.ForeColor = YapayZeka_ItemShop_Isim.ForeColor = Oyuncu_Gold_Gostergesi.ForeColor = YapayZeka_Gold_Gostergesi.ForeColor = Color.Aqua;
                Oyuncu_Item_A_Fiyat.ForeColor = Oyuncu_Item_B_Fiyat.ForeColor = Oyuncu_Item_C_Fiyat.ForeColor = YapayZeka_Item_A_Fiyat.ForeColor = YapayZeka_Item_B_Fiyat.ForeColor = YapayZeka_Item_C_Fiyat.ForeColor = Color.Red;
                ItemShop_Aktif_Mi = true;
            }
            if (e.KeyCode == Keys.Back && ItemShop_Aktif_Mi == true && Game_Paused == false && End_Timer.Enabled == false)
            {
                ItemShop_Aktif_Mi = false;
                ItemShop.ForeColor = Oyuncu_ItemShop_Isim.ForeColor = YapayZeka_ItemShop_Isim.ForeColor = Oyuncu_Gold_Gostergesi.ForeColor = YapayZeka_Gold_Gostergesi.ForeColor = Oyuncu_Item_A_Fiyat.ForeColor = Oyuncu_Item_B_Fiyat.ForeColor = Oyuncu_Item_C_Fiyat.ForeColor = YapayZeka_Item_A_Fiyat.ForeColor = YapayZeka_Item_B_Fiyat.ForeColor = YapayZeka_Item_C_Fiyat.ForeColor = Color.DarkRed;
                Buyu_Akisi_Timer.Enabled = true;
                Hp_Mp_Timer.Enabled = true;
                Oyuncu_Cheats_Timer.Enabled = true;
                YapayZeka_Cheats_Timer.Enabled = true;
            }


            //Imkansiz Tus Basma Olayi (Bu Olayla Ilgili Ekranda Cikan Yaziyi Silen Kodlar Renk_Timer Kisminda
            if (e.KeyCode == Keys.Enter && ItemShop_Aktif_Mi == false && (Oyuncu_Cheat_Bar.ForeColor == Color.DarkRed || YapayZeka_Cheat_Bar.ForeColor == Color.DarkRed || YapayZeka_Revive_Aktiflestirici == true) && Pasif_Yetenekler_Aciklama.Text != "[WARNING]\nHerhangi bir pasif yetenek kullanilirken Item Shop'a giris yapamazsiniz !")
            {
                Pasif_Yetenekler_Aciklama.Text = "[WARNING]\nHerhangi bir pasif yetenek kullanilirken Item Shop'a giris yapamazsiniz !";
                Pasif_Yetenekler_Aciklama.Visible = true;
            }


            //Oyuncu icin Saldiri Tusu
            if (e.KeyCode == Keys.Q && Game_Paused == false && End_Timer.Enabled == false)
            {
                if (Oyuncu_Stunlandi_Mi == false && (Oyuncu_Rp_Bar.Value == 100) && (Oyuncu_Buyu.Visible == false) && YapayZeka_Revive_Aktiflestirici == false && (Oyuncu_Rp_Kullanimi_Aktif_Mi == false) && (Oyuncu_Saldiriyor_Mu == false) && YapayZeka_is_Cheating == false && ItemShop_Aktif_Mi == false && ((Oyuncu_is_Cheating == false && Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false) || (Oyuncu_is_Cheating == true && Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false) || (Oyuncu_is_Cheating == false && Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == true)))
                {
                    Oyuncu_Kalkan.Visible = false;
                    Oyuncu_Buyu.ImageLocation = "Hurkanix Settings//SuperPower1.gif";
                    Oyuncu.Visible = true;
                    Oyuncu_Buyu.Visible = true;
                    Oyuncu_Korunuyor_Mu = false;
                    Oyuncu_Saldiriyor_Mu = true;
                    Oyuncu_Rp_Kullanimi_Aktif_Mi = true;
                }
            }

            //Oyuncu icin Kalkan Tusu
            if (e.KeyCode == Keys.W && Game_Paused == false && End_Timer.Enabled == false)
            {
                if (Oyuncu_Stunlandi_Mi == false && Oyuncu_Rp_Bar.Value == 100 && (Oyuncu_Rp_Kullanimi_Aktif_Mi == false) && YapayZeka_Revive_Aktiflestirici == false && YapayZeka_is_Cheating == false && ItemShop_Aktif_Mi == false && ((Oyuncu_is_Cheating == false && Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false) || (Oyuncu_is_Cheating == true && Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false) || (Oyuncu_is_Cheating == false && Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == true)))
                {
                    Oyuncu.Visible = false;
                    Oyuncu_Kalkan.ImageLocation = "Hurkanix Settings//Heal.gif";
                    Oyuncu_Kalkan.Visible = true;
                    Oyuncu_Korunuyor_Mu = true;
                    Oyuncu_Rp_Kullanimi_Aktif_Mi = true;
                }
            }
        }


        //Yapay Zeka Saldiri/Korunma Hareketleri
        private Random YapayZeka_Rastgele_Saldiri_Secimi = new Random();
        private int YapayZeka_Rastgele_Saldiri_Degeri = 0;
        private void YapayZeka_Davranis_Timer_Yeri(object sender, EventArgs e)
        {
            //YapayZeka stun mu atacak yoksa destansi saldiri mi yapacak ona karar veriyor
            YapayZeka_Rastgele_Saldiri_Degeri = YapayZeka_Rastgele_Saldiri_Secimi.Next(0, 2);


            //YapayZeka icin Stun                    
            if (Game_Paused == false && End_Timer.Enabled == false && (Oyuncu_Korunuyor_Mu == true || (Oyuncu_Korunuyor_Mu == false && YapayZeka_Rastgele_Saldiri_Degeri % 2 == 0)) && YapayZeka_Revive_Aktiflestirici == false && ((YapayZeka_Korunuyor_Mu == true && (Oyuncu_Saldiriyor_Mu == false || Oyuncu_Buyu.Visible == false)) || (YapayZeka_Korunuyor_Mu == false && (Oyuncu_Saldiriyor_Mu == true || Oyuncu_Buyu.Visible == true)) || (YapayZeka_Korunuyor_Mu == false && (Oyuncu_Saldiriyor_Mu == false || Oyuncu_Buyu.Visible == false))) && YapayZeka_is_Cheating == false && ItemShop_Aktif_Mi == false && ((Oyuncu_is_Cheating == false && Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false) || (Oyuncu_is_Cheating == true && Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false) || (Oyuncu_is_Cheating == false && Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == true)))
            {
                if ((YapayZeka_Rp_Bar.Value == 100) && (YapayZeka_Buyu.Visible == false) && (YapayZeka_Rp_Kullanimi_Aktif_Mi == false) && (YapayZeka_Saldiriyor_Mu == false))
                {
                    YapayZeka_Stun_Aktif_Mi = true;
                    YapayZeka_Buyu.ImageLocation = "Hurkanix Settings//Stun.png";
                    YapayZeka.Visible = true;
                    YapayZeka_Buyu.Visible = true;
                    YapayZeka_Korunuyor_Mu = false;
                    YapayZeka_Saldiriyor_Mu = true;
                    YapayZeka_Rp_Kullanimi_Aktif_Mi = true;
                }
            }

            //YapayZeka icin Saldiri
            if (Game_Paused == false && End_Timer.Enabled == false && Oyuncu_Korunuyor_Mu == false && YapayZeka_Revive_Aktiflestirici == false && ((YapayZeka_Korunuyor_Mu == true && (Oyuncu_Saldiriyor_Mu == false || Oyuncu_Buyu.Visible == false)) || (YapayZeka_Korunuyor_Mu == false && (Oyuncu_Saldiriyor_Mu == true || Oyuncu_Buyu.Visible == true)) || (YapayZeka_Korunuyor_Mu == false && (Oyuncu_Saldiriyor_Mu == false || Oyuncu_Buyu.Visible == false))) && YapayZeka_is_Cheating == false && ItemShop_Aktif_Mi == false && ((Oyuncu_is_Cheating == false && Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false) || (Oyuncu_is_Cheating == true && Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false) || (Oyuncu_is_Cheating == false && Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == true)))
            {
                if ((YapayZeka_Rp_Bar.Value == 100) && (YapayZeka_Buyu.Visible == false) && (YapayZeka_Rp_Kullanimi_Aktif_Mi == false) && (YapayZeka_Saldiriyor_Mu == false))
                {
                    YapayZeka_Buyu.ImageLocation = "Hurkanix Settings//SuperPower2.gif";
                    YapayZeka.Visible = true;
                    YapayZeka_Buyu.Visible = true;
                    YapayZeka_Korunuyor_Mu = false;
                    YapayZeka_Saldiriyor_Mu = true;
                    YapayZeka_Rp_Kullanimi_Aktif_Mi = true;
                }
            }

        }

        //Saldiri Hareket Eventi Baslangici
        private int Oyuncu_Destansi_Yetenek_Sayac = 0;
        private int YapayZeka_Destansi_Yetenek_Sayac = 0;
        private void Buyu_Akisi_Timer_Yeri(object sender, EventArgs e)
        {
            WMP1.Ctlcontrols.play();

            //YapayZeka icin Saldiri & Korunma Ayarlari [SONSUZ RP OZELLIKLERI ICIN]         
            if (YapayZeka_Rp_Kullanimi_Aktif_Mi == true)
            {
                YapayZeka_Destansi_Yetenek_Sayac++;
                if (YapayZeka_Destansi_Yetenek_Sayac == 25)
                {
                    YapayZeka_Rp_Kullanimi_Aktif_Mi = false;
                    YapayZeka_Destansi_Yetenek_Sayac = 0;
                }
            }


            //Oyuncu icin Saldiri & Korunma Ayarlari [SONSUZ RP OZELLIKLERI ICIN]         
            if (Oyuncu_Rp_Kullanimi_Aktif_Mi == true)
            {

                if (Oyuncu_Korunuyor_Mu == true)
                {
                    Oyuncu_Destansi_Yetenek_Sayac++;

                    //Oyuncunun Hp si artar
                    if (Oyuncu_Hp_Bar.Value != 100)
                        Oyuncu_Hp_Bar.Value += 1;

                    //Oyuncunun Mp si artar
                    if (Oyuncu_Mp_Bar.Value != 100)
                        Oyuncu_Mp_Bar.Value += 1;

                    Oyuncu_Hp_Yuzdelik.Text = "[HP]: %" + Oyuncu_Hp_Bar.Value;
                    Oyuncu_Mp_Yuzdelik.Text = "[MP]: %" + Oyuncu_Mp_Bar.Value;

                    if (Oyuncu_Destansi_Yetenek_Sayac == 35)
                    {
                        Oyuncu_Kalkan.Visible = false;
                        Oyuncu_Kalkan.ImageLocation = "Hurkanix Settings//Heal.gif";
                        Oyuncu.Visible = true;
                        Oyuncu_Korunuyor_Mu = false;
                        Oyuncu_Rp_Kullanimi_Aktif_Mi = false;
                        Oyuncu_Destansi_Yetenek_Sayac = 0;
                    }
                }
                else
                {
                    Oyuncu_Destansi_Yetenek_Sayac++;
                    if (Oyuncu_Destansi_Yetenek_Sayac == 25)
                    {

                        Oyuncu_Rp_Kullanimi_Aktif_Mi = false;
                        Oyuncu_Destansi_Yetenek_Sayac = 0;
                    }
                }
            }


            //YapayZeka Saldirirsa
            if (YapayZeka_Saldiriyor_Mu == true)
            {
                YapayZeka_Buyu.Visible = true;
                Point YapayZeka_Hareket_Konumu = new Point();
                if (YapayZeka_Buyu.Location.X >= 315 && YapayZeka_Buyu.Location.Y <= 360)
                {
                    YapayZeka_Hareket_Konumu.X = YapayZeka_Buyu.Location.X - 16;
                    YapayZeka_Hareket_Konumu.Y = YapayZeka_Buyu.Location.Y + 4;
                    YapayZeka_Buyu.Location = YapayZeka_Hareket_Konumu;
                }
                else
                {
                    if (Oyuncu_Korunuyor_Mu == false)
                    {

                        //YapayZekanin saldirisi isabet halinde 40 HP hasar verecektir
                        if (YapayZeka_Stun_Aktif_Mi == false && ((Oyuncu_Cheat_Hazir_Mi == false && Oyuncu_Pasif_Kalkan_Satin_Almis_Mi == true) || (Oyuncu_Pasif_Kalkan_Satin_Almis_Mi == false)))
                        {
                            if (Oyuncu_Hp_Bar.Value <= 40)
                                Oyuncu_Hp_Bar.Value = 0;
                            else
                                Oyuncu_Hp_Bar.Value -= 40;
                        }
                        else if (YapayZeka_Stun_Aktif_Mi == true)
                        {
                            Oyuncu_Kalkan.Visible = false;
                            Oyuncu_Kalkan.ImageLocation = "Hurkanix Settings//Heal.gif";
                            Oyuncu.Visible = true;
                            Oyuncu_Korunuyor_Mu = false;
                            Oyuncu_Rp_Kullanimi_Aktif_Mi = false;
                            Oyuncu_Destansi_Yetenek_Sayac = 0;
                            YapayZeka_Stun_Aktif_Mi = false;
                            Sleep_Effect_Picture.Visible = true;
                            Sleep_Effect_Time_Label.Text = "3";
                            Sleep_Effect_Time_Label.Visible = true;

                            Oyuncu.Size = new Size(220, 149);
                            Oyuncu.Location = new Point(13, 303);
                            Oyuncu.ImageLocation = "Hurkanix Settings//Sleep.png";


                            //Stun Kullaniciya Hasar Verir
                            if (Oyuncu_Pasif_Kalkan_Satin_Almis_Mi == true && Oyuncu_Cheat_Hazir_Mi == true)
                            {
                                Oyuncu_Cheat_Bar.Value = 90;
                                Oyuncu_Cheat_Bar.ForeColor = Color.DarkRed;
                                Oyuncu_Kalkan_Tukeniyor_Mu = true;
                                WMP6.URL = "Hurkanix Settings//Teemo_Laugh.mp3";
                                //Upgraded Kalkan YapayZekaya Verdigi Hasarin 5 Kati Kadarini Yansitir
                                YapayZeka_Hp_Bar.Value = 0;
                                YapayZeka_Hp_Yuzdelik.Text = "[HP]: %" + YapayZeka_Hp_Bar.Value;
                            }
                            else if ((Oyuncu_Pasif_Kalkan_Satin_Almis_Mi == true && Oyuncu_Cheat_Hazir_Mi == false) || (Oyuncu_Pasif_Kalkan_Satin_Almis_Mi == false && Oyuncu_Cheat_Hazir_Mi == true) || (Oyuncu_Pasif_Kalkan_Satin_Almis_Mi == false && Oyuncu_Cheat_Hazir_Mi == false))
                            {
                                if (Oyuncu_Hp_Bar.Value >= 20)
                                    Oyuncu_Hp_Bar.Value -= 20;
                                else
                                    Oyuncu_Hp_Bar.Value = 0;

                                Oyuncu_Hp_Yuzdelik.Text = "[HP]: %" + Oyuncu_Hp_Bar.Value;
                            }


                            if (Oyuncu_Stunlandi_Mi == true)
                            {
                                YapayZeka_Stun_Sayaci = 0;
                            }

                            Oyuncu_Stunlandi_Mi = true;
                        }
                        else if (YapayZeka_Stun_Aktif_Mi == false && Oyuncu_Cheat_Hazir_Mi == true && Oyuncu_Pasif_Kalkan_Satin_Almis_Mi == true) //Pasif Kalkanin olmasi durumunda 1 kereligine hicbir sekilde hasar alamaz olacaktir
                        {
                            Oyuncu_Cheat_Bar.Value = 90;
                            Oyuncu_Cheat_Bar.ForeColor = Color.DarkRed;
                            Oyuncu_Kalkan_Tukeniyor_Mu = true;
                            WMP6.URL = "Hurkanix Settings//Teemo_Laugh.mp3";

                            //Upgraded Kalkan YapayZekaya Verdigi Hasarin 5 Kati Kadarini Yansitir
                            YapayZeka_Hp_Bar.Value = 0;
                            YapayZeka_Hp_Yuzdelik.Text = "[HP]: %" + YapayZeka_Hp_Bar.Value;

                            YapayZeka_Buyu.Visible = false;
                            YapayZeka_Hareket_Konumu.X = 760;
                            YapayZeka_Hareket_Konumu.Y = 177;
                            YapayZeka_Buyu.Location = YapayZeka_Hareket_Konumu;
                            YapayZeka_Saldiriyor_Mu = false;
                            Oyuncu_Kalkan_Tukeniyor_Mu = true;
                        }

                        Oyuncu_Hp_Yuzdelik.Text = "[HP]: %" + Oyuncu_Hp_Bar.Value;
                        YapayZeka_Buyu.Visible = false;
                        YapayZeka_Hareket_Konumu.X = 760;
                        YapayZeka_Hareket_Konumu.Y = 177;
                        YapayZeka_Buyu.Location = YapayZeka_Hareket_Konumu;
                        YapayZeka_Saldiriyor_Mu = false;

                    }
                    else
                    {
                        if (YapayZeka_Stun_Aktif_Mi == true)
                        {
                            Oyuncu_Kalkan.Visible = false;
                            Oyuncu_Kalkan.ImageLocation = "Hurkanix Settings//Heal.gif";
                            Oyuncu.Visible = true;
                            Oyuncu_Korunuyor_Mu = false;
                            Oyuncu_Rp_Kullanimi_Aktif_Mi = false;
                            Oyuncu_Destansi_Yetenek_Sayac = 0;
                            YapayZeka_Stun_Aktif_Mi = false;
                            Sleep_Effect_Picture.Visible = true;
                            Sleep_Effect_Time_Label.Text = "3";
                            Sleep_Effect_Time_Label.Visible = true;

                            Oyuncu.Size = new Size(220, 149);
                            Oyuncu.Location = new Point(13, 303);
                            Oyuncu.ImageLocation = "Hurkanix Settings//Sleep.png";


                            //Stun Kullaniciya Hasar Verir
                            if (Oyuncu_Pasif_Kalkan_Satin_Almis_Mi == true && Oyuncu_Cheat_Hazir_Mi == true)
                            {
                                Oyuncu_Cheat_Bar.Value = 90;
                                Oyuncu_Cheat_Bar.ForeColor = Color.DarkRed;
                                Oyuncu_Kalkan_Tukeniyor_Mu = true;
                                WMP6.URL = "Hurkanix Settings//Teemo_Laugh.mp3";
                                //Upgraded Kalkan YapayZekaya Verdigi Hasarin 5 Kati Kadarini Yansitir
                                YapayZeka_Hp_Bar.Value = 0;
                                YapayZeka_Hp_Yuzdelik.Text = "[HP]: %" + YapayZeka_Hp_Bar.Value;
                            }
                            else if ((Oyuncu_Pasif_Kalkan_Satin_Almis_Mi == true && Oyuncu_Cheat_Hazir_Mi == false) || (Oyuncu_Pasif_Kalkan_Satin_Almis_Mi == false && Oyuncu_Cheat_Hazir_Mi == true) || (Oyuncu_Pasif_Kalkan_Satin_Almis_Mi == false && Oyuncu_Cheat_Hazir_Mi == false))
                            {
                                if (Oyuncu_Hp_Bar.Value >= 20)
                                    Oyuncu_Hp_Bar.Value -= 20;
                                else
                                    Oyuncu_Hp_Bar.Value = 0;

                                Oyuncu_Hp_Yuzdelik.Text = "[HP]: %" + Oyuncu_Hp_Bar.Value;
                            }


                            if (Oyuncu_Stunlandi_Mi == true)
                            {
                                YapayZeka_Stun_Sayaci = 0;
                            }

                            Oyuncu_Stunlandi_Mi = true;
                        }

                        YapayZeka_Buyu.Visible = false;
                        YapayZeka_Hareket_Konumu.X = 760;
                        YapayZeka_Hareket_Konumu.Y = 177;
                        YapayZeka_Buyu.Location = YapayZeka_Hareket_Konumu;
                        YapayZeka_Saldiriyor_Mu = false;
                    }
                }
            }




            //Oyuncu Saldirirsa
            if (Oyuncu_Saldiriyor_Mu == true)
            {
                Oyuncu_Buyu.Visible = true;
                Point Oyuncu_Hareket_Konumu = new Point();
                if (Oyuncu_Buyu.Location.X <= 760 && Oyuncu_Buyu.Location.Y >= 177)
                {
                    Oyuncu_Hareket_Konumu.X = Oyuncu_Buyu.Location.X + 16;
                    Oyuncu_Hareket_Konumu.Y = Oyuncu_Buyu.Location.Y - 4;
                    Oyuncu_Buyu.Location = Oyuncu_Hareket_Konumu;
                }
                else
                {
                    if (YapayZeka_Korunuyor_Mu == false)
                    {

                        //Oyuncunun saldirisi isabet halinde 40 hp hasar verecek
                        if (YapayZeka_Hp_Bar.Value <= 40)
                            YapayZeka_Hp_Bar.Value = 0;
                        else
                            YapayZeka_Hp_Bar.Value -= 40;


                        YapayZeka_Hp_Yuzdelik.Text = "[HP]: %" + YapayZeka_Hp_Bar.Value;
                        Oyuncu_Buyu.Visible = false;
                        Oyuncu_Hareket_Konumu.X = 315;
                        Oyuncu_Hareket_Konumu.Y = 360;
                        Oyuncu_Buyu.Location = Oyuncu_Hareket_Konumu;
                        Oyuncu_Saldiriyor_Mu = false;
                    }
                    else
                    {
                        Oyuncu_Buyu.Visible = false;
                        Oyuncu_Hareket_Konumu.X = 315;
                        Oyuncu_Hareket_Konumu.Y = 360;
                        Oyuncu_Buyu.Location = Oyuncu_Hareket_Konumu;
                        Oyuncu_Saldiriyor_Mu = false;
                    }
                }
            }



            //Oyunun Bitisi
            if (Dakika == 0 && Saniye == 0 && Oyuncu_Hp_Bar.Value != 0)
            {
                Oyun_Sonu = true;
                WMP1.Ctlcontrols.stop();
                WMP2.Ctlcontrols.stop();
                WMP3.Ctlcontrols.stop();
                WMP5.Ctlcontrols.stop();
                WMP6.Ctlcontrols.stop();
                YapayZeka_Cheat_Haber_PictureBox.ImageLocation = "Hurkanix Settings//Dolores_Umbridge_2.gif";
                Sleep_Effect_Time_Label.Visible = false;
                Sleep_Effect_Picture.Visible = false;
                Buyu_Akisi_Timer.Enabled = false;
                Oyun_Zamanlayici_Timer.Enabled = false;
                Hp_Mp_Timer.Enabled = false;
                YapayZeka_Davranis_Timer.Enabled = false;
                YapayZeka_Cheats_Timer.Enabled = false;
                Oyuncu_Cheats_Timer.Enabled = false;
                Timer_Saat_Gosterici.Text = " 00 : 00";

                YapayZeka_Hp_Bar.Value = 0;
                YapayZeka_Mp_Bar.Value = 0;

                Oyuncu_Kalkan.Visible = false;
                Oyuncu.Visible = true;
                Oyuncu.Location = new Point(2, 288);
                Oyuncu.Size = new Size(299, 170);
                Oyuncu.ImageLocation = "Hurkanix Settings//Oyuncu1.gif";
                YapayZeka.Visible = true;
                YapayZeka.Location = new Point(930, 194);
                YapayZeka.Size = new Size(200, 131);
                YapayZeka.ImageLocation = "Hurkanix Settings//Rip.png";

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
                End.Oyun_Sonu_Raporu.Text = "Bir dakika boyunca hayatta kalmayi basardiniz tebrikler " + Oyuncu_Isim.Text + " !";
                End.Play_Again_Button.Text = "P L A Y   A G A I N";
                End.Show();
                GameMode3_Hide = false;
                End_Timer.Enabled = true;
            }
            else if ((YapayZeka_Hp_Bar.Value == 0) && (Oyuncu_Hp_Bar.Value == 0))
            {
                if (YapayZeka_Revive_Mevcut_Mu == true)
                {
                    YapayZeka_Hp_Bar.Value = 0;
                    YapayZeka_Mp_Bar.Value = 0;

                    Oyuncu_Hp_Bar.Value = 0;
                    Oyuncu_Mp_Bar.Value = 0;

                    Oyuncu_Rp_Bar.Value = 0;
                    Oyuncu_Cheat_Bar.Value = 0;

                    Oyuncu_Cheat_Haber_PictureBox.ImageLocation = "Hurkanix Settings//Dolores_Umbridge_1.gif";
                    Sleep_Effect_Time_Label.Visible = false;
                    Sleep_Effect_Picture.Visible = false;

                    Oyuncu_Kalkan.Visible = false;
                    Oyuncu.Visible = true;
                    Oyuncu.Location = new Point(16, 294);
                    Oyuncu.Size = new Size(200, 131);
                    Oyuncu.ImageLocation = "Hurkanix Settings//Rip.png";


                    YapayZeka_Hp_Yuzdelik.Text = "[HP]: %" + YapayZeka_Hp_Bar.Value;
                    YapayZeka_Mp_Yuzdelik.Text = "[MP]: %" + YapayZeka_Mp_Bar.Value;

                    Oyuncu_Hp_Yuzdelik.Text = "[HP]: %" + Oyuncu_Hp_Bar.Value;
                    Oyuncu_Mp_Yuzdelik.Text = "[MP]: %" + Oyuncu_Mp_Bar.Value;
                    Oyuncu_Rp_Yuzdelik.Text = "[RP]: %" + Oyuncu_Rp_Bar.Value;

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
                    Oyuncu_Cheat_Haber_PictureBox.ImageLocation = "Hurkanix Settings//Dolores_Umbridge_1.gif";
                    YapayZeka_Cheat_Haber_PictureBox.ImageLocation = "Hurkanix Settings//Dolores_Umbridge_2.gif";
                    Sleep_Effect_Time_Label.Visible = false;
                    Sleep_Effect_Picture.Visible = false;
                    Buyu_Akisi_Timer.Enabled = false;
                    Oyun_Zamanlayici_Timer.Enabled = false;
                    Hp_Mp_Timer.Enabled = false;
                    YapayZeka_Davranis_Timer.Enabled = false;
                    YapayZeka_Cheats_Timer.Enabled = false;
                    Oyuncu_Cheats_Timer.Enabled = false;

                    Oyuncu_Kalkan.Visible = false;
                    Oyuncu.Visible = true;
                    Oyuncu.Location = new Point(16, 294);
                    Oyuncu.Size = new Size(200, 131);
                    Oyuncu.ImageLocation = "Hurkanix Settings//Rip.png";
                    YapayZeka.Visible = true;
                    YapayZeka.Location = new Point(930, 194);
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

                    YapayZeka_Rp_Yuzdelik.Text = "[RP]: %0";
                    Oyuncu_Rp_Yuzdelik.Text = "[RP]: %0";

                    WMP4.URL = "Hurkanix Settings//They_Never_Learn.mp3";

                    //Oyun Sonu Ekrani Aciliyor
                    GameOver End = new GameOver();
                    End.Oyun_Sonu_Raporu.Text = "Uzgunum " + Oyuncu_Isim.Text + " ama malesef hayatta kalmayi basaramadiniz !";
                    End.Play_Again_Button.Text = "P L A Y   A G A I N";
                    End.Show();
                    GameMode3_Hide = false;
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
                    YapayZeka_Cheat_Haber_PictureBox.ImageLocation = "Hurkanix Settings//Dolores_Umbridge_2.gif";
                    Sleep_Effect_Time_Label.Visible = false;
                    Sleep_Effect_Picture.Visible = false;
                    Buyu_Akisi_Timer.Enabled = false;
                    Oyun_Zamanlayici_Timer.Enabled = false;
                    Hp_Mp_Timer.Enabled = false;
                    YapayZeka_Davranis_Timer.Enabled = false;
                    YapayZeka_Cheats_Timer.Enabled = false;
                    Oyuncu_Cheats_Timer.Enabled = false;
                    YapayZeka_Hp_Bar.Value = 0;
                    YapayZeka_Mp_Bar.Value = 0;

                    YapayZeka.Visible = true;
                    YapayZeka.Location = new Point(930, 194);
                    YapayZeka.Size = new Size(200, 131);
                    YapayZeka.ImageLocation = "Hurkanix Settings//Rip.png";

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
                    End.Oyun_Sonu_Raporu.Text = "Lord Voldemort'u yenerek hayatta kalmayi basardiniz tebrikler " + Oyuncu_Isim.Text + " !";
                    End.Play_Again_Button.Text = "P L A Y   A G A I N";
                    End.Show();
                    GameMode3_Hide = false;
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
                Oyuncu_Cheat_Haber_PictureBox.ImageLocation = "Hurkanix Settings//Dolores_Umbridge_1.gif";
                Sleep_Effect_Time_Label.Visible = false;
                Sleep_Effect_Picture.Visible = false;
                Buyu_Akisi_Timer.Enabled = false;
                Oyun_Zamanlayici_Timer.Enabled = false;
                Hp_Mp_Timer.Enabled = false;
                YapayZeka_Davranis_Timer.Enabled = false;
                YapayZeka_Cheats_Timer.Enabled = false;
                Oyuncu_Cheats_Timer.Enabled = false;

                Oyuncu_Kalkan.Visible = false;
                Oyuncu.Visible = true;
                Oyuncu.Location = new Point(16, 294);
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
                End.Oyun_Sonu_Raporu.Text = "Uzgunum " + Oyuncu_Isim.Text + " ama malesef hayatta kalmayi basaramadiniz !";
                End.Play_Again_Button.Text = "P L A Y   A G A I N";
                End.Show();
                GameMode3_Hide = false;
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

            //Oyuncunun Manasi Yenilenir
            if ((Oyuncu_Mp_Bar.Value != 100) && (Oyuncu_Hp_Bar.Value != 0))
            {
                if (Oyuncu_Mp_Bar.Value <= 96)
                    Oyuncu_Mp_Bar.Value += 4;
                else
                    Oyuncu_Mp_Bar.Value = 100;
                Oyuncu_Mp_Yuzdelik.Text = "[MP]: %" + Oyuncu_Mp_Bar.Value;
            }


            //Oyuncunun Canlari Yenilenir
            if ((Oyuncu_Hp_Bar.Value != 100) && (Oyuncu_Hp_Bar.Value != 0))
            {
                if (Oyuncu_Hp_Bar.Value <= 96)
                    Oyuncu_Hp_Bar.Value += 4;
                else
                    Oyuncu_Hp_Bar.Value = 100;
                Oyuncu_Hp_Yuzdelik.Text = "[HP]: %" + Oyuncu_Hp_Bar.Value;
            }
        }



        //Renkli Zaman Yeri
        private Random renk = new Random();
        private void Renk_Timer_Yeri(object sender, EventArgs e)
        {
            //IMKANSIZ TUS BASMA DURUMUNDAKI EKRANDAKI YAZIYI SILME KODU
            if (Oyuncu_Cheat_Hazir_Mi == false && YapayZeka_Cheat_Hazir_Mi == false && Oyuncu_Cheat_Bar.ForeColor != Color.DarkRed && YapayZeka_Cheat_Bar.ForeColor != Color.DarkRed && YapayZeka_Revive_Aktiflestirici == false && Pasif_Yetenekler_Aciklama.Text == "[WARNING]\nHerhangi bir pasif yetenek kullanilirken Item Shop'a giris yapamazsiniz !")
            {
                Pasif_Yetenekler_Aciklama.Visible = false;
                Pasif_Yetenekler_Aciklama.Text = "";
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
                    ItemShop.ForeColor = Oyuncu_ItemShop_Isim.ForeColor = YapayZeka_ItemShop_Isim.ForeColor = Oyuncu_Gold_Gostergesi.ForeColor = YapayZeka_Gold_Gostergesi.ForeColor = Oyuncu_Item_A_Fiyat.ForeColor = Oyuncu_Item_B_Fiyat.ForeColor = Oyuncu_Item_C_Fiyat.ForeColor = YapayZeka_Item_A_Fiyat.ForeColor = YapayZeka_Item_B_Fiyat.ForeColor = YapayZeka_Item_C_Fiyat.ForeColor = Color.DarkRed;
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


            if (Oyuncu_Rp_Bar.Value == 100)
                Oyuncu_Rp_Bar.ForeColor = Oyuncu_Rp_Yuzdelik.BackColor = Exit_Yazi.ForeColor;
            else if (Oyuncu_Hp_Bar.Value == 0)
                Oyuncu_Rp_Yuzdelik.BackColor = Color.Gold;




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


            //OYUNCUNUN YAPAYZEKA TARAFINDAN STUN YEMESI
            if (Oyun_Sonu == false && Oyuncu_Stunlandi_Mi == true && ItemShop_Aktif_Mi == false && YapayZeka_Revive_Aktiflestirici == false && ((Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == true && Oyuncu_is_Cheating == false) || (Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false && Oyuncu_is_Cheating == true) || (Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false && Oyuncu_is_Cheating == false)))
            {
                Sleep_Effect_Picture.Visible = true;
                Sleep_Effect_Time_Label.Visible = true;

                Oyuncu.Size = new Size(220, 149);
                Oyuncu.Location = new Point(13, 303);
                Oyuncu.ImageLocation = "Hurkanix Settings//Sleep.png";

                if (YapayZeka_Stun_Sayaci >= 0 && YapayZeka_Stun_Sayaci < 16)
                    Sleep_Effect_Time_Label.Text = "3";
                else if (YapayZeka_Stun_Sayaci >= 16 && YapayZeka_Stun_Sayaci < 32)
                    Sleep_Effect_Time_Label.Text = "2";
                else if (YapayZeka_Stun_Sayaci >= 32 && YapayZeka_Stun_Sayaci < 50)
                    Sleep_Effect_Time_Label.Text = "1";
                else if (YapayZeka_Stun_Sayaci == 50)
                    Sleep_Effect_Time_Label.Text = "0";

                if (YapayZeka_Stun_Sayaci == 50)
                {
                    YapayZeka_Stun_Sayaci = 0;
                    Oyuncu_Stunlandi_Mi = false;
                    Oyuncu.Location = new Point(2, 288);
                    Oyuncu.Size = new Size(299, 170);
                    Sleep_Effect_Picture.Visible = false;
                    Sleep_Effect_Time_Label.Visible = false;
                    Oyuncu.ImageLocation = "Hurkanix Settings//Oyuncu1.gif";
                }

                YapayZeka_Stun_Sayaci++;

            }


            //YAPAYZEKA CAN & MANA YENILEME SKILL
            if (YapayZeka_Hp_Bar.Value != 0 && YapayZeka_Revive_Aktiflestirici == false && ((Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == true && Oyuncu_is_Cheating == false) || (Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false && Oyuncu_is_Cheating == true) || (Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false && Oyuncu_is_Cheating == false)))
            {
                //Yapay zekanin hp ve mp bari rengarenk oluyor
                if (Oyun_Sonu == false)
                    YapayZeka_Hp_Bar.ForeColor = YapayZeka_Mp_Bar.ForeColor = YapayZeka_Hp_Yuzdelik.BackColor = YapayZeka_Mp_Yuzdelik.BackColor = Exit_Yazi.ForeColor;

                if (YapayZeka_Hp_Bar.Value != 100 && ItemShop_Aktif_Mi == false && Oyun_Sonu == false)
                {
                    if (YapayZeka_Hp_Bar.Value != 100)
                        YapayZeka_Hp_Bar.Value += 1;

                    YapayZeka_Hp_Yuzdelik.Text = "[HP]: %" + YapayZeka_Hp_Bar.Value;
                }

                if (YapayZeka_Mp_Bar.Value != 100 && ItemShop_Aktif_Mi == false && Oyun_Sonu == false)
                {
                    if (YapayZeka_Mp_Bar.Value != 100)
                        YapayZeka_Mp_Bar.Value += 1;

                    YapayZeka_Mp_Yuzdelik.Text = "[MP]: %" + YapayZeka_Mp_Bar.Value;
                }

                if (YapayZeka_Hp_Bar.Value == 100 && YapayZeka_Mp_Bar.Value == 100)
                {
                    YapayZeka_Hp_Bar.ForeColor = Color.DarkRed;
                    YapayZeka_Hp_Yuzdelik.BackColor = Color.Red;
                    YapayZeka_Mp_Bar.ForeColor = Color.MidnightBlue;
                    YapayZeka_Mp_Yuzdelik.BackColor = Color.RoyalBlue;
                }
            }



            //Oyuncu ve YapayZeka ItemShop Renk Ayarlari
            if (ItemShop_Aktif_Mi == true)
            {
                //Oyuncu ItemShop Renk Ayarlari
                Oyuncu_Gold_Gostergesi.ForeColor = Oyuncu_Item_A_Fiyat.ForeColor = Oyuncu_Item_B_Fiyat.ForeColor = Oyuncu_Item_C_Fiyat.ForeColor = Exit_Yazi.ForeColor;

                //YapayZeka ItemShop Renk Ayarlari
                YapayZeka_Gold_Gostergesi.ForeColor = YapayZeka_Item_A_Fiyat.ForeColor = YapayZeka_Item_B_Fiyat.ForeColor = YapayZeka_Item_C_Fiyat.ForeColor = Exit_Yazi.ForeColor;
            }
            else
                ItemShop.ForeColor = Color.DarkRed;



            //CheckBox'larin rengini ayarladik
            if (ItemShop_Aktif_Mi == true)
                Oyuncu_A_CheckBox.BackColor = Oyuncu_B_CheckBox.BackColor = Oyuncu_C_CheckBox.BackColor = YapayZeka_A_CheckBox.BackColor = YapayZeka_B_CheckBox.BackColor = YapayZeka_C_CheckBox.BackColor = Exit_Yazi.ForeColor;
            else
                Oyuncu_A_CheckBox.BackColor = Oyuncu_B_CheckBox.BackColor = Oyuncu_C_CheckBox.BackColor = YapayZeka_A_CheckBox.BackColor = YapayZeka_B_CheckBox.BackColor = YapayZeka_C_CheckBox.BackColor = Color.DarkRed;


            //ItemShop Acik Oldugunda Sleep Label Rengini Ayarladik
            if (ItemShop_Aktif_Mi == true)
                Sleep_Effect_Time_Label.ForeColor = Color.DarkRed;
            else
                Sleep_Effect_Time_Label.ForeColor = Color.Red;


            //ItemShop Yazisinin Rengini Ayarladik
            if (ItemShop_Aktif_Mi == true)
                ItemShop.ForeColor = Exit_Yazi.ForeColor;
            else
                ItemShop.ForeColor = Color.DarkRed;


            //Oyuncu'nun Gold Miktarina Bagli Olarak Item Cursor Seklini Ayarladik
            if (ItemShop_Aktif_Mi == true)
                Oyuncu_Item_A.Cursor = Cursors.Hand;
            else
                Oyuncu_Item_A.Cursor = Cursors.No;
            if (ItemShop_Aktif_Mi == true)
                Oyuncu_Item_B.Cursor = Cursors.Hand;
            else
                Oyuncu_Item_B.Cursor = Cursors.No;
            if (ItemShop_Aktif_Mi == true)
                Oyuncu_Item_C.Cursor = Cursors.Hand;
            else
                Oyuncu_Item_C.Cursor = Cursors.No;


            //Oyuncu B Pasif Skilli Alirsa Onlar Icin Gerekli Hesaplamalar
            if (((Oyuncu_is_Cheating == false && Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == true) || (Oyuncu_is_Cheating == false && Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false) || (Oyuncu_is_Cheating == true && Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false)) && (YapayZeka_is_Cheating == false || YapayZeka_is_Cheating == true))
            {
                Oyuncu_Anlik_Hp_Miktari = Oyuncu_Hp_Bar.Value;
                YapayZeka_Anlik_Hp_Miktari = YapayZeka_Hp_Bar.Value;
                Oyuncu_Anlik_Mp_Miktari = Oyuncu_Mp_Bar.Value;
                YapayZeka_Anlik_Mp_Miktari = YapayZeka_Mp_Bar.Value;
            }

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
                YapayZeka_Cheats_Timer.Interval = 300; //CheatBar Doldurma Hizi
                if (YapayZeka_Cheat_Bar.Value <= 98)
                    YapayZeka_Cheat_Bar.Value += 2;
                else
                    YapayZeka_Cheat_Bar.Value = 100;

                if (YapayZeka_Cheat_Bar.Value == 100)
                {
                    YapayZeka_Cheat_Hazir_Mi = true;
                    YapayZeka_Cheat_Haber_PictureBox.ImageLocation = "Hurkanix Settings//Dolores_Umbridge_4.gif";
                    YapayZeka_Cheats_Timer.Interval = 100; //Pasif Hp ve Mp nin dolma hizi
                }

            }


            /* YAPAYZEKA CAN & MANA YENILEME SKILL

               Renk_Timer_Yeri zaman yerinde bu skillin kodlari var   

            */


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
                Oyuncu_Hp_Bar.Value = (int)(Oyuncu_Hp_Bar.Value * 3 / 10);
                Oyuncu_Mp_Bar.Value = (int)(Oyuncu_Mp_Bar.Value * 3 / 10);
                Oyuncu_Hp_Yuzdelik.Text = "[HP]: %" + Oyuncu_Hp_Bar.Value;
                Oyuncu_Mp_Yuzdelik.Text = "[MP]: %" + Oyuncu_Mp_Bar.Value;
                YapayZeka_Cheat_Bar.Value = 0;
                YapayZeka_Cheat_Haber_PictureBox.ImageLocation = "Hurkanix Settings//Dolores_Umbridge_2.gif";
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
                YapayZeka.Location = new Point(888, 161);
                YapayZeka.Size = new Size(265, 168);
                if (YapayZeka.ImageLocation != "Hurkanix Settings//Angel.gif")
                    YapayZeka.ImageLocation = "Hurkanix Settings//Angel.gif";


                //Boyle yaparak 300 salisede dolduran cheat bar doldurucuyu onlemis olduk ^^
                YapayZeka_Cheat_Hazir_Mi = true;

                Buyu_Akisi_Timer.Enabled = false;
                Hp_Mp_Timer.Enabled = false;
                YapayZeka_Davranis_Timer.Enabled = false;
                Oyuncu_Cheats_Timer.Enabled = false;

                YapayZeka_Cheat_Bar.ForeColor = Color.White;

                if (YapayZeka_Cheat_Bar.Value != 100 && YapayZeka_Hp_Bar.Value == 0 && YapayZeka_Mp_Bar.Value == 0)
                {
                    if (YapayZeka_Cheat_Bar.Value > 90)
                        YapayZeka_Cheat_Bar.Value = 100;
                    else
                        YapayZeka_Cheat_Bar.Value += 10;
                    if (YapayZeka_Cheat_Bar.Value == 100)
                        YapayZeka_Cheat_Haber_PictureBox.ImageLocation = "Hurkanix Settings//Dolores_Umbridge_4.gif";
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
                        YapayZeka.ImageLocation = "Hurkanix Settings//Lord_Voldemort.gif";
                        YapayZeka.Location = new Point(888, 173);
                        YapayZeka.Size = new Size(267, 156);

                        YapayZeka_Hp_Bar.ForeColor = Color.DarkRed;
                        YapayZeka_Mp_Bar.ForeColor = Color.MidnightBlue;
                        YapayZeka_Hp_Yuzdelik.BackColor = Color.Red;
                        YapayZeka_Mp_Yuzdelik.BackColor = Color.RoyalBlue;
                        YapayZeka_Revive_Aktiflestirici = false;
                        YapayZeka_Revive_Mevcut_Mu = true;
                        YapayZeka_Cheat_Haber_PictureBox.ImageLocation = "Hurkanix Settings//Dolores_Umbridge_2.gif";
                        YapayZeka_Cheat_Bar.ForeColor = Color.White;
                        YapayZeka_Cheat_Hazir_Mi = false;

                        if (Dakika == 0 && Saniye == 0 && Oyuncu_Hp_Bar.Value != 0)
                        {
                            Oyun_Sonu = true;
                            WMP1.Ctlcontrols.stop();
                            WMP2.Ctlcontrols.stop();
                            WMP3.Ctlcontrols.stop();
                            WMP5.Ctlcontrols.stop();
                            WMP6.Ctlcontrols.stop();
                            YapayZeka_Cheat_Haber_PictureBox.ImageLocation = "Hurkanix Settings//Dolores_Umbridge_2.gif";
                            Sleep_Effect_Time_Label.Visible = false;
                            Sleep_Effect_Picture.Visible = false;
                            Buyu_Akisi_Timer.Enabled = false;
                            Oyun_Zamanlayici_Timer.Enabled = false;
                            Hp_Mp_Timer.Enabled = false;
                            YapayZeka_Davranis_Timer.Enabled = false;
                            YapayZeka_Cheats_Timer.Enabled = false;
                            Oyuncu_Cheats_Timer.Enabled = false;
                            Timer_Saat_Gosterici.Text = " 00 : 00";

                            YapayZeka_Hp_Bar.Value = 0;
                            YapayZeka_Mp_Bar.Value = 0;

                            Oyuncu_Kalkan.Visible = false;
                            Oyuncu.Visible = true;
                            Oyuncu.Location = new Point(2, 288);
                            Oyuncu.Size = new Size(299, 170);
                            Oyuncu.ImageLocation = "Hurkanix Settings//Oyuncu1.gif";
                            YapayZeka.Visible = true;
                            YapayZeka.Location = new Point(930, 194);
                            YapayZeka.Size = new Size(200, 131);
                            YapayZeka.ImageLocation = "Hurkanix Settings//Rip.png";

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
                            End.Oyun_Sonu_Raporu.Text = "Bir dakika boyunca hayatta kalmayi basardiniz tebrikler " + Oyuncu_Isim.Text + " !";
                            End.Play_Again_Button.Text = "P L A Y   A G A I N";
                            End.Show();
                            GameMode3_Hide = false;
                            End_Timer.Enabled = true;
                        }
                        else if (Oyuncu_Hp_Bar.Value > 0)
                        {
                            Buyu_Akisi_Timer.Enabled = true;
                            Hp_Mp_Timer.Enabled = true;
                            YapayZeka_Davranis_Timer.Enabled = true;
                            Oyuncu_Cheats_Timer.Enabled = true;
                        }
                        else
                        {
                            Oyun_Sonu = true;
                            WMP1.Ctlcontrols.stop();
                            WMP2.Ctlcontrols.stop();
                            WMP3.Ctlcontrols.stop();
                            WMP5.Ctlcontrols.stop();
                            WMP6.Ctlcontrols.stop();
                            Oyuncu_Cheat_Haber_PictureBox.ImageLocation = "Hurkanix Settings//Dolores_Umbridge_1.gif";
                            Sleep_Effect_Time_Label.Visible = false;
                            Sleep_Effect_Picture.Visible = false;
                            Buyu_Akisi_Timer.Enabled = false;
                            Oyun_Zamanlayici_Timer.Enabled = false;
                            Hp_Mp_Timer.Enabled = false;
                            YapayZeka_Davranis_Timer.Enabled = false;
                            YapayZeka_Cheats_Timer.Enabled = false;
                            Oyuncu_Cheats_Timer.Enabled = false;

                            Oyuncu_Kalkan.Visible = false;
                            Oyuncu.Visible = true;
                            Oyuncu.Location = new Point(16, 294);
                            Oyuncu.Size = new Size(200, 131);

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
                            End.Oyun_Sonu_Raporu.Text = "Uzgunum " + Oyuncu_Isim.Text + " ama malesef hayatta kalmayi basaramadiniz !";
                            End.Play_Again_Button.Text = "P L A Y   A G A I N";
                            End.Show();
                            GameMode3_Hide = false;
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
                    Oyuncu_Cheat_Haber_PictureBox.ImageLocation = "Hurkanix Settings//Dolores_Umbridge_3.gif";
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
                    Oyuncu_Cheat_Haber_PictureBox.ImageLocation = "Hurkanix Settings//Dolores_Umbridge_1.gif";
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
                        if (YapayZeka_Hp_Bar.Value < 40)
                            YapayZeka_Hp_Bar.Value = 0;
                        else
                            YapayZeka_Hp_Bar.Value -= 40;
                    if (YapayZeka_Mp_Bar.Value > 0)
                        if (YapayZeka_Mp_Bar.Value < 40)
                            YapayZeka_Mp_Bar.Value = 0;
                        else
                            YapayZeka_Mp_Bar.Value -= 40;

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
                    Oyuncu_Cheat_Haber_PictureBox.ImageLocation = "Hurkanix Settings//Dolores_Umbridge_1.gif";
                    Oyuncu_Cheats_Timer.Interval = 300;  //Pasif Skill dolma hizi
                }

            }



            // EGER PASIF YETENEGIMIZ OYUNCULAR ARASI HP VE MP DEGISIMI ISE
            if (Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == true && YapayZeka_Revive_Aktiflestirici == false && (Oyuncu_Anlik_Hp_Miktari <= 40 && ((Oyuncu_Anlik_Hp_Miktari < YapayZeka_Anlik_Hp_Miktari) || (Oyuncu_Anlik_Mp_Miktari < YapayZeka_Anlik_Mp_Miktari))) && Oyuncu_Cheat_Hazir_Mi == true && ((YapayZeka_is_Cheating == false) || (YapayZeka_is_Cheating == true)) && ((Oyuncu_Korunuyor_Mu == false && Oyuncu_Rp_Kullanimi_Aktif_Mi == true) || (Oyuncu_Korunuyor_Mu == true && Oyuncu_Rp_Kullanimi_Aktif_Mi == false) || (Oyuncu_Korunuyor_Mu == false && Oyuncu_Rp_Kullanimi_Aktif_Mi == false)) || (Oyuncu_is_Cheating == true && Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == true))
            {
                Oyuncu_Cheats_Timer.Interval = 100; //Pasif Skill Hp ve Mp nin dolma hizi

                Oyuncu_is_Cheating = true;

                Buyu_Akisi_Timer.Enabled = false;
                Hp_Mp_Timer.Enabled = false;
                YapayZeka_Cheats_Timer.Enabled = false;


                //Oyuncu'nun cheat yaptiginin haberini veren ses cikartmasini sagladik
                if (Oyuncu_Cheat_Bar.Value == 100 && Oyuncu_is_Cheating == true)
                {
                    WMP6.URL = "Hurkanix Settings//Teemo_Laugh.mp3";
                }

                //Oyuncularin hp ve mp bari rengarenk oluyor
                Oyuncu_Hp_Bar.ForeColor = Oyuncu_Mp_Bar.ForeColor = Oyuncu_Hp_Yuzdelik.BackColor = Oyuncu_Mp_Yuzdelik.BackColor = Exit_Yazi.ForeColor;
                YapayZeka_Hp_Bar.ForeColor = YapayZeka_Mp_Bar.ForeColor = YapayZeka_Hp_Yuzdelik.BackColor = YapayZeka_Mp_Yuzdelik.BackColor = Color.Black;
                Oyuncu_Cheat_Bar.ForeColor = Color.DarkRed;

                //Oyuncu'nun Hp si artiyor
                if (Oyuncu_Hp_Bar.Value < 100)
                {
                    if (Oyuncu_Hp_Bar.Value <= 98)
                        Oyuncu_Hp_Bar.Value += 2;
                    else
                        Oyuncu_Hp_Bar.Value = 100;
                }

                //YapayZeka'nin Hp si azaliyor
                if (YapayZeka_Hp_Bar.Value >= 1)
                {
                    if (YapayZeka_Hp_Bar.Value >= 3)
                        YapayZeka_Hp_Bar.Value -= 2;
                    else
                        YapayZeka_Hp_Bar.Value = 1;
                }

                YapayZeka_Hp_Yuzdelik.Text = "[HP]: %" + YapayZeka_Hp_Bar.Value;
                Oyuncu_Hp_Yuzdelik.Text = "[HP]: %" + Oyuncu_Hp_Bar.Value;


                //Oyuncu'nun Mp si artiyor
                if (Oyuncu_Mp_Bar.Value <= 98)
                    Oyuncu_Mp_Bar.Value += 2;
                else
                    Oyuncu_Mp_Bar.Value = 100;


                //YapayZeka'nin Mp si azaliyor
                if (YapayZeka_Mp_Bar.Value >= 1)
                {
                    if (YapayZeka_Mp_Bar.Value >= 3)
                        YapayZeka_Mp_Bar.Value -= 2;
                    else
                        YapayZeka_Mp_Bar.Value = 1;
                }

                YapayZeka_Mp_Yuzdelik.Text = "[MP]: %" + YapayZeka_Mp_Bar.Value;
                Oyuncu_Mp_Yuzdelik.Text = "[MP]: %" + Oyuncu_Mp_Bar.Value;



                if (Oyuncu_Cheat_Bar.Value != 0)
                    if (Oyuncu_Cheat_Bar.Value >= 5)
                        Oyuncu_Cheat_Bar.Value -= 5;
                    else
                        Oyuncu_Cheat_Bar.Value = 0;


                if ((Oyuncu_Hp_Bar.Value == 100) && (Oyuncu_Mp_Bar.Value == 100) && (YapayZeka_Hp_Bar.Value == 1) && (YapayZeka_Mp_Bar.Value == 1) && Oyuncu_Cheat_Bar.Value == 0)
                {
                    Oyuncu_Hp_Bar.ForeColor = YapayZeka_Hp_Bar.ForeColor = Color.DarkRed;
                    Oyuncu_Mp_Bar.ForeColor = YapayZeka_Mp_Bar.ForeColor = Color.MidnightBlue;
                    Oyuncu_Hp_Yuzdelik.BackColor = YapayZeka_Hp_Yuzdelik.BackColor = Color.Red;
                    Oyuncu_Mp_Yuzdelik.BackColor = YapayZeka_Mp_Yuzdelik.BackColor = Color.RoyalBlue;
                    Buyu_Akisi_Timer.Enabled = true;
                    Hp_Mp_Timer.Enabled = true;
                    YapayZeka_Cheats_Timer.Enabled = true;
                    Oyuncu_is_Cheating = false;
                    Oyuncu_Cheat_Bar.ForeColor = Color.White;
                    Oyuncu_Cheat_Hazir_Mi = false;
                    Oyuncu_Cheat_Haber_PictureBox.ImageLocation = "Hurkanix Settings//Dolores_Umbridge_1.gif";
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
                if (Saniye <= 0 && Dakika <= 0)
                {
                    Saniye = 0;
                    Dakika = 0;
                }
                else
                {
                    if (Saniye >= 0)
                        Saniye--;
                    if (Saniye == -1)
                    {
                        Saniye = 59;
                        Dakika--;
                    }
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


        private void Oyuncu_Item_A_DoubleClick(object sender, EventArgs e)
        {
            if (End_Timer.Enabled == false && ItemShop_Aktif_Mi == true && Oyuncu_Pasif_Kalkan_Satin_Almis_Mi == false)
            {
                Oyuncu_A_CheckBox.Visible = true;
                Oyuncu_B_CheckBox.Visible = false;
                Oyuncu_C_CheckBox.Visible = false;
                Oyuncu_Pasif_Lanet_Satin_Almis_Mi = false;
                Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi = false;
                Oyuncu_Pasif_Kalkan_Satin_Almis_Mi = true;
            }
        }
        private void Oyuncu_Item_B_DoubleClick(object sender, EventArgs e)
        {
            if (End_Timer.Enabled == false && ItemShop_Aktif_Mi == true && Oyuncu_Pasif_Lanet_Satin_Almis_Mi == false)
            {
                Oyuncu_A_CheckBox.Visible = false;
                Oyuncu_B_CheckBox.Visible = true;
                Oyuncu_C_CheckBox.Visible = false;
                Oyuncu_Pasif_Kalkan_Satin_Almis_Mi = false;
                Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi = false;
                Oyuncu_Pasif_Lanet_Satin_Almis_Mi = true;

            }
        }
        private void Oyuncu_Item_C_DoubleClick(object sender, EventArgs e)
        {
            if (End_Timer.Enabled == false && ItemShop_Aktif_Mi == true && Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi == false)
            {
                Oyuncu_A_CheckBox.Visible = false;
                Oyuncu_B_CheckBox.Visible = false;
                Oyuncu_C_CheckBox.Visible = true;
                Oyuncu_Pasif_Kalkan_Satin_Almis_Mi = false;
                Oyuncu_Pasif_Lanet_Satin_Almis_Mi = false;
                Oyuncu_Pasif_HP_ve_MP_Degistirme_Satin_Almis_Mi = true;
            }
        }

        private void Oyuncu_Item_A_Aciklama_MouseEnter(object sender, EventArgs e)
        {
            if (End_Timer.Enabled == false)
            {
                Pasif_Yetenekler_Aciklama.Text = "[UPGRADED PASSIVE]\nRakibin bir sonraki saldirisindan oyuncunun hasar almasini engeller ve rakibin engellenmis hasarinin 5 katini rakibe geri yansitir. Bu yetenek oyuncunun aktif kalkani varken etkinlesemez !";
                Pasif_Yetenekler_Aciklama.Visible = true;
            }
        }

        private void Oyuncu_Item_B_Aciklama_MouseEnter(object sender, EventArgs e)
        {
            if (End_Timer.Enabled == false)
            {
                Pasif_Yetenekler_Aciklama.Text = "[UPGRADED PASSIVE]\nRakibe 5 saniye boyunca\netkin olacak bir lanet uygulayarak her saniye basina rakibin HP ve MP degerinin\n40'ar 40'ar azalmasini saglar.";
                Pasif_Yetenekler_Aciklama.Visible = true;
            }
        }

        private void Oyuncu_Item_C_Aciklama_MouseEnter(object sender, EventArgs e)
        {
            if (End_Timer.Enabled == false)
            {
                Pasif_Yetenekler_Aciklama.Text = "[UPGRADED PASSIVE]\nOyuncunun HP degeri 40'in altina duserse inanilmaz bir sekilde HP ve MP degerini yeniler ve bu esnada rakibin HP ve MP degerini inanilmaz bir sekilde azaltir !";
                Pasif_Yetenekler_Aciklama.Visible = true;
            }
        }

        private void YapayZeka_Item_A_Aciklama_MouseEnter(object sender, EventArgs e)
        {
            if (End_Timer.Enabled == false)
            {
                Pasif_Yetenekler_Aciklama.Text = "[UPGRADED PASSIVE]\nEger oyuncu olumcul bir darbe alirsa pasif skill kutusunu full olana kadar doldurur ve kendisini dirilterek HP ve MP degerini yeniler. Bu yetenek oyun boyunca her kritik durumda kullanilabilir !";
                Pasif_Yetenekler_Aciklama.Visible = true;
            }
        }

        private void YapayZeka_Item_B_Aciklama_MouseEnter(object sender, EventArgs e)
        {
            if (End_Timer.Enabled == false)
            {
                Pasif_Yetenekler_Aciklama.Text = "[UPGRADED PASSIVE]\nRakibin anlik HP ve MP degerini aniden %70 azaltan inanilmaz\nbir lanet uygular.";
                Pasif_Yetenekler_Aciklama.Visible = true;
            }
        }

        private void YapayZeka_Item_C_Aciklama_MouseEnter(object sender, EventArgs e)
        {
            if (End_Timer.Enabled == false)
            {
                Pasif_Yetenekler_Aciklama.Text = "[UPGRADED PASSIVE]\nOyuncunun bedelsiz olarak\nHP ve MP degerini\ninanilmaz bir sekilde yeniler.";
                Pasif_Yetenekler_Aciklama.Visible = true;
            }
        }

        private void Oyuncu_ve_YapayZeka_Item_ABC_Aciklama_MouseLeave(object sender, EventArgs e)
        {
            Pasif_Yetenekler_Aciklama.Visible = false;
        }

        private void Sleep_Effect_MouseEnter(object sender, EventArgs e)
        {
            Pasif_Yetenekler_Aciklama.Text = "[DEBUFF]\nLord Voldemort tarafindan uyku lanetine maruz kaldiniz !";
            Pasif_Yetenekler_Aciklama.Visible = true;
        }

        private void Sleep_Effect_MouseLeave(object sender, EventArgs e)
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
            Exit_Button.Enabled = false;
            Settings_Button.Enabled = false;
            End_Timer.Enabled = true;

            GameOver Settings = new GameOver();
            Settings.Oyun_Sonu_Raporu.Text = "Oyun Durduruldu";
            Settings.Play_Again_Button.Text = "R E S U M E";
            Settings.Show();
            GameMode3_Hide = false;
        }

        public static bool GameMode3_Hide = false;
        private void End_Timer_Yeri(object sender, EventArgs e)
        {
            //Ekrana Tiklanmasini Engeller
            Exit_Button.Enabled = false;
            Settings_Button.Enabled = false;

            if (GameMode3_Hide == true)
            {
                this.Dispose();
                End_Timer.Enabled = false;
            }
        }
    }
}
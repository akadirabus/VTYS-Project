using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LiseOkulYonetimi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=AKA\\SQLEXPRESS;Initial Catalog=odev;User ID=root;Password=root");


        // DUYURULAR
        private void DuyuruListele()
        {
            SqlCommand komut = new SqlCommand("SELECT * FROM Duyurular", baglanti);

            DataTable tablo = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter();
            adap.SelectCommand = komut;
            DataTable dt = new DataTable();

            adap.Fill(tablo);

            for (int i = 0; i < tablo.Rows.Count; i++)
            {
                listView1.Items.Add(tablo.Rows[i][1].ToString());
                listView1.Items[i].SubItems.Add(tablo.Rows[i][2].ToString());
                listView1.Items[i].SubItems.Add(tablo.Rows[i][3].ToString());
                listView1.Items[i].SubItems.Add(tablo.Rows[i][4].ToString());
            }
        }
        private void DuyuruAra(string yazi)
        {
            try
            {
                SqlCommand komut = new SqlCommand("SELECT * FROM Duyurular WHERE DuyuruBaslik LIKE @DuyuruBaslik OR DuyuruMetni LIKE @DuyuruMetni", baglanti);
                komut.Parameters.AddWithValue("@DuyuruBaslik", "%" + yazi + "%");
                komut.Parameters.AddWithValue("@DuyuruMetni", "%" + yazi + "%");

                DataTable tablo = new DataTable();
                SqlDataAdapter adap = new SqlDataAdapter(komut);
                adap.Fill(tablo);

                listView1.Items.Clear();

                for (int i = 0; i < tablo.Rows.Count; i++)
                {
                    listView1.Items.Add(tablo.Rows[i][1].ToString());
                    listView1.Items[i].SubItems.Add(tablo.Rows[i][2].ToString());
                    listView1.Items[i].SubItems.Add(tablo.Rows[i][3].ToString());
                    listView1.Items[i].SubItems.Add(tablo.Rows[i][4].ToString());
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("İşlem başarılı olamadı.");
                MessageBox.Show(ee.ToString());
            }
        }
        //
        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            DuyuruListele();

            list_Devamsizlik.Items.Clear();
            DevamsizlikListele();

            list_Belgeler.Items.Clear();
            BelgeleriListele();

            list_SinavTarihleri.Items.Clear();
            SinavTarihleriniListele();

            list_NotBilgisi.Items.Clear();
            NotBilgisiListele();

            list_DersProgrami.Items.Clear();
            DersProgramiListele();

            list_YilSonuBasariNotuHesaplama.Items.Clear();
            YilSonuListele();

            list_IslemListesi.Items.Clear();
            IslemListesiniListele();
        }
        private void btn_Duyurular_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
        }

        private void btn_DuyuruyuEkle_Click(object sender, EventArgs e)
        {
            if (btn_DuyuruyuEkle.Text != "Güncelle")
            {
                try
                {
                    SqlCommand komut = new SqlCommand("INSERT INTO Duyurular (DuyuruBaslik,DuyuruMetni,KacinciSiniflar,DuyuruTarih) VALUES (@DuyuruBaslik,@DuyuruMetni,@KacinciSiniflar,@DuyuruTarih)", baglanti);
                    komut.Parameters.AddWithValue("@DuyuruBaslik", txt_DuyuruBaslikEkle.Text);
                    komut.Parameters.AddWithValue("@DuyuruMetni", txt_DuyuruIcerikEkle.Text);
                    komut.Parameters.AddWithValue("@KacinciSiniflar", Convert.ToInt32(cmb_KacinciSiniflarDuyuru.Text));
                    komut.Parameters.AddWithValue("@DuyuruTarih", DateTime.Now);
                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Duyurunuz başarı ile eklendi!");

                    txt_DuyuruBaslikEkle.Clear();
                    txt_DuyuruIcerikEkle.Clear();
                    cmb_KacinciSiniflarDuyuru.Text = "";
                    listView1.Items.Clear();
                    DuyuruListele();
                }
                catch (Exception ee)
                {
                    MessageBox.Show("Kayıt Edilemedi :(");
                    MessageBox.Show(ee.ToString());
                }
            }
            else
            {
                try
                {
                    SqlCommand komut = new SqlCommand("UPDATE Duyurular SET DuyuruBaslik=@DuyuruBaslik, DuyuruMetni=@DuyuruMetni,KacinciSiniflar=@KacinciSiniflar,DuyuruTarih=@DuyuruTarih WHERE DuyuruBaslik=@DuyuruBaslik2", baglanti);
                    komut.Parameters.AddWithValue("@DuyuruBaslik", txt_DuyuruBaslikEkle.Text);
                    komut.Parameters.AddWithValue("@DuyuruMetni", txt_DuyuruIcerikEkle.Text);
                    komut.Parameters.AddWithValue("@KacinciSiniflar", Convert.ToInt32(cmb_KacinciSiniflarDuyuru.Text));
                    komut.Parameters.AddWithValue("@DuyuruTarih", DateTime.Now);
                    komut.Parameters.AddWithValue("@DuyuruBaslik2", listView1.SelectedItems[0].SubItems[0].Text.ToString());

                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    baglanti.Close();

                    MessageBox.Show("Tebrikler, güncellendi! :)");

                    listView1.Items.Clear();
                    DuyuruListele();

                    btn_DuyuruyuEkle.Text = "Duyuruyu Ekle";
                    txt_DuyuruBaslikEkle.Clear();
                    txt_DuyuruIcerikEkle.Clear();
                    cmb_KacinciSiniflarDuyuru.Text = "";
                }
                catch (Exception ee)
                {
                    MessageBox.Show("Kayıt Edilemedi :(");
                    MessageBox.Show(ee.ToString());
                }

            }

        }

        private void btn_DuyuruyuGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                txt_DuyuruBaslikEkle.Text = listView1.SelectedItems[0].SubItems[0].Text.ToString();
                txt_DuyuruIcerikEkle.Text = listView1.SelectedItems[0].SubItems[1].Text.ToString();
                cmb_KacinciSiniflarDuyuru.Text = listView1.SelectedItems[0].SubItems[2].Text.ToString();
                btn_DuyuruyuEkle.Text = "Güncelle";
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen listeden bir duyuru seçin.");
            }
        }

        private void btn_SecilenDuyuruyuSil_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("DELETE FROM Duyurular Where DuyuruBaslik=@DuyuruBaslik AND DuyuruMetni=@DuyuruMetni", baglanti);
                komut.Parameters.AddWithValue("@DuyuruBaslik", listView1.SelectedItems[0].SubItems[0].Text.ToString());
                komut.Parameters.AddWithValue("@DuyuruMetni", listView1.SelectedItems[0].SubItems[1].Text.ToString());

                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();

                listView1.Items.Clear();
                DuyuruListele();
            }
            catch (Exception ee)
            {
                MessageBox.Show("İşleminiz başarı ile sonuçlanmadı.");
                MessageBox.Show(ee.ToString());
            }
        }

        private void btn_DuyuruAra_Click(object sender, EventArgs e)
        {
            DuyuruAra(txt_DuyuruAra.Text);
        }







        //DEVAMSIZLIK
        private void DevamsizlikAra(string yazi)
        {
            try
            {
                SqlCommand komut = new SqlCommand("SELECT Ogrenci.OgrenciAd, Ogrenci.OgrenciSoyad, Ogrenci.OgrenciNo, Devamsizlik.DevamDurumu, Devamsizlik.DevamsizlikID FROM Ogrenci INNER JOIN Devamsizlik ON Ogrenci.OgrenciNo = Devamsizlik.OgrenciNo WHERE Ogrenci.OgrenciNo LIKE '%" + yazi + "%'", baglanti);
                DataTable tablo = new DataTable();
                SqlDataAdapter adap = new SqlDataAdapter(komut);
                adap.Fill(tablo);

                list_Devamsizlik.Items.Clear();

                for (int i = 0; i < tablo.Rows.Count; i++)
                {
                    list_Devamsizlik.Items.Add(tablo.Rows[i][0].ToString());
                    list_Devamsizlik.Items[i].SubItems.Add(tablo.Rows[i][1].ToString());
                    list_Devamsizlik.Items[i].SubItems.Add(tablo.Rows[i][2].ToString());
                    list_Devamsizlik.Items[i].SubItems.Add(tablo.Rows[i][3].ToString());
                    list_Devamsizlik.Items[i].SubItems.Add(tablo.Rows[i][4].ToString());
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("İşlem başarılı olamadı.");
                MessageBox.Show(ee.ToString());
            }
        }
        private void DevamsizlikListele()
        {
            SqlCommand komut = new SqlCommand("SELECT Ogrenci.OgrenciAd, Ogrenci.OgrenciSoyad, Ogrenci.OgrenciNo, Devamsizlik.DevamDurumu, Devamsizlik.DevamsizlikID FROM Ogrenci INNER JOIN Devamsizlik ON Ogrenci.OgrenciNo = Devamsizlik.OgrenciNo;", baglanti);

            DataTable tablo = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(komut);
            adap.Fill(tablo);

            for (int i = 0; i < tablo.Rows.Count; i++)
            {
                list_Devamsizlik.Items.Add(tablo.Rows[i][0].ToString());
                list_Devamsizlik.Items[i].SubItems.Add(tablo.Rows[i][1].ToString());
                list_Devamsizlik.Items[i].SubItems.Add(tablo.Rows[i][2].ToString());
                list_Devamsizlik.Items[i].SubItems.Add(tablo.Rows[i][3].ToString());
                list_Devamsizlik.Items[i].SubItems.Add(tablo.Rows[i][4].ToString());
            }
        }
        private void btn_DevamsizligiKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("INSERT INTO Devamsizlik (OgrenciNo,Gun,Ay,Yil,DevamDurumu) VALUES (@OgrenciNo," + Convert.ToInt32(num_Gun.Value) + "," + Convert.ToInt32(num_Ay.Value) + "," + Convert.ToInt32(num_Yil.Value) + ",'" + cmb_GelmeDurumu.Text + "')", baglanti);
                komut.Parameters.AddWithValue("@OgrenciNo", txt_Devamsizlik_OgrNo.Text);

                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Devamsızlık girdiniz başarı ile eklendi!");

                txt_Devamsizlik_OgrNo.Clear();
                num_Gun.Value = 1;
                num_Ay.Value = 1;
                num_Yil.Value = 2016;
                cmb_GelmeDurumu.Text = "";

                list_Devamsizlik.Items.Clear();
                DevamsizlikListele();
            }
            catch (Exception ee)
            {
                MessageBox.Show("İşleminiz başarısız olmuştur.");
                MessageBox.Show(ee.ToString());
            }
        }

        private void btn_DevamsizlikListele_Click(object sender, EventArgs e)
        {
            list_Devamsizlik.Items.Clear();
            DevamsizlikListele();
        }

        private void btn_DevamsizlikAra_Click(object sender, EventArgs e)
        {
            DevamsizlikAra(txt_DevamsizlikAra.Text);
            txt_DevamsizlikAra.Clear();
        }

        private void btn_Devamsizlik_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
        }

        private void btn_DevamsizlikSil_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("DELETE FROM Devamsizlik Where DevamsizlikID=@DevamsizlikID", baglanti);
                komut.Parameters.AddWithValue("@DevamsizlikID", list_Devamsizlik.SelectedItems[0].SubItems[4].Text.ToString());

                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();

                list_Devamsizlik.Items.Clear();
                DevamsizlikListele();
            }
            catch (Exception ee)
            {
                MessageBox.Show("İşleminiz başarı ile sonuçlanmadı.");
                MessageBox.Show(ee.ToString());
            }
        }








        //BELGELER

        private void BelgeleriListele()
        {
            try
            {
                SqlCommand komut = new SqlCommand("SELECT Ogrenci.OgrenciAd, Ogrenci.OgrenciSoyad, Ogrenci.OgrenciNo, Belgeler.BelgeTuru, Belgeler.DonemAraligi, Belgeler.BelgeID FROM Ogrenci INNER JOIN Belgeler ON Ogrenci.OgrenciNo = Belgeler.OgrenciNo", baglanti);
                DataTable tablo = new DataTable();
                SqlDataAdapter adap = new SqlDataAdapter(komut);
                adap.Fill(tablo);

                list_Belgeler.Items.Clear();

                for (int i = 0; i < tablo.Rows.Count; i++)
                {
                    list_Belgeler.Items.Add(tablo.Rows[i][0].ToString());
                    list_Belgeler.Items[i].SubItems.Add(tablo.Rows[i][1].ToString());
                    list_Belgeler.Items[i].SubItems.Add(tablo.Rows[i][2].ToString());
                    list_Belgeler.Items[i].SubItems.Add(tablo.Rows[i][3].ToString());
                    list_Belgeler.Items[i].SubItems.Add(tablo.Rows[i][4].ToString());
                    list_Belgeler.Items[i].SubItems.Add(tablo.Rows[i][5].ToString());
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("İşlem başarılı olamadı.");
                MessageBox.Show(ee.ToString());
            }
        }
        private void btn_BelgeyiKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("INSERT INTO Belgeler (OgrenciNo,BelgeTuru,DonemAraligi) VALUES (@OgrenciNo,@BelgeTuru,@DonemAraligi)", baglanti);
                komut.Parameters.AddWithValue("@OgrenciNo", txt_BelgelerOgrNo.Text);
                komut.Parameters.AddWithValue("@BelgeTuru", cmb_BelgeTuru.Text);
                komut.Parameters.AddWithValue("@DonemAraligi", cmb_BelgelerDonemAraligi.Text);

                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Belge girdiniz başarı ile eklendi!");

                txt_BelgelerOgrNo.Clear();
                cmb_BelgeTuru.Text = "";
                cmb_BelgelerDonemAraligi.Text = "";

                list_Belgeler.Items.Clear();
                BelgeleriListele();
            }
            catch (Exception ee)
            {
                MessageBox.Show("İşleminiz başarısız olmuştur.");
                MessageBox.Show(ee.ToString());
            }
        }

        private void btn_BelgeleriListele_Click(object sender, EventArgs e)
        {
            BelgeleriListele();
        }

        private void btn_SecilenBelgeyiSil_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("DELETE FROM Belgeler Where BelgeID=@BelgeID", baglanti);
                komut.Parameters.AddWithValue("@BelgeID", list_Belgeler.SelectedItems[0].SubItems[5].Text.ToString());

                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();

                list_Belgeler.Items.Clear();
                BelgeleriListele();
            }
            catch (Exception ee)
            {
                MessageBox.Show("İşleminiz başarı ile sonuçlanmadı.");
                MessageBox.Show(ee.ToString());
            }
        }

        private void btn_BelgeyiAra_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("SELECT Ogrenci.OgrenciAd, Ogrenci.OgrenciSoyad, Ogrenci.OgrenciNo, Belgeler.BelgeTuru, Belgeler.DonemAraligi, Belgeler.BelgeID FROM Ogrenci INNER JOIN Belgeler ON Ogrenci.OgrenciNo = Belgeler.OgrenciNo WHERE BelgeTuru LIKE '%" + txt_BelgeAra.Text + "%'", baglanti);
                DataTable tablo = new DataTable();
                SqlDataAdapter adap = new SqlDataAdapter(komut);
                adap.Fill(tablo);

                list_Belgeler.Items.Clear();

                for (int i = 0; i < tablo.Rows.Count; i++)
                {
                    list_Belgeler.Items.Add(tablo.Rows[i][0].ToString());
                    list_Belgeler.Items[i].SubItems.Add(tablo.Rows[i][1].ToString());
                    list_Belgeler.Items[i].SubItems.Add(tablo.Rows[i][2].ToString());
                    list_Belgeler.Items[i].SubItems.Add(tablo.Rows[i][3].ToString());
                    list_Belgeler.Items[i].SubItems.Add(tablo.Rows[i][4].ToString());
                    list_Belgeler.Items[i].SubItems.Add(tablo.Rows[i][5].ToString());
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("İşlem başarılı olamadı.");
                MessageBox.Show(ee.ToString());
            }
        }




        //SINAV TARİHLERİ

        private void SinavTarihleriniListele()
        {
            SqlCommand komut = new SqlCommand("SELECT Dersler.DersAdi, Sinif.SinifAdi, SinavTarihleri.SinavTarihi, SinavTarihleri.SinavTarihiID FROM Dersler,SinavTarihleri,Sinif WHERE Dersler.DersID=SinavTarihleri.DersID AND SinavTarihleri.SinifID=Sinif.SinifID", baglanti);

            DataTable tablo = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(komut);
            adap.Fill(tablo);

            for (int i = 0; i < tablo.Rows.Count; i++)
            {
                list_SinavTarihleri.Items.Add(tablo.Rows[i][0].ToString());
                list_SinavTarihleri.Items[i].SubItems.Add(tablo.Rows[i][1].ToString());
                list_SinavTarihleri.Items[i].SubItems.Add(tablo.Rows[i][2].ToString());
                list_SinavTarihleri.Items[i].SubItems.Add(tablo.Rows[i][3].ToString());
            }
        }
        private void btn_SinavTarihiniKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("INSERT INTO SinavTarihleri (SinifID,DersID,SinavTarihi) VALUES ((SELECT SinifID FROM Sinif WHERE SinifAdi=@SinifAdi),(SELECT DersID FROM Dersler WHERE DersAdi=@DersAdi),@SinavTarihi)", baglanti);
                komut.Parameters.AddWithValue("@SinifAdi", cmb_SinavSinifAdi.Text);
                komut.Parameters.AddWithValue("@DersAdi", cmb_SinavDersAdi.Text);
                komut.Parameters.AddWithValue("@SinavTarihi", txt_SinavSaati.Text);

                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Sınav Tarihi girdiniz başarı ile eklendi!");

                txt_SinavSaati.Clear();
                cmb_SinavSinifAdi.Text = "";
                cmb_SinavDersAdi.Text = "";

                list_SinavTarihleri.Items.Clear();
                SinavTarihleriniListele();
            }
            catch (Exception ee)
            {
                MessageBox.Show("İşleminiz başarısız olmuştur.");
                MessageBox.Show(ee.ToString());
            }
        }

        private void btn_SinavTarihleriniListele_Click(object sender, EventArgs e)
        {
            list_SinavTarihleri.Items.Clear();
            SinavTarihleriniListele();
        }

        private void btn_SinavTarihiAra_Click(object sender, EventArgs e)
        {
            list_SinavTarihleri.Items.Clear();
            SqlCommand komut = new SqlCommand("SELECT Dersler.DersAdi, Sinif.SinifAdi, SinavTarihleri.SinavTarihi, SinavTarihleri.SinavTarihiID FROM Dersler,SinavTarihleri,Sinif WHERE Dersler.DersID=SinavTarihleri.DersID AND SinavTarihleri.SinifID=Sinif.SinifID AND DersAdi LIKE '%" + txt_SinavTarihiAra.Text + "%'", baglanti);

            DataTable tablo = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(komut);
            adap.Fill(tablo);

            for (int i = 0; i < tablo.Rows.Count; i++)
            {
                list_SinavTarihleri.Items.Add(tablo.Rows[i][0].ToString());
                list_SinavTarihleri.Items[i].SubItems.Add(tablo.Rows[i][1].ToString());
                list_SinavTarihleri.Items[i].SubItems.Add(tablo.Rows[i][2].ToString());
                list_SinavTarihleri.Items[i].SubItems.Add(tablo.Rows[i][3].ToString());
            }
        }

        private void SecilenTarihiSil_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("DELETE FROM SinavTarihleri Where SinavTarihiID=@SinavTarihiID", baglanti);
                komut.Parameters.AddWithValue("@SinavTarihiID", list_SinavTarihleri.SelectedItems[0].SubItems[3].Text.ToString());

                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();

                list_SinavTarihleri.Items.Clear();
                SinavTarihleriniListele();
            }
            catch (Exception ee)
            {
                MessageBox.Show("İşleminiz başarı ile sonuçlanmadı.");
                MessageBox.Show(ee.ToString());
            }
        }





        // NOT BİLGİSİ

        private void btn_NotBilgisiKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("INSERT INTO NotBilgisi (DersID,OgrenciNo,SinavNumarasi,Notu) VALUES ((SELECT DersID FROM Dersler WHERE DersAdi=@DersAdi),@OgrenciNo,@SinavNumarasi,@Notu)", baglanti);
                komut.Parameters.AddWithValue("@DersAdi", cmb_NotDersAdi.Text);
                komut.Parameters.AddWithValue("@OgrenciNo", Convert.ToInt32(txt_NotBilgisiOgrNo.Text));
                komut.Parameters.AddWithValue("@SinavNumarasi", Convert.ToInt32(txt_NotBilgisiKacinciSinav.Text));
                komut.Parameters.AddWithValue("@Notu", Convert.ToInt32(txt_Notu.Text));

                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Not bilgisi girdiniz başarı ile eklendi!");

                txt_NotBilgisiOgrNo.Clear();
                txt_NotBilgisiKacinciSinav.Clear();
                txt_Notu.Clear();
                cmb_NotDersAdi.Text = "";

                list_NotBilgisi.Items.Clear();
                NotBilgisiListele();
            }
            catch (Exception ee)
            {
                MessageBox.Show("İşleminiz başarısız olmuştur.");
                MessageBox.Show(ee.ToString());
            }

            list_IslemListesi.Items.Clear();
            IslemListesiniListele();
        }

        private void NotBilgisiListele()
        {
            SqlCommand komut = new SqlCommand("SELECT Dersler.DersAdi, Ogrenci.OgrenciAd, Ogrenci.OgrenciSoyad, Ogrenci.OgrenciNo, NotBilgisi.SinavNumarasi, NotBilgisi.Notu,Notbilgisi.NotID FROM NotBilgisi,Ogrenci,Dersler WHERE NotBilgisi.OgrenciNo=Ogrenci.OgrenciNo AND NotBilgisi.DersID=Dersler.DersID", baglanti);

            DataTable tablo = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(komut);
            adap.Fill(tablo);

            for (int i = 0; i < tablo.Rows.Count; i++)
            {
                list_NotBilgisi.Items.Add(tablo.Rows[i][0].ToString());
                list_NotBilgisi.Items[i].SubItems.Add(tablo.Rows[i][1].ToString());
                list_NotBilgisi.Items[i].SubItems.Add(tablo.Rows[i][2].ToString());
                list_NotBilgisi.Items[i].SubItems.Add(tablo.Rows[i][3].ToString());
                list_NotBilgisi.Items[i].SubItems.Add(tablo.Rows[i][4].ToString());
                list_NotBilgisi.Items[i].SubItems.Add(tablo.Rows[i][5].ToString());
                list_NotBilgisi.Items[i].SubItems.Add(tablo.Rows[i][6].ToString());
            }
        }

        private void btn_NotBilgisi_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(2);
        }

        private void btn_NotBilgisiTumunuListele_Click(object sender, EventArgs e)
        {
            list_NotBilgisi.Items.Clear();
            NotBilgisiListele();
        }

        private void btn_NotBilgisiAra_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("SELECT Dersler.DersAdi, Ogrenci.OgrenciAd, Ogrenci.OgrenciSoyad, Ogrenci.OgrenciNo, NotBilgisi.SinavNumarasi, NotBilgisi.Notu,Notbilgisi.NotID FROM NotBilgisi,Ogrenci,Dersler WHERE NotBilgisi.OgrenciNo=Ogrenci.OgrenciNo AND NotBilgisi.DersID=Dersler.DersID AND Dersler.DersAdi LIKE '%" + txt_NotBilgisiAra.Text + "%'", baglanti);

            DataTable tablo = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(komut);
            adap.Fill(tablo);

            list_NotBilgisi.Items.Clear();

            for (int i = 0; i < tablo.Rows.Count; i++)
            {
                list_NotBilgisi.Items.Add(tablo.Rows[i][0].ToString());
                list_NotBilgisi.Items[i].SubItems.Add(tablo.Rows[i][1].ToString());
                list_NotBilgisi.Items[i].SubItems.Add(tablo.Rows[i][2].ToString());
                list_NotBilgisi.Items[i].SubItems.Add(tablo.Rows[i][3].ToString());
                list_NotBilgisi.Items[i].SubItems.Add(tablo.Rows[i][4].ToString());
                list_NotBilgisi.Items[i].SubItems.Add(tablo.Rows[i][5].ToString());
                list_NotBilgisi.Items[i].SubItems.Add(tablo.Rows[i][6].ToString());
            }
        }

        private void btn_SecilenNotBilgisiniSil_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("DELETE FROM NotBilgisi Where NotID=@NotID", baglanti);
                komut.Parameters.AddWithValue("@NotID", list_NotBilgisi.SelectedItems[0].SubItems[6].Text.ToString());

                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();

                list_NotBilgisi.Items.Clear();
                NotBilgisiListele();
            }
            catch (Exception ee)
            {
                MessageBox.Show("İşleminiz başarı ile sonuçlanmadı.");
                MessageBox.Show(ee.ToString());
            }

            list_IslemListesi.Items.Clear();
            IslemListesiniListele();
        }







        //DERS PROGRAMI



        private void DersProgramiListele()
        {
            SqlCommand komut = new SqlCommand("SELECT Dersler.DersAdi, Sinif.SinifAdi, DersProgrami.DersGun, DersProgrami.DersSaat, DersProgrami.ProgramID FROM Dersler,Sinif,DersProgrami WHERE Dersler.DersID=DersProgrami.DersID AND Sinif.SinifID=DersProgrami.HangiSinif", baglanti);

            DataTable tablo = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(komut);
            adap.Fill(tablo);

            list_DersProgrami.Items.Clear();

            for (int i = 0; i < tablo.Rows.Count; i++)
            {
                list_DersProgrami.Items.Add(tablo.Rows[i][0].ToString());
                list_DersProgrami.Items[i].SubItems.Add(tablo.Rows[i][1].ToString());
                list_DersProgrami.Items[i].SubItems.Add(tablo.Rows[i][2].ToString());
                list_DersProgrami.Items[i].SubItems.Add(tablo.Rows[i][3].ToString());
                list_DersProgrami.Items[i].SubItems.Add(tablo.Rows[i][4].ToString());
            }
        }
        private void btn_ProgramKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("INSERT INTO DersProgrami (DersID,DersGun,DersSaat,HangiSinif) VALUES ((SELECT DersID FROM Dersler WHERE DersAdi=@DersAdi),@DersGun,@DersSaat,(SELECT SinifID FROM Sinif WHERE SinifAdi=@SinifAdi))", baglanti);
                komut.Parameters.AddWithValue("@DersAdi", cmb_ProgramDersAdi.Text);
                komut.Parameters.AddWithValue("@DersGun", txt_ProgramDersGunu.Text);
                komut.Parameters.AddWithValue("@DersSaat", txt_ProgramDersSaati.Text);
                komut.Parameters.AddWithValue("@SinifAdi", cmb_ProgramSinifAdi.Text);

                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Not bilgisi girdiniz başarı ile eklendi!");

                txt_ProgramDersGunu.Clear();
                txt_ProgramDersSaati.Clear();
                cmb_ProgramSinifAdi.Text = "";
                cmb_ProgramDersAdi.Text = "";

                list_DersProgrami.Items.Clear();
                DersProgramiListele();
            }
            catch (Exception ee)
            {
                MessageBox.Show("İşleminiz başarısız olmuştur.");
                MessageBox.Show(ee.ToString());
            }
        }

        private void btn_ProgramAra_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("SELECT Dersler.DersAdi, Sinif.SinifAdi, DersProgrami.DersGun, DersProgrami.DersSaat, DersProgrami.ProgramID FROM Dersler,Sinif,DersProgrami WHERE Dersler.DersID=DersProgrami.DersID AND Sinif.SinifID=DersProgrami.HangiSinif AND Dersler.DersAdi LIKE '%" + txt_ProgramAra.Text+"%'", baglanti);

            DataTable tablo = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(komut);
            adap.Fill(tablo);

            list_DersProgrami.Items.Clear();

            for (int i = 0; i < tablo.Rows.Count; i++)
            {
                list_DersProgrami.Items.Add(tablo.Rows[i][0].ToString());
                list_DersProgrami.Items[i].SubItems.Add(tablo.Rows[i][1].ToString());
                list_DersProgrami.Items[i].SubItems.Add(tablo.Rows[i][2].ToString());
                list_DersProgrami.Items[i].SubItems.Add(tablo.Rows[i][3].ToString());
                list_DersProgrami.Items[i].SubItems.Add(tablo.Rows[i][4].ToString());
            }
        }

        private void btn_ProgramListele_Click(object sender, EventArgs e)
        {
            list_DersProgrami.Items.Clear();
            DersProgramiListele();
        }

        private void btn_ProgramSil_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("DELETE FROM DersProgrami Where ProgramID=@ProgramID", baglanti);
                komut.Parameters.AddWithValue("@ProgramID", list_DersProgrami.SelectedItems[0].SubItems[4].Text.ToString());

                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();

                list_DersProgrami.Items.Clear();
                DersProgramiListele();
            }
            catch (Exception ee)
            {
                MessageBox.Show("İşleminiz başarı ile sonuçlanmadı.");
                MessageBox.Show(ee.ToString());
            }
        }




        //YIL SONU
        private void YilSonuListele()
        {
            SqlCommand komut = new SqlCommand("SELECT * FROM YilSonuNotlari", baglanti);

            DataTable tablo = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(komut);
            adap.Fill(tablo);

            for (int i = 0; i < tablo.Rows.Count; i++)
            {
                list_YilSonuBasariNotuHesaplama.Items.Add(tablo.Rows[i][0].ToString());
                list_YilSonuBasariNotuHesaplama.Items[i].SubItems.Add(tablo.Rows[i][1].ToString());
                list_YilSonuBasariNotuHesaplama.Items[i].SubItems.Add(tablo.Rows[i][2].ToString());
                list_YilSonuBasariNotuHesaplama.Items[i].SubItems.Add(tablo.Rows[i][3].ToString());
                list_YilSonuBasariNotuHesaplama.Items[i].SubItems.Add(tablo.Rows[i][4].ToString());
            }
        }
        private void btn_YilSonuKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                string komut = "DECLARE @NotOrtalamasi int SET @NotOrtalamasi = (SELECT dbo.YilSonuBasariNotuEkle((SELECT Notu FROM NotBilgisi WHERE OgrenciNo = " + Convert.ToInt32(txt_YilSonuOgrNo.Text) + " AND SinavNumarasi = 1 AND DersID = (SELECT DersID FROM Dersler WHERE DersAdi = '" + cmb_YilSonuDersAdi.Text + "')),";
                komut += "(SELECT Notu FROM NotBilgisi WHERE OgrenciNo = " + Convert.ToInt32(txt_YilSonuOgrNo.Text) + " AND SinavNumarasi = 2 AND DersID = (SELECT DersID FROM Dersler WHERE DersAdi = '" + cmb_YilSonuDersAdi.Text + "')),";
                komut += "(SELECT Notu FROM NotBilgisi WHERE OgrenciNo = " + Convert.ToInt32(txt_YilSonuOgrNo.Text) + " AND SinavNumarasi = 3 AND DersID = (SELECT DersID FROM Dersler WHERE DersAdi = '" + cmb_YilSonuDersAdi.Text + "')),";
                komut += "(SELECT Notu FROM NotBilgisi WHERE OgrenciNo = " + Convert.ToInt32(txt_YilSonuOgrNo.Text) + " AND SinavNumarasi = 4 AND DersID = (SELECT DersID FROM Dersler WHERE DersAdi = '" + cmb_YilSonuDersAdi.Text + "')))); EXEC YilSonuBasariNotuKayitEkle " + Convert.ToInt32(txt_YilSonuOgrNo.Text) + ",@NotOrtalamasi,'" + cmb_YilSonuOgretimYili.Text + "','" + cmb_YilSonuDersAdi.Text + "';";
                SqlCommand ekle = new SqlCommand(komut, baglanti);

                baglanti.Open();
                ekle.ExecuteNonQuery();
                baglanti.Close();

                list_YilSonuBasariNotuHesaplama.Items.Clear();
                YilSonuListele();
            }
            catch (Exception ee)
            {
                MessageBox.Show("Başarısız oldu.");
                MessageBox.Show(ee.ToString());
            }
            
        }

        private void btn_YilSonuListele_Click(object sender, EventArgs e)
        {
            list_YilSonuBasariNotuHesaplama.Items.Clear();
            YilSonuListele();
        }

        private void btn_YilSonuSil_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("DELETE FROM YilSonuNotlari Where YilSonuID=@YilSonuID", baglanti);
                komut.Parameters.AddWithValue("@YilSonuID", list_YilSonuBasariNotuHesaplama.SelectedItems[0].SubItems[0].Text.ToString());

                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();

                list_YilSonuBasariNotuHesaplama.Items.Clear();
                YilSonuListele();
            }
            catch (Exception ee)
            {
                MessageBox.Show("İşleminiz başarı ile sonuçlanmadı.");
                MessageBox.Show(ee.ToString());
            }
        }

        private void btn_DersProgrami_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(3);
        }

        private void btn_SinavTarihleri_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(4);
        }

        private void btn_AldigiBelgeler_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(5);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(6);
        }

        private void IslemListesiniListele()
        {
            SqlCommand komut = new SqlCommand("SELECT * FROM IslemListesi", baglanti);

            DataTable tablo = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(komut);
            adap.Fill(tablo);

            for (int i = 0; i < tablo.Rows.Count; i++)
            {
                list_IslemListesi.Items.Add(tablo.Rows[i][0].ToString());
            }
        }

        private void btn_IslemListesi_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(7);
        }
    }
}
//triggerlar ve işlem listesi
/*******************************************************************************************************************
**					SAKARYA ÜNÝVERSÝTESÝ
**				BÝLGÝSAYAR VE BÝLÝÞÝM BÝLÝMLERÝ FAKÜLTESÝ
**				    BÝLGÝSAYAR MÜHENDÝSLÝÐÝ BÖLÜMÜ
**				   NESNEYE DAYALI PROGRAMLAMA DERSÝ
**					2024-2025 BAHAR DÖNEMÝ
**	
**				ÖDEV NUMARASI..........: 2
**				ÖÐRENCÝ ADI............: Yaren Naz KAHYAOÐLU
**				ÖÐRENCÝ NUMARASI.......: B241210094
**              DERSÝN ALINDIÐI GRUP...: 1.Öðretim C grubu
******************************************************************************************************************/
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KelimeEzber
{
    public partial class Main : Form
    {
        // Sözlükleri saklamak için
        private Dictionary<string, string> sozluk = new Dictionary<string, string>();
        public Main()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Uygulamanýn çalýþtýðý klasörün yerini bulur
            string klasor = Application.StartupPath;  // çalýþtýðýn klasör
            string[] dosyalar = Directory.GetFiles(klasor, "*.txt"); // Dosyadaki tüm .txt dosyalarý bulur
            if (dosyalar.Length > 0)
            {
                foreach (string dosya in dosyalar)
                {
                    comboBoxSozluk.Items.Add(Path.GetFileNameWithoutExtension(dosya)); // ComboBoxa dosya ismini ekle uzantýyý kaldýrarak
                }
            }
            else
            {
                MessageBox.Show("Hiçbir .txt dosyasý bulunamadý!"); // Bulunamadýysa uyarý ver
            }

            buttonBaslat.Enabled = false; // Baþlat butonunu pasif yapýyoruz yüklemeden önce
        }



        private void buttonBaslat_Click(object sender, EventArgs e)
        {
            if (sozluk.Count > 0) // Sözlük boþ deðilse
            {
                SoruForm soruForm = new SoruForm(sozluk); // SoruForm formunu oluþtur ve mevcut sözlüðü gönder
                soruForm.Show();
            }
            else
            {
                MessageBox.Show("Önce sözlük yükleyin."); // Seçilmediyse uyarý verir
            }
        }

        private void buttonYukle_Click(object sender, EventArgs e)
        {
            if (comboBoxSozluk.SelectedItem == null) // Eðer kullanýcý bir sözlük seçmediyse uyarý ver
            {
                MessageBox.Show("Lütfen bir sözlük seçiniz.");
                return;
            }

            sozluk.Clear(); //Eskiyi sil
            string secilenDosyaAdi = Path.Combine(Application.StartupPath, comboBoxSozluk.SelectedItem.ToString() + ".txt");
            

            try
            {
                // Dosyadaki tüm satýýr oku
                string[] satirlar = File.ReadAllLines(secilenDosyaAdi);

                foreach (string satir in satirlar)
                {
                    string[] parcalar = satir.Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    // Kelime ve anlamýný ayýrýyoruz tabla

                    // Eðer satýrda hem kelime hem anlam varsa
                    if (parcalar.Length >= 2)
                    {
                        string kelime = parcalar[0].Trim(); // Ýlk parça: kelime
                        string anlam = parcalar[1].Trim(); // Ýkinci parça: anlam
                        sozluk[kelime] = anlam; // Sözlüðe ekle
                    }
                    else
                    {
                        // Satýr hatalýysa kullanýcýya bildir ve iþlemi iptal et
                        MessageBox.Show("Sözlük dosyasýndaki satýrlarda bir hata var. Her satýrda kelime ve anlamý olmalý.");
                        sozluk.Clear();
                        return;
                    }
                }

                if (sozluk.Count > 0)
                {
                    // Eðer sözlük baþarýyla dolduysa
                    MessageBox.Show("Sözlük baþarýyla yüklendi.");
                    buttonBaslat.Enabled = true;  // Baþlat butonunu aktif et
                }
                else
                {
                    // Eðer sözlük boþsa uyarý ver
                    MessageBox.Show("Sözlük yüklenemedi.");
                }
            }
            catch (Exception ex)
            {
               // Hata varsa hata mesajý ver
                MessageBox.Show($"Bir hata oluþtu: {ex.Message}");
                sozluk.Clear();
                buttonBaslat.Enabled = false;
            }
    }

        private void buttonCýkýs_Click(object sender, EventArgs e)
        {
            // Çýkýþ yap
            Application.Exit();
        }
    }
}

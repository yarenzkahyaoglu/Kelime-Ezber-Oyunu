using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Formats.Asn1.AsnWriter;

namespace KelimeEzber
{
    public partial class SoruForm : Form
    {
        private Dictionary<string, string> sozluk; // Kelime ve anlam sözlüğü
        private List<string> kelimeler; // Sıralanmış kelime listesi
        private Random random; // Rastgele sayı üretici
        private int soruIndex; // Hangi sorudayız
        private int skor; // Kullanıcının puanı
        private bool verilenCevap; // Cevap verildi mi
        private int denemeSayisi; // Deneme sayısı
        private List<SoruSonucu> raporListesi; // Soru sonuçlarını raporlama listesi

        // Rapor içi bir soru ve sonucunu tutacak sınıf
        private class SoruSonucu
        {
            public string SorulanKelime { get; set; }
            public string DogruCevap { get; set; }
            public string VerilenCevap { get; set; }
            public bool DogruMu { get; set; }
            public int AlinanPuan { get; set; }
        }
        public SoruForm(Dictionary<string, string> sozluk)
        {
            InitializeComponent();
            this.sozluk = sozluk;
            random = new Random();
            kelimeler = sozluk.Keys.OrderBy(x => random.Next()).ToList(); // Kelimeleri random bir şekilde sıraladık
  
            soruIndex = -1;
            skor = 0;
            verilenCevap = false;
            raporListesi = new List<SoruSonucu>();
            denemeSayisi = 1;
        }

        private void SoruForm_Load(object sender, EventArgs e)
        {
            SonrakiSoruYukle(); //Soruyu yükle
        }
        private void SonrakiSoruYukle()
        {
            denemeSayisi = 0;
            if (soruIndex >= kelimeler.Count - 1) // Eğer tüm sorular sorulduysa quiz bitir
            {
                // Oyun bittikten sonra hangisi doğru hangisi yanlış görmemiz için rapor değerlerini yazırma
                StringBuilder rapor = new StringBuilder();
                rapor.AppendLine("Doğru Bilinenler:");
                foreach (var item in raporListesi.Where(r => r.DogruMu))
                {
                    rapor.AppendLine($"{item.SorulanKelime} - {item.DogruCevap} ({item.AlinanPuan} puan)");
                }

                rapor.AppendLine("\nYanlış Bilinenler:");
                foreach (var item in raporListesi.Where(r => !r.DogruMu))
                {
                    rapor.AppendLine($"{item.SorulanKelime} - {item.DogruCevap} ({item.AlinanPuan} puan)");
                }

                MessageBox.Show($"Quiz Bitti! Toplam Puan: {skor}");
                this.Close();
                return;
            }
            soruIndex++; // Yeni soruya geç
            string sorulanKelime = kelimeler[soruIndex]; // Sorulacak kelimeyi al
            string kelimeninCevabi = sozluk[sorulanKelime]; // Kelimenin doğru cevabını al
            labelKelime.Text = sorulanKelime;

            // Cevap seçeneklerini rastgele oluştur
            List<string> secenekler = new List<string> { kelimeninCevabi };
            while (secenekler.Count < 4)  // 4 seçenek oluştur (biri doğru, diğerleri yanlış)
            {
                string rastgeleCevap = sozluk[kelimeler[random.Next(kelimeler.Count)]];
                if (!secenekler.Contains(rastgeleCevap)) // Rastegele cevap daha önce seçilmediyse ekle
                    secenekler.Add(rastgeleCevap);
            }

            // Seçenekleri karıştır
            secenekler = secenekler.OrderBy(x => random.Next()).ToList();

            // Buttonlara cevapları yerleştir
            buttonSecenek1.Text = secenekler[0];
            buttonSecenek2.Text = secenekler[1];
            buttonSecenek3.Text = secenekler[2];
            buttonSecenek4.Text = secenekler[3];

            // Puan ve ilerlemeyi ekranda göster
            labelSkor.Text = "Puan: " + skor;
            labelSoru.Text = $"Soru: {soruIndex + 1}/{kelimeler.Count}";

            // Yanlış cevap durumunu sıfırlıyoruz
            foreach (var button in new[] { buttonSecenek1, buttonSecenek2, buttonSecenek3, buttonSecenek4 })
            {
                button.BackColor = SystemColors.Control;
            }

            verilenCevap = false; // Yeni sorunun cevaplandırılmadığını gösteriyor
        }
        private void SecenekButton_Click(object sender, EventArgs e)
        {
            if (verilenCevap)
                return; // Eğer cevap verildiyse ikinci kez basmaya izin verme.

            Button tiklananButton = sender as Button; // Hangi butona tıklandığını bul
            string secilenCevap = tiklananButton.Text; // Tıklanan butonun cevabını al
            string sorulanKelime = kelimeler[soruIndex]; // O anki sorulan kelimeyi al
            string dogruCevap = sozluk[sorulanKelime]; // Doğru cevabı al
            int puan = 0; // Sorudan alınacak puanı başta sıfırla
            bool dogruMu = false; // Başta doğru sayma

            if (secilenCevap == dogruCevap)
            {
                if (denemeSayisi == 0)
                    skor += 10; // İlk denemede doğruysa 10 puan
                else if (denemeSayisi == 1)
                    skor += 5; // İkinci denemede doğruysa 5 puan
                else
                    skor += 0; // Üçüncü veya daha fazla denemede doğruysa 0 puan

                skor += puan; // Toplam skora ekle
                tiklananButton.BackColor = Color.Green;
                verilenCevap = true;
                dogruMu = true;
                labelSkor.Text = "Puan: " + skor; // Skoru güncelle
                raporListesi.Add(new SoruSonucu // Raporla
                {
                    SorulanKelime = sorulanKelime,
                    DogruCevap = dogruCevap,
                    VerilenCevap = secilenCevap,
                    AlinanPuan = puan,
                    DogruMu = true
                });

                labelSkor.Text = "Puan: " + skor;

                Task.Delay(500).ContinueWith(_ => // 500ms bekledikten sonra yeni soruyu getir
                {
                    this.Invoke(new Action(() =>
                    {
                        SonrakiSoruYukle();
                    }));
                });
            }
            else
            {
                denemeSayisi++; // Yanlış cevap verdiysem
                tiklananButton.BackColor = Color.Red; // Kırmızı dön

                // Yanlış ise ama 3. deneme değilse kaydetme
                if (denemeSayisi >= 3)
                {
                    // 3 kez yanlış yapıldıysa rapora yanlış olarak ekle
                    raporListesi.Add(new SoruSonucu
                    {
                        SorulanKelime = sorulanKelime,
                        DogruCevap = dogruCevap,
                        VerilenCevap = secilenCevap,
                        AlinanPuan = 0,
                        DogruMu = false
                    });

                    verilenCevap = true;

                    ShowCorrectAnswer(); // Doğru cevabı göster

                    Task.Delay(1000).ContinueWith(_ => // 1sn bekle ve yeni soruyu getir
                    {
                        this.Invoke(new Action(() =>
                        {
                            SonrakiSoruYukle();
                        }));
                    });
                }
            }
        }

        // Doğru cevabı göstermek için
        private void ShowCorrectAnswer()
        {
            string dogruCevap = sozluk[kelimeler[soruIndex]];

            // Butonlardan doğru cevabı bul ve yeşil yap
            foreach (var button in new[] { buttonSecenek1, buttonSecenek2, buttonSecenek3, buttonSecenek4 })
            {
                if (button.Text == dogruCevap)
                {
                    button.BackColor = Color.Green; // Doğru cevabı bulunca döngüyü bitir
                    break;
                }
            }
        }

        private void buttonQuizBitir_Click(object sender, EventArgs e) //Bitir butonuna basınca oyun raporunun çıkması için
        {
            StringBuilder rapor = new StringBuilder();
            rapor.AppendLine("İlk Üç Seferde Doğru Bilinenler:");
            foreach (var item in raporListesi.Where(r => r.DogruMu))
            {
                rapor.AppendLine($"{item.SorulanKelime} - {item.DogruCevap}");
            }

            rapor.AppendLine("\nYanlış Bilinenler:");
            foreach (var item in raporListesi.Where(r => !r.DogruMu))
            {
                rapor.AppendLine($"{item.SorulanKelime} - {item.DogruCevap}");
            }

            // Son olarak toplam puanı göstermek
            MessageBox.Show(rapor.ToString(), $"Quiz Bitti! Toplam Puan: {skor}");

            // Formu kapat
            this.Close();
        }
    }
}

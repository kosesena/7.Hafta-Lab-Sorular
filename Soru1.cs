/*
1. Bir şirketin çalışanlarını yöneten bir program yazmanız isteniyor. Temel bir Calisan sınıfı oluşturun ve bu sınıftan türeyen Yazilimci ve Muhasebeci sınıflarını tanımlayın.
Her çalışan, ad, soyad, maaş ve pozisyon bilgilerine sahiptir. Yazilimci sınıfında yazılım dili bilgisi, Muhasebeci sınıfında ise kullandığı muhasebe yazılımı bilgisi bulunsun.

Aşağıdaki işlemleri gerçekleştirin:
 Calisan sınıfında bir BilgiYazdir() metodu oluşturun. Bu metodun çıktısı, her türetilmiş sınıf için farklı şekilde çalışmalı.
 Yazilimci ve Muhasebeci sınıflarında BilgiYazdir() metodunu override edin.
 Program, kullanıcıdan çalışan türünü seçmesini ve ardından ilgili çalışanın bilgilerini alarak yazdırmasını sağlasın.

Beklenen Çıktı:
 Eğer kullanıcı Yazilimci seçerse, yazılımcı bilgileri yazdırılmalı.
 Eğer kullanıcı Muhasebeci seçerse, muhasebeci bilgileri yazdırılmalı.
*/

using System;

namespace SirketCalisanlari
{
    // Temel Calisan sınıfı
    class Calisan
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public decimal Maas { get; set; }
        public string Pozisyon { get; set; }

        public virtual void BilgiYazdir()
        {
            Console.WriteLine($"Ad: {Ad}, Soyad: {Soyad}, Maaş: {Maas}, Pozisyon: {Pozisyon}");
        }
    }

    // Yazilimci sınıfı
    class Yazilimci : Calisan
    {
        public string YazilimDili { get; set; }

        public override void BilgiYazdir()
        {
            base.BilgiYazdir();
            Console.WriteLine($"Yazılım Dili: {YazilimDili}");
        }
    }

    // Muhasebeci sınıfı
    class Muhasebeci : Calisan
    {
        public string MuhasebeYazilimi { get; set; }

        public override void BilgiYazdir()
        {
            base.BilgiYazdir();
            Console.WriteLine($"Muhasebe Yazılımı: {MuhasebeYazilimi}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Çalışan türünü seçin (1: Yazılımcı, 2: Muhasebeci):");
            string secim = Console.ReadLine();

            if (secim == "1")
            {
                Yazilimci yazilimci = new Yazilimci
                {
                    Ad = "Ali",
                    Soyad = "Yılmaz",
                    Maas = 15000,
                    Pozisyon = "Yazılımcı",
                    YazilimDili = "C#"
                };
                yazilimci.BilgiYazdir();
            }
            else if (secim == "2")
            {
                Muhasebeci muhasebeci = new Muhasebeci
                {
                    Ad = "Ayşe",
                    Soyad = "Demir",
                    Maas = 12000,
                    Pozisyon = "Muhasebeci",
                    MuhasebeYazilimi = "Logo"
                };
                muhasebeci.BilgiYazdir();
            }
            else
            {
                Console.WriteLine("Geçersiz seçim!");
            }
        }
    }
}

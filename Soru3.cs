/*
3.SORU: Bir banka sistemi için temel bir Hesap sınıfı oluşturun. Bu sınıftan türeyen VadesizHesap ve VadeliHesap sınıflarını tanımlayın.
Her hesap, hesap numarası, bakiye ve hesap sahibine sahiptir. VadeliHesap sınıfında vade süresi ve faiz oranı, VadesizHesap sınıfında ise ek hesap limiti bulunsun.

Aşağıdaki işlemleri gerçekleştirin:
 Her hesap türü için bir ParaYatir() metodu oluşturun. Bu metodun çıktısı her türetilmiş sınıf için farklı olmalı.
 Her hesap türü için bir ParaCek() metodu oluşturun. VadeliHesap sınıfında vade dolmadan para çekme işlemi yapılmaya çalışılırsa kullanıcıya uyarı verilsin.
 Hesap sınıfında genel bir BilgiYazdir() metodu tanımlayın.
 Program, kullanıcıdan hesap türünü seçmesini, hesap bilgilerini almasını ve işlem yapmasını sağlayacak şekilde çalışmalıdır.

Beklenen Çıktı:
 Kullanıcı, VadesizHesap veya VadeliHesap türlerinden birini seçebilir.
 Hesaba para yatırma, para çekme ve hesap bilgilerini yazdırma işlemleri doğru şekilde gerçekleştirilmeli.
 Vadeli hesapta vade dolmadan para çekme işlemi yapılmaya çalışıldığında, uygun uyarı verilmelidir.
*/


using System;

namespace BankaSistemi
{
    // Temel Hesap sınıfı
    class Hesap
    {
        public string HesapNo { get; set; }
        public string HesapSahibi { get; set; }
        public decimal Bakiye { get; set; }

        public virtual void ParaYatir(decimal miktar)
        {
            Bakiye += miktar;
            Console.WriteLine($"{miktar} TL hesaba yatırıldı. Yeni bakiye: {Bakiye} TL");
        }

        public virtual void ParaCek(decimal miktar)
        {
            if (Bakiye >= miktar)
            {
                Bakiye -= miktar;
                Console.WriteLine($"{miktar} TL hesap bakiyesinden çekildi. Kalan bakiye: {Bakiye} TL");
            }
            else
            {
                Console.WriteLine("Yetersiz bakiye!");
            }
        }

        public virtual void BilgiYazdir()
        {
            Console.WriteLine($"Hesap No: {HesapNo}, Hesap Sahibi: {HesapSahibi}, Bakiye: {Bakiye} TL");
        }
    }

    // VadesizHesap sınıfı
    class VadesizHesap : Hesap
    {
        public decimal EkHesapLimiti { get; set; }

        public override void ParaCek(decimal miktar)
        {
            if (Bakiye + EkHesapLimiti >= miktar)
            {
                decimal toplamLimit = Bakiye + EkHesapLimiti;
                Bakiye -= miktar;
                Console.WriteLine($"{miktar} TL çekildi. Kalan bakiye ve ek hesap: {Bakiye} TL");
            }
            else
            {
                Console.WriteLine("Çekmek istediğiniz tutar, mevcut bakiye ve ek hesap limitini aşıyor!");
            }
        }

        public override void BilgiYazdir()
        {
            base.BilgiYazdir();
            Console.WriteLine($"Ek Hesap Limiti: {EkHesapLimiti} TL");
        }
    }


    // VadeliHesap sınıfı
    class VadeliHesap : Hesap
    {
        public int VadeSuresi { get; set; } // Vade süresi ay cinsinden
        public decimal FaizOrani { get; set; } // Yıllık faiz oranı
        public bool VadeDoldu { get; set; } // Vade dolma durumu

        public override void ParaCek(decimal miktar)
        {
            if (VadeDoldu)
            {
                if (Bakiye >= miktar)
                {
                    Bakiye -= miktar;
                    Console.WriteLine($"{miktar} TL vadeli hesaptan çekildi. Kalan bakiye: {Bakiye} TL");
                }
                else
                {
                    Console.WriteLine("Yetersiz bakiye!");
                }
            }
            else
            {
                Console.WriteLine("Vade dolmadan para çekemezsiniz!");
            }
        }

        public override void BilgiYazdir()
        {
            base.BilgiYazdir();
            Console.WriteLine($"Vade Süresi: {VadeSuresi} ay, Faiz Oranı: {FaizOrani * 100}%");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hesap türünü seçin (1: Vadesiz Hesap, 2: Vadeli Hesap):");
            string secim = Console.ReadLine();

            if (secim == "1")
            {
                VadesizHesap vadesizHesap = new VadesizHesap
                {
                    HesapNo = "123456",
                    HesapSahibi = "Ali Yılmaz",
                    Bakiye = 1000,
                    EkHesapLimiti = 500
                };

                vadesizHesap.BilgiYazdir();
                vadesizHesap.ParaYatir(200);
                vadesizHesap.ParaCek(1500);
            }
            else if (secim == "2")
            {
                VadeliHesap vadeliHesap = new VadeliHesap
                {
                    HesapNo = "654321",
                    HesapSahibi = "Ayşe Demir",
                    Bakiye = 5000,
                    VadeSuresi = 12,
                    FaizOrani = 0.15m,
                    VadeDoldu = false // Vade henüz dolmadı
                };

                vadeliHesap.BilgiYazdir();
                vadeliHesap.ParaYatir(1000);
                vadeliHesap.ParaCek(2000); // Uyarı verecek
            }
            else
            {
                Console.WriteLine("Geçersiz seçim!");
            }
        }
    }
}

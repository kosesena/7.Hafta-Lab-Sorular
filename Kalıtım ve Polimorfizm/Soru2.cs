/*
2.SORU: Bir hayvanat bahçesi yönetim sistemi yazınız. Temel bir Hayvan sınıfı oluşturun ve bu sınıftan türeyen Memeli ve Kus sınıflarını tanımlayın.
Her hayvanın adı, türü ve yaş bilgisi vardır. Memeli sınıfında TuyRengi, Kus sınıfında ise KanatGenisligi özelliği bulunsun. Ayrıca her hayvanın bir ses çıkarmasını sağlamak için SesCikar() metodunu her sınıfta farklı şekilde tanımlayın.

Aşağıdaki işlemleri gerçekleştirin:
 Hayvan sınıfında bir SesCikar() metodu oluşturun. Bu metodun çıktısı her türetilmiş sınıf için farklı olmalı.
 Memeli ve Kus sınıflarında SesCikar() metodunu override edin.
 Program, kullanıcıdan hayvan türünü seçmesini ve ardından seçilen hayvanın bilgilerini ve sesini yazdırmasını sağlasın.

Beklenen Çıktı:
 Eğer kullanıcı Memeli seçerse, memelinin bilgileri ve ses çıkarma durumu yazdırılmalı.
 Eğer kullanıcı Kus seçerse, kuşun bilgileri ve ses çıkarma durumu yazdırılmalı.
*/


using System;

namespace HayvanatBahcesi
{
    // Temel Hayvan sınıfı
    class Hayvan
    {
        public string Ad { get; set; }
        public string Tur { get; set; }
        public int Yas { get; set; }

        public virtual void SesCikar()
        {
            Console.WriteLine("Bu hayvan bir ses çıkarıyor.");
        }

        public virtual void BilgiYazdir()
        {
            Console.WriteLine($"Ad: {Ad}, Tür: {Tur}, Yaş: {Yas}");
        }
    }

    // Memeli sınıfı
    class Memeli : Hayvan
    {
        public string TuyRengi { get; set; }

        public override void SesCikar()
        {
            Console.WriteLine($"{Ad} memeli bir hayvan olarak ses çıkarıyor: \"Miyav\" veya \"Hav hav\"");
        }

        public override void BilgiYazdir()
        {
            base.BilgiYazdir();
            Console.WriteLine($"Tüy Rengi: {TuyRengi}");
        }
    }

    // Kuş sınıfı
    class Kus : Hayvan
    {
        public double KanatGenisligi { get; set; }

        public override void SesCikar()
        {
            Console.WriteLine($"{Ad} kuş bir hayvan olarak ses çıkarıyor: \"Cik cik\"");
        }

        public override void BilgiYazdir()
        {
            base.BilgiYazdir();
            Console.WriteLine($"Kanat Genişliği: {KanatGenisligi} metre");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hayvan türünü seçin (1: Memeli, 2: Kuş):");
            string secim = Console.ReadLine();

            if (secim == "1")
            {
                Memeli memeli = new Memeli
                {
                    Ad = "Aslan",
                    Tur = "Memeli",
                    Yas = 5,
                    TuyRengi = "Sarı"
                };
                memeli.BilgiYazdir();
                memeli.SesCikar();
            }
            else if (secim == "2")
            {
                Kus kus = new Kus
                {
                    Ad = "Papağan",
                    Tur = "Kuş",
                    Yas = 3,
                    KanatGenisligi = 0.5
                };
                kus.BilgiYazdir();
                kus.SesCikar();
            }
            else
            {
                Console.WriteLine("Geçersiz seçim!");
            }
        }
    }
}

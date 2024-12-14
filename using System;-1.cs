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
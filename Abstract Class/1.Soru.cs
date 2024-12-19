/* Açıklama: Bir banka hesabı yönetim sistemi tasarlamanız isteniyor. Bu sistemde, soyut
sınıflar ve arayüzler kullanarak farklı hesap türlerinin özelliklerini yönetmelisiniz.
Görevler:
1. Soyut Hesap sınıfını oluşturun: Bu sınıfın HesapNo, Bakiye gibi özellikleri ve
ParaYatir(decimal miktar) ve ParaCek(decimal miktar) metodları olmalı.
2. BirikimHesabi ve VadesizHesap sınıflarını oluşturun: Bu sınıflar Hesap sınıfından
türetilmeli.
o BirikimHesabi sınıfı, birikim hesabına özel bir özellik tutmalı (örneğin faiz
oranı) ve ParaYatir() metodunda faizi hesaplamalı.
o VadesizHesap sınıfı, ParaCek() metodunda işlem ücreti uygulamalıdır.

3. IBankaHesabi arayüzü oluşturun: Bu arayüz, her hesabın HesapAcilisTarihi gibi
bir özelliği ve HesapOzeti() gibi bir metod içermelidir.
4. Banka hesabı yönetimini test etmek için birkaç hesap oluşturun ve her hesap için
işlem yaparak hesap özetini ekrana yazdırın.
*/

using System;
using System.Collections.Generic;

abstract class Hesap
{
    public int HesapNo { get; set; }
    public decimal Bakiye { get; protected set; }

    public abstract void ParaYatir(decimal miktar);
    public abstract void ParaCek(decimal miktar);

    public virtual void HesapOzeti()
    {
        Console.WriteLine($"Hesap No: {HesapNo}, Bakiye: {Bakiye:C}");
    }
}

class BirikimHesabi : Hesap
{
    public decimal FaizOrani { get; set; }

    public BirikimHesabi(decimal faizOrani)
    {
        FaizOrani = faizOrani;
    }

    public override void ParaYatir(decimal miktar)
    {
        decimal faiz = miktar * FaizOrani;
        Bakiye += miktar + faiz;
        Console.WriteLine($"{miktar:C} yatırıldı. Faiz: {faiz:C}");
    }

    public override void ParaCek(decimal miktar)
    {
        if (Bakiye >= miktar)
        {
            Bakiye -= miktar;
            Console.WriteLine($"{miktar:C} çekildi.");
        }
        else
        {
            Console.WriteLine("Yetersiz bakiye.");
        }
    }
}

class VadesizHesap : Hesap
{
    public decimal IslemUcreti { get; set; }

    public VadesizHesap(decimal islemUcreti)
    {
        IslemUcreti = islemUcreti;
    }

    public override void ParaYatir(decimal miktar)
    {
        Bakiye += miktar;
        Console.WriteLine($"{miktar:C} yatırıldı.");
    }

    public override void ParaCek(decimal miktar)
    {
        decimal toplamMiktar = miktar + IslemUcreti;

        if (Bakiye >= toplamMiktar)
        {
            Bakiye -= toplamMiktar;
            Console.WriteLine($"{miktar:C} çekildi. İşlem ücreti: {IslemUcreti:C}");
        }
        else
        {
            Console.WriteLine("Yetersiz bakiye.");
        }
    }
}

interface IBankaHesabi
{
    DateTime HesapAcilisTarihi { get; set; }
    void HesapOzeti();
}

class Program
{
    static void Main()
    {
        // Birikim Hesabı oluştur
        BirikimHesabi birikimHesabi = new BirikimHesabi(0.05m)
        {
            HesapNo = 12345
        };

        birikimHesabi.ParaYatir(1000);
        birikimHesabi.ParaCek(500);
        birikimHesabi.HesapOzeti();

        // Vadesiz Hesap oluştur
        VadesizHesap vadesizHesap = new VadesizHesap(10)
        {
            HesapNo = 67890
        };

        vadesizHesap.ParaYatir(2000);
        vadesizHesap.ParaCek(500);
        vadesizHesap.HesapOzeti();
    }
}

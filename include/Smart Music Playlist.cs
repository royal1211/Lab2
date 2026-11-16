using System;
using System.Diagnostics;

namespace vsaLab2_1
{
    public class Mahni
    {
        public string Ad;
        public string Sənətçi;
        public Mahni Növbəti;
        public Mahni Əvvəlki; // Doubly Linked List üçün

        public Mahni(string ad, string sənətçi)
        {
            Ad = ad;
            Sənətçi = sənətçi;
            Növbəti = null;
            Əvvəlki = null;
        }
    }

    public class MusiqiPleylisti
    {
        private Mahni baş;
        private Mahni son;
        private int say;

        public void MahniƏlavəEt(string ad, string sənətçi)
        {
            Mahni yeniMahni = new Mahni(ad, sənətçi);
            if (baş == null)
            {
                baş = son = yeniMahni;
            }
            else
            {
                son.Növbəti = yeniMahni;
                yeniMahni.Əvvəlki = son;
                son = yeniMahni;
            }
            say++;
            Console.WriteLine("Mahnı əlavə olundu: " + ad);
        }

        public void MahniSil(string ad)
        {
            Mahni temp = baş;
            while (temp != null)
            {
                if (temp.Ad.Equals(ad, StringComparison.OrdinalIgnoreCase))
                {
                    if (temp == baş)
                    {
                        baş = baş.Növbəti;
                        if (baş != null) baş.Əvvəlki = null;
                    }
                    else if (temp == son)
                    {
                        son = son.Əvvəlki;
                        if (son != null) son.Növbəti = null;
                    }
                    else
                    {
                        temp.Əvvəlki.Növbəti = temp.Növbəti;
                        temp.Növbəti.Əvvəlki = temp.Əvvəlki;
                    }
                    say--;
                    Console.WriteLine("Mahnı silindi: " + ad);
                    return;
                }
                temp = temp.Növbəti;
            }
            Console.WriteLine("Mahnı tapılmadı!");
        }

        public void PleylistiGöstər()
        {
            if (baş == null)
            {
                Console.WriteLine("Pleylist boşdur.");
                return;
            }
            Mahni temp = baş;
            Console.WriteLine("\n--- Smart Music Playlist ---");
            while (temp != null)
            {
                Console.WriteLine($"Mahnı: {temp.Ad} - Sənətçi: {temp.Sənətçi}");
                temp = temp.Növbəti;
            }
        }
    }
}

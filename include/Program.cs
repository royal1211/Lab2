using System;
using System.Diagnostics;

namespace vsaLab2_3
{
    public class Sernişin
    {
        public int Id;
        public string Ad;
        public string UçuşNömresi;
        public Sernişin Növbeti;

        public Sernişin(int id, string ad, string uçuş)
        {
            Id = id;
            Ad = ad;
            UçuşNömresi = uçuş;
            Növbeti = null;
        }
    }

    public class HavaLimaniNövbesi
    {
        private Sernişin ön;
        private Sernişin arxa;
        private int say;

        public void SernişinelaveEt(int id, string ad, string uçuş)
        {
            Sernişin yeniSernişin = new Sernişin(id, ad, uçuş);
            if (arxa == null)
            {
                ön = arxa = yeniSernişin;
            }
            else
            {
                arxa.Növbeti = yeniSernişin;
                arxa = yeniSernişin;
            }
            say++;
            Console.WriteLine("Sernişin elave olundu: " + ad);
        }

        public void QeydiyyatdanKeçir()
        {
            if (ön == null)
            {
                Console.WriteLine("Növbede sernişin yoxdur!");
                return;
            }
            Console.WriteLine("Qeydiyyatdan keçdi: " + ön.Ad + " (Uçuş: " + ön.UçuşNömresi + ")");
            ön = ön.Növbeti;
            if (ön == null)
            {
                arxa = null;
            }
            say--;
        }

        public void SiradakiSernişineBax()
        {
            if (ön == null)
            {
                Console.WriteLine("Növbe boşdur.");
                return;
            }
            Console.WriteLine("Siradaki sernişin  ID: " + ön.Id + "  Ad: " + ön.Ad + "  Uçuş: " + ön.UçuşNömresi);
        }

        public void NövbeniGöster()
        {
            if (ön == null)
            {
                Console.WriteLine("Növbe boşdur.");
                return;
            }
            Sernişin temp = ön;
            Console.WriteLine("\n Hava Limani Növbesi ");
            while (temp != null)
            {
                Console.WriteLine("ID: " + temp.Id + "  Ad: " + temp.Ad + "  Uçuş: " + temp.UçuşNömresi);
                temp = temp.Növbeti;
            }
        }

        public void SernişinSayiniGöster()
        {
            Console.WriteLine("Növbedeki sernişin sayi: " + say);
        }

        public void PerformansTestiEt(int ölçü)
        {
            HavaLimaniNövbesi q = new HavaLimaniNövbesi();
            Stopwatch sw = new Stopwatch();

            sw.Start();
            for (int i = 1; i <= ölçü; i++)
            {
                q.SernişinelaveEt(i, "Sernişin " + i, "AZ" + (100 + i));
            }
            sw.Stop();
            double elaveVaxti = sw.Elapsed.TotalMilliseconds;

            sw.Restart();
            string adDummy = q.ön != null ? q.ön.Ad : "";
            sw.Stop();
            double baxVaxti = sw.Elapsed.TotalMilliseconds;

            sw.Restart();
            for (int i = 1; i <= ölçü; i++)
            {
                q.QeydiyyatdanKeçir();
            }
            sw.Stop();
            double silVaxti = sw.Elapsed.TotalMilliseconds;

            Console.WriteLine("Element sayi: " + ölçü + "  elave etme: " + elaveVaxti.ToString("F4") + " ms  Silme: " + silVaxti.ToString("F4") + " ms Baxiş: " + baxVaxti.ToString("F4") + " ms");
        }
    }

    class Program
    {
        static void Main()
        {
            HavaLimaniNövbesi növbe = new HavaLimaniNövbesi();
            int seçim;
            do
            {
                Console.WriteLine("\n1. Sernişin elave et\n2. Qeydiyyatdan keçir\n3. Siradaki sernişine bax\n4. Növbeni göster\n5. Sernişin sayini göster\n6. Performans testi\n7. Çixiş");
                Console.Write("Seçiminizi edin: ");
                if (!int.TryParse(Console.ReadLine(), out seçim)) continue;

                if (seçim == 1)
                {
                    Console.Write("Sernişin ID daxil et: ");
                    int.TryParse(Console.ReadLine(), out int id);
                    Console.Write("Ad daxil et: ");
                    string ad = Console.ReadLine();
                    Console.Write("Uçuş nömresi daxil et: ");
                    string uçuş = Console.ReadLine();
                    növbe.SernişinelaveEt(id, ad, uçuş);
                }
                else if (seçim == 2)
                {
                    növbe.QeydiyyatdanKeçir();
                }
                else if (seçim == 3)
                {
                    növbe.SiradakiSernişineBax();
                }
                else if (seçim == 4)
                {
                    növbe.NövbeniGöster();
                }
                else if (seçim == 5)
                {
                    növbe.SernişinSayiniGöster();
                }
                else if (seçim == 6)
                {
                    Console.WriteLine("\n--- TEST NeTİCeLeRİ ---");
                    növbe.PerformansTestiEt(100);
                    növbe.PerformansTestiEt(1000);
                    növbe.PerformansTestiEt(10000);
                }
            } while (seçim != 7);
        }
    }
}
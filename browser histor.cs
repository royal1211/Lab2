using System;

namespace vsaLab2_2
{
    public class SəhifəNode
    {
        public string Url;
        public SəhifəNode Növbəti;

        public SəhifəNode(string url)
        {
            Url = url;
            Növbəti = null;
        }
    }

    public class BrowserHistory
    {
        private SəhifəNode üst;

      
        public void VisitPage(string url)
        {
            SəhifəNode yeniSəhifə = new SəhifəNode(url);
            yeniSəhifə.Növbəti = üst;
            üst = yeniSəhifə;
            Console.WriteLine("Açıldı: " + url);
        }
        public void GoBack()
        {
            if (üst == null)
            {
                Console.WriteLine("Tarixçə boşdur, geri qayıtmaq olmur!");
                return;
            }
            Console.WriteLine("Bağlandı / Geri qayıdıldı: " + üst.Url);
            üst = üst.Növbəti;
        }

        public void CurrentPage()
        {
            if (üst == null)
            {
                Console.WriteLine("Cari səhifə yoxdur.");
                return;
            }
            Console.WriteLine("Cari səhifə: " + üst.Url);
        }
    }
}

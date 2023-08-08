namespace TelefonRehberi
{
    class Program
    {
        static List<Kisi> telefonRehberi = new List<Kisi>();
        static void Main(string[] args)
        {
            telefonRehberi.Add(new Kisi("Yusuf", "Günes", "5551113322"));
            telefonRehberi.Add(new Kisi("Mehmet", "Deniz", "50512235698"));
            telefonRehberi.Add(new Kisi("Fatma", "Er", "5324678998"));
            telefonRehberi.Add(new Kisi("Yunus", "Yıldız", "5421255698"));
            telefonRehberi.Add(new Kisi("Gökhan", "Uslu", "5352225698"));

            string secim;
            Console.WriteLine("Lütfen yapmak istediğiniz islemi seçiniz:");
            Console.WriteLine("1) Yeni Numara Kaydetmek");
            Console.WriteLine("2) Varolan Numarayı Silmek");
            Console.WriteLine("3) Varolan Numarayı Güncelleme");
            Console.WriteLine("4) Rehberi Listelemek");
            Console.WriteLine("5) Rehberde Arama Yapmak");
            Console.WriteLine("Çıkıs için ç harfine basınız.");
            secim = Console.ReadLine();

            while (secim is not "ç")
            {

                switch (secim)
                {
                    case "1":
                        NumaraKaydet();
                        break;
                    case "2":
                        NumaraSil();
                        break;
                    case "3":
                        NumaraGuncelle();
                        break;
                    case "4":
                        RehberiListele();
                        break;
                    case "5":
                        RehberdeAra();
                        break;

                }
                Console.WriteLine("Lütfen yapmak istediğiniz islemi seçiniz:");
                Console.WriteLine("1) Yeni Numara Kaydetmek");
                Console.WriteLine("2) Varolan Numarayı Silmek");
                Console.WriteLine("3) Varolan Numarayı Güncelleme");
                Console.WriteLine("4) Rehberi Listelemek");
                Console.WriteLine("5) Rehberde Arama Yapmak");
                Console.WriteLine("Çıkıs için ç harfine basınız.");
                secim = Console.ReadLine();
            }



        }

        static void NumaraKaydet()
        {
            Console.WriteLine("Lütfen isim giriniz: ");
            string isim = Console.ReadLine();
            Console.WriteLine("Lütfen soyisim giriniz: ");
            string soyisim = Console.ReadLine();
            Console.WriteLine("Lütfen telefon numarası giriniz: ");
            string telefonNo = Console.ReadLine();

            telefonRehberi.Add(new Kisi(isim, soyisim, telefonNo));

            Console.WriteLine("Yeni numara basarıyla kaydedildi.");
        }

        static void NumaraSil()
        {
            Console.WriteLine("Lütfen numarasını silmek istediğiniz kisinin adını veya soyadını giriniz: ");
            string adiVeyaSoyadi = Console.ReadLine();

            List<Kisi> bulunanKisiler = new List<Kisi>();

            foreach (Kisi kisi in telefonRehberi)
            {
                if (kisi.Adi.Contains(adiVeyaSoyadi) || kisi.Soyadi.Contains(adiVeyaSoyadi))
                {
                    bulunanKisiler.Add(kisi);
                }
            }

            if (bulunanKisiler.Count == 0)
            {
                Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı. Lütfen seçim yapınız.\nSilmeyi sonlandırmak için (1)\nYeniden denemek için (2)");

                string secim = Console.ReadLine();

                if (secim == "1")
                {
                    return;
                }

                else if (secim == "2")
                {
                    NumaraSil();
                }
                else
                {
                    Console.WriteLine("Geçersiz bir seçim yaptınız.");
                    NumaraSil();
                }
            }
            else
            {
                Kisi silinecekKisi = bulunanKisiler[0];
                Console.WriteLine($"{silinecekKisi.Adi} isimli kisi silinmek üzere onaylıyor musunuz? (y/n) ");
                string secim = Console.ReadLine();

                if (secim.ToLower() == "y")
                {
                    telefonRehberi.Remove(silinecekKisi);
                    Console.WriteLine("Kisi rehberden silindi.");
                }
                else if (secim.ToLower() == "n")
                {
                    Console.WriteLine("Silme islemi iptal edildi.");
                }

                else
                {
                    Console.WriteLine("Geçersiz bir seçim yaptınız.");
                }

            }
        }

        static void NumaraGuncelle()
        {
            Console.WriteLine("Güncellemek istediğiniz kisinin adını veya soyadını giriniz.");
            string adiVeyaSoyadi = Console.ReadLine();

            List<Kisi> bulunanKisiler = new List<Kisi>();

            foreach (Kisi kisi in telefonRehberi)
            {

                if (kisi.Adi.Contains(adiVeyaSoyadi) || kisi.Soyadi.Contains(adiVeyaSoyadi))
                {
                    bulunanKisiler.Add(kisi);
                }

            }


            if (bulunanKisiler.Count == 0)
            {
                Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.\nGüncellemeyi sonlandırmak için: (1)\nYeniden denemek için: (2) ");
                string secim = Console.ReadLine();

                if (secim == "1")
                {
                    return;
                }
                else if (secim == "2")
                {
                    NumaraGuncelle();
                }

                else
                {
                    Console.WriteLine("Geçersiz bir seçim yaptınız.");
                    NumaraGuncelle();
                }
            }

            else
            {
                Kisi guncellenecekKisi = bulunanKisiler[0];
                Console.WriteLine($"Lütfen {guncellenecekKisi.Adi}  {guncellenecekKisi.Soyadi} adlı kisinin yeni telefon numarasını giriniz. ");
                string yeniTelefon = Console.ReadLine();

                guncellenecekKisi.TelefonNo = yeniTelefon;
                Console.WriteLine("Kisinin telefon numarası basarıyla güncellendi.");
            }

        }

        static void RehberiListele()
        {
            Console.WriteLine("Rehberi nasıl sıralamak istersiniz?");
            Console.WriteLine("(1) A-Z");
            Console.WriteLine("(2) Z-A");
            string secim = Console.ReadLine();

            List<Kisi> siralanmisKisiler;

            if (secim == "1")
            {
                siralanmisKisiler = telefonRehberi.OrderBy(kisi => kisi.Adi).ToList();
            }

            else if (secim == "2")
            {
                siralanmisKisiler = telefonRehberi.OrderByDescending(kisi => kisi.Adi).ToList();
            }
            else
            {
                Console.WriteLine("Geçersiz bir islem yaptınız.");
                return;
            }


            Console.WriteLine("***** Telefon Rehberi *****");

            Console.WriteLine("*****************************");

            foreach (Kisi kisi in siralanmisKisiler)
            {
                Console.WriteLine($"Adı: {kisi.Adi} Soyadı: {kisi.Soyadi} Telefon Numarası: {kisi.TelefonNo} ");
            }
        }

        static void RehberdeAra()
        {
            Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz:");
            Console.WriteLine("İsim veya soyisime göre arama yapmak için: (1)\nTelefon numarasına göre arama yapmak için: (2)");

            string secim = Console.ReadLine();

            if (secim == "1")
            {
                Console.Write("Aranacak kisinin adı veya soyadı: ");
                string adiVeyaSoyadi = Console.ReadLine();

                List<Kisi> bulunanKisiler = new List<Kisi>();

                foreach (Kisi kisi in telefonRehberi)
                {
                    if (kisi.Adi.Contains(adiVeyaSoyadi) || kisi.Soyadi.Contains(adiVeyaSoyadi))
                    {
                        bulunanKisiler.Add(kisi);
                    }
                }

                if (bulunanKisiler.Count > 0)
                {

                    Console.WriteLine("Arama sonuçlarınız:");
                    foreach (Kisi kisi in bulunanKisiler)
                    {
                        Console.WriteLine($"Adı: {kisi.Adi} Soyadı: {kisi.Soyadi} Telefon Numarası: {kisi.TelefonNo}");
                    }
                }
                else
                {
                    Console.WriteLine("Aranan kisi bulunamadı.");
                }
            }

            if (secim == "2")
            {
                Console.WriteLine("Aranacak kisinin telefon numarası: ");
                string telefonNo = Console.ReadLine();

                List<Kisi> bulunanKisiler = new List<Kisi>();

                foreach (Kisi kisi in telefonRehberi)
                {
                    if (kisi.TelefonNo.Contains(telefonNo))
                    {
                        bulunanKisiler.Add(kisi);
                    }
                }

                if (bulunanKisiler.Count > 0)
                {
                    Console.WriteLine("Arama sonuçlarınız:");
                    foreach (Kisi kisi in bulunanKisiler)
                    {
                        Console.WriteLine($"Adı: {kisi.Adi} Soyadı: {kisi.Soyadi} Telefon Numarası: {kisi.TelefonNo}");
                    }
                }
                else
                {
                    Console.WriteLine("Aranan kisi bulunamadı.");
                }
            }
        }
    }
}
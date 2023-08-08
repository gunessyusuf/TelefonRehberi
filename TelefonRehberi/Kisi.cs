namespace TelefonRehberi
{
    public class Kisi
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string TelefonNo { get; set; }

        public Kisi(string adi, string soyadi, string telefonNo)
        {
            Adi = adi;
            Soyadi = soyadi;
            TelefonNo = telefonNo;
        }
    }
}

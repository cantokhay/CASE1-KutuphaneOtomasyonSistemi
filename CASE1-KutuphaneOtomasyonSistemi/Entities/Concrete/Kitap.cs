using CASE1_KutuphaneOtomasyonSistemi.Entities.Enums;

namespace CASE1_KutuphaneOtomasyonSistemi.Entities.BaseClass
{
    public abstract class Kitap
    {
        public string ISBN { get; set; }
        public string Baslik { get; set; }
        public string Yazar { get; set; }
        public int YayinYili { get; set; }
        public Durum KitapDurumu { get; set; }
    }
}

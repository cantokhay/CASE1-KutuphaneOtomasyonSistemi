using CASE1_KutuphaneOtomasyonSistemi.Entities.Abstract;
using CASE1_KutuphaneOtomasyonSistemi.Entities.Enums;

namespace CASE1_KutuphaneOtomasyonSistemi.Entities.BaseClass
{
    public class Uye :IUye
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public List<Kitap> KitapListesi { get; set; } = new List<Kitap>();

        /// <summary>
        /// Kitap ödünç almak için bir uye tarafından çağrıldığında çalışan metot.
        /// </summary>
        /// <param name="kitap">Ödünç alınacak kitap.</param>
        public void KitapOduncAl(Kitap kitap)
        {
            if (kitap.KitapDurumu == Durum.Mevcut)
            {
                KitapListesi.Add(kitap);
                kitap.KitapDurumu = Durum.OduncVerildi;
                Console.WriteLine($"{Ad}, {kitap.Baslik} adlı kitabı ödünç aldı.");
            }
            else
            {
                Console.WriteLine($"{kitap.Baslik} adlı kitap ödünç alınamaz.");
            }
        }

        /// <summary>
        /// Kitap iade etmek için bir uye tarafından çağrıldığında çalışan metot.
        /// </summary>
        /// <param name="kitap">İade edilecek kitap.</param>
        public void KitapIadeEt(Kitap kitap)
        {
            if (KitapListesi.Contains(kitap))
            {
                KitapListesi.Remove(kitap);
                kitap.KitapDurumu = Durum.Mevcut;
                Console.WriteLine($"{Ad}, {kitap.Baslik} adlı kitabı iade etti.");
            }
            else
            {
                Console.WriteLine($"{Ad}, {kitap.Baslik} adlı kitabı ödünç almamış.");
            }
        }

        /// <summary>
        /// uyenin ödünç aldığı kitapları görüntülemek için çağrılan metot.
        /// </summary>
        public void OduncAlinanKitapListesi()
        {
            Console.WriteLine($"{Ad} adlı uyenin ödünç aldığı kitaplar:");
            foreach (var kitap in KitapListesi)
            {
                Console.WriteLine($"{kitap.Baslik} ({kitap.KitapDurumu})");
            }
        }
    }
}

using CASE1_KutuphaneOtomasyonSistemi.Entities.Abstract;
using CASE1_KutuphaneOtomasyonSistemi.Entities.BaseClass;
using CASE1_KutuphaneOtomasyonSistemi.Entities.Entities.BookTypes;
using CASE1_KutuphaneOtomasyonSistemi.Entities.Enums;

namespace CASE1_KutuphaneOtomasyonSistemi.Entities.Entities
{
    public class Kutuphane
    {
        public List<Kitap> Kitaplar { get; set; } = new List<Kitap>();
        public List<IUye> Uyeler { get; set; } = new List<IUye>();

        private Dictionary<Type, List<Kitap>> kitapTurleri = new Dictionary<Type, List<Kitap>>();

        public Kutuphane()
        {
            kitapTurleri[typeof(KitapBilim)] = new List<Kitap>();
            kitapTurleri[typeof(KitapRoman)] = new List<Kitap>();
            kitapTurleri[typeof(KitapTarih)] = new List<Kitap>();
        }

        /// <summary>
        /// Bir kitabı kütüphaneye ekler.
        /// </summary>
        /// <param name="kitap">Eklenecek kitap.</param>
        public void KitapEkle(Kitap kitap)
        {
            Kitaplar.Add(kitap);
            Type kitapTuru = kitap.GetType();
            if (kitapTurleri.ContainsKey(kitapTuru))
            {
                kitapTurleri[kitapTuru].Add(kitap);
            }
            else
            {
                Console.WriteLine("Geçersiz kitap türü.");
            }
            Console.WriteLine($"{kitap.Baslik} adlı kitap kütüphaneye eklendi.");
        }

        /// <summary>
        /// Bir kitabı kütüphaneden kaldırır.
        /// </summary>
        /// <param name="kitap">Kaldırılacak kitap.</param>
        public void KitapKaldir(Kitap kitap)
        {
            if (Kitaplar.Contains(kitap))
            {
                Kitaplar.Remove(kitap);
                Console.WriteLine($"{kitap.Baslik} adlı kitap kütüphaneden kaldırıldı.");
            }
            else
            {
                Console.WriteLine($"{kitap.Baslik} adlı kitap kütüphanede bulunamadı.");
            }
        }

        /// <summary>
        /// Bir üyenin kütüphaneden kitap ödünç almasını sağlar.
        /// </summary>
        /// <param name="uye">Kitap ödünç alacak uye.</param>
        /// <param name="kitap">Ödünç alınacak kitap.</param>
        public void KitapOduncVer(IUye uye, Kitap kitap)
        {
            if (Kitaplar.Contains(kitap) && kitap.KitapDurumu == Durum.Mevcut)
            {
                uye.KitapOduncAl(kitap);
                kitap.KitapDurumu = Durum.OduncVerildi;
            }
            else
            {
                Console.WriteLine($"Ödünç verilecek kitap mevcut değil veya ödünç alınamaz durumda.");
            }
        }

        /// <summary>
        /// Bir üyenin kütüphaneden ödünç aldığı kitabı iade etmesini sağlar.
        /// </summary>
        /// <param name="uye">Kitabı iade edecek uye.</param>
        /// <param name="kitap">İade edilecek kitap.</param>
        public void KitapIadeAl(IUye uye, Kitap kitap)
        {
            if (uye.KitapListesi.Contains(kitap))
            {
                uye.KitapIadeEt(kitap);
                kitap.KitapDurumu = Durum.Mevcut;
            }
            else
            {
                Console.WriteLine($"İade edilecek kitap üyenin ödünç aldığı kitaplar arasında bulunamadı.");
            }
        }

        /// <summary>
        /// Kütüphanede ödünç alınan kitapların listesini ve hangi üye tarafından ödünç alındığını gösterir.
        /// </summary>
        public void OduncAlinanKitaplariListele()
        {
            Console.WriteLine("Ödünç Alınan Kitaplar:");
            foreach (var kitap in Kitaplar)
            {
                if (kitap.KitapDurumu == Durum.OduncVerildi)
                {
                    foreach (var uye in Uyeler)
                    {
                        if (uye.KitapListesi.Contains(kitap))
                        {
                            Console.WriteLine($"Kitap: {kitap.Baslik}, Ödünç Alan Üye: {uye.Ad}");
                            break; // Aynı kitabın birden fazla üye tarafından ödünç alınma ihtimaline karşın döngüyü kırar.
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Kütüphanede kayıtlı olan üyelerin listesini gösterir.
        /// </summary>
        public void UyeListesiniGoruntule()
        {
            Console.WriteLine("Kütüphane Üyeleri:");
            foreach (var uye in Uyeler)
            {
                Console.WriteLine($"Ad: {uye.Ad}");
            }
        }

        /// <summary>
        /// Kütüphanede mevcut olan kitapların listesini gösterir.
        /// </summary>
        public void MevcutKitaplariGoruntule()
        {
            Console.WriteLine("Mevcut Kitaplar:");
            foreach (var kitap in Kitaplar)
            {
                if (kitap.KitapDurumu == Durum.Mevcut)
                {
                    Console.WriteLine($"{kitap.Baslik}");
                }
            }
        }
    }
}

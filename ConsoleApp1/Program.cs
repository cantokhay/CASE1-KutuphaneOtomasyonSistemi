using CASE1_KutuphaneOtomasyonSistemi.Entities.Abstract;
using CASE1_KutuphaneOtomasyonSistemi.Entities.BaseClass;
using CASE1_KutuphaneOtomasyonSistemi.Entities.Entities.BookTypes;
using CASE1_KutuphaneOtomasyonSistemi.Entities.Entities;

Kutuphane kutuphane = new Kutuphane();

// Kitaplar oluşturuluyor
KitapBilim kitap1 = new KitapBilim { Baslik = "Evrim Teorisi", Yazar = "Charles Darwin", YayinYili = 1859 };
KitapRoman kitap2 = new KitapRoman { Baslik = "Suç ve Ceza", Yazar = "Fyodor Dostoyevski", YayinYili = 1866 };
KitapTarih kitap3 = new KitapTarih { Baslik = "Osmanlı İmparatorluğu Tarihi", Yazar = "Halil İnalcık", YayinYili = 1954 };
KitapTarih kitap4 = new KitapTarih { Baslik = "Homodeus", Yazar = "Yuval Noah Harari", YayinYili = 2016 };

// Kitaplar kütüphaneye ekleniyor
kutuphane.KitapEkle(kitap1);
kutuphane.KitapEkle(kitap2);
kutuphane.KitapEkle(kitap3);
kutuphane.KitapEkle(kitap4);

// Kütüphane üyeleri oluşturuluyor
IUye uye1 = new Uye { Ad = "Ahmet Yılmaz", Id = 101 };
IUye uye2 = new Uye { Ad = "Ayşe Demir", Id = 102 };

// Üyeler kütüphaneye ekleniyor
kutuphane.Uyeler.Add(uye1);
kutuphane.Uyeler.Add(uye2);

// Kitapların listesi görüntüleniyor
kutuphane.MevcutKitaplariGoruntule();

// Üyelerin listesi görüntüleniyor
kutuphane.UyeListesiniGoruntule();

// Bir üye bir kitabı ödünç alıyor
kutuphane.KitapOduncVer(uye1, kitap1);

// Ödünç alınan kitaplar listesi görüntüleniyor
kutuphane.OduncAlinanKitaplariListele();

// Bir üye bir kitabı iade ediyor
kutuphane.KitapIadeAl(uye1, kitap1);

// Ödünç alınan kitaplar listesi görüntüleniyor
kutuphane.OduncAlinanKitaplariListele();

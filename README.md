# 🍽️ Restoran Otomasyon Sistemi

Bu proje, restoranlar için geliştirilmiş, masa yönetimi, sipariş takibi, ürün/kategori yönetimi ve personel hareketlerini kayıt altına alan web tabanlı bir otomasyon sistemidir.

## 🚀 Özellikler

* **Admin Paneli:** Ürün, Kategori ve Masa ekleme/düzenleme/silme işlemleri.
* **Personel Paneli:** Sadece sipariş alma ve hesap kapatma yetkisi.
* **Masa Yönetimi:** Masaların doluluk oranlarını görsel olarak takip etme.
* **Sipariş Sistemi:** Masalara ürün ekleme, adisyon takibi ve hesap kapama.
* **Loglama (İşlem Geçmişi):** Hangi personelin hangi masada ne işlem yaptığını tarih ve saatle kaydetme.
* **Güvenlik:** Rol bazlı (Admin/Garson) yetkilendirme sistemi.

## 🛠️ Kullanılan Teknolojiler

* **Platform:** ASP.NET MVC 5
* **Dil:** C#
* **Veritabanı:** MS SQL Server (Entity Framework - Code First)
* **Önyüz:** Bootstrap 5, HTML, CSS, JavaScript
* **IDE:** Visual Studio

## 💻 Kurulum ve Çalıştırma

Projeyi kendi bilgisayarınızda çalıştırmak için aşağıdaki adımları izleyin:

### 1. Gereksinimler

* Visual Studio 2019 veya daha yeni bir sürüm.
* SQL Server (LocalDB veya SQL Express).
* .NET Framework 4.7.2 SDK.

### 2. Projeyi İndirme

Terminal veya Komut İstemcisi'ni açın ve projeyi klonlayın (veya ZIP olarak indirip açın):

```bash
git clone https://github.com/KULLANICI_ADINIZ/REPO_ADINIZ.git

```

### 3. Veritabanını Oluşturma (Code First)

Proje **Entity Framework Code First** kullandığı için veritabanını otomatik oluşturacaktır.

1. Projeyi (`.sln` dosyası) Visual Studio ile açın.
2. **Web.config** dosyasını açın ve `connectionStrings` kısmındaki Server adının kendi bilgisayarınızla uyumlu olduğundan emin olun (Genelde `(localdb)\MSSQLLocalDB` veya `.\SQLEXPRESS` olur).
3. Visual Studio'da üst menüden **Tools (Araçlar) > NuGet Package Manager > Package Manager Console** yolunu izleyin.
4. Açılan konsola şu komutu yazıp Enter'a basın:
```powershell
Update-Database

```


*Bu işlem veritabanını ve tabloları SQL Server'da otomatik oluşturacaktır.*

### 4. Çalıştırma

* Veritabanı oluştuktan sonra `Ctrl + F5` yaparak projeyi tarayıcıda başlatabilirsiniz.

## 🔐 Giriş Bilgileri (Varsayılan)

Veritabanı ilk oluştuğunda boş gelecektir. SQL Server üzerinden veya Seed metodu ile bir Admin kullanıcısı oluşturmanız gerekebilir.

* **Tablo:** `Personels`
* **Örnek Veri:**
* **Kullanıcı Adı:** `admin`
* **Şifre:** `1234`
* **Rol:** `A` (Yönetici)

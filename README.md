# VehaBank - İnternet Bankacılığı Sistemi

ASP.NET Core tabanlı modern bir internet bankacılığı uygulaması. Yönetici, Gişe Yetkilisi ve Müşteri rolleriyle kapsamlı bankacılık işlemlerini destekler.

## 🚀 Özellikler

- **Rol Tabanlı Yetkilendirme**: Yönetici, Gişe Yetkilisi ve Müşteri rolleri
- **Hesap Yönetimi**: Banka hesabı ve kredi hesabı açma/yönetme
- **Para Transferleri**: Hesaplar arası para transferi ve ödeme işlemleri
- **Güvenli Kimlik Doğrulama**: JWT tabanlı kimlik doğrulama ve BCrypt şifreleme
- **E-posta Doğrulama**: MailKit ile otomatik e-posta doğrulama sistemi
- **Şube Yönetimi**: Şube bazlı operasyonlar ve raporlama
- **Ödeme İşlemleri**: Fatura ve yurt ödemeleri

## 🛠️ Teknolojiler

- **Backend**: ASP.NET Core 8.0 Web API
- **Frontend**: ASP.NET Core MVC
- **Veritabanı**: SQL Server + Entity Framework Core 8.0
- **Kimlik Doğrulama**: JWT Bearer Authentication
- **Şifreleme**: BCrypt.Net
- **E-posta**: MailKit

## 📦 Proje Yapısı

```
VehaBank/
├── VEHABANK.WebApi/      # REST API katmanı
│   ├── Controllers/      # API Controller'lar
│   ├── Entities/        # Veritabanı modelleri
│   ├── Context/         # EF Core DbContext
│   ├── Dto/             # Data Transfer Objects
│   └── Service/         # İş mantığı servisleri
├── VEHABANK.WebUI/      # MVC Web uygulaması
│   ├── Controllers/     # MVC Controller'lar
│   ├── Views/           # Razor View'lar
│   ├── Models/          # View modelleri
│   └── ViewComponents/  # Yeniden kullanılabilir bileşenler
└── Shared/              # Paylaşılan DTO'lar
```

## ⚙️ Kurulum

### Gereksinimler
- .NET 8.0 SDK
- SQL Server
- Visual Studio 2022 (önerilen)

### Adımlar

1. Projeyi klonlayın:
```bash
git clone https://github.com/veyselonguc/Internet-Banking.git
cd Internet-Banking/VehaBank
```

2. Veritabanı bağlantı dizesini güncelleyin (`appsettings.json`):
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=VehaBankDB;Trusted_Connection=True;"
}
```

3. Veritabanını oluşturun:
```bash
dotnet ef database update --project VEHABANK.WebApi
```

4. Uygulamayı çalıştırın:
```bash
dotnet run --project VEHABANK.WebApi
dotnet run --project VEHABANK.WebUI
```

## 🔐 Güvenlik

- **JWT Token** bazlı kimlik doğrulama
- **BCrypt** ile şifre hashleme
- **Role-based** yetkilendirme (Admin, BankTeller, Customer)
- E-posta doğrulama sistemi

## 👥 Roller ve Yetkiler

| Rol | Yetkiler |
|-----|----------|
| **Yönetici** | Şube yönetimi, çalışan ekleme/düzenleme, tüm işlemler |
| **Gişe Yetkilisi** | Hesap onaylama, kart kilidi açma, işlem müdahale |
| **Müşteri** | Para transferi, ödeme, hesap görüntüleme |

## 📸 Ekran Görüntüleri
<img width="1891" height="881" alt="Ekran görüntüsü 2025-05-31 131455" src="https://github.com/user-attachments/assets/bf52b474-7827-473e-9abc-67839c1f5d0a" />
<img width="1910" height="885" alt="Ekran görüntüsü 2025-05-31 131522" src="https://github.com/user-attachments/assets/c703a308-4250-4530-b797-b17d01f1c860" />
<img width="1896" height="881" alt="Ekran görüntüsü 2025-05-31 132002" src="https://github.com/user-attachments/assets/36383d1f-99a1-4396-9bd1-077fd6b825d8" />
<img width="1893" height="884" alt="Ekran görüntüsü 2025-05-31 132037" src="https://github.com/user-attachments/assets/7f3f252e-f8b1-4872-aa0b-3a9e1282cbf5" />


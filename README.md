# PreferenceRobot

PreferenceRobot projesi, .NET Core ile ilgili yeni öğrenilen bilgilerin test edilip ileride kullanılması ve destek alınması amacını taşımaktadır. Projede öncelikle bir ASP.NET Core Web API kullanılmıştır. Bu API, çeşitli istemcilerle (web, mobil, masaüstü uygulamaları vb.) iletişim kurmak için kullanılır.

## Kullanılan Teknolojiler

- **ASP.NET Core:** Web API'lerin hızlı ve verimli bir şekilde geliştirilmesini sağlayan bir framework.
- **Web API:** HTTP protokolü üzerinden istemcilerle iletişim kurmak için kullanılan bir protokol.
- **AutoMapper:** Nesne eşleme kütüphanesi. Nesneler arasında veri aktarımını kolaylaştırır.
- **Identity:** Kimlik doğrulama ve yetkilendirme sistemleri için bir çerçeve.
- **JWT (JSON Web Token):** Kimlik doğrulama ve yetkilendirme süreçlerinde kullanılan bir standart.
- **CQRS (Command Query Responsibility Segregation):** Komut sorgu sorumluluğu ayrımı, yazma ve okuma işlemlerini ayrı işlemeler olarak ele almayı sağlayan bir tasarım deseni.
- **Onion Architecture:** Katmanlı mimari yaklaşımı. Kodun katmanlara ayrılmasını ve bağımlılıkların tersine çevrilmesini sağlar.
- **Mail Service:** E-posta gönderimi için kullanılan bir hizmet.
- **Logger (Seq ile):** Loglama işlevselliği sağlayan bir kütüphane. Logların daha detaylı bir şekilde görüntülenmesi için Seq kullanılmaktadır.
- **Veritabanı (MS SQL Server):** İlişkisel veritabanı yönetim sistemi.

## Gereksinimler

- .NET Core SDK'sının yüklü olması gereklidir.
- Bir IDE (Visual Studio, Visual Studio Code) veya tercih ettiğiniz bir metin düzenleyici.
- MS SQL Server veritabanı sunucusuna erişim.


# SimpraOdev

Bu proje, .NET Core Web API kullanılarak geliştirilmiş bir örnektir. Aşağıda, projenin nasıl çalıştırılacağına dair gerekli adımları bulabilirsiniz.

## Başlangıç

Bu talimatlar, projeyi yerel bir makinede geliştirme ve test amacıyla çalıştırmak için size rehberlik edecektir.

### Kurulum

1. `DBContext.cs` dosyasını açın ve veritabanı bağlantı dizesini güncelleyin:

optionsBuilder.UseSqlServer("server=your-server;database=your-database;integrated security=true;");


Kullanım
API'yi test etmek için herhangi bir API istemcisi kullanabilirsiniz. Örneğin, Postman veya Swagger gibi araçları tercih edebilirsiniz. Aşağıda bazı temel isteklerin örnekleri bulunmaktadır:

Tüm personelleri getirmek için GET isteği:

GET https://localhost:5001/api/staff

Bir personele ID ile erişmek için GET isteği:

GET https://localhost:5001/api/staff/{id}

Yeni bir personel eklemek için POST isteği:


POST https://localhost:5001/api/staff

```
{
  "firstName": "John",
  "lastName": "Doe",
  "email": "johndoe@example.com",
  "phone": "555-1234567",
  "dateOfBirth": "1980-01-01",
  "addressLine1": "123 Main St",
  "city": "New York",
  "country": "USA",
  "province": "NY"
}
```
Bir personeli güncellemek için PUT isteği:
PUT https://localhost:5001/api/staff/{id}
```
{
  "createdBy": "string",
  "createdAt": "2023-05-18T19:27:55.324Z",
  "firstName": "string",
  "lastName": "string",
  "email": "string",
  "phone": "string",
  "dateOfBirth": "2023-05-18T19:27:55.324Z",
  "addressLine1": "string",
  "city": "string",
  "country": "string",
  "province": "string"
}
```
Bir personeli silmek için DELETE isteği:

DELETE https://localhost:5001/api/staff/{id}

Personelleri filtrelemek için GET isteği : 
GET https://localhost:5001/api/staff/filter
```
{
"city" : "Antalya",
"country" : Turkey"
}
```


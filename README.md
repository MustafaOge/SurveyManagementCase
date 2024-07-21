# Anket Yönetim Sistemi

Bu proje, anketlerin, soruların ve cevapların yönetildiği bir Anket Yönetim Sistemi'dir. Bu sistem, kullanıcıların yeni anketler oluşturmasına, mevcut anketleri güncellemesine, soruları ve cevapları yönetmesine olanak tanır.

## Teknolojiler
- .NET Core
- Entity Framework Core
- RabbitMQ MassTransit
- CQRS (Command Query Responsibility Segregation)
- AutoMapper, FluentValidation

## API Endpoint'leri

### Answer API

- **POST /api/v1/Answer**: Yeni bir cevap oluşturur.
- **GET /api/v1/Answer**: Tüm cevapları listeler.
- **PUT /api/v1/Answer/{id}**: Belirtilen ID'ye sahip cevabı günceller.
- **DELETE /api/v1/Answer/{id}**: Belirtilen ID'ye sahip cevabı siler.
- **GET /api/v1/Answer/{id}**: Belirtilen ID'ye sahip cevabın detaylarını getirir.

### Questions API

- **POST /api/v1/Questions**: Yeni bir soru oluşturur.
- **GET /api/v1/Questions**: Tüm soruları listeler.
- **PUT /api/v1/Questions/{id}**: Belirtilen ID'ye sahip soruyu günceller.
- **DELETE /api/v1/Questions/{id}**: Belirtilen ID'ye sahip soruyu siler.
- **GET /api/v1/Questions/{id}**: Belirtilen ID'ye sahip sorunun detaylarını getirir.

### Surveys API

- **POST /api/v1/Surveys**: Yeni bir anket oluşturur.
- **GET /api/v1/Surveys**: Tüm anketleri listeler.
- **PUT /api/v1/Surveys/{id}**: Belirtilen ID'ye sahip anketi günceller.
- **DELETE /api/v1/Surveys/{id}**: Belirtilen ID'ye sahip anketi siler.
- **GET /api/v1/Surveys/{id}**: Belirtilen ID'ye sahip anketin detaylarını getirir.

## Swagger Dokümantasyonu
Swagger ile API'yi keşfetmek ve test etmek için [Swagger UI](https://senswisecase.mustafaoge.com/swagger) sayfasını ziyaret edebilirsiniz.

## Postman Koleksiyonu

Postman Koleksiyonu: [Download Link](https://github.com/MustafaOge/SurveyManagementCase/releases/download/V1/Survey.Managment.API.postman_collection.json)

API'yi test etmek için bu Postman koleksiyonunu kullanabilirsiniz. Koleksiyonu indirin ve Postman uygulamasında içe aktarın.

## Database Diagram
![SurveyDb](https://github.com/user-attachments/assets/8b2b59cd-7a6d-49f6-89f5-dadfb4ec5ab7)


# CollegeWebApi

ASP.NET Core Web API для работы с базой CollegeDB (студенты и группы).  
Использует Dapper + Microsoft.Data.SqlClient.

## Связанный проект

Данные и структура базы взяты из консольного приложения:  
[https://github.com/xenimini/CollegeDB-ADO.NET](https://github.com/xenimini/CollegeDB-ADO.NET)

## Как запустить

1. Убедись, что запущен SQL Server Express и существует база `CollegeDB`.
2. Открой решение в Visual Studio.
3. Проверь строку подключения в `StudentsController.cs`.
4. Нажми F5 — откроется Swagger.

## Эндпоинты

- `GET /api/Students` — список всех студентов
- `GET /api/Students/hello` — тестовое сообщение

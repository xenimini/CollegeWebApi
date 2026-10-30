# CollegeWebApi

ASP.NET Core Web API + Entity Framework Core для работы с базой CollegeDB (студенты и группы).

## Связанный проект

Консольная версия:  
https://github.com/xenimini/CollegeDB-ADO.NET

## Как запустить

1. Убедись, что запущен SQL Server Express и существует база `CollegeDB`.
2. Открой решение в Visual Studio.
3. Нажми **F5**.

## Страница

После запуска открой:

https://localhost:7104/index.html

(порт может отличаться — смотри в консоли Visual Studio)

## Эндпоинты

- `GET /students/all` — все студенты
- `GET /groups/all` — все группы
- `POST /students/add` — добавить студента
- `POST /groups/add` — добавить группу
- `PUT /students/{id}` — обновить студента
- `DELETE /students/{id}` — удалить студента
- `DELETE /groups/{id}` — удалить группу

## Технологии

- ASP.NET Core
- Entity Framework Core
- SQL Server Express

# Todo App (Windows Forms)

Приложение для ведения списка задач с категориями, приоритетами и сроками.

## Технологии

- .NET Framework 4.8
- Windows Forms
- PostgreSQL
- Npgsql (ADO.NET)

## Настройка перед запуском

1. Создайте базу данных в PostgreSQL:

```sql
CREATE DATABASE Todo;
```

2. Укажите настройки соединения с базой данных в App.config:
```xml
<connectionStrings>
  <add name="DefaultConnection"
     connectionString="Host=localhost;Port=5432;Database=Todo;Username=postgres;Password=postgres"
     providerName="Npgsql" 
  />
</connectionStrings>
```
3. Запустите приложение. Таблицы и индексы создадутся автоматически.

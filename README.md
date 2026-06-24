# 🥗 SmartFridge API

> REST API серверная часть приложения **Умный холодильник** — системы управления продуктами, питанием и рецептами.

![C#](https://img.shields.io/badge/C%23-ASP.NET_Core-512BD4?logo=dotnet)
![REST API](https://img.shields.io/badge/API-REST-blue)
![Status](https://img.shields.io/badge/status-completed-green)

---

## 📋 О проекте

SmartFridge API — это серверная часть мобильного приложения умного холодильника.  
Позволяет пользователям управлять продуктами в холодильнике, вести дневник питания, составлять списки покупок и получать рецепты на основе имеющихся продуктов.

Реализована интеграция с внешним API **FatSecret** для получения информации о калорийности продуктов.

---

## ⚡ Функциональность

| Модуль | Описание |
|---|---|
| 🧊 **Fridge** | Управление продуктами в холодильнике (CRUD) |
| 📒 **Food Diary** | Дневник питания — учёт потреблённых продуктов |
| 🛒 **Lists** | Списки покупок |
| 🍽 **Recipes** | Рецепты на основе имеющихся продуктов |
| 👤 **User** | Управление пользователями |
| 🔗 **FatSecret** | Интеграция с внешним API для данных о питательности |
| 🧾 **ProverkaCheka** | Сканирование и проверка чеков |

---

## 🛠 Технологии

- **C# / ASP.NET Core** — серверный фреймворк
- **REST API** — HTTP-взаимодействие с клиентом
- **FatSecret API** — внешний сервис данных о питании
- **Entity Framework / ADO.NET** — работа с базой данных

---

## 📁 Структура проекта

```
SmartFridgeAPI/
├── Controllers/          # REST-контроллеры
│   ├── FridgeController.cs
│   ├── FoodDiaryController.cs
│   ├── ListsController.cs
│   ├── RecipesController.cs
│   └── UserController.cs
├── Models/               # Модели данных
├── DataBaseManagement/   # Работа с базой данных
├── FatSecretApi/         # Интеграция с FatSecret API
├── ProverkaCheka/        # Модуль проверки чеков
└── Program.cs            # Точка входа
```

---

## 🚀 Запуск проекта

### Требования
- .NET 8 SDK
- Visual Studio 2022 / Rider

### Установка

```bash
# Клонировать репозиторий
git clone https://github.com/lera328/SmartFridgeAPI.git
cd SmartFridgeAPI

# Запустить
dotnet run
```

API будет доступен по адресу: `https://localhost:7000`  
Swagger документация: `https://localhost:7000/swagger`

---

## 📡 Основные эндпоинты

```
GET    /api/fridge          — Получить все продукты в холодильнике
POST   /api/fridge          — Добавить продукт
DELETE /api/fridge/{id}     — Удалить продукт

GET    /api/recipes         — Получить рецепты по продуктам
GET    /api/lists           — Списки покупок
POST   /api/fooddiary       — Добавить запись в дневник питания
```

---

## 📱 Мобильный клиент

Мобильное приложение (Android, Kotlin): [SmartFridge](https://github.com/lera328/SmartFridge)

---

## 👩‍💻 Автор

**Валерия Шульгина** — [github.com/lera328](https://github.com/lera328)  
Учебный проект, ОмГТУ, Программная инженерия

# School - Лабораторна робота 1

## Опис проєкту

Цей проєкт демонструє об'єктно-орієнтоване програмування на C# з використанням моделі школи.

## Структура рішення

### School.Common
Бібліотека класів, що містить:
- **Базові класи та наслідування:**
  - `Person` - базовий клас для персон
  - `Student : Person` - клас студента
  - `Teacher : Person` - клас викладача
  - `Course` - клас курсу
  - `Grade` - клас оцінки

### School.Console
Консольний застосунок, що демонструє роботу CRUD сервісу.

## Реалізовані конструкції

✅ **Конструктори** - у всіх класах (за замовчуванням та з параметрами)
✅ **Методи** - бізнес-логіка (CalculateAge, GetFullName, Enroll, тощо)
✅ **Статичні поля** - _totalPersonsCreated, MinimumSalary
✅ **Статичні конструктори** - ініціалізація статичних даних
✅ **Статичні методи** - GetTotalPersonsCreated, CalculateAnnualSalary
✅ **Делегати** - PersonEventHandler, GradeEventHandler
✅ **Події** - StudentEnrolled, GradeAssigned
✅ **Методи розширення** - GetInitials, GetStudentSummary, ToTitleCase

## CRUD Сервіс

Реалізовано generic CRUD сервіс `CrudService<T>` з інтерфейсом `ICrudService<T>`:
- `Create(T element)` - створення нового елемента
- `Read(Guid id)` - читання елемента за ID
- `ReadAll()` - читання всіх елементів
- `Update(T element)` - оновлення елемента
- `Remove(T element)` - видалення елемента

## Як побудувати та запустити

### Варіант 1: Через Visual Studio
1. Відкрийте `School.sln` у Visual Studio
2. Натисніть F5 або Ctrl+F5 для запуску

### Варіант 2: Через командний рядок
```cmd
cd "C:\Users\kawau\OneDrive\Рабочий стол\dotnet\lab1"
dotnet build School.sln
dotnet run --project School.Console\School.Console.csproj
```

### Варіант 3: Через PowerShell (якщо є проблеми з кодуванням)
```powershell
cd "C:\Users\kawau\OneDrive\Рабочий стол\dotnet\lab1"
& dotnet build School.sln
& dotnet run --project School.Console\School.Console.csproj
```

## Що демонструє програма

1. Створення CRUD сервісів для Student, Teacher, Course, Grade
2. Створення об'єктів (викладачі, студенти, курси)
3. Виведення всіх об'єктів
4. Читання конкретного об'єкта за ID
5. Оновлення об'єктів (збільшення зарплати, оновлення GPA)
6. Створення та призначення оцінок
7. Видалення об'єктів
8. Демонстрація статичних методів
9. Демонстрація методів розширення
10. Демонстрація подій (StudentEnrolled, GradeAssigned)

## Структура файлів

```
School/
├── School.sln
├── School.Common/
│   ├── Person.cs (базовий клас)
│   ├── Student.cs (наслідується від Person)
│   ├── Teacher.cs (наслідується від Person)
│   ├── Course.cs
│   ├── Grade.cs
│   ├── PersonExtensions.cs (методи розширення)
│   ├── ICrudService.cs (інтерфейс)
│   ├── CrudService.cs (generic реалізація)
│   └── School.Common.csproj
└── School.Console/
    ├── Program.cs (демонстрація)
    └── School.Console.csproj
```

## Використані технології

- .NET 8.0
- C# 12
- Generic Types
- LINQ
- Events and Delegates
- Extension Methods

## Автор

Лабораторна робота 1 - ООП на C#


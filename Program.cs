using EFTemplate.Data;
using EFTemplate.Demos;

Console.Title = "Автосервис — Введение в Entity Framework Core";

using (var db = new AppDbContext())
{
    // Каждый запуск полностью пересоздаёт базу SQLite с нуля
    DbInitializer.ResetAndSeed(db);

    // 1. Демонстрация CRUD
    CrudOperations.Run(db);

    // 2. Демонстрация Change Tracker (состояния объектов)
    ChangeTracker.Run(db);

    // 3. Демонстрация связей и каскадного удаления
    RelationshipsDemo.Run(db);
}

Console.WriteLine("\nНажмите любую клавишу для завершения...");
Console.ReadKey();
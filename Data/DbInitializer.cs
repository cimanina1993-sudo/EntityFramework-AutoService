using EFTemplate.Models;

namespace EFTemplate.Data;

public static class DbInitializer
{
    public static void ResetAndSeed(AppDbContext context)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n[БАЗА ДАННЫХ] Удаление старой версии SQLite...");

        context.Database.EnsureDeleted();

        Console.WriteLine("[БАЗА ДАННЫХ] Создание чистой структуры по текущим моделям...");
        context.Database.EnsureCreated();
        Console.ResetColor();

        // --- Клиенты ---
        var client1 = new Client
        {
            FullName = "Иванов Иван Иванович",
            Phone = "+7-900-111-22-33",
            Email = "ivanov@mail.ru"
        };

        var client2 = new Client
        {
            FullName = "Петров Пётр Петрович",
            Phone = "+7-900-222-33-44",
            Email = "petrov@mail.ru"
        };

        // --- Автомобили с сервисными книжками (связь 1-к-1) ---
        var car1 = new Car
        {
            Brand = "Toyota",
            Model = "Camry",
            Year = 2020,
            LicensePlate = "А123ВС77",
            Client = client1,
            ServiceBook = new ServiceBook
            {
                LastServiceDate = DateTime.Now.AddMonths(-3),
                NextServiceDate = DateTime.Now.AddMonths(3),
                Notes = "Плановое ТО пройдено"
            }
        };

        var car2 = new Car
        {
            Brand = "BMW",
            Model = "X5",
            Year = 2018,
            LicensePlate = "В456ЕК99",
            Client = client1,
            ServiceBook = new ServiceBook
            {
                LastServiceDate = DateTime.Now.AddMonths(-1),
                NextServiceDate = DateTime.Now.AddMonths(5),
                Notes = "Замена масла"
            }
        };

        var car3 = new Car
        {
            Brand = "Lada",
            Model = "Vesta",
            Year = 2015,
            LicensePlate = "С789МН50",
            Client = client2,
            ServiceBook = new ServiceBook
            {
                LastServiceDate = DateTime.Now.AddMonths(-6),
                NextServiceDate = DateTime.Now,
                Notes = "Требуется диагностика"
            }
        };

        context.Clients.AddRange(client1, client2);
        context.Cars.AddRange(car1, car2, car3);

        context.SaveChanges();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("[БАЗА ДАННЫХ] База успешно пересоздана и наполнена!\n");
        Console.ResetColor();
    }
}
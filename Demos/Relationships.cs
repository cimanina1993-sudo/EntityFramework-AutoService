using EFTemplate.Data;
using EFTemplate.Models;
using Microsoft.EntityFrameworkCore;

namespace EFTemplate.Demos;

public static class RelationshipsDemo
{
    public static void Run(AppDbContext db)
    {
        Console.WriteLine("\n3. СВЯЗИ И КАСКАДНОЕ УДАЛЕНИЕ");

        var newClient = new Client
        {
            FullName = "Временный Клиент",
            Phone = "+7-000-000-00-00",
            Cars = new List<Car>
            {
                new Car
                {
                    Brand = "Ford",
                    Model = "Focus",
                    Year = 2012,
                    LicensePlate = "К654РС77",
                    ServiceBook = new ServiceBook
                    {
                        Notes = "Временная запись"
                    }
                }
            }
        };

        db.Clients.Add(newClient);
        db.SaveChanges();
        Console.WriteLine($"Клиент '{newClient.FullName}' создан с автомобилем и сервисной книжкой.");

        Console.WriteLine("\n--> Удаляем клиента 'Временный Клиент'...");
        db.Clients.Remove(newClient);
        db.SaveChanges();

        var orphanCar = db.Cars.FirstOrDefault(c => c.LicensePlate == "К654РС77");
        var orphanBook = db.ServiceBooks.FirstOrDefault(b => b.Notes == "Временная запись");

        Console.WriteLine($"Автомобиль после удаления клиента найден в базе? -> {(orphanCar != null ? "ДА" : "НЕТ (удалён каскадно)")}");
        Console.WriteLine($"Сервисная книжка после удаления клиента найдена в базе? -> {(orphanBook != null ? "ДА" : "НЕТ (удалена каскадно)")}");
    }
}
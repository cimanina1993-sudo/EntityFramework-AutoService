using EFTemplate.Data;
using EFTemplate.Models;

namespace EFTemplate.Demos;

public static class CrudOperations
{
    public static void Run(AppDbContext db)
    {
        Console.WriteLine("1. БАЗОВЫЙ CRUD");

        // --- CREATE ---
        Console.WriteLine("\n--> Добавляем нового клиента...");
        var newClient = new Client
        {
            FullName = "Сидоров Сергей Сергеевич",
            Phone = "+7-900-333-44-55",
            Email = "sidorov@mail.ru"
        };
        db.Clients.Add(newClient);
        db.SaveChanges();
        Console.WriteLine($"Клиент добавлен с Id: {newClient.Id}");

        // --- READ (по первичному ключу) ---
        Console.WriteLine("\n--> Поиск клиента через Find (по Id)...");
        var client = db.Clients.Find(newClient.Id);
        Console.WriteLine($"Найден: {client?.FullName}, телефон: {client?.Phone}");

        // --- UPDATE ---
        Console.WriteLine("\n--> Меняем телефон клиента...");
        if (client != null)
        {
            client.Phone = "+7-900-999-88-77";
            db.SaveChanges();
            Console.WriteLine("Телефон успешно обновлён в базе.");
        }

        // --- DELETE ---
        Console.WriteLine("\n--> Удаляем созданного клиента...");
        if (client != null)
        {
            db.Clients.Remove(client);
            db.SaveChanges();
            Console.WriteLine("Клиент удалён из базы.");
        }
    }
}
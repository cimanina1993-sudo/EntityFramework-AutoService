using EFTemplate.Data;
using EFTemplate.Models;

namespace EFTemplate.Demos;

public static class ChangeTracker
{
    public static void Run(AppDbContext db)
    {
        Console.WriteLine("\n2. CHANGE TRACKER (ТРЕКЕР СОСТОЯНИЙ)");

        var car = new Car
        {
            Brand = "Kia",
            Model = "Rio",
            Year = 2021,
            LicensePlate = "Е321ОР78",
            ClientId = 1
        };

        Console.WriteLine($"1. Новый объект в памяти: State = {db.Entry(car).State}");

        db.Cars.Add(car);
        Console.WriteLine($"2. После db.Cars.Add(): State = {db.Entry(car).State}");

        db.SaveChanges();
        Console.WriteLine($"3. После db.SaveChanges(): State = {db.Entry(car).State}");

        car.Year = 2022;
        Console.WriteLine($"4. Изменили свойство в коде: State = {db.Entry(car).State}");

        db.Cars.Remove(car);
        Console.WriteLine($"5. После db.Cars.Remove(): State = {db.Entry(car).State}");

        db.SaveChanges();
        Console.WriteLine($"6. После удаления и SaveChanges(): State = {db.Entry(car).State}");
    }
}
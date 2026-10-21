namespace EFTemplate.Models;

public class ServiceBook
{
    public int Id { get; set; }
    public DateTime LastServiceDate { get; set; } = DateTime.Now;
    public DateTime NextServiceDate { get; set; } = DateTime.Now.AddMonths(6);
    public string Notes { get; set; } = string.Empty;

    // Внешний ключ: книжка принадлежит конкретному автомобилю
    public int CarId { get; set; }
    public Car? Car { get; set; }
}
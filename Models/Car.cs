namespace EFTemplate.Models;

public class Car
{
    public int Id { get; set; }
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public string LicensePlate { get; set; } = string.Empty;

    // Внешний ключ и связь с клиентом (многие к одному)
    public int ClientId { get; set; }
    public Client? Client { get; set; }

    // Связь один-к-одному с сервисной книжкой
    public ServiceBook? ServiceBook { get; set; }
}
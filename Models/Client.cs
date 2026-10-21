using System.Runtime.ConstrainedExecution;

namespace EFTemplate.Models;

public class Client
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    // Один ко многим: у клиента много автомобилей
    public List<Car> Cars { get; set; } = new();
}
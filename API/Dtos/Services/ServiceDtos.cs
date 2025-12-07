namespace API.Dtos.Service;

public class ServiceResponse
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public int DurationMinutes { get; set; }
    public decimal Price { get; set; }
}

public class CreateServiceDto
{
    public int CompanyId { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public int DurationMinutes { get; set; }
    public decimal Price { get; set; }
}

public class UpdateServiceDto : CreateServiceDto
{
    public int Id { get; set; }
}

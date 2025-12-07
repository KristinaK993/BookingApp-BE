using API.Data;
using API.Dtos.Service;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services;

public class ServiceManager : IServiceManager
{
    private readonly AppDbContext _db;

    public ServiceManager(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<ServiceResponse>> GetAllAsync()
    {
        return await _db.Services
            .OrderBy(s => s.Name)
            .Select(s => new ServiceResponse
            {
                Id = s.Id,
                CompanyId = s.CompanyId,
                Name = s.Name,
                Description = s.Description,
                DurationMinutes = s.DurationMinutes,
                Price = s.Price
            })
            .ToListAsync();
    }

    public async Task<ServiceResponse?> GetByIdAsync(int id)
    {
        return await _db.Services
            .Where(s => s.Id == id)
            .Select(s => new ServiceResponse
            {
                Id = s.Id,
                CompanyId = s.CompanyId,
                Name = s.Name,
                Description = s.Description,
                DurationMinutes = s.DurationMinutes,
                Price = s.Price
            })
            .FirstOrDefaultAsync();
    }

    public async Task<ServiceResponse> CreateAsync(CreateServiceDto dto)
    {
        var service = new Service
        {
            CompanyId = dto.CompanyId,
            Name = dto.Name,
            Description = dto.Description,
            DurationMinutes = dto.DurationMinutes,
            Price = dto.Price
        };

        _db.Services.Add(service);
        await _db.SaveChangesAsync();

        return (await GetByIdAsync(service.Id))!;
    }

    public async Task<ServiceResponse?> UpdateAsync(int id, UpdateServiceDto dto)
    {
        if (id != dto.Id)
            return null;

        var service = await _db.Services.FindAsync(id);
        if (service == null)
            return null;

        service.CompanyId = dto.CompanyId;
        service.Name = dto.Name;
        service.Description = dto.Description;
        service.DurationMinutes = dto.DurationMinutes;
        service.Price = dto.Price;

        await _db.SaveChangesAsync();

        return await GetByIdAsync(id);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var service = await _db.Services.FindAsync(id);
        if (service == null)
            return false;

        _db.Services.Remove(service);
        await _db.SaveChangesAsync();
        return true;
    }
}


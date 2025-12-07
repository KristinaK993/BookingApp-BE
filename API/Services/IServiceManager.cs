using API.Dtos.Service;

namespace API.Services;

public interface IServiceManager
{
    Task<List<ServiceResponse>> GetAllAsync();
    Task<ServiceResponse?> GetByIdAsync(int id);
    Task<ServiceResponse> CreateAsync(CreateServiceDto dto);
    Task<ServiceResponse?> UpdateAsync(int id, UpdateServiceDto dto);
    Task<bool> DeleteAsync(int id);
}

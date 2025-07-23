using Management.EF.Models;

namespace Management.EF.Services.Contracts
{
    public interface IAdminService
    {
        Task<(bool Success, Admins? Admins, string? Error)> RegisterAsync(Admins admins);
        Task<(bool Success, Admins? Admins, string? Error)> GetByIdAsync(Guid id);
        Task<(bool Success, Admins? Admins, string? Error)> GetByEmailAsync(string? email);
        Task<List<Admins>> GetAllAsync();
        Task<(bool Success, Admins? Admins, string? Error)> UpdateAsync(Admins admin);
        Task<(bool Success, Admins? Admins, string? Error)> DeleteByIdAsync(Guid id);

    }
}

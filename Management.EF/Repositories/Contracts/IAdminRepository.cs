using Management.EF.Models;

namespace Management.EF.Repositories.Contracts
{
    public interface IAdminRepository
    {
        Task<Admins?> CreateAdminAsync(Admins admin);
        Task<Admins?> GetAdminByIdAsync(Guid id);
        Task<Admins?> GetAdminByEmailAsync(string email);
        Task<List<Admins>> GetAllAdminsAsync(); //Use null pointer exception to return error if empty/null
        Task<Admins?> UpdateAdminsAsync(Admins admin);
        Task<bool> DeleteAdminByIdAsync(Guid id);

        //Might be useless.
        //Task<bool> DeleteAdminAsync(Admins admin);
    }
}

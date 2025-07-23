using Management.EF.Repositories.Contracts;
using Management.EF.Models;
using Management.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace Management.EF.Repositories
{
    public class AdminRepository: IAdminRepository
    {
        private readonly SchoolManagementContext _context;
        public AdminRepository(SchoolManagementContext context) 
        {
            _context = context;
        }
        public async Task<Admins?> CreateAdminAsync(Admins admin) 
        {
            await _context.AddAsync(admin);
            var result = await _context.SaveChangesAsync(); //returns how many entities were added

            return result > 0 ? admin : null; //if result is zero then return null otherwise return result. 
        }
        public async Task<Admins?> GetAdminByIdAsync(Guid id) => await _context.Admins.FindAsync(id);
        public async Task<Admins?> GetAdminByEmailAsync(string email) => await _context.Admins.FirstOrDefaultAsync(e => e.Email == email);
        public async Task<List<Admins>> GetAllAdminsAsync() => await _context.Admins.ToListAsync();
        public async Task<Admins?> UpdateAdminsAsync(Admins admin)
        {
            var getAdmin = await _context.Admins.FirstOrDefaultAsync(e => e.AdminId == admin.AdminId);

            if (getAdmin != null)
            {
                getAdmin.Email = admin.Email;
                getAdmin.Password_Hash = admin.Password_Hash;
                getAdmin.FirstName = admin.FirstName;
                getAdmin.MiddleName = admin.MiddleName;
                getAdmin.LastName = admin.LastName;
                getAdmin.Role = admin.Role;

                try 
                {
                    await _context.SaveChangesAsync();
                    return getAdmin;
                }
                catch (Exception ex) { throw new InvalidOperationException($"Could not update account. Error: {ex.Message} "); }
            }

            return null;
        }
        public async Task<bool> DeleteAdminByIdAsync(Guid id) //This you might need to pass the object than the id or make a separate method
        {
            var admin = await _context.Admins.FindAsync(id);

            if (admin != null) 
            {
                _context.Remove(admin);
                await _context.SaveChangesAsync();

                return true;
            }

            return true;
        }
    }
}

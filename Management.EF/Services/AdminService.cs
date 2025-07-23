using Management.EF.Models;
using Management.EF.Repositories;
using Management.EF.Repositories.Contracts;
using Management.EF.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Management.EF.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _repository;
        public AdminService(IAdminRepository repository)
        {
            _repository = repository;
        }

        public async Task<(bool Success, Admins? Admin, string? Error)> RegisterAsync(Admins admin)
        {
            try
            {
                var result = await _repository.CreateAdminAsync(admin);
                return (true, result, "");
            }
            catch (DbUpdateException dbEx)
            {
                //Database Exception
                return (false, null, "Database error during admin creation.");
            }
            catch (Exception ex)
            {
                //Unexpected Error
                return (false, null, "Unexpected error occurred.");
            }
        }
        public async Task<(bool Success, Admins? Admin, string? Error)> GetByIdAsync(Guid id)
        {
            try
            {
                var result = await _repository.GetAdminByIdAsync(id);
                return (true, result, "");
            }
            catch (DbUpdateException dbEx)
            {
                return (false, null, "Database error while retrieving admin");
            }
            catch (DbException ex)
            {
                return (false, null, "Unexpected error occured.");
            }
        }
        public async Task<(bool Success, Admins? Admin, string Error)> GetByEmailAsync(string email)
        {
            try
            {
                var result = await _repository.GetAdminByEmailAsync(email);
                return (true, result, "");
            }
            catch (Db)
        }
        }
    }

using System.ComponentModel.DataAnnotations;

namespace Management.EF.Models
{
    public class Admins
    {
        [Key]
        public Guid AdminId { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password_Hash { get; set; }

        [Required]
        public string? FirstName { get; set; }

        public string? MiddleName { get; set; }

        [Required]
        public string? LastName { get; set; }

        //Roles Ex: Super Admin, Manager, Agent
        [Required]
        public string? Role { get; set; }

        public Admins(Guid id, string email, string pass_hash, string first, string middle, string last, string role)
        {
            AdminId = id;
            Email = email;
            Password_Hash = pass_hash;
            FirstName = first;
            MiddleName = middle;
            LastName = last;
            Role = role;
        }

        public Admins() { }
    }
}

using System.ComponentModel.DataAnnotations;

namespace SGBenefic.API.Models
{
    public class User
    {
        public User() { }
        public User(int id,
                     string name,
                     string email,
                     string password,
                     string role)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.Password = password;
            this.Role = role;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Role { get; set; } = "operador"; //admin, supervisor, operador
    }
}

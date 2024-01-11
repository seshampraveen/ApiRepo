using System.ComponentModel.DataAnnotations;

namespace Api.Entites
{
    public class AppUser
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string PasswordHash { get; set; }
        public string passwordSalt { get; set; }
    }
}

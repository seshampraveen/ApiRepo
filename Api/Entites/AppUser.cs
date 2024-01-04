using System.ComponentModel.DataAnnotations;

namespace Api.Entites
{
    public class AppUser
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

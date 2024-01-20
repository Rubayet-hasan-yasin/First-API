using System.ComponentModel.DataAnnotations;

namespace FirstAPI.Model
{
    public class User
    {
        public required string UserName {  get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}

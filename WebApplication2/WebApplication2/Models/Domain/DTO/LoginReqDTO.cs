using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models.Domain.DTO
{
    public class LoginReqDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }
        
        [Required] 
        [DataType(DataType.Password)]
        public string Password { get; set; }
    
    
    
    }
}

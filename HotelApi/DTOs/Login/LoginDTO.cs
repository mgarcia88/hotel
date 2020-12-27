using System.ComponentModel.DataAnnotations;

namespace HotelApi.DTOs.Login
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "O campo login é obrigatório")]
        public string Login { get; set; }
        
        [Required(ErrorMessage = "O campo senha é obrigatório")]
        public string Senha { get; set; }
    }
}
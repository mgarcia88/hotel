using System.ComponentModel.DataAnnotations;
using HotelApi.ValueObjects;

namespace HotelApi.DTOs.Usuario
{
    public class UsuarioInsercaoDTO
    {
        [Required(ErrorMessage = "O login do usário é obrigatório")]
        [MinLength(4,ErrorMessage = "O login deve conter no mínimo 4 caracteres")]
        [MaxLength(12, ErrorMessage = "O login deve conter no máximo 12 caracteres")]
        public string Login { get; set; }

        [Required(ErrorMessage = "A senha do usário é obrigatória")]
        [MaxLength(10, ErrorMessage = "A senha deve conter no máximo 10 caracteres")]
        [MinLength(8, ErrorMessage = "A senha deve conter no mínimo 8 caracteres")]
        public string Senha { get; set; }

        [EnumDataType(typeof(UsuariosGrupo), ErrorMessage = "Grupo inválido")]
        public UsuariosGrupo UsuarioGrupo { get; set; }
    }
}
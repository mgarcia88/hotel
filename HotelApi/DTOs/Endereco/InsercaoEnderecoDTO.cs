using System.ComponentModel.DataAnnotations;

namespace HotelApi.DTOs.Endereco
{
    public class InsercaoEnderecoDTO
    {
        [Required(ErrorMessage = "O campo Cep é obrigatório")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O campo logradouro é obrigatório")]
        [MaxLength(50, ErrorMessage = "O campo logradouro deve conter no máximo 50 caracteres")]
        public string Logradouro { get; set; }
        
        [Required(ErrorMessage = "O campo número é obrigatório")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "O campo cidade é obrigatório")]
        public int CidadeId { get; set; }

        [MaxLength(30, ErrorMessage = "O campo complemento deve conter no máximo 30 caracteres")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "O campo bairro é obrigatório")]
        [MaxLength(20, ErrorMessage = "O campo bairro deve conter no máximo 20 caracteres")]
        public string Bairro { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using HotelApi.ValueObjects;

namespace HotelApi.DTOs
{
    public class InsercaoClienteDTO
    {
        [Required(ErrorMessage = "O campo nome é obrigatório")] 
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo e-mail é obrigatório")] 
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo documento é obrigatório")] 
        public string Documento { get; set; }
        
        [Required(ErrorMessage = "O campo status é obrigatório")] 
        [EnumDataType(typeof(ClienteStatus), ErrorMessage = "Status inválido")]
        public ClienteStatus ClienteStatus { get; set; }
    }
}
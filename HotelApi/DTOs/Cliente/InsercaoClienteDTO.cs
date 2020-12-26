using System;
using System.ComponentModel.DataAnnotations;
using HotelApi.Dominio.Entidades;
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
        [EnumDataType(typeof(StatusPessoa), ErrorMessage = "Status inválido")]
        public StatusPessoa ClienteStatus { get; set; }

        [Required(ErrorMessage = "O campo telefone celular é obrigatório")] 
        public string TelefoneCelular { get; set; }

        public Endereco Endereco { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using HotelApi.Dominio.Entidades;
using HotelApi.DTOs.Endereco;
using HotelApi.DTOs.Pessoa;
using HotelApi.ValueObjects;

namespace HotelApi.DTOs
{
    public class InsercaoClienteDTO
    {
        public InsercaoPessoaDTO Pessoa { get; set; }
        
        [Required(ErrorMessage = "O campo status é obrigatório")] 
        [EnumDataType(typeof(StatusPessoa), ErrorMessage = "Status inválido")]
        public StatusPessoa ClienteStatus { get; set; }

        [Required(ErrorMessage = "O campo telefone celular é obrigatório")] 
        public string TelefoneCelular { get; set; }

        public InsercaoEnderecoDTO Endereco { get; set; }
    }
}
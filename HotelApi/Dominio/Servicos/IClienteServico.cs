using HotelApi.Dominio.Entidades;
using HotelApi.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotelApi.DTOs.Cliente;

namespace HotelApi.Dominio.Servicos
{
    public interface IClienteServico
    {
        Task<dynamic> InserirCliente(InsercaoClienteDTO insercaoClienteDto);

        List<ListagemClienteDTO> RecuperarClientes();
    }
}
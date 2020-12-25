using HotelApi.Dominio.Entidades;
using HotelApi.DTOs;
using System.Collections.Generic;

namespace HotelApi.Dominio.Servicos
{
    public interface IClienteServico
    {
        Cliente InserirCliente(InsercaoClienteDTO insercaoClienteDto);

        List<ListagemClienteDTO> RecuperarClientes();
    }
}
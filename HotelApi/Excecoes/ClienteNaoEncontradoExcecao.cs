using System;

namespace HotelApi.Excecões
{
    public class ClienteNaoEncontradoExcecao : Exception
    {
        public ClienteNaoEncontradoExcecao()
        {
        }
        
        public ClienteNaoEncontradoExcecao(string message)
            : base(message)
        {
        }
        
        
        public ClienteNaoEncontradoExcecao(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
using System;

namespace HotelApi.Excecões
{
    public class UsuarioNaoEncontradoExceção : Exception
    {
        public UsuarioNaoEncontradoExceção()
        {
        }
        
        public UsuarioNaoEncontradoExceção(string message)
            : base(message)
        {
        }
        
        
        public UsuarioNaoEncontradoExceção(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
using System;

namespace HotelApi.Excecões
{
    public class PessoaJaCadastradaExcecao : Exception
    {
        public PessoaJaCadastradaExcecao()
        {
        }
        
        public PessoaJaCadastradaExcecao(string message)
            : base(message)
        {
        }
        
        
        public PessoaJaCadastradaExcecao(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
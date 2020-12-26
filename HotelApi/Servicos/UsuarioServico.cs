using System;
using HotelApi.Data.UnitOfWork;
using HotelApi.Dominio.Entidades;
using HotelApi.Dominio.Servicos;
using HotelApi.DTOs.Usuario;
using HotelApi.Excecões;

namespace HotelApi.Servicos
{
    public class UsuarioServico : IUsuarioServico
    {
        private IUnitOfWork _unitOfWork;
        private ITokenServico _tokenServico;

        public UsuarioServico(IUnitOfWork unitOfWork, ITokenServico tokenServico)
        {
            _unitOfWork = unitOfWork;
            _tokenServico = tokenServico;
        }

        public Usuario InserirUsuario(UsuarioInsercaoDTO usuarioInsercaoDto)
        {
            var usuario = new Usuario
            {
                Login = usuarioInsercaoDto.Login,
                Senha = usuarioInsercaoDto.Senha,
                UsuariosGrupo = usuarioInsercaoDto.UsuarioGrupo
            };

            usuario = _unitOfWork.UsuarioRepositorio.Incluir(usuario);
            _unitOfWork.Commit();

            return usuario;
        }

        public dynamic AutenticarUsuarioComLogineSenha(string login, string senha)
        {
            var usuario = _unitOfWork.UsuarioRepositorio.
                AutenticarUsuarioComLogineSenha(login, senha).Result;

            if (usuario == null)
            {
                throw new UsuarioNaoEncontradoExceção("Login ou senha inválida");
            }

            var token = _tokenServico.GerarToken(usuario);
            return new
            {
                token = token,
                grupo = usuario.UsuariosGrupo
            };
        }
    }
}
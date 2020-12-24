﻿using HotelApi.ValueObjects;

namespace HotelApi.Dominio.Entidades
{
    public class Usuario : Entidade
    {
        public string Login { get; set; }

        public string Senha { get; set; }
        
        public UsuariosGrupo UsuariosGrupo { get; set; }
    }
}
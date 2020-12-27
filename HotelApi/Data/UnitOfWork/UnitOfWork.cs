using System;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using HotelApi.Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace HotelApi.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _dbContexto;
        private IDbContextTransaction _transaction;
        public IClienteRepositorio ClienteRepositorio { get; }
        public IUsuarioRepositorio UsuarioRepositorio { get; }
        public IPessoaRepositorio PessoaRepositorio { get; }
        public IEnderecoRepositorio EnderecoRepositorio { get; }

        public UnitOfWork(ApplicationContext dbContexto,
            IClienteRepositorio clienteRepositorio,
            IUsuarioRepositorio usuarioRepositorio,
            IEnderecoRepositorio enderecoRepositorio,
            IPessoaRepositorio pessoaRepositorio)
        {
            _dbContexto = dbContexto;
            ClienteRepositorio = clienteRepositorio;
            UsuarioRepositorio = usuarioRepositorio;
            PessoaRepositorio = pessoaRepositorio;
            EnderecoRepositorio = enderecoRepositorio;
        }
        
        public void Commit()
        {
           _dbContexto.SaveChanges();
        }

        public async Task BeginTransaction()
        {
            if (_dbContexto.Database.GetDbConnection().State != ConnectionState.Open)
            {
                _dbContexto.Database.OpenConnection();
            }

            _transaction = await _dbContexto.Database.BeginTransactionAsync();
        }

        public async Task CommitTransaction()
        {
            if (_transaction == null)
            {
                throw new Exception("Transação não iniciada");
            }

            await _dbContexto.SaveChangesAsync();
            await _transaction.CommitAsync();
        }
        public async Task RollbackTransaction()
        {
            if (_transaction == null)
            {
                throw new Exception("Transação não iniciada");
            }

            await _transaction.RollbackAsync();
        }
    }
}
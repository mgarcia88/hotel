using HotelApi.Data;
using HotelApi.Data.Repositorios;
using HotelApi.Data.UnitOfWork;
using HotelApi.Dominio.Entidades;
using HotelApi.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HotelTestes
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var db = new ApplicationContext();
            
            var _iUnitOfWork = 
                new UnitOfWork(db, new ClienteRepositorio(db));
            
            var Cliente = new Cliente
            {
                Nome = "Valter Jr",
                Email = "valter@valter.com.br",
                Documento = "25353240243",
                ClienteStatus = ClienteStatus.Ativo
            };

            _iUnitOfWork.ClienteRepositorio.Incluir(Cliente);
            
            _iUnitOfWork.Commit();
        }
    }
}
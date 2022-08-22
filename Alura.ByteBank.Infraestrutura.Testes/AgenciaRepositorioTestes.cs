using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Alura.ByteBank.Infraestrutura.Testes.Servico;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Alura.ByteBank.Infraestrutura.Testes
{
    public class AgenciaRepositorioTestes
    {
        private readonly IAgenciaRepositorio _repositorio;
        public ITestOutputHelper _SaidaConsoleTeste { get; set; }
        public AgenciaRepositorioTestes(ITestOutputHelper SaidaConsoleTeste)
        {
            _SaidaConsoleTeste = SaidaConsoleTeste;
            _SaidaConsoleTeste.WriteLine("Construtor executado com sucesso");

            var servico = new ServiceCollection();
            servico.AddTransient<IAgenciaRepositorio, AgenciaRepositorio>();
            var provedor = servico.BuildServiceProvider();
            _repositorio = provedor.GetService<IAgenciaRepositorio>();

        }

        [Fact]
        public void TestaAdicionarAgenciaMock() 
        {
            //Arrange
            var agencia = new Agencia()
            {
                Nome = "Agência Amaral",
                Identificador = Guid.NewGuid(),
                Id = 4,
                Endereco = "Rua Arthur Costa",
                Numero = 6497
            };

            var repositorioMock = new ByteBankRepositorio();

            //Act
            var adicionar = repositorioMock.AdicionarAgencia(agencia);

            //Assert
            Assert.True(adicionar);

        }

        [Fact]
        public void TestaObterAgenciasMock()
        {
            //Arrange
            var bytebankRepositorioMock = new Mock<IByteBankRepositorio>();
            var mock = bytebankRepositorioMock.Object;

            //Act
            var adicionar = mock.BuscarAgencias();

            //Assert
            bytebankRepositorioMock.Verify(b => b.BuscarAgencias());

        }

    }
}

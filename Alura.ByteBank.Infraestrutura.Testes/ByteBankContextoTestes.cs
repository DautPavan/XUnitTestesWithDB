using Alura.ByteBank.Dados.Contexto;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.ByteBank.Infraestrutura.Testes
{
    public class ByteBankContextoTestes
    {
        [Fact]
        public void TestaConexaoContextoComDBMySql()
        {
            //Arrange
            var contexto = new ByteBankContexto();
            bool conectado;

            //Act
            try
            {
                conectado = contexto.Database.CanConnect();
            }
            catch (Exception ex) 
            {
                throw new Exception("Não foi possivel se conectar a base de dados.");
            }

            //Assert
            Assert.True(conectado);

        }

    }
}

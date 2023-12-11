using Caixa.Infra.Entities;
using Caixa.Infra.Interface;
using Caixa.Service.Services;
using Moq;
namespace Caixa.Tests
{
    public class ServiceTests
    { 
        [Fact]
        public void ObterTransacao_DeveRetornarResultadoCorreto()
        {
            // Arrange
            var transacaoMock = MockRetornos.RetornaTransacao();

            var mockRepositorio = new Mock<ITransacaoRepository>();
            mockRepositorio.Setup(repo => repo.ObterTransacao(0)).Returns(Task.FromResult<Transacao>(transacaoMock));

            var mockRepositorioTipo = new Mock<ITipoTransacaoRepository>();

            var mockRepositorioComerciante = new Mock<IComercianteRepository>();

            var service = new TransacaoService(mockRepositorio.Object, mockRepositorioTipo.Object, mockRepositorioComerciante.Object);

            // Act
            var resultado = service.ObterTransacao(0);

            // Assert
            Assert.NotNull(resultado);
        }
         
    }
}

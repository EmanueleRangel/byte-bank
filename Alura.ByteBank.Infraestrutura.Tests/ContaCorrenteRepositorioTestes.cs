using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Alura.ByteBank.Infraestrutura.Tests {
  public class ContaCorrenteRepositorioTestes {

    private readonly IContaCorrenteRepositorio repositorio;

    public ContaCorrenteRepositorioTestes() {
        var servico = new ServiceCollection();
        servico.AddTransient<IContaCorrenteRepositorio, ContaCorrenteRepositorio>();

        var provedor = servico.BuildServiceProvider();
        this.repositorio = provedor.GetService<IContaCorrenteRepositorio>();
    }
    [Fact]
    public void TesteObterTodosContasCorrentes() {
        //Arrange
        //Act
        var lista = this.repositorio.ObterTodos();

        //Assert
        Assert.NotNull(lista);
        Assert.Equal(2, lista.Count);
    }
    [Fact]
    public void TestaObterContaPorId() {
        //Arrange
        //Act
        var conta = this.repositorio.ObterPorId(1);

        //Assert
        Assert.NotNull(conta);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void TestaObterContaPorVariosId (int id) {
        //Arrange
        //Act
        var conta = this.repositorio.ObterPorId(id);

        //Assert
        Assert.NotNull(conta);
    }
  }
}

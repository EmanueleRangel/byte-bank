using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Alura.ByteBank.Infraestrutura.Tests.Servico;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Alura.ByteBank.Infraestrutura.Tests {
  public class AgenciaRepositorioTestes {
    private readonly IAgenciaRepositorio repositorio;

    public AgenciaRepositorioTestes () {
      var servico = new ServiceCollection();
      servico.AddTransient<IAgenciaRepositorio, AgenciaRepositorio>();

      var provedor = servico.BuildServiceProvider();
      this.repositorio = provedor.GetService<IAgenciaRepositorio>();
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
        var agencia = this.repositorio.ObterPorId(1);

        //Assert
        Assert.NotNull(agencia);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void TestaObterContaPorVariosId(int id) {
        //Arrange
        //Act
        var agencia = this.repositorio.ObterPorId(id);

        //Assert
        Assert.NotNull(agencia);
    }

    [Fact]
    public void TestaAtualizaNumeroDeterminadaAgencia() {
      //Arrange
      var agencia = this.repositorio.ObterPorId(1);
      var numeroNovo = 178;
      agencia.Numero = numeroNovo;

      //Act
      var atualizado = this.repositorio.Atualizar(1, agencia);

      //Assert
      Assert.True(atualizado);
    }

    [Fact]
    public void TestaInsereUmaNovaAgencia() {
        //Arrange            
        var nome = "Agencia Guarapari";
        var numero = 125982;
        var identificador = Guid.NewGuid();
        var endereco = "Rua: 7 de Setembro - Centro";

        var agencia = new Agencia() {
          Nome = nome,
          Identificador = identificador,
          Endereco = endereco,
          Numero = numero
        };

        //Act
        var retorno = this.repositorio.Adicionar(agencia);

        //Assert
        Assert.True(retorno);
    }
    
    [Fact]
    public void TestaRemoverDeterminadaAgencia() {
        //Arrange
        //Act
        var atualizado = this.repositorio.Excluir(3);

        //Assert
        Assert.True(atualizado);
    }

    [Fact]
    public void TestaExcecaoConsultaAgenciaPorId() =>
        //Act
        //Assert
        Assert.Throws<FormatException>(
          () => this.repositorio.ObterPorId(33));

    [Fact]
    public void TestaAdicionarAgenciaMock() {
        //Arrange
        var agencia = new Agencia() {
          Nome = "Agência Amaral",
          Identificador = Guid.NewGuid(),
          Id = 4,
          Endereco = "Rua Arthur Costa",
          Numero = 6497
        };

        var repositorioMock = new ByteBankRepositorio();

        //Act
        var adicionado = repositorioMock.AdicionarAgencia(agencia);

        //Assert
        Assert.True(adicionado);
    }
    [Fact]
    public void TesteObterAgenciasMock() {
        //Arrange
        var byteBankRepositorioMock = new Mock<IByteBankRepositorio>();
        var mock = byteBankRepositorioMock.Object;

        //Act
        var lista = mock.BuscarAgencias();

        //Assert
        byteBankRepositorioMock.Verify(b => b.BuscarAgencias());
    }
  }
}

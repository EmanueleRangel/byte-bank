using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using System;
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

    [Fact]
    public void TestaAtualizaSaldoDeterminadaConta() {
        //Arrange
        var conta = this.repositorio.ObterPorId(1);
        double saldoNovo = 15;
        conta.Saldo = saldoNovo;

        //Act
        var atualizado = this.repositorio.Atualizar(1, conta);

        //Assert
        Assert.True(atualizado);
    }

    [Fact]
    public void TestaInsereUmaNovaContaCorrente() {
        //Arrange
        var conta = new ContaCorrente() {
          Saldo = 10,
          Identificador = Guid.NewGuid(),
          Cliente = new Cliente() {
            Nome = "Linelson Santos",
            CPF = "486.074.980-45",
            Identificador = Guid.NewGuid(),
            Profissao = "Bancário",
            Id = 1
          },
          Agencia = new Agencia() {
            Nome = "Agencia Central Coast City",
            Identificador = Guid.NewGuid(),
            Id = 1,
            Endereco = "Rua das Flores, 25",
            Numero = 147
          }
        };
        //Act
        var retorno = this.repositorio.Adicionar(conta);

        //Assert
        Assert.True(retorno);
    }
  }
}

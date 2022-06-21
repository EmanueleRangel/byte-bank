using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;
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
  }
}

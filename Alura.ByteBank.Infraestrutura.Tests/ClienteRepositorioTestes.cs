using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace Alura.ByteBank.Infraestrutura.Tests {
  public class ClienteRepositorioTestes {
      private readonly IClienteRepositorio repositorio;
      public ClienteRepositorioTestes() {
          var servico = new ServiceCollection();
          servico.AddTransient<IClienteRepositorio, ClienteRepositorio>();
          var provedor = servico.BuildServiceProvider();
          this.repositorio = provedor.GetService<IClienteRepositorio>();
      }

      [Fact]
      public void TesteObterTodosClientes() {
          //Arrange
          //Act
          var lista = this.repositorio.ObterTodos();

          //Assert
          Assert.NotNull(lista);
          Assert.Equal(3, lista.Count);
      }

      [Fact]
      public void TestaObterClientePorId() {
          //Arrange
          //Act
          var cliente = this.repositorio.ObterPorId(1);

          //Assert
          Assert.NotNull(cliente);
      }

      [Theory]
      [InlineData(1)]
      [InlineData(2)]
      public void TestaObterClientesPorVariosId(int id) {
          //Arrange
          //Act
          var cliente = this.repositorio.ObterPorId(id);

          //Assert
          Assert.NotNull(cliente);
      }

      [Fact]
      public void TestaAtualizaNomeDeterminadoCliente() {
        //Arrange
        var cliente = this.repositorio.ObterPorId(1);
        var nomeNovo = "José Oliveira";
        cliente.Nome = nomeNovo;

        //Act
        var atualizado = this.repositorio.Atualizar(1, cliente);

        //Assert
        Assert.True(atualizado);
      }

      [Fact]
      public void TesteInsereUmNovoClienteNaBaseDeDados() {
        //Arrange            
        var nome = "Alberto Roberto";
        var cpf = "088.157.930-03";
        var identificador = Guid.NewGuid();
        var profissao = "Administrador de Empresas";

        var cliente = new Cliente() {
          Nome = nome,
          CPF = cpf,
          Identificador = identificador,
          Profissao = profissao
        };

        //Act
        var retorno = this.repositorio.Adicionar(cliente);

        //Assert
        Assert.True(retorno);
      }
  }
}

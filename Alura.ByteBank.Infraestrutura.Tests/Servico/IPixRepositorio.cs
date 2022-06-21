using Alura.ByteBank.Infraestrutura.Tests.Servico.DTO;
using System;

namespace Alura.ByteBank.Infraestrutura.Tests.Servico {
  public interface IPixRepositorio {
    public PixDTO consultaPix(Guid pix);
  }
}

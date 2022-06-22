# byte-bank

## Sobre
Aplicação console que simula um sistema bancário desenvolvida em .NET com a linguagem C# durante o curso "estes em .NET: 
integrando a aplicação com um banco de dados" da plataforma de ensino Alura. O objetivo da aplicação é implementar e praticar testes unitários e de integração 
com a ferramenta de testes xUnit.
A arquitetura da aplicação é baseada na proposta do DDD (Domain Driven Design), onde as camadas são divididas em:
- Domínio
- Aplicação
- Infraestrutura
- Apresentação

Também há uma quinta camada na solução destinado aos **Testes**. 

## Testes
Na camada de testes, há dois projetos: um destinado a testes unitários onde as classes do Domínio são testadas, são elas:


- AgenciaTestes
- ClienteTestes
- ContaCorrenteTestes


O segundo projeto é destinado aos testes de integração relacionados à camada de Infraestrutura, ou seja, são reponsáveis por testar
a conexão da aplicação com o componente externo que é o Banco de Dados relacional MySQL. Mais especificamente, esses testes
são destinados a validar as operações CRUD dos Models do sistema. São eles:

- AgenciaRepositorioTestes
- ClienteRepositorioTestes
- ContaCorrenteRepositorioTestes

## Tecnologias utilizadas
- .NET 5.0
- Entity Framework
- C#
- xUnit
- Moq
- MySQL

## Autor

LinkedIn: https://www.linkedin.com/in/emanuele-rangel-7b50971b8/

e-mail: emanuele.rangel52@gmail.com

Medium: https://medium.com/@emanuele.rangel52

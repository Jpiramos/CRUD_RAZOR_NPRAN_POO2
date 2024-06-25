# Projeto CRUD em Blazor - Relacionamento Muitos-para-Muitos

Este projeto foi desenvolvido como parte da disciplina de Programação Orientada a Objetos II da faculdade. Ele implementa um sistema CRUD utilizando Razor para gerenciar instituições, seus departamentos, cursos e disciplinas explorando o relacionamento muitos-para-muitos (Curso-Disciplina).

## Funcionalidades

- **Instituições**: Adicionar, listar, editar e excluir instituições.
- **Departamentos**: Adicionar, listar, editar e excluir departamentos.
- **Cursos**: Adicionar, listar, editar e excluir cursos.
- **Disciplinas**: Adicionar, listar, editar e excluir disciplinas.
- **Cursos-Disciplinas**: Associando disciplinas a cursos com sua devida carga horária.

## Estrutura do Projeto

O projeto está organizado da seguinte forma:

- **Models**: Contém as classes `Curso`,`Disciplina`, `Departamento`, `Instituicao` e `CursoDisciplina`.
- **Data**: Contém o contexto do banco de dados e as configurações de migração.
- **Pages**: Contém as páginas Razor que implementam as funcionalidades CRUD.
- **Shared**: Contém componentes compartilhados entre as páginas.

## Pré-requisitos

- [.NET 5 ou superior](https://dotnet.microsoft.com/download)
- [Visual Studio 2019 ou superior](https://visualstudio.microsoft.com/)
-  [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)


## Como Configurar o Projeto

1. **Clone o repositório do GitHub:**

Abra o Terminal e execute o seguinte comando na pasta destino: 
   ```
   git clone https://github.com/Jpiramos/CRUD_RAZOR_NPRAN_POO2.git
   ```
   
Abra o Visual Studio e selecione "Abrir um projeto ou solução", navegando até o diretório onde você clonou o repositório.

2. **Restaurar os pacotes NuGet:**

No Visual Studio, vá para Ferramentas > Gerenciador de Pacotes NuGet > Console do Gerenciador de Pacotes e execute o seguinte comando:

   ```
   Update-Database
   ```
3. **Executar o projeto:**

Pressione F5 ou clique em Executar no Visual Studio para iniciar o projeto.
______________________________________________________________________________________________________________________
Este projeto é licenciado sob os termos da licença MIT. Veja o arquivo LICENSE para mais detalhes.

*Desenvolvido por João Pedro Ramos*

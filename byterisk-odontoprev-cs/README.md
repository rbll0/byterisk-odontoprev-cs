# ByteRisk - Sistema de Gestão de Beneficiários

## Visão Geral do Projeto

ByteRisk é um sistema desenvolvido para a gestão de beneficiários e sinistros em uma clínica odontológica. O objetivo principal é reduzir custos de sinistros e aumentar a eficiência no acompanhamento de beneficiários e sinistros. A aplicação foi construída com ASP.NET Core e Oracle, utilizando boas práticas de arquitetura e design de software.

## Funcionalidades Principais

- **Dashboard**: Exibe um painel de controle com dados agregados, incluindo o total de prevenções, intervenções e valor total de sinistros reduzido.
- **Gerenciamento de Beneficiários**: Permite listar, criar, editar e excluir beneficiários. A interface de usuário apresenta uma tabela com dados dos beneficiários e opções para gerenciar cada um deles.
- **Autenticação**: Tela de login para controle de acesso à área administrativa.

## Estrutura do Projeto

- **Controllers**: Responsáveis por manipular as requisições HTTP, retornar as views e implementar as operações CRUD.
- **Views**: Interface de usuário implementada com layouts personalizados para Dashboard, listagem de beneficiários e formulários para criação, edição e exclusão.
- **Models**: Define as entidades principais do sistema, como `BeneficiarioEntity`, `PlanoEntity`, e `SinistroEntity`.
- **Data**: Contém o `ApplicationContext`, que configura o mapeamento das entidades para as tabelas do banco de dados Oracle.

## Configuração do Banco de Dados

1. **Criação das Tabelas**:
    - Crie as tabelas no Oracle Database conforme a estrutura definida no `ApplicationContext`.

2. **Configuração da Conexão**:
    - Insira os dados de conexão no `appsettings.json`:

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "User Id=SEU_USUARIO;Password=SUA_SENHA;Data Source=ENDERECO_BANCO"
     }
   }
## Executando a Aplicação

1. **Executar o Projeto**:
```bash
dotnet run
```

2. **Acessar a Aplicação**:
````bash
Abra um navegador e acesse http://localhost:5000.
````
## Estrutura do Banco de Dados

### Tabelas

- **Beneficiário**: Armazena informações dos beneficiários, incluindo ID, nome, data de nascimento, CPF, telefone, email, e ranking de risco.
- **Plano**: Detalhes dos planos odontológicos associados aos beneficiários.
- **Sinistro**: Registros dos sinistros relacionados aos beneficiários, com valores e tipos de sinistro.

## Endpoints Principais

### Dashboard

- `GET /Dashboard/Index`: Exibe a página principal do dashboard com dados agregados e estatísticas.

### Beneficiários

- `GET /Dashboard/GetAllBeneficiarios`: Lista todos os beneficiários cadastrados.
- `POST /Dashboard/CreateBeneficiario`: Adiciona um novo beneficiário ao sistema.
- `POST /Dashboard/EditBeneficiario`: Atualiza os dados de um beneficiário existente.
- `POST /Dashboard/DeleteBeneficiario`: Exclui um beneficiário do sistema.

## Tecnologias Utilizadas

- **Back-end**: ASP.NET Core, Entity Framework Core
- **Banco de Dados**: Oracle
- **Front-end**: Bootstrap para estilização das views
- **Documentação**: Swagger para documentação dos endpoints

## Melhorias Futuras

- **Autenticação Avançada**: Implementação de autenticação com JWT para maior segurança.
- **Relatórios**: Geração de relatórios avançados para análise de dados de sinistros.
- **Notificações**: Envio de notificações automáticas para beneficiários.

## Contribuidores

- Gustavo Rabelo RM:553326
- Felipe Arcanjo RM:554018
- Marcelo Vieira RM:553640

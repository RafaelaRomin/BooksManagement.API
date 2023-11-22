## ***Books Management API*** 🌐

####   **É uma API de gerenciamento de livros/biblioteca desenvolvida em ASP.NET Core 7.** 

### Tecnologias utilizadas 💡

* **ASP.NET Core 7:** framework web para desenvolvimento de aplicações .NET
* **Entity Framework Core:** persistência e consulta de dados.
* **SQL Server:** banco de dados relacional.

 ### Funcionalidades 🖥️
  
* **CRUD** (Create, Read, Update, Delete) de usuários/clientes e livros da biblioteca.

* **Empréstimo de livros:** Ao realizar o empréstimo, associa-se um usuário a um livro e calcula o tempo de empréstimo/previsão de devolução.
      - Na funcionalidade empréstimo também existe a opção de renovação do livro.

### Mapeamento do banco de dados 🗺
- Feito utilizando o IEntityTypeConfiguration que permite que a configuração de um tipo de entidade seja fatorada em uma classe separada, em vez de em linha em OnModelCreating(ModelBuilder).

### Conceitos utilizados 🤓
- **InputModel:** como modelo de entrada de dados.
- **ViewModel:** como modelo de saída de dados.
- **Fluent Validation:** Biblioteca para validação de dados.

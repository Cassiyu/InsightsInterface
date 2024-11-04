
# Como rodar o Projeto InsightsInterface

## Sumário
1. [Introdução](#introdução)
2. [Clonando o Repositório](#clonando-o-repositório)
3. [Configurando o Projeto](#configurando-o-projeto)
4. [Executando a Aplicação](#executando-a-aplicação)
5. [Acessando a Documentação Swagger](#acessando-a-documentação-swagger)
6. [Estrutura de Endpoints](#estrutura-de-endpoints)
7. [Testando os Endpoints](#testando-os-endpoints)

---

## Introdução

O projeto **InsightsInterface** é uma API RESTful desenvolvida em ASP.NET Core para gerenciar dados de **clientes**, **produtos** e **feedbacks**. O MongoDB é usado como banco de dados, e a API oferece operações CRUD para cada uma dessas entidades.

## Clonando o Repositório

Para obter o projeto em sua máquina local, clone o repositório GitHub:

```bash
git clone https://github.com/Cassiyu/InsightsInterface.git
cd InsightsInterface
```

## Configurando o Projeto

1. **Pré-requisitos**:
   - .NET 6 SDK ou superior
   - MongoDB rodando localmente ou configurado em um servidor remoto.

2. **Configuração do MongoDB**:
   No arquivo `appsettings.json`, configure a conexão com o MongoDB em:
   ```json
   "MongoDBSettings": {
     "ConnectionString": "mongodb://localhost:27017",
     "DatabaseName": "Insights"
   }
   ```

   Ajuste `ConnectionString` se o MongoDB estiver em um endereço diferente ou exigir autenticação.

## Executando a Aplicação

Após a configuração, execute os comandos abaixo para iniciar o projeto:

```bash
dotnet build
dotnet run
```

Se tudo estiver configurado corretamente, o projeto será iniciado e estará disponível nos endpoints padrão.

## Acessando a Documentação Swagger

Com o projeto em execução, você pode acessar a documentação interativa da API pelo Swagger:

- Abra o navegador e acesse:
  ```
  http://localhost:5116/swagger/index.html
  ```


O Swagger fornece uma interface para testar todos os endpoints e visualizar as respostas.

## Estrutura de Endpoints

A API fornece as operações CRUD para as entidades **Clientes**, **Produtos** e **Feedbacks**:

### Clientes
- `GET /api/Clientes` - Listar todos os clientes
- `POST /api/Clientes` - Criar um novo cliente
- `GET /api/Clientes/{id}` - Obter detalhes de um cliente específico
- `PUT /api/Clientes/{id}` - Atualizar um cliente existente
- `DELETE /api/Clientes/{id}` - Excluir um cliente

### Produtos
- `GET /api/Produtos` - Listar todos os produtos
- `POST /api/Produtos` - Criar um novo produto
- `GET /api/Produtos/{id}` - Obter detalhes de um produto específico
- `PUT /api/Produtos/{id}` - Atualizar um produto existente
- `DELETE /api/Produtos/{id}` - Excluir um produto

### Feedbacks
- `GET /api/Feedbacks` - Listar todos os feedbacks
- `POST /api/Feedbacks` - Criar um novo feedback
- `GET /api/Feedbacks/{id}` - Obter detalhes de um feedback específico
- `PUT /api/Feedbacks/{id}` - Atualizar um feedback existente
- `DELETE /api/Feedbacks/{id}` - Excluir um feedback

## Testando os Endpoints

Aqui estão instruções para testar cada um dos endpoints usando o Swagger.

### Teste dos Endpoints de Clientes

1. **Criar Cliente (POST /api/Clientes)**  
   Exemplo de corpo da requisição:
   ```json
   {
     "nome": "João da Silva",
     "email": "joao.silva@email.com",
     "telefone": "+5511998765432",
     "genero": "Masculino",
     "interesses": ["Roupa", "Tecnologia"],
     "endereco": {
       "rua": "Av. Paulista",
       "numero": 1000,
       "cidade": "São Paulo",
       "estado": "SP",
       "cep": "01310-000"
     },
     "dataNascimento": "1990-05-21",
     "cpf": "123.456.789-00",
     "dataCadastro": "2023-01-15",
     "ativo": true
   }
   ```

2. **Listar Clientes (GET /api/Clientes)**  
   Envie uma requisição GET para obter todos os clientes.

3. **Obter Cliente por ID (GET /api/Clientes/{id})**  
   Substitua `{id}` pelo ID do cliente criado para visualizar os detalhes.

4. **Atualizar Cliente (PUT /api/Clientes/{id})**  
   Envie uma requisição PUT com o ID do cliente e um corpo de requisição atualizado.

   Exemplo de corpo da requisição:
   ```json
   {
     "id": "67283988931b3d781664340b",
     "nome": "João da Silva",
     "email": "joao.silva@email.com",
     "telefone": "+5511998765432",
     "genero": "Masculino",
     "interesses": ["Esporte", "Tecnologia"],
     "endereco": {
       "rua": "Av. Paulista",
       "numero": 1000,
       "cidade": "São Paulo",
       "estado": "SP",
       "cep": "01310-000"
     },
     "dataNascimento": "1995-05-21",
     "cpf": "123.456.789-00",
     "dataCadastro": "2024-01-15",
     "ativo": true
   }
   ```

5. **Excluir Cliente (DELETE /api/Clientes/{id})**  
   Envie uma requisição DELETE com o ID do cliente para excluí-lo.

### Teste dos Endpoints de Produtos

1. **Criar Produto (POST /api/Produtos)**  
   Exemplo de corpo da requisição:
   ```json
   {
     "nome": "Camiseta Branca",
     "descricao": "Camiseta branca 100% algodão",
     "preco": 49.99,
     "peso": "200g",
     "cor": "Branco",
     "estoque": 100,
     "categoria": "Roupas",
     "fornecedor": "Fornecedor A",
     "dataAdicao": "2023-02-01"
   }
   ```

2. **Listar Produtos (GET /api/Produtos)**  
   Envie uma requisição GET para obter todos os produtos.

3. **Obter Produto por ID (GET /api/Produtos/{id})**  
   Substitua `{id}` pelo ID do produto criado.

4. **Atualizar Produto (PUT /api/Produtos/{id})**  
   Envie uma requisição PUT com o ID do produto e um corpo de requisição atualizado.

   Exemplo de corpo da requisição:
   ```json
   {
     "id": "672839f4931b3d781664340f",
     "nome": "Camiseta Preta",
     "descricao": "Camiseta branca 100% algodão",
     "preco": 89.99,
     "peso": "200g",
     "cor": "Preto",
     "estoque": 150,
     "categoria": "Roupas",
     "fornecedor": "Fornecedor B",
     "dataAdicao": "2024-02-01"
   }
   ```

5. **Excluir Produto (DELETE /api/Produtos/{id})**  
   Envie uma requisição DELETE com o ID do produto.

### Teste dos Endpoints de Feedbacks

1. **Criar Feedback (POST /api/Feedbacks)**  
   Exemplo de corpo da requisição:
   ```json
   {
     "clienteNome": "João da Silva",
     "produtoNome": "Camiseta Preta",
     "dataFeedback": "2024-03-12",
     "avaliacao": 4,
     "comentario": "Camiseta de ótima qualidade, tecido confortável.",
     "classificacaoLoja": 5,
     "tempoUso": 30,
     "tipoUso": "casual",
     "recomenda": true
   }
   ```

2. **Listar Feedbacks (GET /api/Feedbacks)**  
   Envie uma requisição GET para obter todos os feedbacks.

3. **Obter Feedback por ID (GET /api/Feedbacks/{id})**  
   Substitua `{id}` pelo ID do feedback criado.

4. **Atualizar Feedback (PUT /api/Feedbacks/{id})**  
   Envie uma requisição PUT com o ID do feedback e um corpo de requisição atualizado.

   Exemplo de corpo da requisição:
   ```json
   {
     "id": "67283a1b931b3d7816643413",
     "clienteNome": "João da Silva",
     "produtoNome": "Camiseta Preta",
     "dataFeedback": "2024-08-12",
     "avaliacao": 3,
     "comentario": "Camiseta boa, tecido confortável.",
     "classificacaoLoja": 4,
     "tempoUso": 20,
     "tipoUso": "casual",
     "recomenda": true
   }
   ```

5. **Excluir Feedback (DELETE /api/Feedbacks/{id})**  
   Envie uma requisição DELETE com o ID do feedback.

# Projeto Reservas entre Usuário e Buffet

Este é um projeto em desenvolvimento para um sistema de reservas entre usuários e buffet. A aplicação permite que os usuários realizem reservas, recebam confirmações por e-mail e gerenciem suas reservas de maneira simples e eficiente.

## Tecnologias Utilizadas
- **Backend**: C#, .NET Core, ASP.NET Core
- **Banco de Dados**: SQL Server
- **Docker**: Para containerização do ambiente
- **Email Service**: Serviço de envio de e-mails configurado com SMTP
- **JWT**: Para autenticação e autorização

## Como Rodar o Projeto

### Pré-requisitos

- **Docker**: Certifique-se de ter o Docker instalado no seu computador.  
  [Instruções para instalar o Docker](https://docs.docker.com/get-docker/)

- **.NET SDK**: Instale o .NET SDK se for necessário para rodar a aplicação localmente sem Docker.  
  [Instruções para instalar o .NET SDK](https://dotnet.microsoft.com/download)

### Rodando com Docker

1. Clone o repositório:
    ```bash
    git clone https://github.com/SEU_USUARIO/Reservas-jwt-ddd.git
    ```

2. Acesse o diretório do projeto:
    ```bash
    cd Reservas-jwt-ddd
    ```

3. Crie a imagem do Docker e suba os containers:
    ```bash
    docker-compose up --build
    ```

### Configuração do E-mail

O serviço de e-mail está configurado diretamente na classe `EmailService.cs` dentro do projeto. Para enviar e-mails, a aplicação precisa das credenciais do seu servidor SMTP.

#### Passos para configurar o e-mail:
1. Abra o arquivo `EmailService.cs` na pasta `Reservas.Application`.

2. Dentro dessa classe, você verá o código responsável por configurar o envio de e-mails. Modifique as configurações conforme necessário.

    - Defina o endereço de e-mail do remetente:
      ```csharp
      email.From.Add(new MailboxAddress("Cadastro de Usuário", "seuemail@email.com")); // linha 14
      ```

    - Autentique com seu servidor SMTP:
      ```csharp
      await smtp.AuthenticateAsync("seuemail@email.com", "senha"); // linha 38
      ```

#### Crie a imagem do Docker e suba os containers:
    ```bash
    docker-compose up --build
    ```


### Acessando a Aplicação

Após subir os containers com o Docker, a aplicação estará disponível na seguinte URL: (http://localhost:8080)


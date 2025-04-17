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
    https://github.com/IgorAnthonyy/reserva-jwt-ddd.git
    ```

2. Acesse o diretório do projeto:
    ```bash
    cd Reservas-jwt-ddd
    ```

### Configuração do E-mail

O serviço de e-mail está configurado diretamente na classe `EmailService.cs` dentro do projeto. Para enviar e-mails, a aplicação precisa das credenciais do seu servidor SMTP.

#### Passos para configurar o e-mail:
1. Abra o arquivo `.env`.

2. Dentro desse arquivo, você verá o código responsável por configurar o envio de e-mails. Modifique as configurações conforme necessário.

    - Defina o endereço de e-mail do remetente:
      ```csharp
      EMAIL_USERNAME=seuemail@email.com
      EMAIL_PASSWORD=suasenha
      ```
      
### Criação e Execução dos Containers Docker

Agora, para construir a imagem do Docker e rodar os containers, utilize o seguinte comando:

```bash
docker-compose up --build
```

### Acessar o projeto

```bash
http://localhost:8080
```

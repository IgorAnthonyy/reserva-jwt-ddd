using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;

namespace EmprestimosLivros.Email
{
    public class EmailService
    {
        public async Task EnviarEmailAsync(string destinatario, string assunto, List<string> bodyEmail)
        {
            var emailEnv = Environment.GetEnvironmentVariable("EMAIL_USERNAME");
            var senhaEnv = Environment.GetEnvironmentVariable("EMAIL_PASSWORD");

            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("Cadastro de Usuário", emailEnv));
            email.To.Add(new MailboxAddress("", destinatario));
            email.Subject = assunto;

            email.Body = new TextPart("html")
            {
                Text = $@"
                    <html>
                    <body style='background-color: rgb(0, 0, 0); color: rgb(255, 255, 255); font-family: Arial, sans-serif; padding: 20px;'>
                        <h2 style='color:rgb(0, 221, 255);'>Bem-vindo, {bodyEmail[0]}!</h2>
                        <p style='color: white'>Seu cadastro foi realizado com sucesso em nossa plataforma.</p>
                        <p style='color: white'><strong>Nome:</strong> {bodyEmail[0]}</p>
                        <p style='color: white'><strong>Email:</strong> {bodyEmail[1]}</p>
                        <p style='color: white'><strong>Telefone:</strong> {bodyEmail[2]}</p>
                        <br/>
                        <p>Você já pode acessar sua conta e aproveitar nossos serviços.</p>
                        <hr>
                        <p style='font-size: 12px; color: #888;'>Este é um e-mail automático. Por favor, não responda.</p>
                    </body>
                    </html>"
            };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(emailEnv, senhaEnv);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
}

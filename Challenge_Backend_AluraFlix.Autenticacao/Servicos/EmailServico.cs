using Challenge_Backend_AluraFlix.Autenticacao.Configuracoes;
using Challenge_Backend_AluraFlix.Autenticacao.Servicos.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Autenticacao.Servicos
{
    public class EmailServico : IEmailServico
    {
        private readonly ISmtpClient client;
        private readonly EmailSettings emailSettings;

        public EmailServico(ISmtpClient client, IOptions<EmailSettings> emailSettings)
        {
            this.client = client;
            this.emailSettings = emailSettings.Value;
        }

        public MimeMessage CriaCorpoEmail(Mensagem mensagem)
        {
            var remetente = new MailboxAddress("AluraFlix", emailSettings.From);

            MimeMessage mensagemEmail = new MimeMessage();

            mensagemEmail.From.Add(remetente);
            mensagemEmail.To.AddRange(mensagem.Destinatario);
            mensagemEmail.Subject = mensagem.Assunto;
            mensagemEmail.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = mensagem.Conteudo
            };

            return mensagemEmail;
        }

        public Mensagem CriarMensagem(string[] destinatario, string assunto, string idUsuario, string token)
        {
            Mensagem mensagem = new Mensagem(destinatario, assunto, idUsuario, token);
            return mensagem;
        }

        public void EnviarEmail(MimeMessage email)
        {
            client.Connect(emailSettings.SmtpServer, emailSettings.Port, true);
            client.AuthenticationMechanisms.Remove("XOAUTH2");
            client.Authenticate(emailSettings.From, emailSettings.Password);


            client.Send(email);
            client.Disconnect(true);
        }
    }
}

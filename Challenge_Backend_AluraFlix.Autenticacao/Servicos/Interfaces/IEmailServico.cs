using Challenge_Backend_AluraFlix.Autenticacao.Configuracoes;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Autenticacao.Servicos.Interfaces
{
    public interface IEmailServico
    {
        void EnviarEmail(MimeMessage email);
        Mensagem CriarMensagem(string[] destinatario, string assunto, string idUsuario, string token);
        MimeMessage CriaCorpoEmail(Mensagem mensagem);
    }
}

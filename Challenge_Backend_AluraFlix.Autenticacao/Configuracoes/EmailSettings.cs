using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Autenticacao.Configuracoes
{
    public class EmailSettings
    {
        public string From { get; set; }
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public string Password { get; set; }
    }
}

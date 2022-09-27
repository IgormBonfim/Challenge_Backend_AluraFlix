using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Dominio.Usuarios.Entidades
{
    public class UsuarioPassword : Usuario
    {
        public virtual string SenhaUsuario { get; protected set; }

        public UsuarioPassword()
        {

        }

        public UsuarioPassword(string? nomeUsuario, string? sobrenomeUsuario, string? emailUsuario, string? senha) : base(nomeUsuario, sobrenomeUsuario, emailUsuario)
        {
            SetSenhaUsuario(senha);
        }

        public virtual void SetSenhaUsuario(string? senha)
        {
            if (string.IsNullOrWhiteSpace(senha))
                throw new Exception("O campo Senha é obrigatório!");
            SenhaUsuario = senha;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Dominio.Usuarios.Entidades
{
    public class Usuario
    {
        public virtual Guid IdUsuario { get; protected set; }
        public virtual string NomeUsuario { get; protected set; }
        public virtual string SobrenomeUsuario { get; protected set; }
        public virtual string EmailUsuario { get; protected set; }

        public Usuario()
        {

        }

        public Usuario(string? nomeUsuario, string? sobrenomeUsuario, string? emailUsuario)
        {
            IdUsuario = Guid.NewGuid();
            SetNomeUsuario(nomeUsuario);
            SetSobrenomeUsuario(sobrenomeUsuario);
            SetEmailUsuario(emailUsuario);
        }

        public Usuario(Guid id, string? nomeUsuario, string? sobrenomeUsuario, string? emailUsuario)
        {
            SetIdUsuario(id);
            SetNomeUsuario(nomeUsuario);
            SetSobrenomeUsuario(sobrenomeUsuario);
            SetEmailUsuario(emailUsuario);
        }

        public virtual void SetIdUsuario(Guid idUsuario)
        {
            IdUsuario = idUsuario;
        }

        public virtual void SetNomeUsuario(string? nomeUsuario)
        {
            if (string.IsNullOrWhiteSpace(nomeUsuario))
                throw new Exception("O campo Nome é obrigatório!");
            NomeUsuario = nomeUsuario;
        }

        public virtual void SetSobrenomeUsuario(string? sobrenome)
        {
            if (string.IsNullOrWhiteSpace(sobrenome))
                throw new Exception("O campo Sobrenome é obrigatório!");
            SobrenomeUsuario= sobrenome;
        }

        public virtual void SetEmailUsuario(string? email)
        {
            Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

            if (string.IsNullOrWhiteSpace(email))
                throw new Exception("O campo Email é obrigatório!");

            if (!rg.IsMatch(email))
                throw new Exception("Formato de email inválido!");
            EmailUsuario = email;
        }

    }
}

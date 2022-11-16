using FluentNHibernate.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Autenticacao.Entidades
{
    public class ApplicationUser : IdentityUser<string>
    {
        public ApplicationUser()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}

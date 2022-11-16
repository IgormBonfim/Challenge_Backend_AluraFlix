using Challenge_Backend_AluraFlix.Autenticacao.Entidades;
using FluentNHibernate.AspNetCore.Identity.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Autenticacao.Mapeamentos
{
    public class ApplicationUserMap : IdentityUserMapBase<ApplicationUser, string>
    {
        public ApplicationUserMap() : base(t => t.Column("id").Length(32))
        {
            Schema("Challenge_Backend_AluraFlix");
        }
    }
}

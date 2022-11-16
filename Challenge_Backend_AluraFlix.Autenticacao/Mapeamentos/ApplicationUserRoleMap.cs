using Challenge_Backend_AluraFlix.Autenticacao.Entidades;
using FluentNHibernate.AspNetCore.Identity.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Autenticacao.Mapeamentos
{
    public class ApplicationUserRoleMap : IdentityUserRoleMapBase<ApplicationUserRole, string>
    {
        public ApplicationUserRoleMap() : base(t => t.KeyProperty(x => x.UserId).KeyProperty(x => x.RoleId))
        {
            Schema("Challenge_Backend_AluraFlix");
        }
    }
}

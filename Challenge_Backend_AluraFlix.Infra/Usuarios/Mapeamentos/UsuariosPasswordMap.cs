using Challenge_Backend_AluraFlix.Dominio.Usuarios.Entidades;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Infra.Usuarios.Mapeamentos
{
    public class UsuariosPasswordMap : ClassMap<UsuarioPassword>
    {
        public UsuariosPasswordMap()
        {
            Schema("CHALLENGE_BACKEND_ALURAFLIX");
            Table("USUARIOS");
            Id(x => x.IdUsuario).Column("IdUsuario").GeneratedBy.Assigned();
            Map(x => x.NomeUsuario).Column("NomeUsuario");
            Map(x => x.SobrenomeUsuario).Column("SobrenomeUsuario");
            Map(x => x.EmailUsuario).Column("EmailUsuario");
            Map(x => x.SenhaUsuario).Column("SenhaUsuario");
        }
    }
}

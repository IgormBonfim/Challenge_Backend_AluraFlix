using Challenge_Backend_AluraFlix.Dominio.Videos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Dominio.Videos.Servicos.Interfaces
{
    public interface IVideosServico
    {
        Video Validar(int id);
        Video Instanciar(string titulo, string desc, string url);
        Video Inserir(Video video);
        Video Editar(Video video);
        void Deletar(Video video);
        IQueryable<Video> Query();
    }
}

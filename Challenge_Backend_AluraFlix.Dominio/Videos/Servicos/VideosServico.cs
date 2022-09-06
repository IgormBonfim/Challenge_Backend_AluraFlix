using Challenge_Backend_AluraFlix.Dominio.Videos.Entidades;
using Challenge_Backend_AluraFlix.Dominio.Videos.Servicos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Dominio.Videos.Servicos
{
    public class VideosServico : IVideosServico
    {
        public void Deletar(Video video)
        {
            throw new NotImplementedException();
        }

        public Video Editar(Video video)
        {
            throw new NotImplementedException();
        }

        public Video Inserir(Video video)
        {
            throw new NotImplementedException();
        }

        public Video Instanciar(string titulo, string desc, string url)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Video> Query()
        {
            throw new NotImplementedException();
        }

        public Video Validar(int id)
        {
            throw new NotImplementedException();
        }
    }
}

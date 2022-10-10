using Challenge_Backend_AluraFlix.DataTransfer.Genericos.Responses;
using Challenge_Backend_AluraFlix.DataTransfer.Videos.Requests;
using Challenge_Backend_AluraFlix.DataTransfer.Videos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Aplicacao.Videos.Servicos.Interfaces
{
    public interface IVideosAppServico
    {
        VideoIdResponse Inserir(VideoInserirRequest inserirRequest);
        Object Recuperar(int idVideo);
        VideoResponse Editar(VideoEditarRequest editarRequest);
        MensagemResponse Deletar(int idVideo);
        IList<VideoResponse> Buscar(VideoBuscarRequest busca);
        IList<VideoResponse> Favoritos(string idUsuario);
    }
}

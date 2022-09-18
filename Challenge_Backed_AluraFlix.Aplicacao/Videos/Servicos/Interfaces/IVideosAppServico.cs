using Challenge_Backend_AluraFlix.DataTransfer.Genericos.Responses;
using Challenge_Backend_AluraFlix.DataTransfer.Videos.Requests;
using Challenge_Backend_AluraFlix.DataTransfer.Videos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backed_AluraFlix.Aplicacao.Videos.Servicos.Interfaces
{
    public interface IVideosAppServico
    {
        VideoIdResponse Inserir(VideoInserirRequest inserirRequest);
        IList<VideoResponse> ListarTodos();
        Object Recuperar(int idVideo);
        VideoResponse Editar(VideoEditarRequest editarRequest);
        MensagemResponse Deletar(int idVideo);
        IList<VideoResponse> Buscar(string busca);
    }
}

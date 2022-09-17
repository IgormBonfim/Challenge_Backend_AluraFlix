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
    }
}

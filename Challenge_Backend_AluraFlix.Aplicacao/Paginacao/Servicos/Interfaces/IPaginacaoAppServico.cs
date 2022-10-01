using Challenge_Backend_AluraFlix.DataTransfer.Genericos.Requests;
using Challenge_Backend_AluraFlix.DataTransfer.Genericos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Aplicacao.Paginacao.Servicos.Interfaces
{
    public interface IPaginacaoAppServico
    {
        PaginacaoResponse Paginar(PaginacaoRequest request);
    }
}

using Challenge_Backend_AluraFlix.Aplicacao.Paginacao.Servicos.Interfaces;
using Challenge_Backend_AluraFlix.DataTransfer.Genericos.Requests;
using Challenge_Backend_AluraFlix.DataTransfer.Genericos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Aplicacao.Paginacao.Servicos
{
    public class PaginacaoAppServico : IPaginacaoAppServico
    {

        public PaginacaoResponse Paginar(PaginacaoRequest paginacao)
        {
            if (!paginacao.Pagina.HasValue || paginacao.Pagina.Value == 0)
                paginacao.Pagina = 1;
            if (!paginacao.Limite.HasValue)
                paginacao.Limite = 5;

            int offset = (paginacao.Pagina.Value * paginacao.Limite.Value) - paginacao.Limite.Value;

            PaginacaoResponse paginacaoResponse = new PaginacaoResponse()
            {
                Limit = paginacao.Limite.Value,
                Offset = offset
            };

            return paginacaoResponse;
        }
    }
}

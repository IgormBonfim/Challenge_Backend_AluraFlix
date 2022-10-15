using Challenge_Backend_AluraFlix.DataTransfer.Categorias.Requests;
using Challenge_Backend_AluraFlix.DataTransfer.Categorias.Responses;
using Challenge_Backend_AluraFlix.DataTransfer.Genericos.Responses;
using Challenge_Backend_AluraFlix.DataTransfer.Videos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Aplicacao.Categorias.Servicos.Interfaces
{
    public interface ICategoriasAppServico
    {
        CategoriaIdResponse Inserir(CategoriaInserirRequest inserirRequest);
        Object Recuperar(int idCategoria);
        CategoriaIdResponse Editar(CategoriaEditarRequest editarRequest);
        MensagemResponse Deletar(int idCategoria);
        ListaPaginadaResponse<CategoriaResponse> Buscar(CategoriaBuscarRequest buscarRequest);
        ListaPaginadaResponse<VideoResponse> ListarPorCategoria(int id);
    }
}

using Challenge_Backend_AluraFlix.Aplicacao.Categorias.Servicos.Interfaces;
using Challenge_Backend_AluraFlix.DataTransfer.Categorias.Requests;
using Challenge_Backend_AluraFlix.DataTransfer.Categorias.Responses;
using Challenge_Backend_AluraFlix.DataTransfer.Genericos.Responses;
using Challenge_Backend_AluraFlix.DataTransfer.Videos.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Challenge_Backend_AluraFlix.API.Controllers.Categorias
{
    [Authorize]
    [Route("api/categorias")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriasAppServico categoriasAppServico;

        public CategoriasController(ICategoriasAppServico categoriasAppServico)
        {
            this.categoriasAppServico = categoriasAppServico;
        }

        [HttpGet]
        public ActionResult<IList<CategoriaResponse>> Listar([FromQuery] CategoriaBuscarRequest buscarRequest)
        {
            var retorno = categoriasAppServico.Buscar(buscarRequest);
            return Ok(retorno);
        }

        [HttpGet("{id}")]
        public ActionResult<Object> Recuperar(int id)
        {
            var retorno = categoriasAppServico.Recuperar(id);
            return Ok(retorno);
        }

        [HttpGet("{id}/videos")]
        public ActionResult<ListaPaginadaResponse<VideoResponse>> VideosPorCategoria(int id)
        {
            var retorno = categoriasAppServico.ListarPorCategoria(id);
            return Ok(retorno);
        }

        [HttpPost]
        public ActionResult<CategoriaIdResponse> Inserir([FromBody] CategoriaInserirRequest inserirRequest)
        {
            var retorno = categoriasAppServico.Inserir(inserirRequest);
            return Ok(retorno);
        }

        [HttpPut("{id}")]
        public ActionResult<CategoriaIdResponse> Editar(int id, [FromBody] CategoriaEditarRequest editarRequest)
        {
            editarRequest.IdCategoria = id;
            var retorno = categoriasAppServico.Editar(editarRequest);
            return Ok(retorno);
        }

        [HttpDelete("{id}")]
        public ActionResult<MensagemResponse> Deletar(int id)
        {
            var retorno = categoriasAppServico.Deletar(id);
            return Ok(retorno);
        }
    }
}

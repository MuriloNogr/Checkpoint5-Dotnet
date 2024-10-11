using CP2.Application.Dtos;
using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CP2.API.Controllers
{
    /// <summary>
    /// Controller responsável por gerenciar as operações relacionadas aos fornecedores.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorApplicationService _applicationService;

        /// <summary>
        /// Construtor do FornecedorController.
        /// </summary>
        /// <param name="applicationService">Serviço de aplicação de fornecedor.</param>
        public FornecedorController(IFornecedorApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        /// <summary>
        /// Obtém todos os fornecedores cadastrados.
        /// </summary>
        /// <returns>Lista de fornecedores.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<FornecedorEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public IActionResult Get()
        {
            var objModel = _applicationService.ObterTodosFornecedores();

            if (objModel != null)
                return Ok(objModel);

            return BadRequest("Não foi possível obter os dados.");
        }

        /// <summary>
        /// Obtém um fornecedor específico pelo ID.
        /// </summary>
        /// <param name="id">ID do fornecedor a ser consultado.</param>
        /// <returns>Fornecedor correspondente ao ID informado.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(FornecedorEntity), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public IActionResult GetPorId(int id)
        {
            var objModel = _applicationService.ObterFornecedorPorId(id);

            if (objModel != null)
                return Ok(objModel);

            return BadRequest("Não foi possível obter os dados.");
        }

        /// <summary>
        /// Adiciona um novo fornecedor.
        /// </summary>
        /// <param name="entity">Dados do fornecedor a ser adicionado.</param>
        /// <returns>Fornecedor criado.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(FornecedorEntity), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public IActionResult Post([FromBody] FornecedorDto entity)
        {
            try
            {
                var fornecedorEntity = new FornecedorEntity
                {
                    Nome = entity.Nome,
                    CNPJ = entity.CNPJ,
                    Endereco = entity.Endereco,
                    Telefone = entity.Telefone,
                    Email = entity.Email,
                    CriadoEm = DateTime.UtcNow
                };

                var objModel = _applicationService.SalvarDadosFornecedor(fornecedorEntity);

                if (objModel != null)
                    return Ok(objModel);

                return BadRequest("Não foi possível salvar os dados.");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    Status = HttpStatusCode.BadRequest,
                });
            }
        }

        /// <summary>
        /// Atualiza os dados de um fornecedor existente.
        /// </summary>
        /// <param name="id">ID do fornecedor a ser atualizado.</param>
        /// <param name="entity">Dados atualizados do fornecedor.</param>
        /// <returns>Fornecedor atualizado.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(FornecedorEntity), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public IActionResult Put(int id, [FromBody] FornecedorDto entity)
        {
            try
            {
                var fornecedorEntity = new FornecedorEntity
                {
                    Id = id,
                    Nome = entity.Nome,
                    CNPJ = entity.CNPJ,
                    Endereco = entity.Endereco,
                    Telefone = entity.Telefone,
                    Email = entity.Email,
                    CriadoEm = entity.CriadoEm
                };

                var objModel = _applicationService.EditarDadosFornecedor(id, fornecedorEntity);

                if (objModel != null)
                    return Ok(objModel);

                return BadRequest("Não foi possível atualizar os dados.");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    Status = HttpStatusCode.BadRequest,
                });
            }
        }

        /// <summary>
        /// Exclui um fornecedor pelo ID.
        /// </summary>
        /// <param name="id">ID do fornecedor a ser excluído.</param>
        /// <returns>Confirmação de exclusão do fornecedor.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(FornecedorEntity), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public IActionResult Delete(int id)
        {
            var objModel = _applicationService.DeletarDadosFornecedor(id);

            if (objModel != null)
                return Ok(objModel);

            return BadRequest("Não foi possível deletar os dados.");
        }
    }
}

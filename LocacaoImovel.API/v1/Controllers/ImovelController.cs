using ControleEstoque.Domain.v1.DTOs.Request;
using LocacaoImoveis.Business.Models;
using LocacaoImoveis.Domain.v1.DTOs.Request;
using LocacaoImoveis.Domain.v1.DTOs.Response;
using LocacaoImoveis.Domain.v1.Extension;
using LocacaoImoveis.Domain.v1.Models;
using LocacaoImoveis.Infrastructure.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace LocacaoImovel.API.v1.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ImovelController : ControllerBase
    {

        private readonly ImovelContext _context;

        public ImovelController(ImovelContext context)
        {
            _context = context;
        }

        [HttpGet("{id:int}")]
        [SwaggerOperation("listar Imovel")]
        public async Task<IActionResult> ListarImovel(int imovelId)
        {
            var imovel = await _context.Imoveis.FindAsync(imovelId);
            if (imovel == null) return NotFound();
            var enderecoImovel = _context.Enderecos.Where(c => c.ImovelId == imovel.Id).FirstOrDefault();

            var imagens = _context.Imagens.Where(c => c.ImovelId == imovel.Id).ToList();


            var response = new ImovelResponse
            {
                TipoImovel = imovel.tipoImovel.ToString(),
                Valor = imovel.Valor,
                VagasGaragem = imovel.VagasGaragem,
                NomProprietario = imovel.NomProprietario,
                Descricao = imovel.Descricao,
            };


            return Ok(response);
        }

      
        [HttpPost]
        [SwaggerOperation("Cadastrar Imovel")]
        public async Task<IActionResult> CadastrarImovel([FromForm] CadastrarImovelRequest Imovel, [FromForm] List<IFormFile> files)
        {

            var endereco = new EnderecoByCep();
            var cepValidation = new CepValidation();

            bool cepValidated = cepValidation.CepValidationExtension(Imovel.Cep);

            if (!cepValidated) return BadRequest("cep nao valido");


            var enderecoResponse = new EnderecoByCepRequest();
            enderecoResponse = await EnderecoByCep.GetEndereco(Imovel.Cep);
            if (enderecoResponse.cep == null) return NotFound("cep nao existe");

            var _imovel = new Imovel
            {
                tipoImovel = Imovel.tipoImovel,
                Valor = Imovel.Valor,
                VagasGaragem = Imovel.VagasGaragem,
                DataAnuncio = DateTime.Now,
                NomProprietario = Imovel.NomProprietario,
                Descricao = Imovel.Descricao,
            };

            _context.Add(_imovel);
            await _context.SaveChangesAsync();

            return Ok();

        }

        [HttpDelete("{id:int}")]
        [SwaggerOperation("Deletar Imovel")]
        public async Task<IActionResult> DeletarImovel(int imovelId)
        {
            var _imovel = await _context.Imoveis.FindAsync(imovelId);
           
            var enderecoImovel = _context.Enderecos.Where(c => c.ImovelId == imovelId).FirstOrDefault();
            if(enderecoImovel != null) _context.Enderecos.Remove(enderecoImovel);

            return Ok();
        }

        [HttpPut("{id:int}")]
        [SwaggerOperation("Atualizar Imovel")]
        public async Task<IActionResult> AtualizartImovel(AtualizarImovelRequest imovel)
        {
            var _imovel = await _context.Imoveis.FindAsync(imovel.Id);
            if(_imovel == null) return NotFound();

            _imovel.Valor = imovel.Valor;
            _imovel.Descricao = imovel.Descricao;

            _context.Imoveis.Update(_imovel);
            await _context.SaveChangesAsync();
            return Ok();
        }


    }
}

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

using System.Linq;
using System.Threading.Tasks;


namespace LocacaoImovel.API.v1.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly ImovelContext _context;

        public EnderecoController(ImovelContext context)
        {
            _context = context;
        }

        [HttpGet("{id:int}")]
        [SwaggerOperation("listar endereco")]
        public IActionResult ListarEndereco(int imovelId)
        {
            var enderecoImovel = _context.Enderecos.Where(c => c.ImovelId == imovelId).FirstOrDefault();

            var Endereco = new EnderecoResponse
            {
                Logradouro = enderecoImovel.Logradouro,
                Numero = enderecoImovel.Numero,
                Complemento = enderecoImovel.Complemento,
                Cep = enderecoImovel.Cep,
                Bairro = enderecoImovel.Bairro,
                Cidade = enderecoImovel.Cidade,
                Estado = enderecoImovel.Estado
            };
            return Ok(Endereco);
        }

        [HttpPost]
        [SwaggerOperation("cadastrar endereco")]

        public async Task<IActionResult> CadastrarEndereco(CadastrarEndereco endereco)
        {

            var enderecoExists = _context.Enderecos.Where(x => x.ImovelId == endereco.ImovelId).FirstOrDefault();
            if (enderecoExists != null) return BadRequest("Endereco ja existe");

            var enderecoByCep = new EnderecoByCepRequest();

            enderecoByCep = await EnderecoByCep.GetEndereco(endereco.Cep);
            if (enderecoByCep.cep == null) return NotFound("cep nao existe");

            var _endereco = new Endereco
            {
                Logradouro = enderecoByCep.logradouro,
                Numero = endereco.Numero,
                Complemento = endereco.Complemento,
                Cep = CepValidation.cepFormatted(enderecoByCep.cep),
                Bairro = enderecoByCep.bairro,
                Cidade = enderecoByCep.localidade,
                Estado = enderecoByCep.uf,
                ImovelId = endereco.ImovelId
            };
            _context.Add(_endereco);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        [SwaggerOperation("deletar endereco")]
        public IActionResult DeletarEndereco(int imovelId)
        {
            var endereco = _context.Enderecos.Where(c => c.ImovelId == imovelId).FirstOrDefault();
            if (endereco == null) return NotFound();
             _context.Remove(endereco);
            return Ok();           
        }



    }
}

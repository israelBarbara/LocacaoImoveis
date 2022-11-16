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
    public class ImagemController : ControllerBase
    {
        private readonly ImovelContext _context;

        public ImagemController(ImovelContext context)
        {
            _context = context;
        }


        [HttpGet("{id:int}")]
        [SwaggerOperation("listar Imagens")]
        public IActionResult ListarImagens(int imovelId)
        {
            var imagemResponse = new ImagemResponse();
            var imagens = _context.Imagens.Where(c => c.ImovelId == imovelId).ToList();
            if (imagens.Count() == 0) return NotFound("nao ha imagens");

            foreach (var item in imagens)
            {
                byte[] imageArray = System.IO.File.ReadAllBytes(item.CaminhoImagem);
                string base64ImageRepresentation = Convert.ToBase64String(imageArray);
                imagemResponse.base64Images.Add(base64ImageRepresentation);
            }

            return Ok(imagemResponse);
        }

        [HttpPost("{id:int}")]
        [SwaggerOperation("cadastrar Imagens")]
        public IActionResult CadastrarImagens(CadastrarImagemRequest imagem)
        {

            foreach (var item in imagem.files)
            {
                var _imagem = new Imagem              
                { 
                    ImovelId = imagem.ImovelId,
                    CaminhoImagem = item.FileName,
                    DataCadastro = DateTime.Now,                           
                };
            }
            return Ok();
        }

        [HttpDelete("{id:int}")]
        [SwaggerOperation("deletar Imagens")]
        public async Task<IActionResult> DeletarImagens(int imovelId)
        {
            var imagemResponse = new ImagemResponse();
            var imagens = _context.Imagens.Where(c => c.ImovelId == imovelId).ToList();
            if (imagens.Count() == 0) return NotFound("nao ha imagens");

            _context.Imagens.RemoveRange(imagens);
            await _context.SaveChangesAsync();

            return Ok();
        }


    }
}

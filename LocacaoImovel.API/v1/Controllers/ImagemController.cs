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
            imagemResponse.base64Images = new List<string>();
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
        public async Task<IActionResult> CadastrarImagens([FromForm] CadastrarImagemRequest imagem)
        {
                  
            var imagens = _context.Imagens.Where(c => c.ImovelId == imagem.ImovelId).ToList();
            if (imagens.Count() >= 10) return BadRequest("Maximo de 10 imagens");

            foreach (var item in imagem.files)
            {
                if(item.FileName.Length > 80) return BadRequest("tamanho imagem muito grande");
            }

            foreach (var item in imagem.files)
            {
                string img = ImageUpload.SaveImg(item);
                if (img.Length == 0) return BadRequest("imagem invalida");
                var _imagem = new Imagem
                {
                    ImovelId = imagem.ImovelId,
                    CaminhoImagem = img,
                    DataCadastro = DateTime.Now,
                };
                _context.Imagens.Add(_imagem);
            }
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        [SwaggerOperation("deletar Imagens")]
        public async Task<IActionResult> DeletarImagens(int imovelId)
        {
            var imagemResponse = new ImagemResponse();
            var imagens = _context.Imagens.Where(c => c.ImovelId == imovelId).ToList();
            if (imagens.Count() == 0) return NotFound("nao ha imagens");

            foreach (var item in imagens)
            {
                ImageUpload.DeleteImg(item.CaminhoImagem);
            }

            _context.Imagens.RemoveRange(imagens);
            await _context.SaveChangesAsync();
            return Ok();
        }


    }
}

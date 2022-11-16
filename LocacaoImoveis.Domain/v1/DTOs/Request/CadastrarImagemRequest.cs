using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace LocacaoImoveis.Domain.v1.DTOs.Request
{
    public class CadastrarImagemRequest
    {
        public int ImovelId { get; set; }
        public List<IFormFile> files { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocacaoImoveis.Domain.v1.DTOs.Response
{
    public class ImagemResponse
    {
       public List<string> base64Images { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocacaoImoveis.Domain.v1.DTOs.Request
{
    public class CadastrarEndereco
    {
        public string Cep { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public int ImovelId { get; set; }   

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LocacaoImoveis.Domain.v1.Models.Imovel;

namespace LocacaoImoveis.Domain.v1.DTOs.Request
{
    public class CadastrarImovelRequest
    {

        public TipoImovel tipoImovel { get; set; }
        public decimal Valor { get; set; }
        public int VagasGaragem { get; set; }
        public string NomProprietario { get; set; }
        public string Descricao { get; set; }
        public string Cep { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }  
        public string imagens { get; set; }
        


    }
}

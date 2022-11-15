
using System.Collections.Generic;

namespace LocacaoImoveis.Domain.v1.DTOs.Response
{
    public class ImovelResponse
    {
        public string TipoImovel { get; set; }
        public decimal Valor { get; set; }
        public decimal VagasGaragem { get; set; }
        public string NomProprietario { get; set; }
        public string Descricao { get; set; }
        public EnderecoResponse Endereco { get; set; }

        public List<string> base64Images;

    }
}

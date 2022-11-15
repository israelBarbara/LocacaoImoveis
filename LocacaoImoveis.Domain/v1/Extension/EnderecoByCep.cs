using ControleEstoque.Domain.v1.DTOs.Request;
using LocacaoImoveis.Domain.v1.DTOs.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LocacaoImoveis.Domain.v1.Extension
{
    public class EnderecoByCep
    {
        public static async Task<EnderecoByCepRequest> GetEndereco(string cep)
        {
            var end = new EnderecoResponse();
            var url = $"http://viacep.com.br/ws/{cep}/json/";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            var data = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<EnderecoByCepRequest>(data);
            return result;
        }


    }
}

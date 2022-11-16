
using LocacaoImoveis.Business.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LocacaoImoveis.Domain.v1.Models
{
    public partial class Imovel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public TipoImovel tipoImovel { get; set; }    
        public decimal Valor { get; set; }
        public int Metros2 { get; set; }
        public int VagasGaragem { get; set; }
        public DateTime DataAnuncio { get; set; }
        public string NomProprietario { get; set; }
        public string Descricao { get; set; }
        public Endereco Endereco { get; set; }
        public IEnumerable<Imagem> Imagem { get; set; }

    }
}

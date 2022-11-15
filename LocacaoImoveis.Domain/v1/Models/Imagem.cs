
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LocacaoImoveis.Domain.v1.Models
{
    public class Imagem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CaminhoImagem { get; set; }
        public int ImovelId { get; set; }
        public DateTime DataCadastro { get; set; }
        // ef relation
        public Imovel Imovel { get; set; }
        

    }
}

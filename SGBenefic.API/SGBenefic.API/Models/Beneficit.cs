using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SGBenefic.API.Models
{
    public class Beneficit
    {
        public Beneficit() { }
        public Beneficit(int id,
                     string cpfCnpj,
                     string razaoSocial,
                     string nivel,
                     string codigoBeneficio,
                     string beneficio,
                     string orgCod,
                     DateTime dataConcessaoBeneficio,
                     int beneficioUtilizado)
        {
            this.Id = id;
            this.CpfCnpj = cpfCnpj;
            this.RazaoSocial = razaoSocial;
            this.Nivel = nivel;
            this.CodigoBeneficio = codigoBeneficio;
            this.Beneficio = beneficio;
            this.OrgCod = orgCod;
            this.DataConcessaoBeneficio = dataConcessaoBeneficio;
            this.BeneficioUtilizado = beneficioUtilizado;
        }
        [Key]
        public int Id { get; set; }

        [JsonPropertyName("CPF_CNPJ")]
        public string CpfCnpj { get; set; }

        [JsonPropertyName("RAZAO_SOCIAL")]
        public string RazaoSocial { get; set; }

        [JsonPropertyName("NIVEL")]
        public string Nivel { get; set; }

        [JsonPropertyName("CODIGO_BENEFICIO")]
        [Required]
        public string CodigoBeneficio { get; set; }

        [JsonPropertyName("BENEFICIO")]
        [Required]
        public string Beneficio { get; set; }

        [JsonPropertyName("ORG_COD")]
        [Required]
        public string OrgCod { get; set; }

        [JsonPropertyName("DATA_CONCESSAO_BENEFICIO")]
        [Required]
        public DateTime DataConcessaoBeneficio { get; set; }

        [JsonPropertyName("DATA_VALIDADE_BENEFICIO")]
        public DateTime? DataValidadeBeneficio { get; set; } = null;

        [JsonPropertyName("DATA_UTILIZACAO_BENEFICIO")]
        public DateTime? DataUtilizacaoBeneficio { get; set; } = null;

        [JsonPropertyName("BENEFICIO_UTILIZADO")]
        [Required]
        public int BeneficioUtilizado { get; set; } = 0;

        [JsonPropertyName("COMENTARIO")]
        public string Comentario { get; set; }
    }
}

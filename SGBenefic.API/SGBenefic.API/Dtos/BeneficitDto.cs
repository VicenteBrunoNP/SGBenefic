using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGBenefic.API.Dtos
{
    public class BeneficitDto
    {
        public int Id { get; set; }
        public string CpfCnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string Nivel { get; set; }
        public string CodigoBeneficio { get; set; }
        public string Beneficio { get; set; }
        public string OrgCod { get; set; }
        public DateTime DataConcessaoBeneficio { get; set; }
        public DateTime? DataValidadeBeneficio { get; set; } = null;
        public DateTime? DataUtilizacaoBeneficio { get; set; } = null;
        public int BeneficioUtilizado { get; set; } = 0;
        public string Comentario { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SGBenefic.API.Models
{
    public class Value
    {
        public string Id { get; set; }
        public string Description { get; set; } = "";
    }
}

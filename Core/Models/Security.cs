using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvestipsApi.Core.Models
{
    public class Security
    {
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Symbol { get; set; }
    }
}

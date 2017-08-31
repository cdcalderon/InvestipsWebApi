using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvestipsApi.Controllers.Resources
{
    public class SavePortfolioResource
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        public ICollection<int> Securities { get; set; }
        public SavePortfolioResource()
        {
            Securities = new Collection<int>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gastos.Web.Models
{
    public class TagPostViewModel
    {
        [Required]
        public string Tag { get; set; }
    }
}

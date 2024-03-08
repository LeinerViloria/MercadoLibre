using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoLibre.Models
{
    public class Menu
    {
        public string Name { get; set; } = string.Empty;
        public bool IsSeparator { get; set; }
        public bool ShowInfo => !IsSeparator;
    }
}

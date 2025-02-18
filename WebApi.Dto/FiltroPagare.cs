using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Dto
{
    public class FiltroPagare
    {
        public string FkOrganismo { get; set; }
        public string Condicion { get; set; }
        public string Modulo { get; set; } = string.Empty;
        public int ChequesNulos { get; set; }
        public string ImpresionCH { get; set; }
    }
}

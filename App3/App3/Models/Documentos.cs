using System;
using System.Collections.Generic;
using System.Text;

namespace App3.Models
{
    public class Documentos
    {
        public long DocumentosId { get; set; }
        public string Descripcion { get; set; }
        public string Url { get; set; }
        public long ClasesId { get; set; }

        public Clases Clases { get; set; }

    }
}

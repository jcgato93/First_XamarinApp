using System;
using System.Collections.Generic;
using System.Text;

namespace App3.Models
{
    public  class Clases
    {
        public Clases()
        {
            this.Comentarios = new List<Comentarios>();
            this.Documentos = new List<Documentos>();
        }

        public long ClasesId { get; set; }
        public long CursoId { get; set; }
        public string LinkVideo { get; set; }
        public string Descripcion { get; set; }
        public string Titulo { get; set; }
        public int Calificacion { get; set; }
        public DateTime Fecha_Publicacion { get; set; }

        public List<Comentarios> Comentarios { get; set; }
        public List<Documentos> Documentos { get; set; }

    }
}

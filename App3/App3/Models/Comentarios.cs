using System;
using System.Collections.Generic;
using System.Text;

namespace App3.Models
{
    public class Comentarios
    {
        public long ComentariosId { get; set; }
        public string Comentario { get; set; }
        public long ClasesId { get; set; }
        public long UserId { get; set; }

        public Clases Clases { get; set; }
        public User User { get; set; }
    }
}

using System;

namespace App3.Models
{
    public class Cursos
    {
        public long CursoId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Requisitos { get; set; }
        public int Calificacion { get; set; }
        public int Status { get; set; }
        public DateTime Fecha_Publicacion { get; set; }
        public long UserId { get; set; }
        public string VerificacionModerador { get; set; }
    

    }
}

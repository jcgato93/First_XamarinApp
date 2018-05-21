using System;
using System.Collections.Generic;
using System.Text;

namespace App3.Models
{
    public class User
    {

        public User()
        {
            this.Comentarios = new List<Models.Comentarios>();
        }

        public long UserId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RolId { get; set; }
        public int Status { get; set; }

        public List<Comentarios> Comentarios { get; set; }
        public Rol Rol { get; set; }

    }
}

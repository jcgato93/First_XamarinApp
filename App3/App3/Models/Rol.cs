using System;
using System.Collections.Generic;
using System.Text;

namespace App3.Models
{
    public class Rol
    {
        public Rol()
        {
            this.User = new List<Models.User>();
        }


        public int RolId { get; set; }
        public string Descripcion { get; set; }

        public List<User> User { get; set; }
    }
}

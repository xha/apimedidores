using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Models
{
    public class MenuItem
    {
        public MenuItem()
        {
            Id = 0;
            Controller = "";
            Action = "";
            Url = "";
            Descripcion = "";
            Padre = 0;
            Childs = 0;
            EsLink = false;
        }

        public int Id { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Url { get; set; }
        public string Descripcion { get; set; }
        public int Padre { get; set; }
        public int Childs { get; set; }
        public bool EsLink { get; set; }
    }
}

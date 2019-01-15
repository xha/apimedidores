using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Models
{
    public class Combo
    {
        public Combo()
        {
            Id = 0;
            Texto = "";
            Selected = false;
        }

        public int Id { get; set; }
        public string Texto { get; set; }
        public bool Selected { get; set; }
    }
}

using Datos;
using Datos.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globalizacion
{
    public class Labels
    {
        private static Dictionary<string, string> _labels = new Dictionary<string, string>();

        public void CambiarIdioma(string idioma)
        {
            try
            {
                _labels = new Dictionary<string, string>(2000);
                DataTable etiquetas = GlobalizacionData.GetEtiquetas(idioma);

                foreach (DataRow row in etiquetas.Rows)
                {
                    if (!_labels.ContainsKey((string)row["origen"]))
                    {
                        _labels.Add((string)row["origen"], (string)row[idioma]);
                    }

                }
            }
            catch
            {
            }
        }

        public static string Etiqueta(string etiqueta)
        {
            return (!_labels.Keys.Contains(etiqueta) ? "Labels." + etiqueta : _labels[etiqueta]);
        }
    }
}

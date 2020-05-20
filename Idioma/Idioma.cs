using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Idioma
{
    public class Idioma
    {
        private ResourceManager _resMana { get; set; }

        public Idioma(int idioma)
        {
            foreach (SettingsProperty currentProperty in Properties.Settings.Default.Properties)
            {
                if (currentProperty.DefaultValue.ToString() == idioma.ToString())
                {
                    this._resMana = new ResourceManager("Idioma.Resources." + currentProperty.Name,
                               typeof(Idioma).Assembly);
                }
            }
        }

        public string GetString(string value)
        {
            string resultado = "";
            resultado = this._resMana.GetString(value);
            return resultado;
        }
    }
}

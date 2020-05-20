using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Idioma
{
    public class IdiomaManager
    {
        private ResourceManager _resMana { get; set; }

        public IdiomaManager(int idioma)
        {
            if (idioma < 1)
            {
                SetResource();
                return;
            }
            else
            {
                foreach (SettingsProperty currentProperty in Properties.Settings.Default.Properties)
                {
                    if (currentProperty.DefaultValue.ToString() == idioma.ToString())
                    {
                        SetResource(currentProperty.Name);
                        return;
                    }
                }
            }
        }

        private void SetResource(string resource = "")
        {
            try
            {
                this._resMana = new ResourceManager("Idioma.Resources." + (resource == "" ? "Castellano" : resource),
                       typeof(IdiomaManager).Assembly);
            }
            catch (Exception)
            {
                throw;
            }

            return;
        }

        public string GetString(string value)
        {
            string resultado = "";
            resultado = this._resMana.GetString(value);
            if (resultado == null)
            {
                throw new Exception($"Traduccion no definida en {_resMana.BaseName}: {value}");
            }
            return resultado;
        }
    }
}

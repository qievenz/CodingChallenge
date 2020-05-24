using System;
using System.Configuration;
using System.Resources;

namespace Idioma
{
    public class IdiomaManager
    {
        private ResourceManager _resMana { get; set; }

        public IdiomaManager(int idioma)
        {
            //Si el idioma ingresado no es valido se setea el predeterminado
            foreach (SettingsProperty currentProperty in Properties.Settings.Default.Properties)
            {
                if (currentProperty.DefaultValue.ToString() == idioma.ToString())
                {
                    SetResource(currentProperty.Name);
                    return;
                }
            }
            SetResource();
            return;
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
            
            resultado = this._resMana.GetString(value.Trim());
            
            if (string.IsNullOrEmpty(resultado))
            {
                throw new Exception($"Traduccion no definida en {_resMana.BaseName}: {value.Trim()}");
            }
            return resultado;
        }
    }
}

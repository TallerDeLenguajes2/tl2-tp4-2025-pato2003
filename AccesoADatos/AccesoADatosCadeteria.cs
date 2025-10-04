using System.Text.Json;
using cadeteria;

namespace accesoADatosCadeteria
{
    public class AccesoADatosCadeteria
    {
        private string archivo = "./Data/cadeteria.json";

        public Cadeteria Obtener()
        {
            using (FileStream fs = new FileStream(archivo, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string contenido = sr.ReadToEnd();
                    Cadeteria cadeteria = JsonSerializer.Deserialize<Cadeteria>(contenido);
                    fs.Close();
                    return cadeteria;
                }
            }

        }
    }
    
}
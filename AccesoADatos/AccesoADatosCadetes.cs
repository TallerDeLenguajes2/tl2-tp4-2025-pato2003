using System.Text.Json;
using cadete;

namespace accesoADatosCadetes
{
    public class AccesoADatosCadetes
    {

        private string archivo = "./Data/cadetes.json";


        public List<Cadete> Obtener()
        {
            using (FileStream fs = new FileStream(archivo, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string contenido = sr.ReadToEnd();
                    List<Cadete> listaCadetes = JsonSerializer.Deserialize<List<Cadete>>(contenido);
                    fs.Close();
                    return listaCadetes;
                }
            }
        }
    }
    
}
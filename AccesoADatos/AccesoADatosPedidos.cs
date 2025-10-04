namespace accesoADatosPedidos
{
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using pedidos;
    public class AccesoADatosPedidos
    {
        private string archivo = "./Data/pedidos.json";


        public List<Pedidos> Obtener()
        {
            using (FileStream fs = new FileStream(archivo, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string contenido = sr.ReadToEnd();
                    var options = new JsonSerializerOptions();
                    options.Converters.Add(new JsonStringEnumConverter());
                    List<Pedidos> listaPedidos = JsonSerializer.Deserialize<List<Pedidos>>(contenido, options);
                    fs.Close();
                    return listaPedidos;
                }
            }
        }

        public void Guardar(List<Pedidos> listaPedidos)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(listaPedidos, options);
            File.WriteAllText(archivo, json);
        }

    }
    
}
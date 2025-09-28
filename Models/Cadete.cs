using System.Text.Json.Serialization;
using cadeteria;
namespace cadete
{
    public class Cadete
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("nombre")]
        public string Nombre { get; set; }
        [JsonPropertyName("direccion")]
        public string Direccion { get; set; }
        [JsonPropertyName("telefono")]
        public string Telefono { get; set; }

        public Cadete(int id, string nombre, string direccion, string telefono)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Direccion = direccion;
            this.Telefono = telefono;
        }


        public static List<Cadete> procesarDatosCadetes(List<string[]> contenido)
        {
            List<Cadete> listaCadetes = new List<Cadete>();
            foreach (var linea in contenido)
            {
                Cadete Cadete = new Cadete(Convert.ToInt32(linea[0]), linea[1], linea[2], linea[3]);
                listaCadetes.Add(Cadete);
            }
            return listaCadetes;
        }

    }
    
}

using System.Text.Json.Serialization;

namespace cliente
{
    public class Cliente
    {

        public Cliente(string nombre, string direccion, string telefono, string datosReferenciaDireccion)
        {
            this.Nombre = nombre;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.DatosReferenciaDireccion = datosReferenciaDireccion;
        }

        [JsonPropertyName("nombre")]
        public string Nombre { get; set; }
        [JsonPropertyName("direccion")]
        public string Direccion { get; set; }
        [JsonPropertyName("telefono")]
        public string Telefono { get; set; }
        [JsonPropertyName("referencia")]
        public string DatosReferenciaDireccion { get; set; }
    }
    
}
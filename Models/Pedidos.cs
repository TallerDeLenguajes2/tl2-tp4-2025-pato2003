using System.Text.Json.Serialization;
using cadete;
using cliente;
namespace pedidos
{
    
    public class Pedidos
    {
        [JsonPropertyName("nro")]
        public int Nro{ get; set; }
        [JsonPropertyName("obs")]
        public string Obs{ get; set; }
        [JsonPropertyName("cliente")]
        public Cliente Cliente{ get; set; }
        [JsonPropertyName("estado")]
        private Estado Estado{ get; set; }
        private Cadete cadete;
        public static int id = 0;

        public Pedidos(string obs, Cliente cliente)
        {
            ++id;
            Nro = id;
            Obs = obs;
            Cliente = cliente;
            Estado = Estado.EsperandoConfirmacion;
        }

        public void cambiarEstado(Estado estadoNuevo)
        {
            Estado  = estadoNuevo;
            return;
        }

        public void asignarCadete(Cadete cadete)
        {
            this.cadete = cadete;
            return;
        }

        public Cadete getCadete()
        {
            return cadete;
        }

        public string verDireccionCliente()
        {
            return Cliente.Direccion;
        }


    }
}
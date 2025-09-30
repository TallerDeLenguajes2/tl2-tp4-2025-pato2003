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
        public Estado Estado{ get; set; }
        [JsonPropertyName("cadete")]
        public Cadete Cadete{ get; set; }
        private static int id = 0;

        public Pedidos(string obs, Cliente cliente)
        {
            ++id;
            Nro = id;
            Obs = obs;
            Cliente = cliente;
            Estado = Estado.EsperandoConfirmacion;
        }

        public void cambiarEstado(int estadoNuevo)
        {
            switch (estadoNuevo)
            {
                case 1:
                    Estado = Estado.Preparando;
                    break;
                case 2:
                    Estado = Estado.Listo;
                    break;
                case 3:
                    Estado = Estado.Cancelado;
                    break;
                case 4:
                    Estado = Estado.Enviado;
                    break;
                case 5:
                    Estado = Estado.Entregado;
                    break;
                default:
                    Estado = Estado.EsperandoConfirmacion;
                    break;
            }
            return;
        }

        public void asignarCadete(Cadete cadete)
        {
            this.Cadete = cadete;
            return;
        }

        public Cadete getCadete()
        {
            return Cadete;
        }

        public string verDireccionCliente()
        {
            return Cliente.Direccion;
        }


    }
}
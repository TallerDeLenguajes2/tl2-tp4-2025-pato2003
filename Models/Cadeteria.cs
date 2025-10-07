using System.Data.Common;
using System.Text.Json;
using System.Text.Json.Serialization;
using cadete;
using cliente;
using pedidos;

namespace cadeteria
{
    public class Cadeteria
    {

        [JsonPropertyName("nombre")]
        public string Nombre { get; set; }
        [JsonPropertyName("telefono")]
        public string Telefono { get; set; }
        public List<Cadete> ListadoCadetes { get; set; }
        public List<Pedidos> ListadoPedidos { get; set; }
        public Cadeteria(string nombre, string telefono)
        {
            Nombre = nombre;
            Telefono = telefono;
            ListadoCadetes = new List<Cadete>();
            ListadoPedidos = new List<Pedidos>();
        }


        public void anadirCadete(Cadete cadete)
        {
            ListadoCadetes.Add(cadete);
            return;
        }


        private Pedidos GetPedido(int idPedido)
        {
            return ListadoPedidos.Find(pedido => pedido.Nro == idPedido);
        }
        private Cadete GetCadete(int idCadete)
        {
            return ListadoCadetes.Find(cadete => cadete.Id == idCadete);
        }



        public Pedidos asignarPedido(int idPedido, int idCadete)
        {
            Pedidos pedido = GetPedido(idPedido);
            if (pedido.Cadete == null)
            {
                return null;
            }
            Cadete cadete = GetCadete(idCadete);
            pedido.asignarCadete(cadete);
            return pedido;
        }
        public void reasignarPedido(int idPedido, int idCadeteNuevo)
        {
            Pedidos pedidoAReasignar = GetPedido(idPedido);
            Cadete cadeteNuevo = GetCadete(idCadeteNuevo);
            pedidoAReasignar.asignarCadete(cadeteNuevo);
        }

        public double jornalACobrar(int idCadete)
        {
            int cantPedidos = 0;
            foreach (var pedido in ListadoPedidos)
            {
                if (pedido.getCadete().Id == idCadete)
                {
                    ++cantPedidos;
                }
            }
            return cantPedidos * 500;
        }


        public void CambiarCadeteAPedido(int idCadete, int idPedido)
        {
            Pedidos pedidoAAsignar = GetPedido(idPedido);
            Cadete cadete = GetCadete(idCadete);
            pedidoAAsignar.asignarCadete(cadete);
            return;
        }

        public int cantidadPedidos(int idCadete)
        {
            int cantPedidos = 0;
            foreach (var pedido in ListadoPedidos)
            {
                if (pedido.getCadete().Id == idCadete)
                {
                    ++cantPedidos;
                }
            }
            return cantPedidos;
        }



        public void mostrarCadetes()
        {
            Console.WriteLine("\n--- Lista de Cadetes ---");
            foreach (var cadete in ListadoCadetes)
            {
                Console.WriteLine($"ID: {cadete.Id}");
                Console.WriteLine($"Nombre: {cadete.Nombre}");
                Console.WriteLine($"Dirección: {cadete.Direccion}");
                Console.WriteLine($"Teléfono: {cadete.Telefono}");
                Console.WriteLine("-----------------------------");
            }
            Console.WriteLine("--- Fin de la lista de cadetes ---\n");
        }





        public void agregarListaCadetes(List<Cadete> listadoCadetes)
        {
            foreach (Cadete cadete in listadoCadetes)
            {
                ListadoCadetes.Add(cadete);
            }
        }


        public void agregarListaPedidos(List<Pedidos> listaPedidos)
        {
            foreach (Pedidos pedido in listaPedidos)
            {
                ListadoPedidos.Add(pedido);
            }
        }

        public void crearPedido(Pedidos pedido)
        {
            ListadoPedidos.Add(pedido);
        }


        public void cambiarEstadoPedido(int estadoNuevo, int idPedido)
        {
            Pedidos pedido = GetPedido(idPedido);
            pedido.cambiarEstado(estadoNuevo);
            return;
        }
    }

}


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


        public static Cadeteria procesarDatosCadeterias(string[] contenido)
        {
            Cadeteria cadeteria = new Cadeteria(contenido[0], contenido[1]);
            return cadeteria;
        }

        public void anadirCadete(Cadete cadete)
        {
            ListadoCadetes.Add(cadete);
            return;
        }



        public string mostrarInforme()
        {
            string mensaje = "\n--- Informe de Pedidos ---\n";
            int totalEnvios = 0;
            double totalMonto = 0;
            int cantidadDePedidos;

            foreach (var cadete in ListadoCadetes)
            {
                cantidadDePedidos = cantidadPedidos(cadete.Id);
                totalEnvios += cantidadDePedidos;
                double montoGanado = cantidadDePedidos * 500;
                totalMonto += montoGanado;
                mensaje += $"Cadete: {cadete.Nombre} | Envíos: {cantidadDePedidos} | Monto ganado: ${montoGanado}\n";
            }

            double promedioEnvios = ListadoCadetes.Count > 0 ? (double)totalEnvios / ListadoCadetes.Count : 0;
            mensaje += $"\nTotal de envíos: {totalEnvios}\n";
            mensaje += $"Total ganado por todos los cadetes: ${totalMonto}\n";
            mensaje += $"Promedio de envíos por cadete: {promedioEnvios:F2}\n";
            return mensaje;
        }


        private Pedidos? GetPedido(int idPedido)
        {
            return ListadoPedidos.Find(pedido => pedido.Nro == idPedido);
        }
        private Cadete? GetCadete(int idCadete)
        {
            return ListadoCadetes.Find(cadete => cadete.Id == idCadete);
        }



        public void reasignarPedido(int idPedido, int idCadeteNuevo)
        {
            Pedidos? pedidoAReasignar = GetPedido(idPedido);
            Cadete? cadeteNuevo = GetCadete(idCadeteNuevo);
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


        public void asignarCadeteAPedido(int idCadete, int idPedido)
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


        

        public void cambiarEstadoPedido(int idPedido, int idEstadoNuevo)
        {
            Pedidos pedido = ListadoPedidos.Find(pedido => pedido.Nro == idPedido);
            Estado estadoNuevo;
            switch (idEstadoNuevo)
            {
                case 1:
                    estadoNuevo = Estado.Preparando;
                    break;
                case 2:
                    estadoNuevo = Estado.Listo;
                    break;
                case 3:
                    estadoNuevo = Estado.Cancelado;
                    break;
                case 4:
                    estadoNuevo = Estado.Enviado;
                    break;
                case 5:
                    estadoNuevo = Estado.Entregado;
                    break;
                default:
                    estadoNuevo = Estado.EsperandoConfirmacion;
                    break;
            }
            pedido.cambiarEstado(estadoNuevo);
            return;
        }

        public void agregarListaCadetes(List<Cadete> listadoCadetes)
        {
            foreach (Cadete cadete in listadoCadetes)
            {
                ListadoCadetes.Add(cadete);
            }
        }

        public void crearPedido(Pedidos pedido)
        {
            ListadoPedidos.Add(pedido);
        }
    }

}


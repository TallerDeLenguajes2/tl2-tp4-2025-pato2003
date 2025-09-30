using iAccesoADatos;
using Microsoft.AspNetCore.Mvc;
using accesoADatosJSON;
using pedidos;
using cadete;
using informe;

namespace tl2_tp4_2025_pato2003.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadeteriaController : ControllerBase
    {
        private IAccesoADatos accesoADatos;
        public CadeteriaController()
        {
            accesoADatos = new AccesoADatosJSON("cadeterias.json", "cadetes.json", "pedidos.json", "informe.json");
        }

        [HttpGet("GetCadetes")]
        public ActionResult<List<Cadete>> GetCadetes()
        {
            List<Cadete> cadetes = accesoADatos.getCadetes();
            return Ok(cadetes);
        }
        [HttpGet("GetPedidos")]
        public ActionResult<List<Pedidos>> GetPedidos()
        {
            List<Pedidos> pedidos = accesoADatos.getPedidos();
            return Ok(pedidos);
        }
        [HttpGet("GetInforme")]
        public ActionResult<InformeCadeteria> GetInforme()
        {
            InformeCadeteria informe = accesoADatos.getInforme();
            return Ok(informe);
        }


        [HttpPost]
        public ActionResult<Pedidos> agregarPedido(Pedidos pedidoNuevo)
        {
            var pedido = accesoADatos.agregarPedido(pedidoNuevo);
            return Ok(pedido);
        }


        [HttpPut("AsignarPedido")]
        public ActionResult<Pedidos> AsignarPedido(int idPedido, int idCadete)
        {
            var listaPedidos = accesoADatos.getPedidos();
            var listaCadetes = accesoADatos.getCadetes();
            Pedidos pedido = listaPedidos.Find(p => p.Nro == idPedido);
            if (pedido == null)
            {
                return NotFound("No existe ningun pedido con ese id");
            }

            Cadete cadete = listaCadetes.Find(c => c.Id == idCadete);
            if (cadete == null)
            {
                return NotFound("No existe ningun cadete con ese id");
            }

            if (pedido.Cadete!=null)
            {
                return BadRequest("Este pedido ya tiene asignado un cadete");
            }
            pedido.asignarCadete(cadete);
            accesoADatos.guardarPedidos(listaPedidos);
            return Ok(pedido);
        }

        [HttpPut("CambiarEstadoPedido")]
        public ActionResult<Pedidos> CambiarEstadoPedido(int idPedido, int nuevoEstado)
        {
            var listaPedidos = accesoADatos.getPedidos();
            Pedidos pedido = listaPedidos.Find(p => p.Nro == idPedido);
            if (pedido == null)
            {
                return NotFound("No existe ningun pedido con ese id");
            }

            if (nuevoEstado < 0 || nuevoEstado > 5)
            {
                return BadRequest("Valor de estado incorrecto");
            }

            pedido.cambiarEstado(nuevoEstado);
            accesoADatos.guardarPedidos(listaPedidos);
            return Ok(pedido);
        }

        [HttpPut("CambiarCadetePedido")]
        public ActionResult<Pedidos> CambiarCadetePedido(int idPedido, int idNuevoCadete)
        {
            var listaPedidos = accesoADatos.getPedidos();
            var listaCadetes = accesoADatos.getCadetes();
            Pedidos pedido = listaPedidos.Find(p => p.Nro == idPedido);
            if (pedido == null)
            {
                return NotFound("No existe ningun pedido con ese id");
            }

            Cadete cadete = listaCadetes.Find(c => c.Id == idNuevoCadete);
            if (cadete == null)
            {
                return NotFound("No existe ningun cadete con ese id");
            }
            pedido.asignarCadete(cadete);
            accesoADatos.guardarPedidos(listaPedidos);
            return Ok(pedido);
        }
    }
}
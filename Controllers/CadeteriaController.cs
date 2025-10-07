using Microsoft.AspNetCore.Mvc;
using pedidos;
using cadete;
using cadeteria;
using accesoADatosCadeteria;
using accesoADatosCadetes;
using accesoADatosPedidos;

namespace tl2_tp4_2025_pato2003.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class CadeteriaController : ControllerBase
    {
        private Cadeteria cadeteria;
        private AccesoADatosCadeteria ADCadeteria;
        private AccesoADatosCadetes ADCadetes; 
        private AccesoADatosPedidos ADPedidos;
        public CadeteriaController()
        {
            ADCadeteria = new AccesoADatosCadeteria();
            ADCadetes = new AccesoADatosCadetes();
            ADPedidos = new AccesoADatosPedidos();

            cadeteria = ADCadeteria.Obtener();
            cadeteria.agregarListaCadetes(ADCadetes.Obtener());
            cadeteria.agregarListaPedidos(ADPedidos.Obtener());

        }

        /// <summary>
        /// Devuelve el listado de todos los cadetes
        /// </summary>
        /// <returns>200 ok -</returns>
        [HttpGet]
        [Route("GetCadetes")]
        public ActionResult<List<Cadete>> GetCadetes()
        {
            var listaCadetes = cadeteria.ListadoCadetes;
            return Ok(listaCadetes);
        }

        [HttpGet]
        [Route("GetPedidos")]
        public ActionResult<List<Pedidos>> GetPedidos()
        {
            var listaPedidos = cadeteria.ListadoPedidos;
            return Ok(listaPedidos);
        }


        /// <summary>
        /// Recibe los datos de un nuevo pedido
        /// </summary>
        /// <param name="pedidoNuevo">Json con los datos del nuevo pedido</param>
        /// <returns>201 - objeto creado</returns>

        [HttpPost("DarDeAltaPedido")]
        public ActionResult<string> agregarPedido(Pedidos pedidoNuevo)
        {
            cadeteria.crearPedido(pedidoNuevo);
            ADPedidos.Guardar(cadeteria.ListadoPedidos);
            return Created("","Se creo exitosamente el pedido");
        }


        [HttpPut("AsignarPedido")]
        public ActionResult<Pedidos> AsignarPedido(int idPedido, int idCadete)
        {
            Pedidos pedido = cadeteria.asignarPedido(idPedido, idCadete);
            if (pedido!= null) {
                ADPedidos.Guardar(cadeteria.ListadoPedidos);
                return Ok(pedido);
            }else
            {
                return BadRequest("El pedido ya tiene asignado un cadete");
            }
        }

        [HttpPut("CambiarEstadoPedido")]
        public ActionResult<string> CambiarEstadoPedido(int idPedido, int nuevoEstado)
        {
            cadeteria.cambiarEstadoPedido(nuevoEstado, idPedido);
            ADPedidos.Guardar(cadeteria.ListadoPedidos);
            return Ok("El estado del pedido se actualizo correctamente");
        }

        [HttpPut("CambiarCadetePedido")]
        public ActionResult<string> CambiarCadetePedido(int idPedido, int idNuevoCadete)
        {
            cadeteria.CambiarCadeteAPedido(idNuevoCadete, idPedido);
            ADPedidos.Guardar(cadeteria.ListadoPedidos);
            return Ok("El pedido se guardo correctamente");
        }
    }
}
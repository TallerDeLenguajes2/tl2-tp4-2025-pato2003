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
        public void agregarPedido(Pedidos pedidoNuevo)
        {
            
        }

    }
}
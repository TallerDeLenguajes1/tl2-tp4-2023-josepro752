using EspacioArchivos;
using Microsoft.AspNetCore.Mvc;

namespace tl2_tp4_2023_josepro752.Controllers;

[ApiController]
[Route("[controller]")]
public class CadeteriaController : ControllerBase
{
    private Cadeteria cadeteria;
    private readonly ILogger<CadeteriaController> _logger;

    public CadeteriaController(ILogger<CadeteriaController> logger)
    {
        _logger = logger;
        cadeteria = Cadeteria.Instance;
    }

    [HttpGet]
    public ActionResult <string> GetCadeteria() {
        return (Ok(cadeteria));
    }

    [HttpGet]
    [Route("Informe")]
    public ActionResult <string> GetInforme() {
        return (Ok(cadeteria.GetInforme()));
    }

    [HttpPost ("Add_Pedidos")]
    public ActionResult <string> AddPedidos(string nombre, string direccion, long telefono, string datosRef, string observacion) {
        cadeteria.TomarPedido(nombre,direccion,telefono,datosRef,observacion);
        var pedido = cadeteria.Pedidos.FirstOrDefault(p => p.Numero == cadeteria.Pedidos.Count()-1);
        if (pedido != null) {
            return (Ok(pedido));
        }
        return StatusCode(500,"No se pudo tomar el pedido");
    }

    [HttpPut ("Asignar_Pedido")]
    public ActionResult <string> AsignarPedido(int idCadete, int numPedido) {
        var pedido = cadeteria.Pedidos.FirstOrDefault(p => p.Numero == numPedido);
        var cadete = cadeteria.Cadetes.FirstOrDefault(p => p.Id == idCadete);
        if (pedido != null) {
            if (cadete != null) {
                pedido.IdCadete = idCadete;
                return (Ok(pedido));
            }
            return StatusCode(500,"No se pudo encontrar el cadete");
        }
        return StatusCode(500,"No se pudo encontrar el pedido");
    }

    [HttpPut ("Cambiar_Estado_Pedido")]
    public ActionResult <string> CambiarEstadoPedido(int numPedido, int estado) {
        var pedido = cadeteria.Pedidos.FirstOrDefault(p => p.Numero == numPedido);
        if (pedido != null) {
            if (pedido.Estado == Estado.SinEntregar) {
                if (estado > 0 && estado < 4) {
                    pedido.Estado = (Estado)Enum.Parse(typeof(Estado),estado.ToString());
                    return (Ok(pedido));
                }
                return StatusCode(500,"El estado que quiere asgirnar no es valido");
            } else {
                if (pedido.Estado == Estado.Entregado) {
                    return NotFound("El pedido ya fue entregado");
                } else {
                    return NotFound("El pedido ya fue cancelado");
                }
            }
        }
        return StatusCode(500,"No se pudo encontrar el pedido");
    }
    [HttpPut ("Cambiar_Cadete_Pedido")]
    public ActionResult <string> CambiarCadetePedido(int idCadete, int numPedido) {
        return AsignarPedido(idCadete,numPedido);
    }
}
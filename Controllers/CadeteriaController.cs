using Microsoft.AspNetCore.Mvc;
using EspacioCadeteria;

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
        cadeteria = Cadeteria.GetInstance();
    }

    [HttpGet]
    public ActionResult <string> GetCadeteria() {
        return (Ok(cadeteria));
    }

    [HttpGet]
    [Route("Pedidos")]
    public ActionResult <string> GetPedidos() {
        return (Ok(cadeteria.GetPedidos()));
    }

    [HttpGet]
    [Route("Cadete")]
    public ActionResult <string> GetCadete() {
        return (Ok(cadeteria.GetCadetes()));
    }

    [HttpGet]
    [Route("Informe")]
    public ActionResult <string> GetInforme() {
        return (Ok(cadeteria.GetInforme(cadeteria)));
    }

    [HttpPost ("Add_Cadete")]
    public ActionResult <string> AddCadete(string nombre, string direccion, long telefono) {
        cadeteria.AddCadete(nombre,direccion,telefono);
        var cadete = cadeteria.GetCadetes().FirstOrDefault(c => c.Id == cadeteria.GetCadetes().Count()-1);
        if (cadete != null) {
            return (Ok(cadete));
        }
        return StatusCode(500,"No se pudo tomar el pedido");
    }

    [HttpPost ("Add_Pedidos")]
    public ActionResult <string> AddPedidos(string nombre,string observacion, Estado estado, Cliente cliente) {
        cadeteria.AddPedido(nombre,observacion,estado,cliente);
        var pedido = cadeteria.GetPedidos().FirstOrDefault(p => p.Id == cadeteria.GetPedidos().Count()-1);
        if (pedido != null) {
            return (Ok(pedido));
        }
        return StatusCode(500,"No se pudo tomar el pedido");
    }

    [HttpPut ("Asignar_Pedido")]
    public ActionResult <string> AsignarPedido(int idCadete, int numPedido) {
        var pedido = cadeteria.GetPedidos().FirstOrDefault(p => p.Id == numPedido);
        var cadete = cadeteria.GetCadetes().FirstOrDefault(p => p.Id == idCadete);
        if (pedido != null) {
            if (cadete != null) {
                pedido.IdCad = idCadete;
                return (Ok(pedido));
            }
            return StatusCode(500,"No se pudo encontrar el cadete");
        }
        return StatusCode(500,"No se pudo encontrar el pedido");
    }

    [HttpPut ("Cambiar_Estado_Pedido")]
    public ActionResult <string> CambiarEstadoPedido(int numPedido, int estado) {
        var pedido = cadeteria.GetPedidos().FirstOrDefault(p => p.Id == numPedido);
        if (pedido != null) {
            if (pedido.Estado == Estado.EnPreparacion) {
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
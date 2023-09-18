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
    [Route("Pedidos")]
    public ActionResult <string> GetPedidos() {
        return (Ok(cadeteria.Pedidos));
    }

    [HttpGet]
    [Route("Cadete")]
    public ActionResult <string> GetCadete() {
        return (Ok(cadeteria.Cadetes));
    }

    [HttpGet]
    [Route("Informe")]
    public ActionResult <string> GetInforme() {
        return (Ok(cadeteria.GetInforme()));
    }
}

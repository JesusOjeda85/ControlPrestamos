using ClsObjetos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Entidades;
using WebApi.Repositorio.CargarPadrones;
using WebApi.Repositorio.CargayDescarga;

namespace WebApi.Controllers.CargarPadrones
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargarPadronesController : ControllerBase
    {
        [HttpPost]
        [Route("Padron_Liquidez")]
        public IActionResult Padron_Liquidez(DatosCargar Obj)
        {
            ObjMensaje msg = RCargarPadrones.Padron_Liquidez(Obj);
            return StatusCode(StatusCodes.Status200OK, msg);
        }
    }
}

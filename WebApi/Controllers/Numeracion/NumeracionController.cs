using ClsObjetos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Entidades;
using WebApi.Repositorio.AplicacionDescuentos;
using WebApi.Repositorio.Numeracion;

namespace WebApi.Controllers.Numeracion
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumeracionController : ControllerBase
    {
        [HttpGet]
        [Route("Listar_Emisiones")]
        public IActionResult Listar_Emisiones()
        {
            ObjMensaje msg = RNumeracion.Listar_Emisiones();
            return StatusCode(StatusCodes.Status200OK, msg);
        }

        [HttpPost]
        [Route("Aplicar_Numeracion")]
        public IActionResult Aplicar_Numeracion(DatosNumeracion ObjDto)
        {          
            ObjMensaje msg = RNumeracion.Aplicar_Numeracion(ObjDto);
            return StatusCode(StatusCodes.Status200OK, msg);
        }
    }

}

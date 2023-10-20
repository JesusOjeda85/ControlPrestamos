using ClsObjetos;
using Microsoft.AspNetCore.Mvc;
using WebApi.Entidades;
using WebApi.Repositorio.CargayDescarga;

namespace WebApi.Controllers.CargayDescarga
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargayDescargaController : ControllerBase
    {
      

        [HttpPost]
        [Route("Subir_Archivo_014a")]
        public IActionResult Subir_Archivo_014a(DatosCargar Obj)
        {          
            ObjMensaje msg = RCargayDescarga.Subir_Archivo_014a(Obj);
            return StatusCode(StatusCodes.Status200OK, msg);
        }
    }
}

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
        [Route("Subir_Archivo")]
        public IActionResult Subir_Archivo(DatosCargar Obj)
        {          
            ObjMensaje msg = RCargayDescarga.Subir_Archivo(Obj);
            return StatusCode(StatusCodes.Status200OK, msg);
        }

        [HttpPost]
        [Route("Salida_Archivo")]
        public IActionResult Salida_Archivo(ArchivoSalida Obj)
        {
            ObjMensaje msg = RCargayDescarga.Salida_Archivo(Obj);
            return StatusCode(StatusCodes.Status200OK, msg);
        }



    }
}

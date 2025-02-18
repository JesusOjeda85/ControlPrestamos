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
        [HttpPost]
        [Route("Listar_Emisiones")]
        public IActionResult Listar_Emisiones(DatosNumeracion ObjDto)
        {
            ObjMensaje msg = RNumeracion.Listar_Emisiones(ObjDto);
            return StatusCode(StatusCodes.Status200OK, msg);
        }

        [HttpPost]
        [Route("Aplicar_Numeracion")]
        public IActionResult Aplicar_Numeracion(DatosNumeracion ObjDto)
        {
            ObjMensaje msg = RNumeracion.Aplicar_Numeracion(ObjDto);
            return StatusCode(StatusCodes.Status200OK, msg);
        }


        [HttpPost]
        [Route("Listar_SalidasEmisiones")]
        public IActionResult Listar_SalidasEmisiones(DatosNumeracion ObjDto)
        {
            ObjMensaje msg = RNumeracion.Listar_SalidasEmisiones(ObjDto);
            return StatusCode(StatusCodes.Status200OK, msg);
        }

        [HttpPost]
        [Route("Listar_Emisiones_Renumeracion")]
        public IActionResult Listar_Emisiones_Renumeracion(DatosNumeracion ObjDto)
        {
            ObjMensaje msg = RNumeracion.Listar_Emisiones_Renumeracion(ObjDto);
            return StatusCode(StatusCodes.Status200OK, msg);
        }

        [HttpPost]
        [Route("Aplicar_Renumeracion")]
        public IActionResult Aplicar_Renumeracion(DatosNumeracion ObjDto)
        {
            ObjMensaje msg = RNumeracion.Aplicar_Renumeracion(ObjDto);
            return StatusCode(StatusCodes.Status200OK, msg);
        }
    }

}

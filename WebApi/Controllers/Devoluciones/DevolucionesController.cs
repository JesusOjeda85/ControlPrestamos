
using ClsObjetos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using WebApi.Entidades;
using WebApi.Repositorio.Captura;
using WebApi.Repositorio.Devoluciones;
using WebApi.Repositorio.Numeracion;

namespace WebApi.Controllers.Devoluciones
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevolucionesController : ControllerBase
    {

        [HttpPost]
        [Route("Listar_Adeudos_Creditos")]
        public IActionResult Listar_Adeudos_Creditos(BuscarEmpleado ObjDto)
        {
            ObjMensaje msg = RDevoluciones.Listar_Adeudos_Creditos(ObjDto);
            return StatusCode(StatusCodes.Status200OK, msg);
        }

        [HttpPost]
        [Route("Guardar_Devoluciones")]
        public IActionResult Guardar_Devoluciones(DatosCapturaDevoluciones ObjDto)
        {
            ObjMensaje msg = RDevoluciones.Guardar_Devoluciones(ObjDto);
            return StatusCode(StatusCodes.Status200OK, msg);
        }

        [HttpPost]
        [Route("Listar_Adeudos_Impresion")]
        public IActionResult Listar_Adeudos_Impresion(FiltroAdeudos ObjDto)
        {
            ObjMensaje msg = RDevoluciones.Listar_Adeudos_Impresion(ObjDto);
            return StatusCode(StatusCodes.Status200OK, msg);
        }

        [HttpPost]
        [Route("Aplicar_Renumeracion")]
        public IActionResult Aplicar_Renumeracion(DatosNumeracion ObjDto)
        {
            ObjMensaje msg = RDevoluciones.Aplicar_Renumeracion(ObjDto);
            return StatusCode(StatusCodes.Status200OK, msg);
        }
    }  
}

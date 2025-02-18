using ClsObjetos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using WebApi.Repositorio.Devoluciones;
using WebApi.Repositorio.Reportes;

namespace WebApi.Controllers.Reportes
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportesController : ControllerBase
    {
        [HttpPost]
        [Route("Listar_Pagare")]
        public IActionResult Listar_Pagare(FiltroPagare Obj)
        {
            ObjMensaje msg = RReportes.Listar_Pagare(Obj);
            return StatusCode(StatusCodes.Status200OK, msg);
        }
        [HttpPost]
        [Route("Listar_Saldos")]
        public IActionResult Listar_Saldos(FiltroPagare Obj)
        {
            ObjMensaje msg = RReportes.Listar_Saldos(Obj);
            return StatusCode(StatusCodes.Status200OK, msg);
        }

        [HttpPost]
        [Route("Salida_Emisiones")]
        public IActionResult Salida_Emisiones(FiltroPagare Obj)
        {
            ObjMensaje msg = RReportes.Salida_Emisiones(Obj);
            return StatusCode(StatusCodes.Status200OK, msg);
        }

        [HttpPost]
        [Route("Listar_Empleados")]
        public IActionResult Listar_Empleados(FiltroBuscarEmpleado Obj)
        {
            ObjMensaje msg = RReportes.Listar_Empleados(Obj);
            return StatusCode(StatusCodes.Status200OK, msg);
        }

        [HttpPost]
        [Route("Listar_Adeudos")]
        public IActionResult Listar_Adeudos(FiltroPagare Obj)
        {
            ObjMensaje msg = RReportes.Listar_Adeudos(Obj);
            return StatusCode(StatusCodes.Status200OK, msg);
        }

        [HttpPost]
        [Route("Listar_Cancelaciones")]
        public IActionResult Listar_Cancelaciones(FiltroPagare Obj)
        {
            ObjMensaje msg = RReportes.Listar_Cancelaciones(Obj);
            return StatusCode(StatusCodes.Status200OK, msg);
        }

        [HttpPost]
        [Route("Revision_Captura")]
        public IActionResult Revision_Captura(FiltroPagare Obj)
        {
            ObjMensaje msg = RReportes.Revision_Captura(Obj);
            return StatusCode(StatusCodes.Status200OK, msg);
        }

    }
}

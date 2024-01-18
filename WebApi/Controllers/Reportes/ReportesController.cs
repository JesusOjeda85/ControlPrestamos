using ClsObjetos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
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
        [Route("Listar_Empleados")]
        public IActionResult Listar_Empleados(BuscarEmpleado Obj)
        {
            ObjMensaje msg = RReportes.Listar_Empleados(Obj);
            return StatusCode(StatusCodes.Status200OK, msg);
        }
    }
}

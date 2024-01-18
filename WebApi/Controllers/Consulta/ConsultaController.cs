using ClsObjetos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using WebApi.Repositorio.Consulta;
using WebApi.Repositorio.Reportes;

namespace WebApi.Controllers.Consulta
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        [HttpPost]
        [Route("Listar_Empleados")]
        public IActionResult Listar_Empleados(FiltroBuscarEmpleado Obj)
        {
            ObjMensaje msg = RConsulta.Listar_Empleados(Obj);
            return StatusCode(StatusCodes.Status200OK, msg);
        }

        [HttpPost]
        [Route("Listar_NumCreditos")]
        public IActionResult Listar_NumCreditos(FiltroEmpleado Obj)
        {
            ObjMensaje msg = RConsulta.Listar_NumCreditos(Obj);
            return StatusCode(StatusCodes.Status200OK, msg);
        }

        [HttpPost]
        [Route("Listar_DetalleCredito")]
        public IActionResult Listar_DetalleCredito(FiltroIdCredito Obj)
        {
            ObjMensaje msg = RConsulta.Listar_DetalleCredito(Obj);
            return StatusCode(StatusCodes.Status200OK, msg);
        }
    }
}

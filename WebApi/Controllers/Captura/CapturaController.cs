using AutoMapper;
using ClsObjetos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using WebApi.Entidades;
using WebApi.Repositorio.Captura;
using WebApi.Repositorio.Usuarios;

namespace WebApi.Controllers.Captura
{
    [Route("api/[controller]")]
    [ApiController]
    public class CapturaController : ControllerBase
    {
        private readonly IMapper mapper;

        public CapturaController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("Listar_Plazos")]
        public IActionResult Listar_Plazos(IdOrganismoDto ObjDto)
        {
            var obj = mapper.Map<DatosCaptura>(ObjDto);
            ObjMensaje msg = RCaptura.Listar_Plazos(obj);
            return StatusCode(StatusCodes.Status200OK, msg);
        }

        [HttpGet]
        [Route("Listar_Bancos")]
        public IActionResult Listar_Bancos()
        {           
            ObjMensaje msg = RCaptura.Listar_Bancos();
            return StatusCode(StatusCodes.Status200OK, msg);
        }

        [HttpGet]
        [Route("Listar_TipoPago")]
        public IActionResult Listar_TipoPago()
        {
            ObjMensaje msg = RCaptura.Listar_TipoPago();
            return StatusCode(StatusCodes.Status200OK, msg);
        }

        [HttpGet]
        [Route("Listar_ZonaPago")]
        public IActionResult Listar_ZonaPago()
        {
            ObjMensaje msg = RCaptura.Listar_ZonaPago();
            return StatusCode(StatusCodes.Status200OK, msg);
        }

        [HttpGet]
        [Route("Listar_TipoPuesto")]
        public IActionResult Listar_TipoPuesto()
        {
            ObjMensaje msg = RCaptura.Listar_TipoPuesto();
            return StatusCode(StatusCodes.Status200OK, msg);
        }


        [HttpPost]
        [Route("Buscar_Empleado")]
        public IActionResult Buscar_Empleado(BuscarEmpleado ObjDto)
        {           
            ObjMensaje msg = RCaptura.Buscar_Empleado(ObjDto);
            return StatusCode(StatusCodes.Status200OK, msg);
        }

        [HttpPost]
        [Route("Guardar_Captura")]
        public IActionResult Guardar_Captura(DatosCaptura ObjDto)
        {
            ObjMensaje msg = RCaptura.Guardar_Captura(ObjDto);
            return StatusCode(StatusCodes.Status200OK, msg);
        }

        [HttpPost]
        [Route("Modificar_Captura")]
        public IActionResult Modificar_Captura(ModificarCapturaDto ObjDto)
        {
            var obj = mapper.Map<DatosCaptura>(ObjDto);
            ObjMensaje msg = RCaptura.Modificar_Captura(obj);
            return StatusCode(StatusCodes.Status200OK, msg);
        }
    }
}

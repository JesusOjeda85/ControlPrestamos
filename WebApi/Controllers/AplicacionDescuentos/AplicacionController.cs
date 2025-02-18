using AutoMapper;
using ClsObjetos;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using WebApi.Repositorio.AplicacionDescuentos;


namespace WebApi.Controllers.AplicacionDescuentos
{
    [Route("api/[controller]")]
    [ApiController]
    public class AplicacionController : ControllerBase
    {
        //private readonly IMapper mapper;

        //public AplicacionController(IMapper mapper)
        //{
        //    this.mapper = mapper;
        //}

        [HttpPost]
        [Route("Cargar_Descuentos")]
        public IActionResult Cargar_Descuentos(BuscarEmpleado Obj)
        {
            ObjMensaje msg = RAplicacion.Cargar_Descuentos(Obj);
            return StatusCode(StatusCodes.Status200OK, msg);
        }

        [HttpPost]
        [Route("Aplicar_Descuentos")]
        public IActionResult Aplicar_Descuentos(Aplicar_DescuentosDto ObjDto)
        {
            //var obj = mapper.Map<DatosCaptura>(ObjDto);
            ObjMensaje msg = RAplicacion.Aplicar_Descuentos(ObjDto);
            return StatusCode(StatusCodes.Status200OK, msg);
        }

        [HttpGet]
        [Route("Listar_Quincenas")]
        public IActionResult Listar_Quincenas()
        {         
           ObjMensaje msg = RAplicacion.Listar_Quincenas();
           return StatusCode(StatusCodes.Status200OK, msg);
        }
    }
}

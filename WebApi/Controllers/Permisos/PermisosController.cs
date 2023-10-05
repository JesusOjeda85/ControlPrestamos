using AutoMapper;
using ClsObjetos;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using WebApi.Entidades;
using WebApi.Repositorio.Permisos;

namespace WebApi.Controllers.Permisos
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermisosController : ControllerBase
    {
        private readonly IMapper mapper;

        public PermisosController(IMapper mapper)
        {
            this.mapper = mapper;
        }


        [HttpPost]
        [Route("Listar_Permisos_Asignados")]
        public IActionResult Listar_Permisos_Asignados(IdUuarioDto objDto)
        {
            var obj = mapper.Map<DatosUsuario>(objDto);
            ObjMensaje msg = RPermisos.Listar_Permisos_Asignados(obj);
            return StatusCode(StatusCodes.Status200OK, msg);
        }
        [HttpGet]
        [Route("Listar_Perfiles")]
        public IActionResult Listar_Perfiles()
        {           
            ObjMensaje msg = RPermisos.Listar_Perfiles();
            return StatusCode(StatusCodes.Status200OK, msg);
        }

        [HttpGet]
        [Route("Listar_Menus")]
        public IActionResult Listar_Menus()
        {
            ObjMensaje msg = RPermisos.Listar_Menus();
            return StatusCode(StatusCodes.Status200OK, msg);
        }
    }
}

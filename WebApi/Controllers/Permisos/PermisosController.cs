using AutoMapper;
using ClsObjetos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using WebApi.Entidades;
using WebApi.Repositorio.Permisos;
using WebApi.Repositorio.Usuarios;

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


        //[HttpPost]
        //[Route("Listar_Permisos_Asignados")]
        //public IActionResult Listar_Permisos_Asignados(IdUuarioDto objDto)
        //{
        //    var obj = mapper.Map<DatosUsuario>(objDto);
        //    ObjMensaje msg = RPermisos.Listar_Permisos_Asignados(obj);
        //    return StatusCode(StatusCodes.Status200OK, msg);
        //}
        [HttpPost]
        [Route("Listar_Perfiles")]
        public IActionResult Listar_Perfiles(IdUuarioDto objDto)
        {
            var obj = mapper.Map<DatosUsuario>(objDto);
            ObjMensaje msg = RPermisos.Listar_Perfiles(obj);
            return StatusCode(StatusCodes.Status200OK, msg);
        }

        [HttpGet]
        [Route("Listar_Menus")]
        public IActionResult Listar_Menus()
        {
            ObjMensaje msg = RPermisos.Listar_Menus();
            return StatusCode(StatusCodes.Status200OK, msg);
        }

        [HttpGet]
        [Route("Listar_Reportes")]
        public IActionResult Listar_Reportes()
        {
            ObjMensaje msg = RPermisos.Listar_Reportes();
            return StatusCode(StatusCodes.Status200OK, msg);
        }

        [HttpPost]
        [Route("Guardar_Permisos")]
        public IActionResult Guardar_Permisos(DatosPermisos ObjDto)
        {
            ObjMensaje msg = RPermisos.Guardar_Permisos(ObjDto);
            return StatusCode(StatusCodes.Status200OK, msg);
        }

        [HttpPost]
        [Route("Cargar_Permisos")]
        public IActionResult Cargar_Permisos(IdUuarioDto objDto)
        {
            var obj = mapper.Map<DatosUsuario>(objDto);
            ObjMensaje msg = RPermisos.Cargar_Permisos(obj);
            return StatusCode(StatusCodes.Status200OK, msg);
        }
    }
}

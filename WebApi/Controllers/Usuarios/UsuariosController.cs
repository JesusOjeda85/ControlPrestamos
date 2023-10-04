using AutoMapper;
using ClsObjetos;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using WebApi.Entidades;
using WebApi.Repositorio.Usuarios;

namespace WebApi.Controllers.Usuarios
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IMapper mapper;

        public UsuariosController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("Listar_Usuarios")]
        public IActionResult Listar_Usuarios()
        {
            ObjMensaje msg = RUsuarios.Listar_Usuarios();
            return StatusCode(StatusCodes.Status200OK, msg);
        }

        [HttpPost]
        [Route("Buscar_Usuario")]
        public IActionResult Buscar_Usuario(IdUuarioDto ObjDto)
        {
            var obj = mapper.Map<DatosUsuario>(ObjDto);
            ObjMensaje msg = RUsuarios.Buscar_UsuarioId(obj);
            return StatusCode(StatusCodes.Status200OK, msg);
        }

        [HttpPost]
        [Route("Guardar_Usuario")]
        public IActionResult Guardar_Usuario(DatosUsuario ObjDto)
        {
            ObjMensaje msg = RUsuarios.Guardar_Usuario(ObjDto);
            return StatusCode(StatusCodes.Status200OK, msg);
        }
    }
}

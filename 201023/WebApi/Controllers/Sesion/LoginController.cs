using AutoMapper;

using ClsObjetos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using WebApi.Entidades;
using WebApi.Repositorio.RSesion;

namespace WebApi.Controllers.Login
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMapper mapper;

        public LoginController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("Iniciar_Sesion")]
        public IActionResult Iniciar_Session(LoginDto objDto)
        {
            var obj = mapper.Map<DatosUsuario>(objDto);
            ObjMensaje msg = RSesion.Iniciar_Seccion(obj);
            return StatusCode(StatusCodes.Status200OK, msg);
        }


        [HttpPost]
        [Route("Cambiar_Contraseña")]
        public IActionResult Cambiar_Contraseña(CambioContraseñaDTO ObjDto)
        {
            var obj = mapper.Map<DatosUsuario>(ObjDto);
            ObjMensaje msg = RSesion.Cambiar_Contraseña(obj);
            return StatusCode(StatusCodes.Status200OK, msg);
        }
    }
}

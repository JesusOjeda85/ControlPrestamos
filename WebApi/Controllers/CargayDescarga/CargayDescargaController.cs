using ClsObjetos;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using WebApi.Entidades;
using WebApi.Mapeo;
using WebApi.Repositorio.CargayDescarga;
using AutoMapper;

namespace WebApi.Controllers.CargayDescarga
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargayDescargaController : ControllerBase
    {

      

        [HttpPost]
        [Route("Subir_Archivo_014a")]
        public IActionResult Subir_Archivo_014a(DatosCargar Obj)
        {          
            ObjMensaje msg = RCargayDescarga.Subir_Archivo_014a(Obj);
            return StatusCode(StatusCodes.Status200OK, msg);
        }

       

       
    }
}

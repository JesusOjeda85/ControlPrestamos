//using AutoMapper;
using ClsObjetos;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using WebApi.Entidades;
using WebApi.Repositorio.Captura;

namespace WebApi.Controllers.Captura
{
    [Route("api/[controller]")]
    [ApiController]
    public class CapturaController : ControllerBase
    {
        //private readonly IMapper mapper;

        //public CapturaController(IMapper mapper)
        //{
        //    this.mapper = mapper;
        //}

        [HttpPost]
        [Route("Listar_ImportePlazos")]
        public IActionResult Listar_ImportePlazos(IdOrganismoDto ObjDto)
        {
            //var obj = mapper.Map<DatosCaptura>(ObjDto);
            ObjMensaje msg = RCaptura.Listar_ImportesPlazos(ObjDto);
            return StatusCode(StatusCodes.Status200OK, msg);
        }

        [HttpPost]
        [Route("Listar_Plazos")]
        public IActionResult Listar_Plazos(IdOrganismoDto ObjDto)
        {
            //var obj = mapper.Map<DatosCaptura>(ObjDto);
            ObjMensaje msg = RCaptura.Listar_Plazos(ObjDto);
            return StatusCode(StatusCodes.Status200OK, msg);
        }

        [HttpPost]
        [Route("Listar_ConceptosPorPuesto")]
        public IActionResult Listar_ConceptosPorPuesto(IdTipoPuestoDto ObjDto)
        {
            //var obj = mapper.Map<DatosCaptura>(ObjDto);
            ObjMensaje msg = RCaptura.Listar_ConceptosPorPuesto(ObjDto);
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

        [HttpGet]
        [Route("Listar_MotivosBajas")]
        public IActionResult Listar_MotivosBajas()
        {
            ObjMensaje msg = RCaptura.Listar_MotivosBajas();
            return StatusCode(StatusCodes.Status200OK, msg);
        }

        [HttpGet]
        [Route("Listar_CausasMuerte")]
        public IActionResult Listar_CausasMuerte()
        {
            ObjMensaje msg = RCaptura.Listar_CausasMuerte();
            return StatusCode(StatusCodes.Status200OK, msg);
        }

        [HttpGet]
        [Route("Listar_ConceptosSiniestros")]
        public IActionResult Listar_ConceptosSiniestros()
        {
            ObjMensaje msg = RCaptura.Listar_ConceptosSiniestros();
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
        [Route("Buscar_Retiros_Siniestros")]
        public IActionResult Buscar_Retiros_Siniestros(BuscarEmpleado ObjDto)
        {
            ObjMensaje msg = RCaptura.Buscar_Retiros_Siniestros(ObjDto);
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
        [Route("Eliminar_Captura")]
        public IActionResult Eliminar_Captura(DatosCaptura ObjDto)
        {
            ObjMensaje msg = RCaptura.Eliminar_Captura(ObjDto);
            return StatusCode(StatusCodes.Status200OK, msg);
        }


        [HttpPost]
        [Route("Guardar_Captura_Retiros")]
        public IActionResult Guardar_Captura_Retiros(DatosCapturaRetiros ObjDto)
        {
            ObjMensaje msg = RCaptura.Guardar_Captura_Retiros(ObjDto);
            return StatusCode(StatusCodes.Status200OK, msg);
        }

        [HttpPost]
        [Route("Guardar_Captura_Siniestros")]
        public IActionResult Guardar_Captura_Siniestros(DatosCapturaSiniestros ObjDto)
        {
            ObjMensaje msg = RCaptura.Guardar_Captura_Siniestros(ObjDto);
            return StatusCode(StatusCodes.Status200OK, msg);
        }

        [HttpPost]
        [Route("Modificar_Captura")]
        public IActionResult Modificar_Captura(DatosCaptura ObjDto)
        {
            //var obj = mapper.Map<DatosCaptura>(ObjDto);
            ObjMensaje msg = RCaptura.Modificar_Captura(ObjDto);
            return StatusCode(StatusCodes.Status200OK, msg);
        }

        [HttpPost]
        [Route("Guardar_Cancelaciones")]
        public IActionResult Guardar_Cancelaciones(DatosCancelaciones ObjDto)
        {
            ObjMensaje msg = RCaptura.Guardar_Cancelaciones(ObjDto);
            return StatusCode(StatusCodes.Status200OK, msg);
        }

        [HttpPost]
        [Route("Guardar_PagosExternos")]
        public IActionResult Guardar_PagosExternos(DatosPagosExternos ObjDto)
        {
            ObjMensaje msg = RCaptura.Guardar_PagosExternos(ObjDto);
            return StatusCode(StatusCodes.Status200OK, msg);
        }

        [HttpPost]
        [Route("Listar_Revision_Captura")]
        public IActionResult Listar_Revision_Captura(DatosNumeracion obj)
        {
            ObjMensaje msg = RCaptura.Listar_Revision_Captura(obj);
            return StatusCode(StatusCodes.Status200OK, msg);
        }
    }
}

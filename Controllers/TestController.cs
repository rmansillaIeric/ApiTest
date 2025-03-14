using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class TestController : ControllerBase
        {
        // Endpoint GET que devuelve una persona hardcodeada
        [HttpGet]
        public IActionResult Get()
        {
            // Datos hardcodeados para varios objetos TestModel
            var testData = new List<Testmodel>
    {
        new Testmodel
        {
            Acta = 1,
            TipoActa = "I",
            IERIC = 5222245,
            Cuit = 20142583692,
            RazonSocial = "Rodrigo Mansilla",
            Asignacion = "12/03/2024",
            Inicio = "",
            Fin = "",
            Fiscalizacion = "08/09/2024",
            Estado = "INICIADO",
            Girado = "",
            GiradoFecha = "",
            Resultado = "Sin multa",
            Inspector = "Perez",
            Representacion = "Cordoba"
        },
        new Testmodel
        {
            Acta = 2,
            TipoActa = "I",
            IERIC = 5250,
            Cuit = 27929584713,
            RazonSocial = "ANA GARCÍA",
            Asignacion = "13/03/2024",
            Inicio = "14/03/2024",
            Fin = "15/03/2024",
            Fiscalizacion = "09/09/2024",
            Estado = "FINALIZADO",
            Girado = "SÍ",
            GiradoFecha = "14/03/2024",
            Resultado = "Multa aplicada",
            Inspector = "Carlos López",
            Representacion = "Mendoza"
        },
    };

            // Retornar el arreglo como JSON
            return Ok(testData);
        }

    }

}


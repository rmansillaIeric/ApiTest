using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Diagnostics.Contracts;

namespace WebApplication1.Controllers
{
    [Route("api")]
    [ApiController]
    public class TestController : ControllerBase
    {
        // Endpoint GET que devuelve una persona hardcodeada
        [HttpGet("testJson")]

        public IActionResult Get()
        {
            // Datos hardcodeados para varios objetos TestModel
            var testData = new List<Testmodel>
            {
                new() {
                    Acta = 1,
                    TipoActa = "I",
                    IERIC = 5222245,
                    Cuit = 20142583692,
                    razonsocial = "Rodrigo Mansilla",
                    Asignacion = GetRandomDate(new DateTime(1995, 9, 3), new DateTime(2025, 9, 3)),
                    Inicio = GetRandomDate(new DateTime(1995, 9, 3), new DateTime(2025, 9, 3)),
                    Fin = GetRandomDate(new DateTime(1995, 9, 3), new DateTime(2025, 9, 3)),
                    Fiscalizacion = GetRandomDate(new DateTime(1995, 9, 3), new DateTime(2025, 9, 3)),
                    Estado = "INICIADO",
                    Girado = "No",
                    GiradoFecha = GetRandomDate(new DateTime(1995, 9, 3), new DateTime(2025, 9, 3)),
                    Resultado = "Sin multa",
                    Inspector = "Perez",
                    Representacion = "Cordoba"
                },
                new() {
                    Acta = 2,
                    TipoActa = "I",
                    IERIC = 5250,
                    Cuit = 27929584713,
                    razonsocial = "ANA GARCÍA",
                    Asignacion = GetRandomDate(new DateTime(1995, 9, 3), new DateTime(2025, 9, 3)),
                    Inicio = GetRandomDate(new DateTime(1995, 9, 3), new DateTime(2025, 9, 3)),
                    Fin = GetRandomDate(new DateTime(1995, 9, 3), new DateTime(2025, 9, 3)),
                    Fiscalizacion = GetRandomDate(new DateTime(1995, 9, 3), new DateTime(2025, 9, 3)),
                    Estado = "FINALIZADO",
                    Girado = "SÍ",
                    GiradoFecha = GetRandomDate(new DateTime(1995, 9, 3), new DateTime(2025, 9, 3)),
                    Resultado = "Multa aplicada",
                    Inspector = "Carlos López",
                    Representacion = "Mendoza"
                },
            };
            return Ok(testData);
        }

        [HttpGet("testJson2")]
        public IActionResult GetTest()
        {
            // Datos hardcodeados para varios objetos TestModel
            var testData = new List<Testmodel>
            {
                new() {
                    Acta = 1,
                    TipoActa = "I",
                    IERIC = 5222245,
                    Cuit = 20142583692,
                    razonsocial = "Rodrigo Mansilla",
                    Asignacion = GetRandomDate(new DateTime(1995, 9, 3), new DateTime(2025, 9, 3)),
                    Inicio = GetRandomDate(new DateTime(1995, 9, 3), new DateTime(2025, 9, 3)),
                    Fin = GetRandomDate(new DateTime(1995, 9, 3), new DateTime(2025, 9, 3)),
                    Fiscalizacion = GetRandomDate(new DateTime(1995, 9, 3), new DateTime(2025, 9, 3)),
                    Estado = "INICIADO",
                    Girado = "No",
                    GiradoFecha = GetRandomDate(new DateTime(1995, 9, 3), new DateTime(2025, 9, 3)),
                    Resultado = "Sin multa",
                    Inspector = "Perez",
                    Representacion = "Cordoba"
                },
                new() {
                    Acta = 2,
                    TipoActa = "I",
                    IERIC = 5250,
                    Cuit = 27929584713,
                    razonsocial = "ANA GARCÍA",
                    Asignacion = GetRandomDate(new DateTime(1995, 9, 3), new DateTime(2025, 9, 3)),
                    Inicio = GetRandomDate(new DateTime(1995, 9, 3), new DateTime(2025, 9, 3)),
                    Fin = GetRandomDate(new DateTime(1995, 9, 3), new DateTime(2025, 9, 3)),
                    Fiscalizacion = GetRandomDate(new DateTime(1995, 9, 3), new DateTime(2025, 9, 3)),
                    Estado = "FINALIZADO",
                    Girado = "SÍ",
                    GiradoFecha = GetRandomDate(new DateTime(1995, 9, 3), new DateTime(2025, 9, 3)),
                    Resultado = "Multa aplicada",
                    Inspector = "Carlos López",
                    Representacion = "Mendoza"
                },
            };
            return Ok(testData);
        }

        public static string GetRandomDate(DateTime startDate, DateTime endDate)
        {
            Random random = new Random();
            long range = endDate.Ticks - startDate.Ticks;
            long randomTicks = (long)(random.NextDouble() * range);
            DateTime fecha = new DateTime(startDate.Ticks + randomTicks).Date;
            return fecha.ToString("dd-MM-yyyy");
        }

    }

}


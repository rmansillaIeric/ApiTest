using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Xml;
using System.Text.Json.Nodes;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SumariosController : ControllerBase
    {
        private readonly string _connectionString;
        public SumariosController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        [HttpGet("GetSumarios")]
        public IActionResult GetSumarios()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_GetSumarios", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        string jsonResult = JsonConvert.SerializeObject(dataTable, Newtonsoft.Json.Formatting.Indented);

                        return Ok(jsonResult);
                    }
                }
            }
        }
        [HttpGet("GetSumariosId")]
        public IActionResult GetSumarioId(int idNumeroSumario)
        {
            string query = "SELECT *, CASE WHEN Estado = 1 THEN 'Iniciado' WHEN Estado = 2 THEN 'Resuleto' WHEN Estado = 3 THEN 'Anulado' WHEN Estado = 4 THEN 'Absuelto' WHEN Estado = 5 THEN 'Habilitado para el pago' WHEN Estado = 6 THEN 'Apelación' WHEN Estado = 7 THEN 'Reconsideración' WHEN Estado = 8 THEN 'Alzada' WHEN Estado = 10 THEN 'Para ejecución' WHEN Estado = 12 THEN 'En instrucción' WHEN Estado = 13 THEN 'Instruido para resolver' WHEN Estado = 14 THEN 'Recurso en trámite' ELSE CAST(Estado AS VARCHAR) END AS EstadoDescripcion, CASE WHEN FechaPago = CONVERT(DATETIME, '1899-12-30', 120) THEN NULL ELSE FechaPago END AS FechaPagoCorrigida FROM [IERICLegales].[dbo].[Sumarios] WHERE IdNumeroSumario = @IdNumeroSumario";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@IdNumeroSumario", idNumeroSumario);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        if (dataTable.Rows.Count == 0)
                        {
                            return NotFound($"No se encontró un sumario con IdNumeroSumario {idNumeroSumario}");
                        }

                        string jsonResult = JsonConvert.SerializeObject(dataTable, Newtonsoft.Json.Formatting.Indented);
                        
                        return Ok(jsonResult);
                    }
                }
            }
        }
    }
}


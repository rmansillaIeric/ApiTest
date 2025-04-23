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
            string query = "SELECT S.*, ET.DESCRIPCION AS EstadoDescripcion, R.DescRepresentacion AS RepresentacionDescripcion, rr.DescRepresentacion AS OrigenDescripcion, CASE WHEN FechaPago = CONVERT(DATETIME, '1899-12-30', 120) THEN NULL ELSE FechaPago END AS FechaPagoModificada FROM SUMARIOS AS S JOIN ESTADOTEMPORAL AS ET  ON ET.ESTADOID = S.ESTADO JOIN Representaciones AS R  ON R.CodigoRepresentacion = S.RepresentacionActual join Representaciones as rr on rr.CodigoRepresentacion = s.Origen WHERE NumeroSumario = @IdNumeroSumario";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@IdNumeroSumario", idNumeroSumario);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        try
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
                        catch (Exception e)
                        {
                            new Exception(e.Message.ToString());
                            return BadRequest();
                        }

                    }
                }
            }
        }
    }
}


using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Xml;

namespace WebApplication1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SumariosController : ControllerBase
    {
        private readonly string connectionString = "Server=192.168.7.199;Database=IERICLegales;Integrated Security=True;TrustServerCertificate=True;";

    [HttpGet("GetSumarios")]
    public IActionResult GetSumarios()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
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
    }
}


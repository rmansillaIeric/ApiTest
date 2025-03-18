using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;
using WebApplication1;
using WebApplication1.DTOs;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly string _connectionString;

    public AuthController(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("ReportingConnection");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDTO request)
    {
        try
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("[ControlAcceso].[ValidarLogin]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Usuario", request.Usuario);
                    command.Parameters.AddWithValue("@PasswordEncrypted", request.PasswordEncrypted);

                    // Usamos SqlDataAdapter para llenar un DataTable con los resultados
                    using (var adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        await Task.Run(() => adapter.Fill(dataTable)); // Aseguramos que sea asincrónico si es necesario
                                                                       // Verificamos si se encontraron resultados
                        if (dataTable.Rows.Count == 0)
                        {
                            return NotFound("Usuario o contraseña incorrectos."); // Usuario no encontrado
                        }
                        // Convertimos el DataTable a JSON
                        string jsonResult = JsonConvert.SerializeObject(dataTable, Newtonsoft.Json.Formatting.Indented);

                        // Retornamos el JSON
                        return Ok(jsonResult);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error interno del servidor: {ex.Message}");
        }
    }
}
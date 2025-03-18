# Proyecto de Prueba - WebApplication1

## Descripci�n
Este es un proyecto de prueba en **.NET 8** que implementa una API simple con un solo controlador (**TestController**). El controlador expone dos endpoints GET que devuelven datos hardcodeados en formato JSON.

## Tecnolog�as utilizadas
- .NET 8
- ASP.NET Core Web API
- C#

## Endpoints disponibles
### 1. Obtener datos de prueba (testJson)
**M�todo:** `GET`

**URL:** `/api/testJson`

**Descripci�n:** Devuelve una lista de objetos **TestModel** con datos ficticios.

### 2. Obtener datos de prueba (testJson2)
**M�todo:** `GET`

**URL:** `/api/testJson2`

**Descripci�n:** Devuelve otra lista de objetos **TestModel** con datos ficticios similares al primer endpoint.

## C�mo ejecutar el proyecto
1. Clonar el repositorio o descargar el c�digo fuente.
2. Abrir el proyecto en **Visual Studio**.
3. Ejecutar el proyecto presionando `F5` o usando el comando:
   ```sh
   dotnet run
   ```
4. Acceder a los endpoints en el navegador o usar **Postman** para hacer las solicitudes.

## Pruebas con archivo .http
Para probar los endpoints dentro de **Visual Studio**, puedes usar el siguiente archivo `.http`:
```http
@WebApplication1_HostAddress = http://localhost:5142

### Obtener datos de testJson
GET {{WebApplication1_HostAddress}}/api/testJson
Accept: application/json

### Obtener datos de testJson2
GET {{WebApplication1_HostAddress}}/api/testJson2
Accept: application/json
```
## Notas
- Si el puerto del servidor cambia, aseg�rate de modificar `WebApplication1_HostAddress` en el archivo `.http`.
- Este proyecto es solo para pruebas y demostraciones.


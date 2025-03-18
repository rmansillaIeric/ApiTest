namespace WebApplication1
{
    public class UsuarioModel
    {
        public long Id { get; set; } // Cambia de int a long
        public string Usuario { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public int IdRol { get; set; } // Si IdRol es int, déjalo como está
        public string Rol { get; set; }
        public string Descripcion { get; set; }
        public long IdRepresentacion { get; set; } // Cambia de int a long si es necesario
        public string DescRepresentacion { get; set; }
    }
}

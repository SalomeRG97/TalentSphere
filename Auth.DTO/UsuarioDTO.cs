namespace Auth.DTO
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string NumeroDocumento { get; set; }
        public string Correo { get; set; }
        public string Contrasenna { get; set; }
        public int Role { get; set; }
        public string CodigoValidacion { get; set; }
        public DateTime ExpiracionCodigo { get; set; }
        public DateTime FechaDesactivacion { get; set; }
    }
}

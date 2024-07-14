namespace Admin.DTO
{
    public class CreateEmpleadoDTO
    {
        public int TipoDocumento { get; set; }

        public string NumeroDocumento { get; set; }

        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public string CorreoPersonal { get; set; }

        public string CorreoEmpresarial { get; set; }

        public string Direccion { get; set; }

        public long Telefono { get; set; }

        public long ContactoEmergencia { get; set; }

        public long TelefonoContactoEmergencia { get; set; }
    }
}

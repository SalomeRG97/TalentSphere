namespace Admin.DTO.Maestros
{
    public class CreateContratoLaboralDTO
    {
        public int Id { get; set; }

        public int ServicioId { get; set; }

        public int CargoId { get; set; }

        public decimal Salario { get; set; }

        public int Arlid { get; set; }

        public int FondoPensionId { get; set; }

        public int Epsid { get; set; }

        public int TipoContratoId { get; set; }

        public DateTime FechaIngreso { get; set; }
    }
}

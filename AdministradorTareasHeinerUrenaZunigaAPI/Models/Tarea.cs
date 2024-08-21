namespace AdministradorTareasHeinerUrenaZunigaAPI.Models
{
    public class Tarea
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public int? ColaboradorId { get; set; }
        public Colaborador? Colaborador { get; set; }
        public int Estado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFinalizacion { get; set; }
        public string? Notas { get; set; }
    }
}

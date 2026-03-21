namespace SistemaPropostas.API.DTOs
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Documento { get; set; } = string.Empty;
        public string TipoPessoa { get; set; } = string.Empty;
    }
}
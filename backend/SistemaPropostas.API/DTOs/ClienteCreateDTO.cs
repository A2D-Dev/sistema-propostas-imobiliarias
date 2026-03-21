namespace SistemaPropostas.API.DTOs
{
    public class ClienteCreateDTO
    {
        public string Nome { get; set; } = string.Empty;
        public string Documento { get; set; } = string.Empty;
        public string TipoPessoa { get; set; } = string.Empty;
    }
}
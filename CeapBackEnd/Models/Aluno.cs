namespace CeapBackEnd.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Curso { get; set; }    
        public DateTime? DataNascimento { get; set; }
        public bool Ativo { get; set; } = true;

    }
}

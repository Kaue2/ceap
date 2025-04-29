using CeapBackEnd.Context;
using CeapBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace CeapBackEnd.Services
{
    public class AlunoService
    {
        private readonly CeapDbContext _dbContext;
        public AlunoService(CeapDbContext context)
        {
            this._dbContext = context;
        }

        public async Task<List<Aluno>> ListarTodosAlunos()
        {
            try
            {
                return await _dbContext.Alunos.ToListAsync();
            }
            catch (Exception ex) { throw new Exception(); }
        }

        public async Task<Aluno?> ObterAlunoId(int id)
        {
            return await _dbContext.Alunos.FindAsync(id);
        }

        public async Task<Aluno> Criar(Aluno aluno)
        {
            _dbContext.Alunos.Add(aluno);
            await _dbContext.SaveChangesAsync();

            Aluno novoAluno = await _dbContext.Alunos.FindAsync(aluno.Id);
            return aluno;
        }

        public async Task<bool> AtulizarAluno(Aluno aluno)
        {
            var alunoDoBanco = await _dbContext.Alunos.FindAsync(aluno.Id);

            if(alunoDoBanco  == null) { return false; }

            alunoDoBanco.Nome = aluno.Nome;
            alunoDoBanco.Email = aluno.Email;
            alunoDoBanco.Curso = aluno.Curso;
            alunoDoBanco.DataNascimento = aluno.DataNascimento;
            alunoDoBanco.Ativo = aluno.Ativo;

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletarAluno(int id)
        {
            var alunoDoBanco = await _dbContext.Alunos.FindAsync(id);

            if(alunoDoBanco == null) { return false; }

            _dbContext.Alunos.Remove(alunoDoBanco);

            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}

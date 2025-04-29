using CeapBackEnd.Models;
using CeapBackEnd.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CeapBackEnd.Controllers
{
    [Route("ceap/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly AlunoService _alunoService;

        public AlunoController(AlunoService alunoService)
        {
            this._alunoService = alunoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> ObterAlunos()
        {
            try
            {
                IEnumerable<Aluno> alunos = await this._alunoService.ListarTodosAlunos();
                return Ok(alunos);
            }
            catch (Exception ex) { throw new Exception(); }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> ObterAlunoId(int id)
        {
            try
            {
                Aluno? alunoDesejado = await this._alunoService.ObterAlunoId(id);
                if (alunoDesejado != null)
                {
                    return Ok(alunoDesejado);
                }
                return BadRequest("Usuário não econtrado");
            }
            catch (Exception ex) { throw new Exception(); }
        }

        [HttpPost]
        public async Task<ActionResult<Aluno>> CriarAluno([FromBody] Aluno aluno)
        {
            try
            {
                Aluno novoAluno = await this._alunoService.Criar(aluno);
                return Ok(novoAluno);
            }
            catch (Exception ex) { throw new Exception(); };
        }

        [HttpPut]
        public async Task<IActionResult> AtulizarAluno(Aluno aluno)
        {
            try
            {
                var atualizacao = await _alunoService.AtulizarAluno(aluno);
                if (!atualizacao) { return BadRequest(aluno); }
                return Ok(atualizacao);
            }
            catch (Exception ex) { throw new Exception(); };
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAluno(int id)
        {
            try
            {
                var atualizacao = await _alunoService.DeletarAluno(id);
                if (!atualizacao) { return BadRequest(); }
                return Ok(atualizacao);
            }
            catch (Exception ex) { throw new Exception(); };
        }
    }
}

import { Component } from '@angular/core';
import { Aluno } from '../../models/aluno.model';
import { AlunoServiceService } from '../../services/aluno-service.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  alunos: Aluno[] = new Array<Aluno>();
  aluno: Aluno = new Aluno();

  constructor(private alunoService: AlunoServiceService){}

  ngOnInit(){
    this.alunoService.listarAlunos().subscribe((response) =>{
      this.alunos = response;
      console.log(this.alunos);
    });
  }

  criarAluno(){
    this.alunoService.criarAluno(this.aluno).subscribe(() => {
      this.alunoService.listarAlunos().subscribe((response) => {
        this.alunos = response;

      });
    })
  }

  selecionarAluno(alunoNovo: Aluno){
    this.aluno = alunoNovo;
  }

  atualizarAluno(){
    this.alunoService.atualizarAluno(this.aluno).subscribe((response) => {
      if(response){
        console.log("Aluno atualizado: " + this.aluno.nome);
        this.alunoService.listarAlunos().subscribe((response) => {
          this.alunos = response;
        });
      }
    });
  }

  deletarAluno(aluno: Aluno){
    this.alunoService.deletarAluno(aluno).subscribe((response) => {
      if(response){
        console.log("Aluno deletado com sucesso: " + aluno.nome);
      }
      this.alunoService.listarAlunos().subscribe((response) => {
        this.alunos = response;
      });
    });
  }
}

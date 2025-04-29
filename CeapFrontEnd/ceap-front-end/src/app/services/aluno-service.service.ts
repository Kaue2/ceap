import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Aluno } from '../models/aluno.model';

@Injectable({
  providedIn: 'root'
})
export class AlunoServiceService {
  requestUrl: string = environment.apiUrl + '/ceap/aluno'

  constructor(private httpCliente: HttpClient) { }

  listarAlunos(){
    return this.httpCliente.get<Aluno[]>(this.requestUrl);
  }

  obterAlunoId(aluno: Aluno) {
    return this.httpCliente.get<Aluno>(this.requestUrl + `/${aluno.id}`);
  }

  criarAluno(aluno: Aluno){
    return this.httpCliente.post(this.requestUrl, aluno);
  }

  atualizarAluno(aluno: Aluno){
    return this.httpCliente.put(this.requestUrl, aluno);
  }

  deletarAluno(aluno: Aluno){
    return this.httpCliente.delete(this.requestUrl + `/${aluno.id}`, { body: aluno });
  }
}

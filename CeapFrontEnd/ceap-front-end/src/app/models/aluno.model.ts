export class Aluno {
  id!: number;
  nome?: string;
  email?: string;
  curso?: string;
  dataNascimento?: Date;
  ativo?: boolean;

  constructor(nome?: string, curso?: string, dataNascimento?: Date, ativo: boolean = true){
    this.nome = nome;
    this.curso = curso;
    this.dataNascimento = dataNascimento;
    this.ativo = ativo;
  }
}

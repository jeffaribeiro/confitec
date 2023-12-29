import { HistoricoEscolarGrid } from './historico-escolar.grid';

export interface UsuarioDetalhe {
  idUsuario: number;
  nome: string;
  sobrenome: string;
  email: string;
  dataNascimento: Date;
  idEscolaridade: number;
  escolaridade: string;
  historicos: HistoricoEscolarGrid[];
}

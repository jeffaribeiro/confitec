import { FormGroup } from '@angular/forms';
import { ElementRef } from '@angular/core';

import { FormBaseComponent } from '../base-components/form-base.component';
import { UsuarioForm } from './models/usuario.form';
import { EscolaridadeGrid } from '../escolaridade/models/escolaridade.grid';

export abstract class UsuarioBaseComponent extends FormBaseComponent {
  usuario: UsuarioForm;
  escolaridades: EscolaridadeGrid[];
  errors: any[] = [];
  formGroup: FormGroup;

  constructor() {
    super();

    this.validationMessages = {
      idEscolaridade: {
        required: 'Escolha a escolaridade',
      },
      nome: {
        required: 'Informe o Nome',
        minlength: 'Mínimo de 2 caracteres',
        maxlength: 'Máximo de 20 caracteres',
      },
      sobrenome: {
        required: 'Informe o Sobrenome',
        minlength: 'Mínimo de 2 caracteres',
        maxlength: 'Máximo de 100 caracteres',
      },
      email: {
        required: 'Informe o E-mail',
        minlength: 'Mínimo de 2 caracteres',
        maxlength: 'Máximo de 50 caracteres',
      },
      dataNascimento: {
        required: 'Informe a Data de Nascimento',
      },
    };

    super.configurarMensagensValidacaoBase(this.validationMessages);
  }

  protected configurarValidacaoFormulario(formInputElements: ElementRef[]) {
    super.configurarValidacaoFormularioBase(formInputElements, this.formGroup);
  }

  public ajustarDataNascimento(): string {
    let ano = this.usuario.dataNascimento.getFullYear().toString();
    let mes = (this.usuario.dataNascimento.getMonth() + 1).toString();
    let dia = this.usuario.dataNascimento.getDay().toString();

    if (mes.length < 2) {
      mes = '0' + mes;
    }

    if (dia.length < 2) {
      dia = '0' + dia;
    }

    return `${dia}/${mes}/${ano}`;
  }
}

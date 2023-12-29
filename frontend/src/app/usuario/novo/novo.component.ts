import { Component, OnInit, ViewChildren, ElementRef } from '@angular/core';
import { FormBuilder, Validators, FormControlName } from '@angular/forms';
import { Router } from '@angular/router';

import { ToastrService } from 'ngx-toastr';
import { ImageTransform } from 'ngx-image-cropper';

import { UsuarioService } from '../services/usuario.service';
import { UsuarioBaseComponent } from '../usuario-form.base.component';
import { EscolaridadeService } from 'src/app/escolaridade/services/escolaridade.service';

@Component({
  selector: 'app-novo',
  templateUrl: './novo.component.html',
})
export class NovoComponent extends UsuarioBaseComponent implements OnInit {
  @ViewChildren(FormControlName, { read: ElementRef })
  formInputElements: ElementRef[];

  constructor(
    private fb: FormBuilder,
    private escolaridadeService: EscolaridadeService,
    private usuarioService: UsuarioService,
    private router: Router,
    private toastr: ToastrService
  ) {
    super();
  }

  ngOnInit(): void {
    this.escolaridadeService
      .obterTodos()
      .subscribe((escolaridades) => (this.escolaridades = escolaridades));

    this.formGroup = this.fb.group({
      nome: [
        '',
        [
          Validators.required,
          Validators.minLength(2),
          Validators.maxLength(20),
        ],
      ],
      sobrenome: [
        '',
        [
          Validators.required,
          Validators.minLength(2),
          Validators.maxLength(100),
        ],
      ],
      email: [
        '',
        [
          Validators.required,
          Validators.minLength(2),
          Validators.maxLength(50),
        ],
      ],
      dataNascimento: ['', [Validators.required]],
      idEscolaridade: ['', [Validators.required]],
    });
  }

  ngAfterViewInit(): void {
    super.configurarValidacaoFormulario(this.formInputElements);
  }

  adicionarUsuario() {
    if (this.formGroup.dirty && this.formGroup.valid) {
      this.usuario = Object.assign({}, this.usuario, this.formGroup.value);

      console.log(this.usuario);

      this.usuarioService.novoUsuario(this.usuario).subscribe({
        next: (sucesso: any) => {
          this.processarSucesso(sucesso);
        },
        error: (falha: any) => {
          this.processarFalha(falha);
        },
      });

      this.mudancasNaoSalvas = false;
    }
  }

  processarSucesso(response: any) {
    this.formGroup.reset();
    this.errors = [];

    let toast = this.toastr.success(
      'Usuario cadastrado com sucesso!',
      'Sucesso!'
    );
    if (toast) {
      toast.onHidden.subscribe(() => {
        this.router.navigate(['/usuarios/listar-todos']);
      });
    }
  }

  processarFalha(fail: any) {
    this.errors = fail.error.errors;
    this.toastr.error('Ocorreu um erro!', 'Opa :(');
  }
}

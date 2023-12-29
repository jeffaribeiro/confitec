import { Component, OnInit, ViewChildren, ElementRef } from '@angular/core';
import { FormBuilder, Validators, FormControlName } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';

import { ToastrService } from 'ngx-toastr';

import { UsuarioService } from '../services/usuario.service';
import { UsuarioBaseComponent } from '../usuario-form.base.component';
import { EscolaridadeService } from 'src/app/escolaridade/services/escolaridade.service';

@Component({
  selector: 'app-editar',
  templateUrl: './editar.component.html',
})
export class EditarComponent extends UsuarioBaseComponent implements OnInit {
  @ViewChildren(FormControlName, { read: ElementRef })
  formInputElements: ElementRef[];

  arquivo: any;
  arquivoNome: string;

  constructor(
    private fb: FormBuilder,
    private escolaridadeService: EscolaridadeService,
    private usuarioService: UsuarioService,
    private router: Router,
    private route: ActivatedRoute,
    private toastr: ToastrService
  ) {
    super();
    this.usuario = this.route.snapshot.data['usuario'];
  }

  ngOnInit(): void {
    this.escolaridadeService
      .obterTodos()
      .subscribe((escolaridades) => (this.escolaridades = escolaridades));

    this.formGroup = this.fb.group({
      idUsuario: ['', [Validators.required]],
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

    this.formGroup.patchValue({
      idUsuario: this.usuario.idUsuario,
      nome: this.usuario.nome,
      sobrenome: this.usuario.sobrenome,
      email: this.usuario.email,
      dataNascimento: this.usuario.dataNascimento,
      idEscolaridade: this.usuario.idEscolaridade,
    });
  }

  ngAfterViewInit(): void {
    super.configurarValidacaoFormulario(this.formInputElements);
  }

  editarUsuario() {
    if (this.formGroup.dirty && this.formGroup.valid) {
      this.usuario = Object.assign({}, this.usuario, this.formGroup.value);

      this.usuarioService.atualizarUsuario(this.usuario).subscribe(
        (sucesso) => {
          this.processarSucesso(sucesso);
        },
        (falha) => {
          this.processarFalha(falha);
        }
      );

      this.mudancasNaoSalvas = false;
    }
  }

  processarSucesso(response: any) {
    this.formGroup.reset();
    this.errors = [];

    let toast = this.toastr.success('Usuario editado com sucesso!', 'Sucesso!');
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

  upload(file: any) {
    this.arquivoNome = file[0].name;

    var reader = new FileReader();
    reader.onload = this.manipularReader.bind(this);
    reader.readAsBinaryString(file[0]);
  }

  manipularReader(readerEvt: any) {
    var binaryString = readerEvt.target.result;
    this.arquivo = btoa(binaryString);
  }
}

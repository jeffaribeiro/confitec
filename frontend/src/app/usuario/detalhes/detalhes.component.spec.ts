import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AppModule } from 'src/app/app.module';
import { UsuarioModule } from '../usuario.module';

import { DetalhesComponent } from './detalhes.component';

describe('DetalhesComponent', () => {
  let component: DetalhesComponent;
  let fixture: ComponentFixture<DetalhesComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      imports: [UsuarioModule, AppModule],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DetalhesComponent);
    component = fixture.componentInstance;

    component.imagens = '';
    component.usuario = {
      idUsuario: 2,
      nome: 'string',
      sobrenome: 'string',
      email: 'string',
      dataNascimento: new Date('1990-01-01'),
      idEscolaridade: 2,
      escolaridade: 'string',
      historicos: [],
    };

    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

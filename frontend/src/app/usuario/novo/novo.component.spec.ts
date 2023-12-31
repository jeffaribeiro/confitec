import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ReactiveFormsModule } from '@angular/forms';
import { AppModule } from 'src/app/app.module';
import { UsuarioModule } from '../usuario.module';
import { UsuarioService } from '../services/usuario.service';

import { NovoComponent } from './novo.component';

describe('NovoComponent', () => {
  let component: NovoComponent;
  let fixture: ComponentFixture<NovoComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      imports: [UsuarioModule, AppModule],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NovoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

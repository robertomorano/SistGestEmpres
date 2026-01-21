import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormulaEstilo } from './formula-estilo';

describe('FormulaEstilo', () => {
  let component: FormulaEstilo;
  let fixture: ComponentFixture<FormulaEstilo>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FormulaEstilo]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FormulaEstilo);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

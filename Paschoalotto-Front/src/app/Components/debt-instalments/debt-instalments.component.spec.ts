import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DebtInstalmentsComponent } from './debt-instalments.component';

describe('DebtInstalmentsComponent', () => {
  let component: DebtInstalmentsComponent;
  let fixture: ComponentFixture<DebtInstalmentsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DebtInstalmentsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DebtInstalmentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

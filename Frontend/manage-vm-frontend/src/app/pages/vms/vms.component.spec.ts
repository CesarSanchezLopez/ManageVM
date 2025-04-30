import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VmsComponent } from './vms.component';

describe('VmsComponent', () => {
  let component: VmsComponent;
  let fixture: ComponentFixture<VmsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [VmsComponent]
    });
    fixture = TestBed.createComponent(VmsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

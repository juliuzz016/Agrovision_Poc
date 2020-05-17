import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SprayersComponent } from './sprayers.component';

describe('SprayersComponent', () => {
  let component: SprayersComponent;
  let fixture: ComponentFixture<SprayersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SprayersComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SprayersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

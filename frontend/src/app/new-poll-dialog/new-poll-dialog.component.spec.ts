import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewPollDialogComponent } from './new-poll-dialog.component';

describe('NewPollDialogComponent', () => {
  let component: NewPollDialogComponent;
  let fixture: ComponentFixture<NewPollDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NewPollDialogComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NewPollDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

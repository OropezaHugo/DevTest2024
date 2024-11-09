import {Component, inject} from '@angular/core';
import {
  MAT_DIALOG_DATA,
  MatDialogActions,
  MatDialogClose,
  MatDialogContent,
  MatDialogRef,
  MatDialogTitle
} from '@angular/material/dialog';
import {MatFormField, MatLabel} from '@angular/material/form-field';
import {MatInput} from '@angular/material/input';
import {FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators} from '@angular/forms';
import {MatButton} from '@angular/material/button';
import {NewPollModel} from '../shared/new-poll.model';

@Component({
  selector: 'app-new-poll-dialog',
  standalone: true,
  imports: [
    MatDialogContent,
    MatLabel,
    MatInput,
    MatDialogActions,
    FormsModule,
    MatDialogClose,
    MatFormField,
    MatDialogTitle,
    MatButton,
    ReactiveFormsModule
  ],
  templateUrl: './new-poll-dialog.component.html',
  styleUrl: './new-poll-dialog.component.scss'
})
export class NewPollDialogComponent {
  readonly dialogRef = inject(MatDialogRef<NewPollDialogComponent>);
  newPollData?:  NewPollModel
  actualOptions: number = 2
  newPollForm = new FormGroup({
    name: new FormControl<string>('', [Validators.required]),
    options: new FormGroup({
      option1: new FormControl<string>('', [Validators.required]),
      option2: new FormControl<string>('', [Validators.required]),
    })
  })

  newOptionControl(): FormControl{
    return new FormControl<string>('', [Validators.required]);
  }
  onAddOption() {
    this.actualOptions += 1;
  }
  onClose() {
    console.log(this.newPollForm)
    this.dialogRef.close({
      name: this.newPollForm.value.name,
      options: [
        {name: this.newPollForm.value.options?.option1},
        {name: this.newPollForm.value.options?.option2}
      ]
    });
  }
}

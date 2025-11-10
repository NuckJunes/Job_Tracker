import { Component, inject } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { MainComponent } from '../main/main.component';

@Component({
  selector: 'app-create-account',
  imports: [],
  templateUrl: './create-account.component.html',
  styleUrl: './create-account.component.css'
})
export class CreateAccountComponent {

  readonly dialogRef = inject(MatDialogRef<MainComponent>);

  close() {
    this.dialogRef.close();
  }

}

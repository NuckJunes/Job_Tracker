import { Component, inject } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { MainComponent } from '../main/main.component';

@Component({
  selector: 'app-login',
  imports: [],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  readonly dialogRef = inject(MatDialogRef<MainComponent>);

  login() {
    this.dialogRef.close();
  }

  close() {
    this.dialogRef.close();
  }
}

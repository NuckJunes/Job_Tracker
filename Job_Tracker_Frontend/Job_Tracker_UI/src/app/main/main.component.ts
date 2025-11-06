import { Component, inject } from '@angular/core';
import { MatDialog} from '@angular/material/dialog';
import { LoginComponent } from '../login/login.component';
import { CreateAccountComponent } from '../create-account/create-account.component';

@Component({
  selector: 'app-main',
  imports: [],
  templateUrl: './main.component.html',
  styleUrl: './main.component.css'
})
export class MainComponent {

  readonly dialog = inject(MatDialog);

  openLogin(): void {
    const dialogRef = this.dialog.open(LoginComponent);
  }

  openSignUp(): void {
    const dialogRef = this.dialog.open(CreateAccountComponent);
  }
}

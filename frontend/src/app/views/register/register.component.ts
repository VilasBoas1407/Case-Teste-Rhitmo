import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/service/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css', '../../app.component.css'],
})
export class RegisterComponent {
  userData = {
    name: '',
    email: '',
    cpf: '',
    address: '',
    state: '',
    cep: '',
    city: '',
    paymentType: 0,
    cardName: '',
    monthExpiration: 1,
    yearExpiration: '',
    cardNumber: '',
    cardSafeCode: 0,
  };

  constructor(public route: Router, public UserService: UserService) {}

  register() {
    console.log(this.userData);
    this.UserService.AddUser(this.userData).subscribe((data) => {
      console.log(data);
    });
  }
}

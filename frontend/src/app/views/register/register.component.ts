import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CepService } from 'src/app/service/cep.service';
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
    safeCode: 0,
  };

  months: { value: number; description: string }[] = [
    { value: 1, description: 'Janeiro' },
    { value: 2, description: 'Fevereiro' },
    { value: 3, description: 'Março' },
    { value: 4, description: 'Abril' },
    { value: 5, description: 'Maio' },
    { value: 6, description: 'Junho' },
    { value: 7, description: 'Julho' },
    { value: 8, description: 'Agosto' },
    { value: 9, description: 'Setembro' },
    { value: 10, description: 'Outubro' },
    { value: 11, description: 'Novembro' },
    { value: 12, description: 'Dezembro' },
  ];
  years: number[] = [];

  states = [
    {
      id: 0,
      value: '',
      name: '',
    },
  ];

  cities = [
    {
      id: 0,
      name: '',
    },
  ];
  constructor(
    public route: Router,
    public UserService: UserService,
    public CepService: CepService
  ) {
    const year = new Date().getFullYear();
    const maxYear = 2030;

    for (let i = year; i <= maxYear; i++) {
      this.years.push(i);
    }
  }

  ngOnInit() {
    this.CepService.GetStates().subscribe((data) => {
      data.forEach((state: any) => {
        this.states.push({
          id: state.id,
          value: state.sigla,
          name: state.nome,
        });
      });
    });
  }

  getCities(state: string) {
    console.log(state);
    this.CepService.GetCities(state).subscribe((data) => {
      data.forEach((city: any) => {
        this.cities.push({
          id: city.codigo_ibge,
          name: city.nome,
        });
      });
    });
  }
  register() {
    console.log(this.userData);
    this.UserService.AddUser(this.userData).subscribe((data) => {
      console.log(data);
    });
  }
}

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root',
})
export class CepService {
  apiUrl = 'https://brasilapi.com.br/api/ibge';

  constructor(private httpClient: HttpClient) {}

  public GetStates(): Observable<any> {
    return this.httpClient.get(this.apiUrl + '/uf/v1');
  }

  public GetCities(state: string): Observable<any> {
    return this.httpClient.get(
      `${this.apiUrl}/municipios/v1/${state}?providers=dados-abertos-br,gov,wikipedia`
    );
  }
}

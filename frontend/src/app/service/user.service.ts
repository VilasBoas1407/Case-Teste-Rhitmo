import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private httpClient: HttpClient) {}

  apiUrl = 'https://localhost:7162/user';
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };

  public GetUser(name: string): Observable<any> {
    return this.httpClient.get<any>(
      this.apiUrl + `?name=${name}`,
      this.httpOptions
    );
  }

  public DeleteUser(idUser: string): Observable<any> {
    return this.httpClient.delete<any>(
      this.apiUrl + `?id=${idUser}`,
      this.httpOptions
    );
  }
  public AddUser(User: any): Observable<any> {
    return this.httpClient.post<any>(this.apiUrl, User, this.httpOptions);
  }

  public UpdateUser(User: any): Observable<any> {
    return this.httpClient.put<any>(this.apiUrl, User, this.httpOptions);
  }
}

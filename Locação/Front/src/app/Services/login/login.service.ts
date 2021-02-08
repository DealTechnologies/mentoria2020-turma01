import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Login } from './Login';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  url = 'https://localhost:44375/v1';

  constructor(private http: HttpClient) { }


  login(login: Login): Observable<Login> {
    var baseurl = `${this.url}/login`
    return this.http.post<Login>(baseurl, login)

  }


}
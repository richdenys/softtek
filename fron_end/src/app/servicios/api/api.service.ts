import { Injectable } from '@angular/core';

import { LoginI } from '../../Modelos/login.interface'
import { responseI } from '../../Modelos/response.interface'
import { ListaVentasI } from '../../Modelos/listaVentas.interface'

import { HttpClient, HttpHeaders } from '@angular/common/http'

import { Observable } from 'rxjs';
@Injectable(
  {
    providedIn: 'root'
  })
export class ApiService {
  url: string = "http://localhost:2023/api/";
  constructor(private http: HttpClient) { }

  loginByEmail(from: LoginI): Observable<responseI> {
    let direction = this.url + "Users/Login";
    return this.http.post<responseI>(direction, from)
  }

  getAllVentas(pagne: number): Observable<ListaVentasI[]> {
  let direction=this.url+"Ventas";
  const token=localStorage.getItem('token');
  return this.http.get<ListaVentasI[]>(direction,{
    headers:{
      'Authorization': `Bearer ${token}`
    }
  }); 
  }
}
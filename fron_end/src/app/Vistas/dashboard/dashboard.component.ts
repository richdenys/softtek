import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../servicios/api/api.service'
import { ListaVentasI } from '../../Modelos/listaVentas.interface'
import { Router } from '@angular/router'
@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  lisventas: ListaVentasI[]=[];

  constructor(private api: ApiService, private router: Router) { }

  ngOnInit(): void {
    this.api.getAllVentas(1).subscribe(data => {
      this.lisventas = data;
      console.log(data);
    });
  }
}

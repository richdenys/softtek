import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms'
import { ApiService } from '../../servicios/api/api.service'
import { responseI } from '../../Modelos/response.interface'

import {Router} from '@angular/router'
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm = new FormGroup({
    Email: new FormControl('', Validators.required),
    Password: new FormControl('', Validators.required)
  });
  constructor(private api: ApiService,private router:Router) { }
  errorStatus:boolean=false;
  errorMsj:any="";
  ngOnInit(): void {

  }
checkLocalStorage(){
  if(localStorage.getItem('token')){
  this.router.navigate(['dashboard']);
  }  
}


  onLogin(form: any) {
    this.api.loginByEmail(form).subscribe(data => {
      let dataresponse:responseI=data;
      console.log(dataresponse)
    
      if(dataresponse.exito==1){
        localStorage.setItem("token",dataresponse.data.token);
        this.router.navigate(['dashboard']);
      }else{
        this.errorStatus=true;
        this.errorMsj=dataresponse.mensaje;
      }  
    });
    ;
  }
}

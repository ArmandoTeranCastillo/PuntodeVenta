import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { PublicService } from '../public.service';
import { Router } from '@angular/router';
import notify from 'devextreme/ui/notify';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  isLoading = false;

  constructor(private publicService: PublicService, private router: Router) {}

  ngOnInit() {
    localStorage.clear();
  }

  verifyLogin(e: any) {
    e.preventDefault();
    this.isLoading = true;
    const username = e.target.elements[0].value;
    const password = e.target.elements[1].value;
    const dataToSend = {
      username,
      password,
    };

    this.publicService
      .verifyLogin(dataToSend)
      .subscribe(
        (data) => {
          console.log(data);
          localStorage.clear();
          //Guardamos el token en el local storage
          localStorage.setItem('token', data['token']);
          localStorage.setItem('role', data['role']);
          if (data['role'] == 'User') {
            this.router.navigate(['/', 'home']);
          } else {
            this.router.navigate(['/', 'login']);
          }
          //Redirigimos al usuario a la pagina principal
          notify('Bienvenido', 'success', 3000);
        },
        (error: HttpErrorResponse) => {
          notify(error, 'error', 3000);
        }
      )
      .add(() => {
        //Finalizacion del servicio
        this.isLoading = false;
      });
  }
}

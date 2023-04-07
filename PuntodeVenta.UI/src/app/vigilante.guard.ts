import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  CanActivate,
  Router,
  RouterStateSnapshot,
  UrlTree,
} from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class VigilanteGuard implements CanActivate {
  constructor(private router: Router) {}

  redirect(cookie: boolean): boolean {
    if (cookie == false) {
      this.router.navigate(['/', 'login']);
      return false;
    } else {
      if (localStorage.getItem('role') != 'User') {
        return false;
      } else {
        return true;
      }
    }
  }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ):
    | Observable<boolean | UrlTree>
    | Promise<boolean | UrlTree>
    | boolean
    | UrlTree {
    const cookie = localStorage.getItem('token') ? true : false;
    return this.redirect(cookie);
  }
}

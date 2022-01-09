import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router, RouterModule } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';

@Injectable({
  providedIn: 'root'
})
export class AdministrationService {
readonly APIUrl = "https://localhost:44392/api/Administration";

constructor(
  private http: HttpClient, 
  private router: Router,
  private cookieService: CookieService
) { }

SignUp(data: any) {
  this.http.post(this.APIUrl+'/SignUp', data).subscribe(() => this.router.navigate(['/login']));
}

SignIn(data: any) {
  this.http.post(this.APIUrl+'/SignIn', data, {
    withCredentials: true,
    responseType: 'text' as 'json'
  }).subscribe(() => this.router.navigate(['/knowledge']).then(() => {window.location.reload()}));
}

SignOut(){
  this.http.post(this.APIUrl+'/SignOut', null).subscribe(() => this.router.navigate(['/']));
  this.cookieService.deleteAll();
}

ifLoggedIn():boolean {
  if(this.cookieService.check('.AspNetCore.Application.Id')){
    return true;
  }
  return false;
}

}

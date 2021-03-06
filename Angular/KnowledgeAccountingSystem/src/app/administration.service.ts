import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router, RouterModule } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { ForgotPassword } from './models/ForgotPassword';
import { ResetPassword } from './models/ResetPassword';
import { Observable } from 'rxjs';

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

SignIn(data: any){
  this.http.post<string>(this.APIUrl+'/SignIn', data, {
    withCredentials: true,
    responseType: 'text' as 'json'
  }).subscribe(() => this.router.navigate(['/knowledge']).then(() => {window.location.reload()}));
}

SignOut(){
  this.http.post(this.APIUrl+'/SignOut', null).subscribe(() => {window.location.reload()});
  this.cookieService.deleteAll();
}

ForgotPassword(model: ForgotPassword): Observable<string> {
  return this.http.post<any>(this.APIUrl + '/ForgotPassword', model , {withCredentials: true,  responseType: 'text' as 'json'})
}

ResetPassword(model: ResetPassword): Observable<string>{
  return this.http.post<any>(this.APIUrl + '/ResetPassword', model, {withCredentials: true , responseType: 'text' as 'json'})
}

ifLoggedIn():boolean {
    if(this.cookieService.check('.AspNetCore.Application.Id')){
      return true;
    }
    return false;
  }



}

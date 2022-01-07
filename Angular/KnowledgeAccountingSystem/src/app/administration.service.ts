import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AdministrationService {
readonly APIUrl = "https://localhost:44392/api/Administration";

constructor(private http: HttpClient) { }

SignUp(data: any) {
  this.http.post(this.APIUrl+'/signup', data).subscribe(res => {
    console.log(res);
  });
}

}

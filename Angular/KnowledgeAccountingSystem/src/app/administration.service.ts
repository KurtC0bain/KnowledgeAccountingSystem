import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AdministrationService {
readonly APIUrl = "https://localhost:44392/api";

constructor(private http: HttpClient) { }


}

import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs'; 


@Injectable({
  providedIn: 'root'
})
export class SharedService {
readonly APIUrl = "https://localhost:44392/api";

  constructor(private http: HttpClient) { }


  //Knowledge
  GetAllKnowledge(): Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/Knowledge');
  }

  AddKnowledge(val:any) {
    return this.http.post(this.APIUrl+'/Knowledge', val);
  }

  UpdateKnowledge(val:any) {
    return this.http.patch(this.APIUrl+'/Knowledge', val);
  }

  DeleteKnowledge(val:any) {
    return this.http.delete(this.APIUrl+'/Knowledge', val);
  }

  GetKnowledge(id:Number) {
    return this.http.get(this.APIUrl+'/Knowledge/'+ id);
  }



  //Areas
  GetAreas(): Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/Area');
  }

  AddArea(val:any) {
    return this.http.post(this.APIUrl+'/Area', val);
  }

  UpdateArea(val:any) {
    return this.http.patch(this.APIUrl+'/Area', val);
  }

  DeleteArea(val:any) {
    return this.http.delete(this.APIUrl+'/Area', val);
  }




 //Users
  GetUsers(): Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/User/Users');
  }

  DeleteUser(val:any) {
    return this.http.delete(this.APIUrl+'/User/DeleteUser', val);
  }




  //Roles
  GetRoles() : Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/Role/Roles');
  }
  AddRole(val:any){
    return this.http.post(this.APIUrl+'/Role/NewRole', val);
  }
  AssignUserToTole(val:any){
    return this.http.post(this.APIUrl+'/Role/AssignUserToRole', val);
  }

}



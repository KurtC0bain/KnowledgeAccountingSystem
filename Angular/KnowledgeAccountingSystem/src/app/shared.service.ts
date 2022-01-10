import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable, retryWhen } from 'rxjs';
import { first, map } from 'rxjs/operators';

import {Knowledge} from "./models/Knowledge";
import { Area } from './models/Area';
import { User } from './models/User';
import { Role } from './models/Role';
import{AreaRating} from './models/AreaRating';
import { pipe } from 'rxjs';



@Injectable({
  providedIn: 'root'
})
export class SharedService {
readonly APIUrl = "https://localhost:44392/api";

  constructor(private http: HttpClient) { }


  //Knowledge
  GetAllKnowledge(): Observable<Knowledge[]>{
    return this.http.get<Knowledge[]>(this.APIUrl+'/Knowledge');
  }

  GetKnowledge(id:Number): Observable<Knowledge> {
    return this.http.get<Knowledge>(this.APIUrl+'/Knowledge/'+ id);
  }
  
  AddKnowledge(knowledge:any){
    return this.http.post<Knowledge>(this.APIUrl+'/Knowledge', knowledge, 
    {withCredentials: true, 
      responseType: 'json' as 'json'
    });
  }

  UpdateKnowledge(knowledge:any) {
    return this.http.patch(this.APIUrl+'/Knowledge', knowledge, {withCredentials: true});
  }

  DeleteKnowledge(id:Number){
    return this.http.delete(this.APIUrl+'/Knowledge/'+ id, {withCredentials: true});
  }

  



  //Areas

  GetAreas(): Observable<Area[]>{
    return this.http.get<Area[]>(this.APIUrl+'/Area');
  }

  
  AddArea(area:any) {
    return this.http.post(this.APIUrl+'/Area', area, {withCredentials: true});
  }

  UpdateArea(area:any) {
    return this.http.patch(this.APIUrl+'/Area', area, {withCredentials: true});
  }

  DeleteArea(id:Number) {
    return this.http.delete(this.APIUrl+'/Area/' + id, {withCredentials: true});
  }




 //Users
  GetUsers(): Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/User/Users', {withCredentials: true});
  }

  DeleteUser(user:any) {
    this.http.delete(this.APIUrl+'/User/DeleteUser'+ user, {withCredentials: true});
  }

  GetUserId(): Observable<String>{
    return this.http.get(this.APIUrl+'/User/UserId', {
      withCredentials: true, 
      responseType: 'text'
    });
  }



  //Roles
  GetRoles() : Observable<Role[]>{
    return this.http.get<any>(this.APIUrl+'/Role/Roles');
  }
  AddRole(role:Role){
    this.http.post(this.APIUrl+'/Role/NewRole', role);
  }
  AssignUserToTole(role:Role){
    this.http.post(this.APIUrl+'/Role/AssignUserToRole', role);
  }

  GetUserRoles(email:String): Observable<Role[]>{
    return this.http.get<any>(this.APIUrl + '/Role/UserRole/'+ email)
  }
}




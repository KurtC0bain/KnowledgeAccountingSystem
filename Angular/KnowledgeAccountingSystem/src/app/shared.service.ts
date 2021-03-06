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
import { FullArea } from './models/FullArea';



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
  
  GetUserKnowledge(email:string): Observable<Knowledge[]>{
    return this.http.get<Knowledge[]>(this.APIUrl+'/Knowledge/user/'+ email, {withCredentials: true})
  }

  AddKnowledge(knowledge:Knowledge){
    return this.http.post<Knowledge>(this.APIUrl+'/Knowledge', knowledge, 
    {withCredentials: true, 
      responseType: 'json' as 'json'
    });
  }

  UpdateKnowledge(knowledge:Knowledge) {
    return this.http.patch<Knowledge>(this.APIUrl+'/Knowledge', knowledge, {withCredentials: true, responseType: 'json' as 'json'});
  }

  DeleteKnowledge(id:Number){
    return this.http.delete(this.APIUrl+'/Knowledge/'+ id, {withCredentials: true});
  }

  



  //Areas

  GetAreas(): Observable<Area[]>{
    return this.http.get<Area[]>(this.APIUrl+'/Area');
  }

  GetFullAreas(): Observable<FullArea[]>{
    return this.http.get<FullArea[]>(this.APIUrl+'/Area/FullAreas', {withCredentials: true});
  }

  AddArea(area:any) {
    return this.http.post(this.APIUrl+'/Area', area, {withCredentials: true, responseType: 'json' as 'json'});
  }

  UpdateArea(area:any) {
    return this.http.patch(this.APIUrl+'/Area', area, {withCredentials: true});
  }

  DeleteArea(id:Number) {
    return this.http.delete(this.APIUrl+'/Area/' + id, {withCredentials: true});
  }




 //Users
  GetUsers(): Observable<User[]>{
    return this.http.get<User[]>(this.APIUrl+'/User/Users', {withCredentials: true});
  }

  GetUserById(id:String): Observable<User>{
    return this.http.get<User>(this.APIUrl + '/User/' + id, {withCredentials: true})
  }

  DeleteUser(user:any) {
    this.http.delete(this.APIUrl+'/User/DeleteUser'+ user, {withCredentials: true});
  }

  GetCurrentUser(): Observable<User> {
    return this.http.get<User>(this.APIUrl+'/User/current', {withCredentials: true})
  }

  //GetUserId(): Observable<String>{
 //   return this.http.get(this.APIUrl+'/User/UserId', {
 //     withCredentials: true, 
 //     responseType: 'text'
 //   });
 // }

  GetUserId(email:string): Observable<string>{
    return this.http.get(this.APIUrl+'/User/UserId/'+ email, {
      withCredentials: true,
      responseType: 'text'
    });
  }

  GetCurrentUserMail(): Observable<String>{
    return this.http.get(this.APIUrl + '/User/UserEmail', {
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
    return this.http.get<Role[]>(this.APIUrl + '/Role/UserRole/'+ email, {withCredentials : true})
  }
}

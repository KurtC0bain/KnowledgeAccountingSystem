import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs';
import { AdministrationService } from './administration.service';
import { User } from './models/User';
import { SharedService } from './shared.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  constructor(public admin: AdministrationService, private service : SharedService) {}
  title = 'KnowledgeAccountingSystem';
  ifLoggedIn = false;
  ifAdmin = false;
  currentUserName:String = "";
  CurrentUser:User;


  ngOnInit(): void {
    this.ifLoggedIn = this.admin.ifLoggedIn();
    this.service.GetCurrentUser().pipe(first()).subscribe(data => {
      this.CurrentUser = data;
      if(this.CurrentUser != null){
        this.currentUserName = data.firstName;
        this.service.GetUserRoles(this.CurrentUser.email).pipe(first()).subscribe(data => {
          this.CurrentUser.role = data;
          this.CurrentUser.role.forEach((r) => {
            if(r.toString() == 'admin') this.ifAdmin = true;
          })          
        });
      }
    });
  }

  refresh(){
    window.location.reload();
  }

  signOut(){
    this.admin.SignOut();
    this.refresh();
  }

}

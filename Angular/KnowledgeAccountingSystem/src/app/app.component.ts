import { Component, OnInit } from '@angular/core';
import { AdministrationService } from './administration.service';
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
  currentUserName:String = "";


  ngOnInit(): void {
    this.ifLoggedIn = this.admin.ifLoggedIn();
    if(this.ifLoggedIn){
      this.service.GetCurrentUserMail().subscribe(data => this.currentUserName = data)
    }
    console.log(this.currentUserName);
    console.log(this.ifLoggedIn);
  }

  refresh(){
    window.location.reload();
  }

  signOut(){
    this.admin.SignOut();
    this.refresh();
  }

}

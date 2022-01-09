import { Component, OnInit } from '@angular/core';
import { AdministrationService } from './administration.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  constructor(public admin: AdministrationService) {}
  title = 'KnowledgeAccountingSystem';
  ifLoggedIn = false;


  ngOnInit(): void {
    this.ifLoggedIn = this.admin.ifLoggedIn();
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

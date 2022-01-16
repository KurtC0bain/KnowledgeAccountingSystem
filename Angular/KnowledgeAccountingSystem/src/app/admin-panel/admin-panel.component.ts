import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs';
import { Knowledge } from '../models/Knowledge';
import { User } from '../models/User';
import { SharedService } from '../shared.service';

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.css']
})
export class AdminPanelComponent implements OnInit {

  constructor(private service: SharedService) { }

  UserList:User[] = [];

  KnowledgeForInfo:Knowledge[] = [];

  ModalTitle:string="";
  ActivateAddEditKnow: boolean = false;
  ActivateInfo:boolean = false;

  ngOnInit(): void {
    this.refreshList();
  }

  infoClick(knowledge: Knowledge[]){
    this.KnowledgeForInfo = knowledge;
    this.ModalTitle = "Info";
    this.ActivateInfo = true;
  }

  refreshList(){
    this.service.GetUsers().pipe(first()).subscribe(users => {
      this.UserList = users;
      this.UserList.forEach((user) =>{
        this.service.GetUserRoles(user.email).pipe(first()).subscribe(roles => {
          user.role = roles;
        });
        this.service.GetUserKnowledge(user.email).pipe(first()).subscribe(knowledge => {
          user.knowledge = knowledge;
        })
      })
    })
  }
}

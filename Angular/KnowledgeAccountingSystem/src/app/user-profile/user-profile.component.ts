import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs';
import { User } from '../models/User';
import { SharedService } from '../shared.service';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {

  constructor(private service: SharedService) { }

  //KnowledgeList: Knowledge[] = [];
  User: User;

  ngOnInit(): void {
    this.service.GetCurrentUser().pipe(first()).subscribe(user => {
      this.User = user;
      this.service.GetUserKnowledge(this.User.email).pipe(first()).subscribe(data => {
        this.User.knowledge = data;
      })  
    });

  }

}

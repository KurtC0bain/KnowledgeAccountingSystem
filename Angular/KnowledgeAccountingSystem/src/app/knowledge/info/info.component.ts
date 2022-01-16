import { Component, Input, OnInit } from '@angular/core';
import { first } from 'rxjs';
import { Knowledge } from 'src/app/models/Knowledge';
import { SharedService } from '../../shared.service';


@Component({
  selector: 'app-info',
  templateUrl: './info.component.html',
  styleUrls: ['./info.component.css']
})


export class InfoComponent implements OnInit {

  constructor(private service: SharedService, ) { }


  @Input() Knowledge:Knowledge;
  @Input() KnowledgeList:Knowledge[] = [];
  UserEmail:string = "";
  UserFullName:string = "";
  
  UserRoles:string[] = [];



  ngOnInit(): void {
    this.getKnowledge();
  }


  getKnowledge(): any {
    if(this.Knowledge != null) {
      this.service.GetKnowledge(this.Knowledge.id).subscribe(data => {
        this.Knowledge = data;
        this.service.GetUserById(data.userId).pipe(first()).subscribe(data => {
          this.UserEmail = data.email;
          this.UserFullName = data.firstName + " " + data.lastName;
        })
      });  
    }
  }
}

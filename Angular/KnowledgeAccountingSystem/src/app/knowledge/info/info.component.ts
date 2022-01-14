import { Component, Input, OnInit } from '@angular/core';
import { first } from 'rxjs';
import { Knowledge } from 'src/app/models/Knowledge';
import { SharedService } from '../../shared.service';
import { Mailto, NgxMailtoService } from 'ngx-mailto';


@Component({
  selector: 'app-info',
  templateUrl: './info.component.html',
  styleUrls: ['./info.component.css']
})


export class InfoComponent implements OnInit {

  constructor(private service: SharedService, private mailtoService: NgxMailtoService) { }


  @Input() Knowledge:Knowledge;
  @Input() KnowledgeList:Knowledge[] = [];
  UserEmail:string = "";
  UserFullName:string = "";
  
  

  mailto: Mailto = {
    receiver: ""
  };


  ngOnInit(): void {
    this.getKnowledge();
    console.log(this.KnowledgeList)
  }

  sendMail(): void {
    this.mailto.receiver = this.UserEmail;
    this.mailtoService.open(this.mailto);
  }

  getKnowledge(): any {
    if(this.Knowledge != null) {
      this.service.GetKnowledge(this.Knowledge.id).subscribe(data => {
        this.Knowledge = data;
        this.service.GetUserById(data.userId).pipe(first()).subscribe(data => {
          console.log(data);
          this.UserEmail = data.email;
          this.UserFullName = data.firstName + " " + data.lastName;
        })
      });  
    }
  }
}

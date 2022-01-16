import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { first, map } from 'rxjs';
import { EmailService } from 'src/app/email-service.service';
import { Area } from 'src/app/models/Area';
import { AreaRating } from 'src/app/models/AreaRating';
import { Knowledge } from 'src/app/models/Knowledge';
import { User } from 'src/app/models/User';
import{SharedService} from '../../shared.service';
import {InfoComponent} from '../info/info.component'


@Component({
  selector: 'app-show-know',
  templateUrl: './show-know.component.html',
  styleUrls: ['./show-know.component.css']
})
export class ShowKnowComponent implements OnInit {

  constructor(public service: SharedService, public info: InfoComponent, private emailService: EmailService) { }

  @Input() KnowledgeList: Knowledge[] = [];

  AllAreas: Area[] = [];

  ModalTitle:string="";
  ActivateAddEditKnow: boolean = false;
  ActivateInfo:boolean = false;
  CurrentUser:User;

  know: Knowledge;

  ifManager:boolean = false;

  KnowledgeArea:any=[];
  AreaName:string="";


  searchText: any;


  KnowledgeTitleFilter:string="";
  KnowledgeIdFilter:string="";

  KnowledgeUserIdFilter:string="";
  KnowledgeEmailFilter:string="";

  KnowledgeAreaFilter:string="";

  KnowledgeListWithoutFilter:Knowledge[]=[];

  pageOfItems: Array<any>;

  ngOnInit(){
    this.refreshKnowledgeList();

  }


  addClick(){
    this.know={
      id: 0,
      title:"",
      description:"",
      areaRating: [],
      userId: ""
    };

    this.ModalTitle = "Add Knowledge";
    this.ActivateAddEditKnow = true;
  }

  generateReportClick(knowledge:Knowledge){
    this.service.GetUserById(knowledge.userId).subscribe(data => {
      this.emailService.mailto.receiver = data.email;
      this.emailService.userFullName = data.firstName + " " + data.lastName;
    });

    this.emailService.managerFullName = this.CurrentUser.firstName + " " + this.CurrentUser.lastName;
    this.emailService.knowledgeTitle = knowledge.title;
    this.emailService.sendMail();
  }

  editClick(knowledge: Knowledge){
    this.know=knowledge;
    this.ModalTitle = "Edit Knowledge";
    this.ActivateAddEditKnow = true;
  }

  infoClick(knowledge: Knowledge){
    this.know = knowledge;
    this.ModalTitle = "Info";
    this.ActivateInfo = true;
  }

  deleteClick(knowledge: Knowledge){
    if(confirm('Are you sure?')){
      this.service.DeleteKnowledge(knowledge.id).subscribe();
      this.refreshKnowledgeList();
    }
    this.refresh();
  }

  closeClick(){
    this.ActivateAddEditKnow=false;
    this.ActivateInfo = false;
  }


  refreshKnowledgeList(): void {
   this.service.GetAllKnowledge().pipe(first()).subscribe(data => {
      this.KnowledgeList = data;
      this.KnowledgeListWithoutFilter = data;
    });
    this.service.GetAreas().pipe(first()).subscribe(data => {
      this.AllAreas = data;
    });
    this.service.GetCurrentUser().pipe(first()).subscribe(data => {
      this.CurrentUser = data;
      if(this.CurrentUser != null){
        this.service.GetUserRoles(this.CurrentUser.email).pipe(first()).subscribe(data => {
          this.CurrentUser.role = data;
          this.CurrentUser.role.forEach((r) => {
            if(r.toString() == 'manager'){
            this.ifManager = true;
        }
      })
        })
      }
      
    });
    

  }


  refresh(){
    window.location.reload();
  }


  FilterByName(){
    var KnowledgeTitleFilter = this.KnowledgeTitleFilter;

    this.KnowledgeList = this.KnowledgeListWithoutFilter.filter(function (el){
      return el.title.toString().toLowerCase().includes(
        KnowledgeTitleFilter.toString().trim().toLowerCase()
      )
    });
  }

  FilterByUser(){
    var KnowledgeEmailFilter = this.KnowledgeEmailFilter;
    var KnowledgeUserIdFilter = this.KnowledgeUserIdFilter;

    if(KnowledgeEmailFilter != ""){
      this.service.GetUserId(KnowledgeEmailFilter).pipe(first()).subscribe(data => {
        KnowledgeUserIdFilter = data;

        this.KnowledgeList = this.KnowledgeListWithoutFilter.filter(function (el){
          return el.userId.toString().toLowerCase().includes(
            KnowledgeUserIdFilter.toString().trim().toLowerCase())
        });    
      },
      err => {
        this.KnowledgeList = [];
      });  
    };

  }

  FilterByArea(){
    var KnowledgeAreaFilter = this.KnowledgeAreaFilter;


    this.KnowledgeList = this.KnowledgeListWithoutFilter.filter(function (el){
      for(let a of el.areaRating){
        if(a.name.toString().toLowerCase().includes(
          KnowledgeAreaFilter.toString().trim().toLowerCase()
        )){
          return true;
        }
      }
      return false
    });
  }
}

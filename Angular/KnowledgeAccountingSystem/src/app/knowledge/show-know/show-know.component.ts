import { Component, OnInit } from '@angular/core';
import { first, map } from 'rxjs';
import { Area } from 'src/app/models/Area';
import { AreaRating } from 'src/app/models/AreaRating';
import { Knowledge } from 'src/app/models/Knowledge';
import{SharedService} from '../../shared.service';
import {InfoComponent} from '../info/info.component'


@Component({
  selector: 'app-show-know',
  templateUrl: './show-know.component.html',
  styleUrls: ['./show-know.component.css']
})
export class ShowKnowComponent implements OnInit {

  constructor(public service: SharedService, public info: InfoComponent) { }


  KnowledgeList: Knowledge[] = [];

  AllAreas: Area[] = [];

  ModalTitle:string="";
  ActivateAddEditKnow: boolean = false;
  ActivateInfo:boolean = false;
  
  know: any;



  KnowledgeArea:any=[];
  AreaName:string="";



  searchText: any;

  KnowledgeTitleFilter:string="";
  KnowledgeIdFilter:string="";
  KnowledgeAreaFilter:string="";
  KnowledgeListWithoutFilter:Knowledge[]=[];


  ngOnInit(){
    this.refreshKnowledgeList();
  }

  addClick(){
    this.know={
      id:0,
      title:"",
      desc: "",
    };

    this.ModalTitle = "Add Knowledge";
    this.ActivateAddEditKnow = true;
  }

  editClick(knowledge: any){
    this.know=knowledge;
    this.ModalTitle = "Edit Knowledge";
    this.ActivateAddEditKnow = true;
  }

  infoClick(knowledge: any){
    this.know = knowledge;
    this.ModalTitle = "Info";
    this.ActivateInfo = true;
  }

  deleteClick(knowledge: any){
    if(confirm('Are you sure?')){
      alert(knowledge);
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
  }


  refresh(){
    window.location.reload();
  }


  FilterByName(){
    var KnowledgeTitleFilter = this.KnowledgeTitleFilter;

    console.log(KnowledgeTitleFilter)
    this.KnowledgeList = this.KnowledgeListWithoutFilter.filter(function (el){
      return el.title.toString().toLowerCase().includes(
        KnowledgeTitleFilter.toString().trim().toLowerCase()
      )
    });
  }
  
  FilterByArea(){
    var KnowledgeAreaFilter = this.KnowledgeAreaFilter;

    console.log(KnowledgeAreaFilter);

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

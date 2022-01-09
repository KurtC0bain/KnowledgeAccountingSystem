import { Component, OnInit } from '@angular/core';
import { first, map } from 'rxjs';
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


  bufferAreas:any=[];


  KnowledgeList: Knowledge[] = [];

  ModalTitle:string="";
  ActivateAddEditKnow: boolean = false;
  ActivateInfo:boolean = false;
  know: any;

  Areas:any=[];



  KnowledgeArea:any=[];
  AreaName:string="";




  KnowledgeIdFilter:string = "";
  KnowledgeTitleFilter:string="";
  KnowledgeAreaFilter:string="";
  KnowledgeUserIdFilter:string="";


  KnowledgeListWithoutFilter:any=[];


  ngOnInit(){
    this.refreshKnowledgeList();
  }

  getAreas(id:Number): any[]{
    return this.info.getAreas(id).subscribe((data: any) => {
      this.bufferAreas = data;
    });
  };


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
      this.service.DeleteKnowledge(knowledge.id);
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
      console.log(data)
    });

    this.service.GetAreas().subscribe(data => {
      this.KnowledgeArea = data;
    });
    console.log(this.KnowledgeList);
  }


  refresh(){
    window.location.reload();
  }


  FilterFn(){
    var KnowledgeIdFilter = this.KnowledgeIdFilter;
    var KnowledgeTitleFilter = this.KnowledgeTitleFilter;
    var KnowledgeUserIdFilter = this.KnowledgeUserIdFilter;

    this.KnowledgeList = this.KnowledgeListWithoutFilter.filter(function (el:any){
      return el.id.toString().toLowerCase().includes(
        KnowledgeIdFilter.toString().trim().toLowerCase()
      )&&
      el.title.toString().toLowerCase().includes(
        KnowledgeTitleFilter.toString().trim().toLowerCase()
      )
    });
  }
  
  FilterByArea(){
    this.service.FilterKnowledgeByArea(this.AreaName).subscribe(data => {
      this.KnowledgeList = data;
    })
  }


  FilterFnArea(){
    var AreaNameFilter = this.AreaName;
    var AreaFilter;
    this.service.GetAreas().subscribe(data => {
      AreaFilter = data
    });

    this.KnowledgeList = this.KnowledgeListWithoutFilter.filter
    (
      (knowledge: { id: Number, title: string}) => {
        var knowAreas:any[]=[];
        var result:boolean = false;
        
        console.log(knowledge.title);

        this.service.GetAreasByKnowledgeId(knowledge.id).subscribe(data=>{
          data.forEach(d => knowAreas.push(d))
        });

        console.log(knowAreas[0]);

        for(var i of knowAreas[0])
        {
          console.log(i);
        }
        console.log("______");

        //console.log(knowAreas);
       // console.log("______________");
       // console.log(knowAreas.forEach(area => console.log(area)));


        //if(
        //  knowAreas[0].Name.toString().toLowerCase().includes(
       //     this.AreaName.toString().trim().toLowerCase())
       //   )
      //  {
      //    return true
     //   }
      }
    )
      
      
  
      /*function (el:any){
      for(let item of buff){
        console.log(item.name);
        if(item.name.toString().toLowerCase().includes(
          AreaNameFilter.toString().trim().toLowerCase()
        )){
          return true;
        }
      }
      return false;
    })*/
  }

}

import { Component, OnInit } from '@angular/core';
import{SharedService} from '../../shared.service';


@Component({
  selector: 'app-show-know',
  templateUrl: './show-know.component.html',
  styleUrls: ['./show-know.component.css']
})
export class ShowKnowComponent implements OnInit {

  constructor(private service: SharedService) { }

  KnowledgeList:any=[];

  ModalTitle:string="";
  ActivateAddEditKnow: boolean = false;
  ActivateInfo:boolean = false;
  know: any;

  KnowledgeArea:any=[];
  Area:any;

  KnowledgeIdFilter:string = "";
  KnowledgeTitleFilter:string="";
  KnowledgeAreaFilter:string="";
  KnowledgeUserIdFilter:string="";

  KnowledgeListWithoutFilter:any=[];


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
    this.service.GetAllKnowledge().subscribe(data => {
      this.KnowledgeList=data;
      this.KnowledgeListWithoutFilter=data
    });
    this.service.GetAreas().subscribe(data => {
      this.KnowledgeArea = data;
    })
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

}

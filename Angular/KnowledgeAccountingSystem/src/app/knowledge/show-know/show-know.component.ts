import { Component, OnInit } from '@angular/core';
import{SharedService} from '../../shared.service'

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
  know: any;

  ngOnInit(): void {
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

  deleteClick(knowledge: any){
    if(confirm('Are you sure??')){
      this.service.DeleteKnowledge(knowledge).subscribe(data=>{
        alert(data.toString());
        this.refreshKnowledgeList();
      })
    }
  }

  closeClick(){
    this.ActivateAddEditKnow=false;
    this.refreshKnowledgeList();
  }

  refreshKnowledgeList(): void {
    this.service.GetAllKnowledge().subscribe(data => {
      this.KnowledgeList=data;
    })
  }

}

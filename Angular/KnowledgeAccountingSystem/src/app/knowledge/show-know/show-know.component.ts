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
      KnowledgeId:0,
      KnowledgeTitle:""
    };
    this.ModalTitle = "Add Knowledge";
    this.ActivateAddEditKnow = true;
  }

  closeClick(): void {
    this.ActivateAddEditKnow=false;
    this.refreshKnowledgeList();
  }

  refreshKnowledgeList(): void {
    this.service.GetAllKnowledge().subscribe(data => {
      this.KnowledgeList=data;
    })
  }

}

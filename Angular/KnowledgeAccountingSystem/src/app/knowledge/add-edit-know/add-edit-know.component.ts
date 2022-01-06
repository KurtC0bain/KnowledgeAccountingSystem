import { Component, OnInit, Input} from '@angular/core';
import { SharedService } from 'src/app/shared.service';
import { ShowKnowComponent } from '../show-know/show-know.component';


@Component({
  selector: 'app-add-edit-know',
  templateUrl: './add-edit-know.component.html',
  styleUrls: ['./add-edit-know.component.css']
})
export class AddEditKnowComponent implements OnInit {

  constructor(private service: SharedService, private comp: ShowKnowComponent) { }

  @Input() know: any;

  KnowledgeId?:number;
  KnowledgeTitle?: string;
  KnowledgeDesc?: string;


  ngOnInit(): void {
    this.KnowledgeId = this.know.id;
    this.KnowledgeTitle = this.know.title;
    this.KnowledgeDesc = this.know.desc;
  }

  addKnowledge(){
    var val = {
      Title: this.KnowledgeTitle,
      Description: this.KnowledgeDesc,
    }
    this.service.AddKnowledge(val).subscribe();
    this.comp.refresh();
  }

  updateKnowledge(){
    var val = {
      Id: this.KnowledgeId,
      Title: this.KnowledgeTitle,
      Description: this.KnowledgeDesc,
    }
    this.service.UpdateKnowledge(val).subscribe();
    this.comp.refresh();
  }
  
}

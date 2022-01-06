import { Component, OnInit, Input} from '@angular/core';

@Component({
  selector: 'app-add-edit-know',
  templateUrl: './add-edit-know.component.html',
  styleUrls: ['./add-edit-know.component.css']
})
export class AddEditKnowComponent implements OnInit {

  constructor() { }

  @Input() know: any;
  KnowledgeId: Number = 0;
  KnowledgeTitle:string = "";

  ngOnInit(): void {
    this.KnowledgeId = this.know.KnowledgeId;
    this.KnowledgeTitle = this.know.KnowledgeTitle;
  }

}

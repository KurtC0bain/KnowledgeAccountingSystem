import { Component, Input, OnInit } from '@angular/core';
import { Knowledge } from 'src/app/models/Knowledge';
import { SharedService } from '../../shared.service';


@Component({
  selector: 'app-info',
  templateUrl: './info.component.html',
  styleUrls: ['./info.component.css']
})


export class InfoComponent implements OnInit {

  constructor(private service: SharedService) { }

  @Input() Knowledge:Knowledge;
  @Input() KnowledgeList:Knowledge[] = [];

  ngOnInit(): void {
    this.getKnowledge();
    console.log(this.KnowledgeList)
  }

  getKnowledge(): any {
    if(this.Knowledge != null) {
      this.service.GetKnowledge(this.Knowledge.id).subscribe(data => {
        this.Knowledge = data;
      });  
    }
  }
}

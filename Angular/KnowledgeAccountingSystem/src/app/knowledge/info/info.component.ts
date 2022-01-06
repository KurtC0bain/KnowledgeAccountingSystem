import { Component, Input, OnInit } from '@angular/core';
import { SharedService } from '../../shared.service';

@Component({
  selector: 'app-info',
  templateUrl: './info.component.html',
  styleUrls: ['./info.component.css']
})
export class InfoComponent implements OnInit {

  constructor(private service: SharedService) { }

  @Input() Knowledge: any;

  ngOnInit(): void {
    this.getKnowledge();
  }

  getKnowledge(): any {
    this.service.GetKnowledge(this.Knowledge.id).subscribe(data => {
      this.Knowledge = data;
    })
  } 

}

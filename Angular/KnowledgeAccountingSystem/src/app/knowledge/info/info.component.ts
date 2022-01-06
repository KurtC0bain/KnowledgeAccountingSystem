import { Component, OnInit } from '@angular/core';
import { SharedService } from '../../shared.service';

@Component({
  selector: 'app-info',
  templateUrl: './info.component.html',
  styleUrls: ['./info.component.css']
})
export class InfoComponent implements OnInit {

  constructor(private service: SharedService) { }

  Knowledge: any;


  ngOnInit(): void {
 
  }

  getKnowledge(id:Number): any {
    this.service.GetKnowledge(id).subscribe(data => {
      this.Knowledge = data;
    })
  } 

}

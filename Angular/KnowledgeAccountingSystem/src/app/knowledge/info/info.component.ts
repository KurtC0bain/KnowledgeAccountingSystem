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
  areas:any = [];
  areasToShow:any = [];


  ngOnInit(): void {
    this.getKnowledge();
    this.service.GetAreas().subscribe(data => {
      this.areas = data;
    });
    this.getAreas(this.Knowledge.id);
  }

  getKnowledge(): any {
    this.service.GetKnowledge(this.Knowledge.id).subscribe(data => {
      this.Knowledge = data;
    });
  }

  getAreas(id:Number){
    return this.service.GetAreasById(id).subscribe(data => {
      this.areasToShow = data;
    })
  }

}

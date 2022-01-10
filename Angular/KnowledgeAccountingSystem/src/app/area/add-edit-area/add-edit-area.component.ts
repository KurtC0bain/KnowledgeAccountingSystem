import { Component, Input, OnInit } from '@angular/core';
import { Area } from 'src/app/models/Area';
import { SharedService } from 'src/app/shared.service';
import { ShowAreaComponent } from '../show-area/show-area.component';
@Component({
  selector: 'app-add-edit-area',
  templateUrl: './add-edit-area.component.html',
  styleUrls: ['./add-edit-area.component.css']
})
export class AddEditAreaComponent implements OnInit {

  constructor(private service: SharedService, private comp: ShowAreaComponent) { }

  @Input() area: any;

  AreaId?:number;
  AreaName?: string;

  ngOnInit(): void {
    this.AreaId = this.area.id;
    this.AreaName = this.area.name;
  }

  addArea(){
    var val = {
      Name: this.AreaName
    }
    this.service.AddArea(val).subscribe();

    //this.comp.refresh();
  }

  updateArea(){
    console.log(this.AreaId)
    var val = {
      Id: this.AreaId,
      Name: this.AreaName,
    }
    console.log(val);
    this.service.UpdateArea(val).subscribe();  
    this.comp.closeClick();
  }
}


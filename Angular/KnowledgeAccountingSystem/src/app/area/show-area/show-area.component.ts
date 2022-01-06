import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-area',
  templateUrl: './show-area.component.html',
  styleUrls: ['./show-area.component.css']
})
export class ShowAreaComponent implements OnInit {

  constructor(private service: SharedService) { }

  AreaList:any = [];
  ModalTitle:string="";
  ActivateAddEditArea: boolean = false;

  area:any;


  ngOnInit(): void {
    this.refreshAreaList();
  }

  addClick(){
    this.area={
      id:0,
      name:"",
    };

    this.ModalTitle = "Add Area";
    this.ActivateAddEditArea = true;
  }
  editClick(area:any){
    this.area=area;
    this.ModalTitle = "Edit Area";
    this.ActivateAddEditArea = true;
  };
  deleteClick(area:any){
    if(confirm('Are you sure?')){
      this.service.DeleteArea(area.id).subscribe();
    }
    this.refresh();
  };

  closeClick(){
    this.ActivateAddEditArea = false;
    this.refreshAreaList();
  }

  refreshAreaList(): void{
    this.service.GetAreas().subscribe(data => {
      this.AreaList=data;
    });
  }

  refresh(): void {
    window.location.reload();
}
  
}

import { Component, OnInit } from '@angular/core';
import { Area } from 'src/app/models/Area';
import { SharedService } from 'src/app/shared.service';
import { ToastrService } from 'ngx-toastr';

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

  showArea: any;

  avRating:Number = 0;

  ngOnInit(): void {

    this.refreshAreaList();
    
  }

  addClick(){
    this.showArea={
      id:0,
      name:"",
    };
    this.ModalTitle = "Add Area";
    this.ActivateAddEditArea = true;
  }

  editClick(area:any){
    this.showArea=area;
    this.ModalTitle = "Edit Area";
    this.ActivateAddEditArea = true;
  };

  getAreaAverageRating(id:number){
    this.service.GetAreaAverageRating(id).subscribe(data => {
      this.avRating = data;
    });
  }

  deleteClick(id:Number){
    if(confirm('Are you sure?')){
      this.service.DeleteArea(id).subscribe(() => {
        this.refreshAreaList() 
      });
    }
  };



  closeClick(){
    this.ActivateAddEditArea = false;
    this.refreshAreaList();
  }

  refreshAreaList(){
    this.service.GetAreas().subscribe(res => this.AreaList = res);
    
  }

  refresh(): void {
    window.location.reload();
}
  
}

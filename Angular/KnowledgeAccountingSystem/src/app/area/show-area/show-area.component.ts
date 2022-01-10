import { Component, OnInit } from '@angular/core';
import { Area } from 'src/app/models/Area';
import { SharedService } from 'src/app/shared.service';
import { ToastrService } from 'ngx-toastr';
import { first } from 'rxjs';
import { FullArea } from 'src/app/models/FullArea';

@Component({
  selector: 'app-show-area',
  templateUrl: './show-area.component.html',
  styleUrls: ['./show-area.component.css']
})
export class ShowAreaComponent implements OnInit {

  constructor(private service: SharedService) { }

  AreaList:FullArea[] = [];
  

  ModalTitle:string="";
  ActivateAddEditArea: boolean = false;

  showArea: any;


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

  refreshAreaList(): void {
    this.service.GetFullAreas().pipe(first()).subscribe(data => {
      this.AreaList = data;
    });
 
  }

  refresh(): void {
    window.location.reload();
  }
  
}

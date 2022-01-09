import { Component, OnInit, Input, Renderer2, RendererFactory2} from '@angular/core';
import { SharedService } from 'src/app/shared.service';
import { ShowKnowComponent } from '../show-know/show-know.component';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from "@angular/forms";
import { ShowAreaComponent } from 'src/app/area/show-area/show-area.component';
import { Knowledge } from 'src/app/models/Knowledge';

@Component({
  selector: 'app-add-edit-know',
  templateUrl: './add-edit-know.component.html',
  styleUrls: ['./add-edit-know.component.css']
})
export class AddEditKnowComponent implements OnInit {
  
  knowledgeForm: FormGroup;
  currentUser:string;
  

  constructor(private formBuilder: FormBuilder, private service: SharedService, private comp: ShowKnowComponent) {}
  ngOnInit(): void {
    this.initForm();
    this.service.GetAreas().subscribe(data => {
      this.AllAreas = data;
    });
    this.service.GetUserId().subscribe(data => {
      this.currentUser = data;
    })
    console.log(this.AllAreas);
  }

  private initForm(){
    this.knowledgeForm = this.formBuilder.group({
      Title: ["", Validators.required],
      Description: ["", Validators.required],
      Areas : this.formBuilder.array([this.formBuilder.control("")])
    });
  }

  get Areas(){
    return this.knowledgeForm.get('Areas') as FormArray;
  }

  addArea(){
    this.Areas.push(this.formBuilder.control(''));
  }
  removeArea(index: number){
    this.Areas.removeAt(index);
  }














  @Input() know: any;

  KnowledgeId:number;
  KnowledgeTitle: string;
  KnowledgeDesc: string;
  KnowledgeAreas = [];

  CurrentArea:any;
  CurrentRating:number;

  AllAreas:any[]=[];



  addKnowledge(){
    /*this.KnowledgeAreas.append(this.CurrentArea);
    var val = {
      Title: this.KnowledgeTitle,
      Description: this.KnowledgeDesc,
      Areas: this.KnowledgeAreas
    }
    this.service.AddKnowledge(val).subscribe();
    this.comp.refreshKnowledgeList();*/


    var val = {
      Title: this.knowledgeForm.get('Title')?.value,
      Description: this.knowledgeForm.get('Description')?.value,
      Areas: this.knowledgeForm.get('Areas')?.value,
      UserId: this.currentUser
    }
    let knowledge = new Knowledge();
    console.log(val);
    /*this.service.AddKnowledge(val);*/
    this.comp.refreshKnowledgeList();
    console.log("add");
  }


  updateKnowledge(){
    /*
    var val = {
      Id: this.KnowledgeId,
      Title: this.KnowledgeTitle,
      Description: this.KnowledgeDesc,
      Areas: this.KnowledgeAreas
    }
    this.service.UpdateKnowledge(val).subscribe();
    this.comp.refresh();
      */
     console.log("update");
  }

}

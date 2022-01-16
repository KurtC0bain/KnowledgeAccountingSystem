import { Component, OnInit, Input, Renderer2, RendererFactory2} from '@angular/core';
import { SharedService } from 'src/app/shared.service';
import { ShowKnowComponent } from '../show-know/show-know.component';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from "@angular/forms";
import { Knowledge } from 'src/app/models/Knowledge';
import { Area } from 'src/app/models/Area';

@Component({
  selector: 'app-add-edit-know',
  templateUrl: './add-edit-know.component.html',
  styleUrls: ['./add-edit-know.component.css']
})
export class AddEditKnowComponent implements OnInit {
  
  

  knowledgeForm: FormGroup;
  currentUser:String = "";
  currentId:Number = 0;

  AllAreas:Area[]=[];

  constructor(private formBuilder: FormBuilder, public service: SharedService, private comp: ShowKnowComponent) {
  }
  ngOnInit(): void {
    this.service.GetAreas().subscribe(data => {
      this.AllAreas = data;
    });
    if(this.know.userId !== null){
      this.currentUser = this.know.userId;
    }
    else if(this.know.id !== 0){
      this.currentId = this.know.id;
    }
    this.initForm();
  }

  private initForm(){
    this.knowledgeForm = this.formBuilder.group({
      Id:[this.know.id, Validators.required],
      Title: [this.know.title, Validators.required],
      Description: [this.know.description, Validators.required],
      UserId: [ this.currentUser, Validators.required],
      AreaRating : this.formBuilder.array([this.getAreaItem()])
    });
  }

  get Areas(){
    return this.knowledgeForm.get('AreaRating') as FormArray;
  }


  private getAreaItem(){
    return this.formBuilder.group({
      Name:[],
      Rating:[]
    })
  }

  addArea(){
    this.Areas.push(this.getAreaItem());
  }
  removeArea(index: number){
    this.Areas.removeAt(index);
  }

  

  submit(){
    if(this.know.id === 0){
      this.service.AddKnowledge(this.knowledgeForm.getRawValue()).subscribe();  
    }
    else{
      this.service.UpdateKnowledge(this.knowledgeForm.getRawValue()).subscribe();  
    }

    this.comp.refresh();
  }






  @Input() know: Knowledge;



  KnowledgeId:number;
  KnowledgeTitle: string;
  KnowledgeDesc: string;
  KnowledgeAreas = [];

  CurrentArea:any;
  CurrentRating:number;

}

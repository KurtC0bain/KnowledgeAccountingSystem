import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { KnowledgeComponent } from './knowledge/knowledge.component';
import { ShowKnowComponent } from './knowledge/show-know/show-know.component';
import { AddEditKnowComponent } from './knowledge/add-edit-know/add-edit-know.component';
import { AreaComponent } from './area/area.component';
import { ShowAreaComponent } from './area/show-area/show-area.component';
import { AddEditAreaComponent } from './area/add-edit-area/add-edit-area.component';
import { UserComponent } from './user/user.component';
import { ShowUserComponent } from './user/show-user/show-user.component';
import { AddEditUserComponent } from './user/add-edit-user/add-edit-user.component';
import {SharedService} from './shared.service'

import {HttpClientModule} from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RoleComponent } from './role/role.component';
import { AddEditRoleComponent } from './role/add-edit-role/add-edit-role.component';
import { ShowRoleComponent } from './role/show-role/show-role.component';
import { InfoComponent } from './knowledge/info/info.component';

@NgModule({
  declarations: [
    AppComponent,
    KnowledgeComponent,
    ShowKnowComponent,
    AddEditKnowComponent,
    AreaComponent,
    ShowAreaComponent,
    AddEditAreaComponent,
    UserComponent,
    ShowUserComponent,
    AddEditUserComponent,
    RoleComponent,
    AddEditRoleComponent,
    ShowRoleComponent,
    InfoComponent,
  
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [SharedService],
  bootstrap: [AppComponent]
})
export class AppModule { }
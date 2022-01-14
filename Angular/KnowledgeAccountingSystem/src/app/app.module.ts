import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { NgxMailtoModule } from 'ngx-mailto';

import { MatCardModule } from '@angular/material/card';
import {  MatButtonModule} from '@angular/material/button';
import { MatFormFieldModule} from '@angular/material/form-field';
import { MatInputModule} from '@angular/material/input';
import {MatIconModule} from '@angular/material/icon';

import { JwPaginationComponent } from 'jw-angular-pagination';

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
import { AdminPanelComponent } from './admin-panel/admin-panel.component'

import {SharedService} from './shared.service'
import { AdministrationService } from './administration.service';
import { CookieService } from 'ngx-cookie-service';

import{InfoComponent} from './knowledge/info/info.component'

import {HttpClientModule} from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RoleComponent } from './role/role.component';
import { AddEditRoleComponent } from './role/add-edit-role/add-edit-role.component';
import { ShowRoleComponent } from './role/show-role/show-role.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
import { UserProfileComponent } from './user-profile/user-profile.component';

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
    LoginComponent,
    RegisterComponent,
    ForgotPasswordComponent,
    ResetPasswordComponent,
    UserProfileComponent,
    AdminPanelComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    Ng2SearchPipeModule,
    MatCardModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule,
    NgxMailtoModule
  ],
  providers: [SharedService, ShowAreaComponent, InfoComponent, AdministrationService, CookieService],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { KnowledgeComponent } from './knowledge/knowledge.component';
import { AreaComponent} from './area/area.component';
import { UserComponent } from './user/user.component';
import { RoleComponent } from './role/role.component';
import {LoginComponent} from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { AdminPanelComponent } from './admin-panel/admin-panel.component';


const routes: Routes = [
  {path:'knowledge', component: KnowledgeComponent},
  {path: 'user', component: UserComponent},
  {path: 'role', component: RoleComponent},
  {path: 'area', component: AreaComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'login', component: LoginComponent},
  {path: 'forgotPass', component: ForgotPasswordComponent},
  {path: 'resetPass', component: ResetPasswordComponent},
  {path: 'profile', component: UserProfileComponent},
  {path: 'admin-panel', component: AdminPanelComponent}
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

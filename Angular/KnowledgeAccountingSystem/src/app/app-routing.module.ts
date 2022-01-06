import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { KnowledgeComponent } from './knowledge/knowledge.component';
import { AreaComponent} from './area/area.component';
import { UserComponent } from './user/user.component';
import { RoleComponent } from './role/role.component';
import { InfoComponent } from './knowledge/info/info.component';

const routes: Routes = [
  {path: 'user', component: UserComponent},
  {path: 'role', component: RoleComponent},
  {path: 'knowledge', component: KnowledgeComponent},
  {path: 'area', component: AreaComponent},
  {path: 'knowledge/info', component: InfoComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
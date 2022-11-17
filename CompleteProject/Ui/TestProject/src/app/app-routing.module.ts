import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegisteredListComponent } from './component/registered-list/registered-list.component';
//import { RegistrationComponent } from './component/registration/registration.component';

const routes: Routes = [{path:"",component:RegisteredListComponent}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

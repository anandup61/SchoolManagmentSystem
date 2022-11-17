import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
//import { RegistrationComponent } from './component/registration/registration.component';
import { RegisteredListComponent } from './component/registered-list/registered-list.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import{HttpClientModule} from'@angular/common/http'

@NgModule({
  declarations: [
    AppComponent,
    //RegistrationComponent,
    RegisteredListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,ReactiveFormsModule,
    FormsModule,HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

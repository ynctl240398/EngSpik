import { SharedModule } from './../../shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthenRoutingModule } from './authen-routing.module';
import { AuthenComponent } from './authen.component';


@NgModule({
  declarations: [AuthenComponent],
  imports: [
    CommonModule,
    AuthenRoutingModule,
    SharedModule
  ]
})
export class AuthenModule { }

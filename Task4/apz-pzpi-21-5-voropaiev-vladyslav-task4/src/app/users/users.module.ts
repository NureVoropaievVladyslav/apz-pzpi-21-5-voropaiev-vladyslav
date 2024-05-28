import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserListComponent } from './user-list.component';
import { BrowserModule } from '@angular/platform-browser';



@NgModule({
  declarations: [
    UserListComponent
  ],
  imports: [
    CommonModule,
    BrowserModule
  ]
})
export class UsersModule { }

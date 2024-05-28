import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { NavbarComponent } from './shared/navbar/navbar.component';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { UsersModule } from './users/users.module';
import { AuthModule } from './auth/auth.module';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent
  ],
    imports: [
        CommonModule,
        BrowserModule,
        AppRoutingModule,
        HttpClientModule,
        UsersModule,
        AuthModule
    ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

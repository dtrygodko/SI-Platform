import { NgModule, ErrorHandler } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { IonicApp, IonicModule, IonicErrorHandler } from 'ionic-angular';
import { MyApp } from './app.component';

import { StatusBar } from '@ionic-native/status-bar';
import { SplashScreen } from '@ionic-native/splash-screen';
import {UserService} from "../services/user.service";
import {UsersPage} from "./users/users.component";
import {UserDatailsComponent} from "./users/user-datails/user-datails.component";
import {FormsModule} from "@angular/forms";
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    MyApp,
    UsersPage,
    UserDatailsComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,

    IonicModule.forRoot(MyApp)
  ],
  bootstrap: [IonicApp],
  entryComponents: [
    MyApp,
    UsersPage,
    UserDatailsComponent
  ],
  providers: [
    StatusBar,
    SplashScreen,
    UserService,
    {provide: ErrorHandler, useClass: IonicErrorHandler}
  ]
})
export class AppModule {}

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
import { IdeasService } from '../services/idea.service';
import { IdeaDetailsPage } from './ideas/idea-detail.component';

@NgModule({
  declarations: [
    MyApp,
    UsersPage,
    UserDatailsComponent,
    IdeaDetailsPage
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
    UserDatailsComponent,
    IdeaDetailsPage
  ],
  providers: [
    StatusBar,
    SplashScreen,
    UserService,
    IdeasService,
    {provide: ErrorHandler, useClass: IonicErrorHandler}
  ]
})
export class AppModule {}

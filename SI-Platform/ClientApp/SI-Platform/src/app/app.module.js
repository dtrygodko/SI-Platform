var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { NgModule, ErrorHandler } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { IonicApp, IonicModule, IonicErrorHandler } from 'ionic-angular';
import { MyApp } from './app.component';
import { StatusBar } from '@ionic-native/status-bar';
import { SplashScreen } from '@ionic-native/splash-screen';
import { UserService } from "../services/user.service";
import { UsersPage } from "./users/users.component";
import { UserDatailsComponent } from "./users/user-datails/user-datails.component";
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from '@angular/common/http';
import { IdeasService } from '../services/idea.service';
import { IdeaDetailsPage } from './ideas/idea-detail.component';
import { AddIdeaPage } from './ideas/add-idea/add-idea.component';
import { AddUserPage } from './users/add-user/add-user.component';
var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        NgModule({
            declarations: [
                MyApp,
                UsersPage,
                UserDatailsComponent,
                IdeaDetailsPage,
                AddIdeaPage,
                AddUserPage
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
                IdeaDetailsPage,
                AddIdeaPage,
                AddUserPage
            ],
            providers: [
                StatusBar,
                SplashScreen,
                UserService,
                IdeasService,
                { provide: ErrorHandler, useClass: IonicErrorHandler }
            ]
        })
    ], AppModule);
    return AppModule;
}());
export { AppModule };
//# sourceMappingURL=app.module.js.map
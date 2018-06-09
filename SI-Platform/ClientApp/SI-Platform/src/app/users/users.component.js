var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component } from '@angular/core';
import { NavController, NavParams } from 'ionic-angular';
import { UserService } from "../../services/user.service";
import { UserDatailsComponent } from './user-datails/user-datails.component';
import { AddUserPage } from './add-user/add-user.component';
var UsersPage = /** @class */ (function () {
    function UsersPage(navCtrl, navParams, userService) {
        this.navCtrl = navCtrl;
        this.navParams = navParams;
        this.userService = userService;
        this.pageTitle = "Users List";
        this.allUsers = [];
    }
    UsersPage.prototype.getAllUsers = function () {
        var _this = this;
        this.userService.getUsers().subscribe(function (data) {
            _this.allUsers = data.users;
        });
    };
    UsersPage.prototype.userSelected = function ($event, user) {
        this.navCtrl.push(UserDatailsComponent, user);
    };
    UsersPage.prototype.ionViewDidLoad = function () {
        this.getAllUsers();
    };
    UsersPage.prototype.addUser = function () {
        this.navCtrl.push(AddUserPage);
    };
    UsersPage = __decorate([
        Component({
            selector: 'page-users',
            templateUrl: 'users.component.html',
        }),
        __metadata("design:paramtypes", [NavController, NavParams, UserService])
    ], UsersPage);
    return UsersPage;
}());
export { UsersPage };
//# sourceMappingURL=users.component.js.map
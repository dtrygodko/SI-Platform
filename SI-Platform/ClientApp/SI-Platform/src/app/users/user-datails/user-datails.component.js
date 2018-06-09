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
import { IdeasService } from '../../../services/idea.service';
import { IdeaDetailsPage } from '../../ideas/idea-detail.component';
import { AddIdeaPage } from '../../ideas/add-idea/add-idea.component';
var UserDatailsComponent = /** @class */ (function () {
    function UserDatailsComponent(ideasService, navCtrl, navParams) {
        this.ideasService = ideasService;
        this.navCtrl = navCtrl;
        this.navParams = navParams;
        this.ideas = [];
        this.user = {
            firstName: "1",
            lastName: "1",
            type: "1",
            id: "1",
            city: "1",
            email: "1",
            phone: "1"
        };
    }
    UserDatailsComponent.prototype.getIdeas = function () {
        var _this = this;
        this.ideasService.getIdeas(this.user.id).subscribe(function (data) {
            _this.ideas = data.ideas;
        });
    };
    UserDatailsComponent.prototype.ideaSelected = function ($event, idea) {
        this.navCtrl.push(IdeaDetailsPage, idea);
    };
    UserDatailsComponent.prototype.ionViewDidLoad = function () {
        this.user = this.navParams.data;
        this.getIdeas();
    };
    UserDatailsComponent.prototype.addIdea = function () {
        this.navCtrl.push(AddIdeaPage, this.user.id);
    };
    UserDatailsComponent = __decorate([
        Component({
            selector: 'user-datails',
            templateUrl: 'user-datails.component.html'
        }),
        __metadata("design:paramtypes", [IdeasService, NavController, NavParams])
    ], UserDatailsComponent);
    return UserDatailsComponent;
}());
export { UserDatailsComponent };
//# sourceMappingURL=user-datails.component.js.map
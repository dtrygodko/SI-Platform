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
import { NavParams, NavController } from 'ionic-angular';
import { FundIdeaPage } from './fund-idea/fund-idea.component';
var IdeaDetailsPage = /** @class */ (function () {
    function IdeaDetailsPage(navParams, navCtrl) {
        this.navParams = navParams;
        this.navCtrl = navCtrl;
        this.idea = {
            id: "1",
            description: "1",
            startFundingDate: new Date(),
            stopFundingDate: new Date(),
            status: "1",
            title: "1",
            authorId: "1",
            fullfillment: 0,
            target: 0
        };
    }
    IdeaDetailsPage.prototype.ionViewDidLoad = function () {
        this.idea = this.navParams.data;
    };
    IdeaDetailsPage.prototype.fund = function () {
        this.navCtrl.push(FundIdeaPage, this.idea);
    };
    IdeaDetailsPage = __decorate([
        Component({
            selector: 'page-idea-details',
            templateUrl: 'idea-detail.component.html',
        }),
        __metadata("design:paramtypes", [NavParams, NavController])
    ], IdeaDetailsPage);
    return IdeaDetailsPage;
}());
export { IdeaDetailsPage };
//# sourceMappingURL=idea-detail.component.js.map
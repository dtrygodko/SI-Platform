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
import { FormBuilder } from '@angular/forms';
import { IdeasService } from '../../../services/idea.service';
var FundIdeaPage = /** @class */ (function () {
    function FundIdeaPage(formBuilder, navParams, ideaService, navCtrl) {
        this.formBuilder = formBuilder;
        this.navParams = navParams;
        this.ideaService = ideaService;
        this.navCtrl = navCtrl;
        this.idea = this.formBuilder.group({
            amount: ['']
        });
    }
    FundIdeaPage.prototype.fundIdea = function () {
        var _this = this;
        this.ideaService.fundIdea(this.navParams.data, this.idea.value).subscribe(function () {
            _this.navCtrl.pop();
        });
    };
    FundIdeaPage = __decorate([
        Component({
            templateUrl: 'fund-idea.component.html'
        }),
        __metadata("design:paramtypes", [FormBuilder, NavParams, IdeasService, NavController])
    ], FundIdeaPage);
    return FundIdeaPage;
}());
export { FundIdeaPage };
//# sourceMappingURL=fund-idea.component.js.map
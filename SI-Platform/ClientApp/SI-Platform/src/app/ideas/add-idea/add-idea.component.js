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
var AddIdeaPage = /** @class */ (function () {
    function AddIdeaPage(formBuilder, navParams, ideaService, navCtrl) {
        this.formBuilder = formBuilder;
        this.navParams = navParams;
        this.ideaService = ideaService;
        this.navCtrl = navCtrl;
        this.idea = this.formBuilder.group({
            title: [''],
            description: [''],
            startFundingDate: [''],
            stopFundingDate: ['']
        });
    }
    AddIdeaPage.prototype.addIdea = function () {
        var _this = this;
        this.ideaService.addIdea(this.navParams.data, this.idea.value).subscribe(function (data) {
            _this.navCtrl.pop();
        });
    };
    AddIdeaPage = __decorate([
        Component({
            templateUrl: 'add-idea.component.html'
        }),
        __metadata("design:paramtypes", [FormBuilder, NavParams, IdeasService, NavController])
    ], AddIdeaPage);
    return AddIdeaPage;
}());
export { AddIdeaPage };
//# sourceMappingURL=add-idea.component.js.map
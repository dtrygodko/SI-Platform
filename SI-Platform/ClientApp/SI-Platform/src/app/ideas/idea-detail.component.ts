import {Component} from '@angular/core';
import { NavParams, NavController } from 'ionic-angular';
import { IIdea } from '../../models/idea.model';
import { FundIdeaPage } from './fund-idea/fund-idea.component';

@Component({
  selector: 'page-idea-details',
  templateUrl: 'idea-detail.component.html',
})
export class IdeaDetailsPage {
  idea: IIdea = {
    id: "1",
    description: "1",
    startFundingDate: new Date(),
    stopFundingDate: new Date(),
    status: "1",
    title: "1",
    authorId: "1"
  };

  constructor(private navParams: NavParams, private navCtrl: NavController) {
  }

  ionViewDidLoad() {
    this.idea = this.navParams.data;
  }

  fund() {
    this.navCtrl.push(FundIdeaPage, this.idea);
  }
}

import {Component} from '@angular/core';
import { NavParams } from 'ionic-angular';
import { IIdea } from '../../models/idea.model';

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
    title: "1"
  };

  constructor(private navParams: NavParams) {
  }

  ionViewDidLoad() {
    this.idea = this.navParams.data;
  }
}

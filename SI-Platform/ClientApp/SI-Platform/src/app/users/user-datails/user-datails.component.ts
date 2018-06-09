import { Component } from '@angular/core';
import { IIdea} from '../../../models/idea.model';
import { IUser } from '../../../models/user';
import { NavController, NavParams } from 'ionic-angular';
import { IdeasService } from '../../../services/idea.service';
import { IdeaDetailsPage } from '../../ideas/idea-detail.component';
import { AddIdeaPage } from '../../ideas/add-idea/add-idea.component';

@Component({
  selector: 'user-datails',
  templateUrl: 'user-datails.component.html'
})
export class UserDatailsComponent {
 ideas: IIdea[] = [];
 user: IUser = {
   firstName: "1",
   lastName: "1",
   type: "1",
   id: "1",
   city: "1",
   email: "1",
   phone: "1"
 };

  constructor(public ideasService: IdeasService, public navCtrl: NavController, public navParams: NavParams) {
  }

  getIdeas() {
    this.ideasService.getIdeas(this.user.id).subscribe(data => {
      this.ideas = data.ideas;
    })
  }

  ideaSelected($event, idea) {
    this.navCtrl.push(IdeaDetailsPage, idea);
  }

  ionViewDidEnter() {
    this.user = this.navParams.data;
    this.getIdeas();
  }

  addIdea() {
    this.navCtrl.push(AddIdeaPage, this.user.id);
  }
}

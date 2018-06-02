import { Component } from '@angular/core';
import { Idea } from '../../../models/idea.model';
import {UserService} from "../../../services/user.service";

@Component({
  selector: 'user-datails',
  templateUrl: 'user-datails.component.html'
})
export class UserDatailsComponent {
 ideas = [
    {
      "idea": "1",
    },
   {
     "idea": "2",
   },
   {
     "idea": "3",
   },
  ];

  newIdea: any;
  isIdeas: boolean = false;
  submitted = false;

  constructor(public userService: UserService) {
  }

  onSubmit() { this.submitted = true; }

  showIdeas() {
    this.isIdeas = true;
  }

  addIdea() {
     this.isIdeas = true;
  }

  postIdea() {
    this.userService.addIdea(this.newIdea).subscribe(data => {

    });
  }

  showIdeasDetails() {

  }

}

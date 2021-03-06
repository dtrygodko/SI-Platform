import {Component} from '@angular/core';
import { NavController} from 'ionic-angular';
import {UserService} from "../../services/user.service";
import {IUser} from "../../models/user";
import { UserDetailsPage } from './user-datails/user-datails.component';
import { AddUserPage } from './add-user/add-user.component';


@Component({
  selector: 'page-users',
  templateUrl: 'users.component.html',
})
export class UsersPage {
  pageTitle: string = "Users List";
  allUsers: IUser[] = [];
  constructor(public navCtrl: NavController, private userService: UserService) {
  }

  getAllUsers() {
    this.userService.getUsers().subscribe(data => {
      this.allUsers = data.users;
    })
  }

  userSelected($event, user) {
    this.navCtrl.push(UserDetailsPage, user);
  }

  ionViewDidEnter() {
    this.getAllUsers();
  }

  addUser() {
    this.navCtrl.push(AddUserPage);
  }
}

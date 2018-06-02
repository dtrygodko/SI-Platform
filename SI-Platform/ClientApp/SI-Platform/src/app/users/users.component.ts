import {Component, OnInit} from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';
import {UserService} from "../../services/user.service";



@Component({
  selector: 'page-users',
  templateUrl: 'users.component.html',
})
export class UsersPage implements OnInit{
  allUsers = [
    {
    "name": "Max", "id": "1"
    },
    {
      "name": "Victor", "id": "2"
    },
    {
      "name": "Ibrahim", "id": "3"
    }
  ];
  testUuser: any;
  userDetailsId: any;
  constructor(public navCtrl: NavController, public navParams: NavParams, private userService: UserService) {
  }

  ngOnInit() {
    // this.getAllUSers()
  }

  getAllUSers() {
    this.userService.getUsers().subscribe(data => {
      this.testUuser = data;
      console.log(this.testUuser);
    })
  }
  showDetails(id: any) {
    this.userDetailsId = id;
  }

  ionViewDidLoad() {
    console.log('ionViewDidLoad UsersPage');
  }

}

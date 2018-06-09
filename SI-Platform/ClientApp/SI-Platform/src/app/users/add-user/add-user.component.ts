import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';
import {FormBuilder, FormGroup } from '@angular/forms';
import { UserService } from '../../../services/user.service';
@Component({
    templateUrl: 'add-user.component.html'
})
export class AddUserPage {
  private user : FormGroup;

  constructor( private formBuilder: FormBuilder, private navCtrl: NavController, private userService: UserService) {
    this.user = this.formBuilder.group({
      type: [''],
      firstName: [''],
      lastName: [''],
      password: [''],
      city: [''],
      phone: [''],
      email: ['']
    });
  }

  addUser(){
    this.userService.addUser(this.user.value).subscribe(data => {
        this.navCtrl.pop();
    })
  }
}
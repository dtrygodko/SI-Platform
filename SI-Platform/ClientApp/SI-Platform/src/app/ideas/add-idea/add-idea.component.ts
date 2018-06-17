import { Component } from '@angular/core';
import { NavParams, NavController } from 'ionic-angular';
import {FormBuilder, FormGroup } from '@angular/forms';
import { IdeasService } from '../../../services/idea.service';
@Component({
    templateUrl: 'add-idea.component.html'
})
export class AddIdeaPage {
  private idea : FormGroup;

  constructor( private formBuilder: FormBuilder, private navParams: NavParams, private ideaService: IdeasService, private navCtrl: NavController) {
    this.idea = this.formBuilder.group({
      title: [''],
      description: [''],
      startFundingDate: [''],
      stopFundingDate: [''],
      target: ['']
    });
  }
  addIdea(){
    this.ideaService.addIdea(this.navParams.data, this.idea.value).subscribe(data => {
      this.navCtrl.pop();
    });
  }
}
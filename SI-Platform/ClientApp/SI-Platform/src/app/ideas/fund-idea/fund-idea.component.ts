import { Component } from '@angular/core';
import { NavParams, NavController } from 'ionic-angular';
import {FormBuilder, FormGroup } from '@angular/forms';
import { IdeasService } from '../../../services/idea.service';
@Component({
    templateUrl: 'fund-idea.component.html'
})
export class FundIdeaPage {
  private idea : FormGroup;

  constructor( private formBuilder: FormBuilder, private navParams: NavParams, private ideaService: IdeasService, private navCtrl: NavController) {
    this.idea = this.formBuilder.group({
      amount: ['']
    });
  }
  fundIdea() {
    this.ideaService.fundIdea(this.navParams.data, this.idea.value).subscribe(() => {
      this.navCtrl.pop();
    });
  }
}
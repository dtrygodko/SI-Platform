import { NgModule } from '@angular/core';
import { TranslateModule } from '@ngx-translate/core';
import { IonicPageModule } from 'ionic-angular';

import { UsersListPage } from './users-list';

@NgModule({
  declarations: [
    UsersListPage,
  ],
  imports: [
    IonicPageModule.forChild(UsersListPage),
    TranslateModule.forChild()
  ],
  exports: [
    UsersListPage
  ]
})
export class UsersListPageModule { }

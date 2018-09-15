import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { WinnersListComponent } from 'src/app/winners-list/winners-list.component';
import { SubmitCodeComponent } from 'src/app/submit-code/submit-code.component';

const routes: Routes = [
  {path: 'submit-code', component: SubmitCodeComponent},
  {path: 'winners', component: WinnersListComponent},
  {path: '', component: WinnersListComponent}
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ],
  declarations: []
})
export class AppRoutingModule { }

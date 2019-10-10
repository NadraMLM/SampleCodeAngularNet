import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { ListClientsComponent } from './list-clients/list-clients.component';
import { SaveClientComponent } from './save-client/save-client.component';
import { FormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { DialogComponent } from 'src/app/shared/components/dialog/dialog.component';

@NgModule({
  imports: [
    CommonModule,
    FontAwesomeModule,
    FormsModule,
    SharedModule
  ],
  declarations: [ListClientsComponent, SaveClientComponent],
  entryComponents: [DialogComponent]
})
export class ClientsModule { }

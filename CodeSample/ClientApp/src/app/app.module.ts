import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


import { AppComponent } from './app.component';
import { ListClientsComponent } from './modules/clients/list-clients/list-clients.component';
import { ClientsModule } from './modules/clients/clients.module';
import { SharedModule } from './shared/shared.module';
import { SaveClientComponent } from './modules/clients/save-client/save-client.component';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    ClientsModule,
    SharedModule,
    RouterModule.forRoot([
      {
        path: '', children: [
          { path: '', component: ListClientsComponent, pathMatch: 'full' },
          { path: 'save', component: SaveClientComponent }
        ]
      },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

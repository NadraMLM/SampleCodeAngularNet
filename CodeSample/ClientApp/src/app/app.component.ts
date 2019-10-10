import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';
  tabs: NavTab[] = [{ label: "Home", url: "/" }, { label: "Add new client", url:"/save" }];
}

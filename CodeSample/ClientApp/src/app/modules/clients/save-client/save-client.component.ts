import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ClientService } from 'src/app/core/services/client.service';

@Component({
  selector: 'app-save-client',
  templateUrl: './save-client.component.html',
  styleUrls: ['./save-client.component.css']
})
export class SaveClientComponent implements OnInit  {

  client: FullClient = {
    id: null,
    firstName: null,
    lastName: null,
    email: null
  };
  isRequesting: boolean = false;
  constructor(private route: ActivatedRoute, private router: Router, private clientService: ClientService) {
    var id = this.route.snapshot.params['id'];
    if (id != null) {
      this.clientService.getById(id).subscribe((res: FullClient) => {
        this.client = res;
        console.log(res);
      })
    } 
  }

  ngOnInit() {
  }

  saveClient() {
    this.isRequesting = true;
    this.clientService.save(this.client).subscribe(res => {
      console.log(res);
      this.isRequesting = false;
      this.router.navigate(['/']);

    }, err => {
      console.log(err);
      this.isRequesting = false;
    });
  }

}

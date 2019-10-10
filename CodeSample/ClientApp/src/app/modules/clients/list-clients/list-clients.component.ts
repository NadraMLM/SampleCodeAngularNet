import { Component, OnInit } from '@angular/core';
import { ClientService } from 'src/app/core/services/client.service';
import { faPen, faUserMinus } from '@fortawesome/free-solid-svg-icons';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DialogComponent } from 'src/app/shared/components/dialog/dialog.component';

@Component({
  selector: 'app-list-clients',
  templateUrl: './list-clients.component.html',
  styleUrls: ['./list-clients.component.css']
})
export class ListClientsComponent implements OnInit {

  clients: Client[];
  faPen = faPen;
  faUserMinus = faUserMinus;

  constructor(public dialog: MatDialog, private _snackBar: MatSnackBar, private clientService: ClientService, private route: Router) {
    this.getData();
  }

  ngOnInit() {
  }

  goToSave(id: string) {
    this.route.navigate(['save', { id: id }]);
  }

  confirmDelete(id: string, name: string) {
    const dialogRef = this.dialog.open(DialogComponent, {
      width: '50vw',
      position: { top: '0vh', left:'25vw' },
      data: { question: "Are you sure you want to delete client "+name+"?" }
    });

    dialogRef.beforeClose().subscribe((res: boolean) => {
      if (res) {
        this.clientService.delete(id).subscribe(res => {
          console.log(res);
          this.openSnackBar("Client " + name + " was deleted successfully!", "Ok");
          this.getData();
        })
      }
    });
    dialogRef.afterClosed().subscribe((result:boolean) => {
      console.log('The dialog was closed');      
    });
  }

  getData() {
    this.clientService.get().subscribe((data: Client[]) => {
      this.clients = data;
    })
  }

  openSnackBar(message: string, action: string) {
    this._snackBar.open(message, action, {
      duration: 2000,
    });
  }

}

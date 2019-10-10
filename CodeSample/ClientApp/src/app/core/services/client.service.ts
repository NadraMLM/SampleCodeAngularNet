import { Injectable, Inject } from "@angular/core";
import { HttpClient, HttpHeaders } from '@angular/common/http';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root',
})

export class ClientService {

  clientApiUrl = "";

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.clientApiUrl = baseUrl + "api/Client/";
  }

  get() {
    return this.http.get<Client[]>(this.clientApiUrl+'GetAll', httpOptions);
  }

  getById(id: string) {
    return this.http.get<FullClient>(this.clientApiUrl + 'GetById?id=' + id, httpOptions);
  }

  save(client: FullClient) {
    return this.http.post(this.clientApiUrl + 'Save', client, httpOptions);
  }

  delete(id: string) {
    return this.http.delete(this.clientApiUrl + 'Delete?id='+id, httpOptions);
  }
}

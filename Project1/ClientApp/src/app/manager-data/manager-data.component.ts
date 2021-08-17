import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
@Component({
  selector: 'app-manager-data',
  templateUrl: './manager-data.component.html',
  styleUrls: ['./manager-data.component.css']
})
export class ManagerDataComponent implements OnInit {
  public managerDataset = new MessageData();
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<MessageData>(baseUrl + 'privatedata/managers-data').subscribe(
      result => {
        this.managerDataset.message = result.message;
      },
      error => {
        console.log("managerdata says: " + error)
      }
    );
  }

  ngOnInit() {
  }

}

export class MessageData {
  message: string;
}

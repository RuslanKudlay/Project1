import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
@Component({
  selector: 'app-editor-data',
  templateUrl: './editor-data.component.html',
  styleUrls: ['./editor-data.component.css']
})
export class EditorDataComponent implements OnInit {
  public editorDataset = new MessageData();
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<MessageData>(baseUrl + 'privatedata/editors-data').subscribe(
      result => {
        this.editorDataset = result;
      },
      error => {
        console.log("editordata says: " + error)
      }
    );
  }

  ngOnInit() {
  }

}
export class MessageData {
  message: string;
}

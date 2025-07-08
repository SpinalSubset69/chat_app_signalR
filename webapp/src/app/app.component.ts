import { Component, OnInit } from '@angular/core';
import { ChatHubService } from 'src/shared';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  constructor(private readonly chatHubService: ChatHubService) {}

  ngOnInit(): void {
    this.chatHubService.startConnection();

    this.chatHubService.addOnRoomCreatedListener();
  }

  title = 'webapp';
}

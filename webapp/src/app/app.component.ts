import { Component, OnInit } from '@angular/core';
import {
  Form,
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { ApiResponse, ChatHubService } from 'src/shared';
import { ChatService } from 'src/shared/Services/chat.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  roomName!: FormControl;
  roomCreateForm!: FormGroup;
  constructor(
    private readonly fb: FormBuilder,
    private readonly chatService: ChatService,
    private readonly chatHubService: ChatHubService
  ) {
    this.roomName = new FormControl('', [Validators.required]);
    this.roomCreateForm = fb.group({
      roomName: this.roomName,
    });
  }

  ngOnInit(): void {
    this.chatHubService.startConnection();

    this.chatHubService.addOnRoomCreatedListener();
  }

  title = 'webapp';

  createRoom() {
    if (this.roomCreateForm.invalid) return;

    this.chatService
      .createChat(this.roomCreateForm.get('roomName')?.value)
      .subscribe((response: ApiResponse<string>) => {
        this.roomCreateForm.reset();
        console.log('Room created!!, Connection ID:' + response.data);
        this.chatHubService.sendRoomCreatedNotification(response.data);
      });
  }
}

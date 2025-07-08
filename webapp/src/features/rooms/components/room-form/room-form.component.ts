import { Component } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { ApiResponse, ChatHubService } from 'src/shared';
import { ChatService } from 'src/shared/Services/chat.service';

@Component({
  selector: 'room-form',
  templateUrl: './room-form.component.html',
})
export class RoomFormComponent {
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

  createRoom() {
    if (this.roomCreateForm.invalid) return;

    this.chatService
      .createChat(this.roomCreateForm.get('roomName')?.value)
      .subscribe((response: ApiResponse<string>) => {
        this.roomCreateForm.reset();
        this.chatHubService.sendRoomCreatedNotification(response.data);
      });
  }
}

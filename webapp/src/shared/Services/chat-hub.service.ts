import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { Room } from '../models';

@Injectable({
  providedIn: 'root',
})
export class ChatHubService {
  private connectionHub!: signalR.HubConnection;

  startConnection() {
    this.connectionHub = new signalR.HubConnectionBuilder()
      .withUrl('http://localhost:5000/chat-hub')
      .build();

    this.connectionHub
      .start()
      .then(() => console.log('Connection started'))
      .catch((err) => console.log('Error connecting' + err));
  }

  addOnRoomCreatedListener() {
    this.connectionHub.on('RoomCreated', (room: Room) => {
      console.log('Room Added', room);
    });
  }

  sendRoomCreatedNotification(connectionId: string){
    this.connectionHub
    .invoke('RoomCreated', connectionId)
    .then(() => console.log('Notification room created done'))
    .catch((err) => console.log('Error while notification room created' + err))
  }
}

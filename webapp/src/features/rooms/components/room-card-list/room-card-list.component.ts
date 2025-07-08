import { Component, Input } from '@angular/core';
import { Room } from 'src/shared';

@Component({
  selector: 'room-card-list',
  templateUrl: './room-card-list.component.html',
})
export class RoomCardListComponent {
  @Input() rooms: Array<Room> = [
    {
      id: '',
      roomName: 'Room test!',
      totalUsers: 10,
    },
    {
      id: '',
      roomName: 'Room test!',
      totalUsers: 10,
    },
    {
      id: '',
      roomName: 'Room test!',
      totalUsers: 10,
    },
    {
      id: '',
      roomName: 'Room test!',
      totalUsers: 10,
    },
    {
      id: '',
      roomName: 'Room test!',
      totalUsers: 10,
    },
    {
      id: '',
      roomName: 'Room test!',
      totalUsers: 10,
    },
    {
      id: '',
      roomName: 'Room test!',
      totalUsers: 10,
    },
    {
      id: '',
      roomName: 'Room test!',
      totalUsers: 10,
    },
    {
      id: '',
      roomName: 'Room test!',
      totalUsers: 10,
    },
    {
      id: '',
      roomName: 'Room test!',
      totalUsers: 10,
    },
    {
      id: '',
      roomName: 'Room test!',
      totalUsers: 10,
    },
    {
      id: '',
      roomName: 'Room test!',
      totalUsers: 10,
    },
  ];
}

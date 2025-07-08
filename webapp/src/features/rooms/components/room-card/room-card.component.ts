import { Component, Input } from '@angular/core';
import { Room } from 'src/shared';

@Component({
  selector: 'room-card',
  templateUrl: './room-card.component.html',
})
export class RoomCardComponent {
  @Input({ required: true }) room: Room = {} as Room;
}

import { NgModule } from '@angular/core';
import {
  RoomCardComponent,
  RoomCardListComponent,
  RoomFormComponent,
} from './components';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { SharedModule } from "../../shared/shared.module";

@NgModule({
  declarations: [RoomCardComponent, RoomCardListComponent, RoomFormComponent],
  imports: [FormsModule, ReactiveFormsModule, CommonModule, SharedModule],
  exports: [RoomCardListComponent, RoomFormComponent],
})
export class RoomsModule {}

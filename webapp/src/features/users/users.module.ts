import { NgModule } from '@angular/core';
import { UserFormComponent } from './components';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [UserFormComponent],
  imports: [FormsModule, ReactiveFormsModule],
  exports: [UserFormComponent],
})
export class UsersModule {}

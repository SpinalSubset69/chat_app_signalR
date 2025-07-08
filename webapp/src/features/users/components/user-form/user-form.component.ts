import { Component } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { User, UsersService } from 'src/shared';
import { Guid } from 'guid-typescript';

@Component({
  selector: 'user-form',
  templateUrl: './user-form.component.html',
})
export class UserFormComponent {
  formGroup!: FormGroup;
  userName!: FormControl;

  constructor(
    private readonly fb: FormBuilder,
    private readonly userService: UsersService
  ) {
    this.userName = new FormControl('', [Validators.required]);
    this.formGroup = fb.group({
      userName: this.userName,
    });
  }

  onCreateUser() {
    if (this.formGroup.invalid) return;
    const userName = this.formGroup.get('userName')?.value;
    const guid = Guid.create().toString()
    this.userService.setUser({ userName: userName, id: guid } as User);
  }
}

import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from 'src/shared/models';
import { UsersService } from 'src/shared/Services';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
})
export class NavbarComponent {
  user$: Observable<User>;

  constructor(private readonly userService: UsersService) {
    this.user$ = userService.getUserAsObservable();
  }
}

import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { User, UsersService } from 'src/shared';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
})
export class DashboardComponent {
  user$: Observable<User>;
  constructor(private readonly userService: UsersService) {
    this.user$ = userService.getUserAsObservable();
  }
}

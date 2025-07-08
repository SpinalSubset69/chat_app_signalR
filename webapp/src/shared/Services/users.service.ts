import { Injectable } from '@angular/core';
import { User } from '../models';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UsersService {
  USER_KEY = 'USER';

  user$!: BehaviorSubject<User>;
  constructor() {
    this.user$ = new BehaviorSubject(
      this.getUserFromSessionStorage() ?? ({} as User)
    );
  }

  getUserFromSessionStorage(): User | null {
    const user = sessionStorage.getItem(this.USER_KEY);

    if (!user) return null;

    return JSON.parse(user) as User;
  }

  saveUserInSessionStorage(user: User) {
    sessionStorage.setItem(this.USER_KEY, JSON.stringify(user));
  }

  setUser(user: User) {
    // IF NO USER IN SESSION, SAVE IT

    if (!this.getUserFromSessionStorage()) this.saveUserInSessionStorage(user);

    this.user$.next(user);
  }

  getUserAsObservable(): Observable<User> {
    return this.user$.asObservable();
  }
}

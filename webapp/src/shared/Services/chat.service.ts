import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResponse } from '../models';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class ChatService {
  constructor(private readonly _http: HttpClient) {}

  createChat(roomName: string): Observable<ApiResponse<string>> {
    return this._http.post<ApiResponse<string>>(
      'http://localhost:5000/api/rooms',
      {
        roomName,
      }
    );
  }
}

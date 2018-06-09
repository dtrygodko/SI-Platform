import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs/Observable";
import 'rxjs/add/operator/map';
import "rxjs/add/operator/do";
import {IUser, IUsersList} from "../models/user";

@Injectable()
export class UserService {

  constructor(public http: HttpClient) {
  }

  getUsers(): Observable<IUsersList> {
    return this.http.get<IUsersList>('http://localhost:52952/api/users');
  }

  getUser(id: string) : Observable<IUser> {
    return this.http.get<IUser>(`http://localhost:52952/api/users/${id}`);
  }

  addUser(user) : Observable<any> {
    return this.http.post('http://localhost:52952/api/users', user);
  }
}

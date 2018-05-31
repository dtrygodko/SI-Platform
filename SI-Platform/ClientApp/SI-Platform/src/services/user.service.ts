import {Injectable, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs/Observable";
import 'rxjs/add/operator/map';

@Injectable()
export class UserService implements OnInit {

  constructor(public http: HttpClient) {
  }

  ngOnInit() {
  }


  getUsers(): Observable<any> {
    return this.http.get('/api/users')
      .map((res: Response) => {
        return res;
      })
  }

  addUser(user: any): Observable<any> {
    return this.http.post('/api/addUser', {username: user.username, password: user.password})
      .map((res: Response) => {
        return res;
      })
  }


}

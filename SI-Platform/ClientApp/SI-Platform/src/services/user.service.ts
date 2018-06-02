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
    return this.http.get('localhost:4200/api/users')
      .map((res: Response) => {
        return res;
      })
  }

  addIdea(idea: any) {
    return this.http.post('localhost:4200/api/addIdea', {ideaSomething: idea.something})
      .map((res: Response) => {
        return res;
      })
  }


}

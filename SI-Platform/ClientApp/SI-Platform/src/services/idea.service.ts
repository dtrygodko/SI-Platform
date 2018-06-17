import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs/Observable";
import {IIdeasList, IIdea} from "../models/idea.model";

@Injectable()
export class IdeasService {

  constructor(private http: HttpClient) {
  }

  getIdeas(authorId: string): Observable<IIdeasList> {
    return this.http.get<IIdeasList>(`http://localhost:52952/api/users/${authorId}/ideas`);
  }

  getIdea(authorId: string, id: string) : Observable<IIdea> {
    return this.http.get<IIdea>(`http://localhost:52952/api/users/${authorId}/ideas/${id}`);
  }

  addIdea(authorId: string, idea) : Observable<any> {
    return this.http.post(`http://localhost:52952/api/users/${authorId}/ideas`, idea);
  }

  fundIdea(idea: IIdea, amount) : Observable<any> {
    return this.http.put(`http://localhost:52952/api/users/${idea.authorId}/ideas/${idea.id}`, amount);
  }
}

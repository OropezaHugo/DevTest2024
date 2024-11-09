import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {PollModel} from './poll.model';
import {NewPollModel} from './new-poll.model';

@Injectable({providedIn: 'root'})
export class PollsService {
  constructor(private httpClient: HttpClient) {}


  getPollsData() {
    return this.httpClient.get<PollModel[]>('http://localhost:5296/api/v1/Polls')
  }

  postNewPoll(poll: NewPollModel){
    return this.httpClient.post<PollModel>('http://localhost:5296/api/v1/Polls', poll)
  }
}

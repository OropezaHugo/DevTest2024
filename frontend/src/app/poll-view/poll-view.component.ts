import {Component, input, OnInit} from '@angular/core';
import {PollModel} from '../shared/poll.model';
import {MatButton} from '@angular/material/button';

@Component({
  selector: 'app-poll-view',
  standalone: true,
  imports: [
    MatButton
  ],
  templateUrl: './poll-view.component.html',
  styleUrl: './poll-view.component.scss'
})
export class PollViewComponent implements OnInit {
  pollData = input.required<PollModel>()
  totalVotes: number = 0;
  ngOnInit() {
    for (let option of this.pollData().options){
      this.totalVotes += option.votes
    }

  }
}

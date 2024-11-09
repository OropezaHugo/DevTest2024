import {Component, inject, OnInit} from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {MatButton} from '@angular/material/button';
import {PollsService} from './shared/polls.service';
import {PollModel} from './shared/poll.model';
import {PollViewComponent} from './poll-view/poll-view.component';
import {MatDialog} from '@angular/material/dialog';
import {NewPollDialogComponent} from './new-poll-dialog/new-poll-dialog.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, MatButton, PollViewComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit{
  pollsService = inject(PollsService)
  polls: PollModel[] = []
  readonly dialog = inject(MatDialog);

  ngOnInit() {
    this.pollsService.getPollsData().subscribe(
      res => {
        this.polls = res
      }
    )
  }

  openDialog(){
    this.dialog.open(NewPollDialogComponent, {
      data: "new poll"
    }).afterClosed().subscribe( res => {
      this.pollsService.postNewPoll(res).subscribe()
    })
  }
}

import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import Pusher from 'pusher-js';
import { User } from '../models/user';


interface ChatMessage {
  username: string;
  message: string;
}
@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss']
})
export class ChatComponent implements OnInit {
  user?: User
  message = '';
  messages: ChatMessage[] = [];
  username = this.user?.displayName

  constructor(private http: HttpClient) {

  }

  ngOnInit(): void {
    Pusher.logToConsole = true;

    const pusher = new Pusher('3cb19a1bd9a88a188c23', {
      cluster: 'sa1'
    });

    const channel = pusher.subscribe('chat');
    channel.bind('message', (data: ChatMessage) => {
      this.messages.push(data);
    });
  }

  submit(): void {
    this.http.post('https://localhost:5001/api/messages', {
      username: this.username,
      message: this.message
    }).subscribe(() => this.message = '');
  }

}

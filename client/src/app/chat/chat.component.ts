import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import Pusher from 'pusher-js';
import { User } from '../models/user';
import { jwtDecode } from 'jwt-decode';

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
  user?: User;
  message = '';
  messages: ChatMessage[] = [];
  username = '';
  static pusher: any;
  channel: any;
  channels: string[] = [];

  constructor(private http: HttpClient) {

    if (!ChatComponent.pusher) {
      Pusher.logToConsole = true;
      ChatComponent.pusher = new Pusher('3cb19a1bd9a88a188c23', {
        cluster: 'sa1'
      });
    }
  }

  ngOnInit(): void {
    const token = localStorage.getItem('token');

    if (token) {
      const decodedToken: any = jwtDecode(token);

      this.username = decodedToken.given_name;
    } else {
      this.username = ''
    }

    this.channel = this.getOrCreateChannel(`suporte-${this.username}`);
    this.channel.bind('message', (data: ChatMessage) => {
      this.messages.push(data);
    });
  }

  submit(): void {

    const trimmedMessage = this.message.trim();
    const trimmedUsername = this.username.trim();

    this.createNewChannel();

    if (trimmedMessage !== '' && trimmedUsername !== '') {
      this.http.post('https://localhost:5001/api/messages', {
        username: this.username,
        message: this.message
      }).subscribe(() => (this.message = ''));
    }
  }

  private channelCreated(channelName: string): boolean {
    return this.channels.includes(channelName);
  }

  private createNewChannel(): void {
    const channelName = `suporte-${this.username}`;

    if (!this.channelCreated(channelName)) {
      this.channel = this.getOrCreateChannel(channelName);
      this.channels.push(channelName);
      console.log(`Canal ${channelName} criado e pronto para mensagens.`);
    }
  }

  private getOrCreateChannel(channelName: string): any {
    return ChatComponent.pusher.subscribe(channelName);
  }
}

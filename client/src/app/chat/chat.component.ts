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
  user?: User;
  message = '';
  messages: ChatMessage[] = [];
  username = '';
  channels: string[] = [];

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    Pusher.logToConsole = true;

    const pusher = new Pusher('3cb19a1bd9a88a188c23', {
      cluster: 'sa1'
    });


    const channel = pusher.subscribe(`suporte-${this.username}`);
    channel.bind('message', (data: ChatMessage) => {
      this.messages.push(data);
    });

    this.createNewChannel();
  }

  submit(): void {
    const trimmedMessage = this.message.trim();
    const trimmedUsername = this.username.trim();

    if (trimmedMessage !== '' && trimmedUsername !== '') {
      
      if (!this.channelCreated()) {
        this.createNewChannel();
      }

      
      this.http.post('https://localhost:5001/api/messages', {
        username: this.username,
        message: this.message
      }).subscribe(() => (this.message = ''));
    }
  }

  private channelCreated(): boolean {
    
    const channelName = `suporte-${this.username}`;
    return this.channels.includes(channelName);
  }

  private createNewChannel(): void {
    
    const channelName = `suporte-${this.username}`;

   
    const pusher = new Pusher('3cb19a1bd9a88a188c23', {
      cluster: 'sa1'
    });

    const channel = pusher.subscribe(channelName);
    channel.bind('message', (data: ChatMessage) => {
      this.messages.push(data);
    });

    
    this.channels.push(channelName);

    console.log(`Canal ${channelName} criado e pronto para mensagens.`);
  }
}
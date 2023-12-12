import { Component } from '@angular/core';


interface ChatMessage {
  username: string;
  message: string;
}
@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss']
})
export class ChatComponent {
  username = 'username';
  message = '';
  messages: ChatMessage[] = [];

  submit(): void {

  }

}

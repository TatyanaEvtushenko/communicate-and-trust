import { Component, Input } from '@angular/core';
import { Message } from "../../models/dialog/message";

@Component({
  selector: 'message-list',
  templateUrl: './message-list.component.html',
  styleUrls: ['./message-list.component.css']
})
export class MessageListComponent {
  @Input() messages: Message[];
}

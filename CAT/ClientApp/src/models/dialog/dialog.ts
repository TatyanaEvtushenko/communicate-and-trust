import { Message } from "./message";

export class Dialog {
  public isOnline: boolean;
  public name: string;
  public avatar: string;
  public messages: Message[];
}

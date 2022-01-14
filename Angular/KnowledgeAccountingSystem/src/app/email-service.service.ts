import { Injectable } from '@angular/core';
import { Mailto, NgxMailtoService } from 'ngx-mailto';


@Injectable({
  providedIn: 'root'
})
export class EmailService {

  constructor(private mailtoService: NgxMailtoService) { }

  userFullName:string = "";
  managerFullName:string = "";
  knowledgeTitle: string = "";

  mailto: Mailto = {
    receiver: "",
    subject: undefined,
    body: undefined
  };

  sendMail(): void {
    this.mailto.subject = "Report from KAS";
    this.mailto.body = "Hello, " + this.userFullName + "! We have reviewed your knowledge with title: '" + this.knowledgeTitle + "' and want to say some words about that.\n\n\n*Tap Text Here*\n\n\n Best regards, " + this.managerFullName + "\n\n";
    this.mailtoService.open(this.mailto);
  }

}

import { Component } from '@angular/core';
import { AddstudentsService } from './addstudents.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  providers:[AddstudentsService]
})
export class AppComponent {
  title = 'students';
}
  

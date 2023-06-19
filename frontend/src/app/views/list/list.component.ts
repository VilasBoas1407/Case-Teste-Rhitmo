import { Component } from '@angular/core';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css', '../../app.component.css'],
})
export class ListComponent {
  search_name = '';
}

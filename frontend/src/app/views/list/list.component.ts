import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css', '../../app.component.css'],
})
export class ListComponent {
  constructor(public route: Router) {}

  search_name = '';
}

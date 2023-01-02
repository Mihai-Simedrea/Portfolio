import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-card-holder',
  templateUrl: './card-holder.component.html',
  styleUrls: ['./card-holder.component.scss'],
})
export class CardHolderComponent implements OnInit {
  @Input() title: string = '';
  @Input() animation: string = '';

  constructor() {}

  ngOnInit(): void {}
}

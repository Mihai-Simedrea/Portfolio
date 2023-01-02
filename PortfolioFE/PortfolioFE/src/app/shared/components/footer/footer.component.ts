import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss'],
})
export class FooterComponent implements OnInit {
  facebookUrl = 'https://www.facebook.com/mihainicolae.simedrea/';
  instagramUrl = 'https://www.instagram.com/mihai_simedrea/';
  linkedinUrl = 'https://www.linkedin.com/in/mihai-simedrea-80522421a/';

  constructor() {}

  ngOnInit(): void {}
}

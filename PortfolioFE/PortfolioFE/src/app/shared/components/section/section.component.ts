import { Component, Input, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-section',
  templateUrl: './section.component.html',
  styleUrls: ['./section.component.scss'],
})
export class SectionComponent implements OnInit {
  quote =
    '"Ambition fuels hope in the face of dismay, leading us towards utopia."';
  @Input() showImage = false;
  @Input() title = '';
  @Input() sectionTitle = '';
  @Input() sectionSubtitle = '';
  @Input() sectionDescription = '';
  @Input() url = '';
  @Input() isVideo = false;

  constructor(private sanitizer: DomSanitizer) {
    this.sanitizer = sanitizer;
  }

  ngOnInit(): void {}

  getUrl() {
    return this.sanitizer.bypassSecurityTrustResourceUrl(this.url);
  }
}

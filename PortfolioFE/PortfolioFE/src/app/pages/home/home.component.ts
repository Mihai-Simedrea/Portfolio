import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  quote =
    '"Ambition fuels hope in the face of dismay, leading us towards utopia."';

  titles = [
    'The Mystery of the Self',
    'The Ambition Algorithm',
    'From Utopian Dreams to AI Reality: The Journey Ahead',
    'Embracing the Dismay of Uncertainty',
  ];
  sections = {
    titles: ['Mihai Simedrea', 'test'],
    subtitles: ['CEO of Simedrea Industries', 'quote'],
    description: [
      `Good evening, everyone. I'm glad you could join me today for this
    presentation on the mystery of the self. Have you ever stopped to think
    about who you really are? Have you ever wondered what makes you, you?
    These are questions that have fascinated philosophers and scientists for
    centuries, and they continue to be at the heart of the mystery of the
    self. In this presentation, we will explore the concept of the self and
    how it shapes our lives. We will discuss different methods for discovering
    and understanding the self, and we will talk about the importance of
    self-acceptance and self-love. But before we dive into these topics, let's
    start by defining the self. The self is a complex and multifaceted
    concept. It includes our thoughts, feelings, behaviors, and relationships
    with others. Our sense of self is shaped by our experiences, our beliefs,
    and the people we interact with. There are many different theories about
    the self, such as the social identity theory, the self-perception theory,
    and the self-esteem theory. These theories help us to understand how we
    form our sense of self and how it influences our behavior. Now that we
    have a basic understanding of the self, let's move on to the topic of
    self-discovery.`,
      'something2',
    ],
  };

  imageUrl = `https://scontent.fomr1-1.fna.fbcdn.net/v/t1.6435-9/172875203_1610895769105633_5707496466293632507_n.jpg?_nc_cat=102&ccb=1-7&_nc_sid=09cbfe&_nc_eui2=AeHzRpkETadBr-puV28Q7iUg1Q2W3izxs_PVDZbeLPGz81GF2HSlZdnE3a8jXe3DB6s9IJKNuBbjHNwzPlR9_8iH&_nc_ohc=NWqkQH7VuQIAX-4kDqH&_nc_ht=scontent.fomr1-1.fna&oh=00_AfC3MGUpWPdYjce4uegSZpZfschmHoGNFkkH5pSBImcrDw&oe=63D987F8`;
  videoUrl = `https://www.youtube.com/embed/pio6C9tL2SU`;

  constructor() {}

  ngOnInit(): void {}

  scroll(el: HTMLElement) {
    el.scrollIntoView({ behavior: 'smooth', block: 'center' });
  }
}

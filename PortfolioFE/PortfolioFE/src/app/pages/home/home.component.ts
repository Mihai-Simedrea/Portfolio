import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  quote =
    '"Ambition fuels hope in the face of dismay, leading us towards utopia."';

  titles = ['The Mystery of the Self', 'The Ambition Algorithm'];
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

  constructor() {}

  ngOnInit(): void {}
}

import { Component, OnInit } from '@angular/core';
import { AuthUserService } from '../services/auth-user.service';

@Component({
  selector: 'app-analytics',
  templateUrl: './analytics.component.html',
  styleUrls: ['./analytics.component.css']
})
export class AnalyticsComponent implements OnInit {
  trendingHashTag: string;
  personWithMostTweet:string;
  
  constructor(private api: AuthUserService) {

  }
  analytics(){
    this.getMostTrendingHashtag();
    this.getMostTweetedPerson();
  }
  
  getMostTrendingHashtag() {
    this.api.getTrendingHastag()
      .subscribe((response) => {
        this.trendingHashTag = JSON.stringify(response);
      }, error => {
        console.log("Unable to get the trending hashtag.")
      });
  }
  getMostTweetedPerson(){
    this.api.getMostTweetedPerson()
      .subscribe((response) => {
        this.personWithMostTweet = JSON.stringify(response);
      }, error => {
        console.log("Unable to get the most tweeted person.")
      });
  }

  ngOnInit() {
    this.analytics();
  }

}

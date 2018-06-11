import { Component, OnInit, Input } from '@angular/core';
import { AuthUserService } from '../services/auth-user.service';
import { Tweet } from '../utils/tweets'
@Component({
  selector: 'app-playground',
  templateUrl: './playground.component.html',
  styleUrls: ['./playground.component.css']
})
export class PlaygroundComponent implements OnInit {
  tweets: Tweet[];
  TweetContent:string;
  currentUser:string;
  imageSource:string = "assets/images/default.png";
  constructor(private api: AuthUserService) {
    this.currentUser = localStorage.getItem("uid");
   }
  getUserTweet() {
    this.api.getUserTweets(this.currentUser)
      .subscribe(data => {
        this.tweets = data;
        console.log(this.tweets);
      })
  }
  newTweet() {
    let data = {
      "TweetContent": this.TweetContent,
      "email":""
    }
    this.api.newUserTweet(data)
      .subscribe((response) => {
        this.tweets.unshift(response);
      })
  }
  ngOnInit() {
    this.getUserTweet()
  }

}

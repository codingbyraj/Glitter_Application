import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { serializeObj } from '../utils/serialize'
import "rxjs/add/observable/throw";
import "rxjs/add/operator/catch";
import "rxjs/add/operator/do";
import { Route } from '@angular/router';
import {httpOptions} from '../utils/httpoptions';

@Injectable()
export class AuthUserService {
  TWEET_URL: string;
  FOLLOWERS_URL: string;
  FOLLOWINGS_URL: string;
  TWEETADD_URL: string;
  constructor(private http: HttpClient) {
  }

  getUserTweets(uid): Observable<any> {
      this.TWEET_URL = "http://localhost:52905/api/users/" + uid + "/tweets";
      return this.http.get<any>(this.TWEET_URL)
        .catch(this.handleError);        
  }

  getUserFollowings(uid) {
      this.FOLLOWINGS_URL = "http://localhost:52905/api/users/" + uid + "/getfollowingscount";
      return this.http.get<any>(this.FOLLOWINGS_URL)
        .catch(this.handleError);
  }

  getUserFollowers(uid) {        
      this.FOLLOWERS_URL = "http://localhost:52905/api/users/" + uid + "/getfollowerscount";
      return this.http.get<any>(this.FOLLOWERS_URL)
        .catch(this.handleError);    
  }

  newUserTweet(data): Observable<any> {
    let uid = localStorage.getItem("uid");
    if (uid) {
      data.email = uid;
      this.TWEETADD_URL = "http://localhost:52905/api/tweets/addtweet"
      let body = JSON.stringify(data);
      return this.http.post(this.TWEETADD_URL, body, httpOptions);
    }
  }

  getFollowersDetails(uid) {
    return this.http.get("http://localhost:52905/api/users/" + uid + "/followers")
      .catch(this.handleError)
  }
  getFollowingsDetails(uid) {
    return this.http.get("http://localhost:52905/api/users/" + uid + "/followings")
      .catch(this.handleError)
  }

  unFollow(currentUser, userId){
    let data = JSON.stringify({
      "FollowingId": userId,
      "Email": currentUser
    });
    return this.http.post("http://localhost:52905/api/follows/unfollow", data, httpOptions);
  }
  getTrendingHastag(){
    return this.http.get('http://localhost:52905/api/tweets/gettrendinghashtag');
  }
  getMostTweetedPerson(){
    return this.http.get('http://localhost:52905/api/users/getmaxtweetuser');
  }
  private handleError(err: HttpErrorResponse) {
    console.error(err.message);
    return Observable.throw(err.message);
  }
}
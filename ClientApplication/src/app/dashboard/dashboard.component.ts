import { Component, OnInit } from '@angular/core';
import { AuthUserService } from '../services/auth-user.service';
import { Route } from '@angular/compiler/src/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  followers: number;
  followings: number;
  TweetContent: string;
  email: string;
  currentUser:string;
  constructor(private api: AuthUserService, private router:Router) {     
    this.currentUser = localStorage.getItem("uid");
    console.log("dashboard called")
  }

  getFollowers() {
    if(this.currentUser){
    this.api.getUserFollowers(this.currentUser)
      .subscribe(data => {
        this.followers = data;
      })
  }
  else{
    alert("You are not logged in...");
  }
}

  getFollowings() {
    if(this.currentUser){
      this.api.getUserFollowings(this.currentUser)
      .subscribe(data => {
        this.followings = data;
      })
    }
    else{
      alert("You are not logged in...")
    }    
  }

  logout() {
    localStorage.removeItem("uid");
    localStorage.removeItem("access_token");
    alert("Successfully Logout");
    this.router.navigate(['login']);
  }

  ngOnInit() {
    this.getFollowers();
    this.getFollowings();
  }
}

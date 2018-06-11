import { Component, OnInit } from '@angular/core';
import { AuthUserService } from '../services/auth-user.service';
import { SearchService } from '../services/search.service';

@Component({
  selector: 'app-followers',
  templateUrl: './followers.component.html',
  styleUrls: ['./followers.component.css']
})
export class FollowersComponent implements OnInit {
  followers:object;
  currentUser:string;  
  imageSource:string;
  constructor(private api:AuthUserService, private searchApi: SearchService) {
    this.currentUser = localStorage.getItem("uid");
    this.imageSource = "assets/images/default.png";
   }

  getFollowersDetails(){
    this.api.getFollowersDetails(this.currentUser)
    .subscribe(response=>{
      this.followers = response;
      console.log(this.followers);
    },err=>{
      console.log(err);
    })
  }

  addFollowing(email){
    if (this.currentUser) {
      this.searchApi.addFollowing(email, this.currentUser)
        .subscribe(response => {
          console.log("follow");
        })
    }
  }
  ngOnInit() {
    this.getFollowersDetails();
  }

}

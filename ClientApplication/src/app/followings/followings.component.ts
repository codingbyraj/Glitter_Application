import { Component, OnInit } from '@angular/core';
import { AuthUserService } from '../services/auth-user.service';

@Component({
  selector: 'app-followings',
  templateUrl: './followings.component.html',
  styleUrls: ['./followings.component.css']
})
export class FollowingsComponent implements OnInit {
  followings:object;
  currentUser:string;  
  imageSource:string;
  constructor(private api:AuthUserService) {
    this.currentUser = localStorage.getItem("uid");
    this.imageSource = "assets/images/default.png";
   }
  getFollowingsDetails(){
    this.api.getFollowingsDetails(this.currentUser)
    .subscribe(response=>{
      this.followings = response;      
      console.log(this.followings);
    },err=>{
      console.log(err);
    })
  }

  unFollowUser(userId){
    this.api.unFollow(this.currentUser, userId)
    .subscribe(response=>{

    })
  }

  ngOnInit() {
    this.getFollowingsDetails();
  }

}

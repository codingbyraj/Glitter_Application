import { Component, OnInit } from '@angular/core';
import { UsersService } from '../services/users.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})

export class RegisterComponent implements OnInit {
  email: string = "rikit@gmail.com";
  password: string = "Ritik@123";
  confirmPassword: string = "Ritik@123";
  contactNumber: string = "1234567890";
  country: string = "USA";
  profileImage: File;
  name: string = "Ritik Roushan";
  constructor(private api: UsersService, private router: Router) { }

  doRegister() {
    let userData = {
      "email": this.email,
      "password": this.password,
      "confirmpassword": this.confirmPassword
    };

    let userDetails = {
      "Email": this.email,
      "Name": this.name,
      "Country": this.country,
      "ProfileImage": this.profileImage.name,
      "ContactNumber": this.contactNumber
    };

    if (!this.isValid()) {
      alert("Oops!, All Fields are mandatory")
    }
    else {
      this.api.saveUsersInformation(userDetails)
        .subscribe((response) => {
          this.clearAll();
          alert("Hey! Your are successfully registered.");
          this.router.navigate(['login']);
        },
          err => {
            alert("Validation Error! Fill all fields carefully.");
            return;
          });

      this.api.register(userData)
        .subscribe((response) => {
        },
          err => {
            alert("Validation Error! You are is alreay registered");
            return;
          });
    }

  }

  clearAll() {
    this.email = "";
    this.password = "";
    this.confirmPassword = "";
    this.contactNumber = "";
    this.country = "";
    this.profileImage = null;
    this.name = "";
  }

  public uploadFile($event) {
    console.log("upload file");
    this.profileImage = $event.target.files[0];
    console.log(this.profileImage)
  }


  redirectToLogin() {
    console.log("clicked")
    this.router.navigate(['login']);
  }

  isValid(): boolean {
    if (this.name  &&  this.email  &&  this.contactNumber  &&  this.country  &&  this.password  &&  this.confirmPassword) {
      return  true;
    }
    else {
      return  false;
    }
  }
  ngOnInit() {
  }
}
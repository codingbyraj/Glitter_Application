import { Component, OnInit } from '@angular/core';
import { SearchService } from '../services/search.service';

@Component({
  selector: 'app-people',
  templateUrl: './people.component.html',
  styleUrls: ['./people.component.css']
})
export class PeopleComponent implements OnInit {
  searchedPeople: any;
  currentUser: string;
  searchText: string;
  constructor(private api: SearchService) {
    this.currentUser = localStorage.getItem("uid");
  }

  getSearchedResult() {
    let temporaryPeople;
    this.api.searchPeople(this.searchText)
      .subscribe(response => {
        temporaryPeople = response;
        this.searchedPeople = [];
        for (let index in temporaryPeople) {
          if (temporaryPeople[index].Email != this.currentUser) {
            this.searchedPeople.push(temporaryPeople[index]);
          }
        }
      });
  }

  addFollowing(email) {
    if (this.currentUser) {
      this.api.addFollowing(email, this.currentUser)
        .subscribe(response => {
          console.log("follow");
        })
    }
  }
  ngOnInit() {
    this.getSearchedResult();
  }
}
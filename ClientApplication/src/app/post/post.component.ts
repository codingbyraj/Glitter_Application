import { Component, OnInit } from '@angular/core';
import { SearchService } from '../services/search.service';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent implements OnInit {
  searchedPost: object;
  searchText: string;

  constructor(private api: SearchService) { }

  doSearch() {
    this.api.searchPost(this.searchText)
      .subscribe(response => {
        this.searchedPost = response;
      })
  }

  ngOnInit() {

  }
}

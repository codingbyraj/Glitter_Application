import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { serializeObj } from '../utils/serialize';
import {httpOptions  } from '../utils/httpoptions';

const LOGIN_URL = "http://localhost:52905/token";
const USER_DETAILS_REGISTER_URL = "http://localhost:52905/api/users/register";
const USER_ACCOUNT_REGISTER_URL = "http://localhost:52905/api/account/register";

@Injectable()
export class UsersService {
  constructor(private http: HttpClient) { }
  login(data): Observable<any> {
    let body = serializeObj(data);
    // console.log(body);
    return this.http.post(LOGIN_URL, body);
  }

  // save data to users table
  register(userData): Observable<any> {    
    let body = userData;
    return this.http.post(USER_ACCOUNT_REGISTER_URL, body, httpOptions)
      .do(response => {
        // console.log("response", response)
      })
      .catch(this.handleError)
  }

  // save data to users table
  saveUsersInformation(userDetails): Observable<any> {
    let body = userDetails;
    // console.log("in service", body.ProfileImage);
    return this.http.post(USER_DETAILS_REGISTER_URL, body)
    .do(response => {
      // console.log(response);
    }).catch(this.handleError);
  }

  private handleError(err: HttpErrorResponse) {
    console.error(err.message);
    return Observable.throw(err.message);
  }
}
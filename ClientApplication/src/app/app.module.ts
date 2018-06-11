import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms'
import { HttpClientModule } from '@angular/common/http'
import { AppComponent } from './app.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { RouterModule, Routes } from '@angular/router';
import { UsersService } from './services/users.service';
import { AuthUserService } from './services/auth-user.service';
import { FollowersComponent } from './followers/followers.component';
import { FollowingsComponent } from './followings/followings.component';
import { SearchComponent } from './search/search.component';
import { PlaygroundComponent } from './playground/playground.component';
import { SearchService } from './services/search.service';
import { PeopleComponent } from './people/people.component';
import { PostComponent } from './post/post.component';
import { AnalyticsComponent } from './analytics/analytics.component';


const appRoutes: Routes = [

  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  {
    path: 'dashboard',
    component: DashboardComponent,
    children: [
      { path: '', pathMatch: 'full', redirectTo: 'playground' },
      { path: 'playground', component: PlaygroundComponent },
      { path: 'followers', component: FollowersComponent },
      { path: 'followings', component: FollowingsComponent },
      {
        path: 'search', component: SearchComponent,
        children: [          
          { path: 'people', component: PeopleComponent },
          { path: 'post', component: PostComponent }
        ]
      },
      { path: 'analytics', component: AnalyticsComponent },
    ]
  },
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: '**', redirectTo: '/login', pathMatch: 'full' }
];

@NgModule({
  declarations: [
    AppComponent,
    RegisterComponent,
    LoginComponent,
    DashboardComponent,
    FollowersComponent,
    FollowingsComponent,
    SearchComponent,
    PlaygroundComponent,
    PeopleComponent,
    PostComponent,
    AnalyticsComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [UsersService, AuthUserService, SearchService],
  bootstrap: [AppComponent]
})
export class AppModule { }
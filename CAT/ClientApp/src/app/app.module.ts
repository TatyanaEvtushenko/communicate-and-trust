import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { WebcamModule } from 'ngx-webcam';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { SearchComponent } from './search/search.component';
import { UserListComponent } from './user-list/user-list.component';
import { AdminPageComponent } from './admin-page/admin-page.component';
import { SmileDetectorComponent } from './smile-detector/smile-detector.component';
import { RegisterFormComponent } from './register-form/register-form.component';
import { SigninFormComponent } from './signin-form/signin-form.component';
import { LoaderComponent } from './loader/loader.component';
import { DialogComponent } from './dialog/dialog.component';
import { DialogListComponent } from './dialog-list/dialog-list.component';
import { MessageListComponent } from './message-list/message-list.component';
import { TrainingPageComponent } from './training-page/training-page.component';
import { TestPageComponent } from './test-page/test-page.component';
import { SessionsComponent } from './sessions/sessions.component';
import { AuthFormComponent } from './auth-form/auth-form.component';

import { AccountService } from '../services/account-service/account.service';
import { UserService } from '../services/user-service/user.service';
import { DialogService } from '../services/dialog-service/dialog.service';
import { EmotionService } from '../services/emotion-service/emotion.service';
import { TestService } from '../services/test-service/test.service';
import { TrainingService } from '../services/training-service/training.service';
import { HttpService } from '../services/http-service/http.service';
import { AuthorizedUserService } from '../services/authorized-user-service/authorized-user.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    SearchComponent,
    UserListComponent,
    AdminPageComponent,
    SmileDetectorComponent,
    RegisterFormComponent,
    SigninFormComponent,
    LoaderComponent,
    AuthFormComponent,
    DialogComponent,
    DialogListComponent,
    MessageListComponent,
    TrainingPageComponent,
    TestPageComponent,
    SessionsComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'search', component: SearchComponent },
      { path: 'admin-page', component: AdminPageComponent },
      { path: 'dialog/:userName', component: DialogComponent },
      { path: 'dialogs', component: DialogListComponent }
    ]),
    WebcamModule
  ],
  providers: [
    HttpService,
    AccountService,
    AuthorizedUserService,
    UserService,
    DialogService,
    EmotionService,
    TestService,
    TrainingService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

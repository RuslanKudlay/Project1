import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { PrivateDataComponent } from './private-data/private-data.component';
import { LoginComponent } from './login/login.component';
import { JwtInterceptor } from '../app/jwt-interceptor';
import { EditorDataComponent } from './editor-data/editor-data.component';
import { ManagerDataComponent } from './manager-data/manager-data.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    PrivateDataComponent,
    LoginComponent,
    EditorDataComponent,
    ManagerDataComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'private-data', component: PrivateDataComponent },
      { path: 'login', component: LoginComponent },
      { path: 'managers-data', component: ManagerDataComponent },
      { path: 'editors-data', component: EditorDataComponent },

    ])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

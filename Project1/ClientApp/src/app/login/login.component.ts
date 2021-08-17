import { Component, OnInit, Inject} from '@angular/core';
import { NgForm } from '@angular/forms';
import { Route, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  private baseUrl: string;
  invalidLogin: boolean;
  public http;
  public router;
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, router: Router) {
    this.http = http;
    this.baseUrl = baseUrl;
    this.router = router;
  }

  ngOnInit() {
  }
  login(form: NgForm) {
    const payload = form.value;
    this.http.post(this.baseUrl + 'auth/login', payload).subscribe(result => {
      const token = (<any>result).token;
      localStorage.setItem('jwt', token);
      this.invalidLogin = false;
      this.router.navigate(['/private-data']);
    },
      err => {

        this.invalidLogin = true;
      });
     
  }

}

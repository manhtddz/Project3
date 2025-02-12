import { Component } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { UserService } from '../services/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrl: './index.component.scss'
})
export class IndexComponent {
  public token: string;
  public name: string;
  constructor(private authenticationService: UserService, private cookieService: CookieService, private router: Router) {

    // var expiredDate;
    // expiredDate = new Date();
    // expiredDate.setSeconds(expiredDate.getSeconds() + 10);
    // this.cookieService.set('token', token);
    // if(this.loginResponse.isLogin === true){
    //   this.router.navigateByUrl('/dashboard');
    // }

  }

  ngOnInit() {
    let currentUser = this.cookieService.get('currentUser');
    let token = this.cookieService.get('token');
    this.cookieService.set('currentUser', currentUser)

    this.name = currentUser;
    this.token = token;
    if (token !== "") {
      this.authenticationService.getAuthentication(token).subscribe(
        (result: any) => {
          this.authRes = result;
          if (this.authRes.isLogin === true) {
            this.router.navigateByUrl('/dashboard');
          }
        }

      )
    }


  }

  emailForLogin: string = "nxl@gmail.com";
  passwordForLogin: string = "12345";

  authRes = {
    isLogin: false
  }

  loginResponse = {
    userName: "",
    errors: {
      notExistedError: "",
      passwordError: "",
      emailEmptyError: "",
      passwordEmptyError: ""
    },
    token: ""
  }
  login() {
    var inputData = {
      email: this.emailForLogin,
      password: this.passwordForLogin
    }
    this.authenticationService.login(inputData).subscribe(
      (result: any) => {
        this.loginResponse = result
        var expiredDate;
        expiredDate = new Date();
        expiredDate.setHours(expiredDate.getHours() + 5);
        this.cookieService.set('token', this.loginResponse.token, expiredDate);
        this.cookieService.set('currentUser', this.loginResponse.userName, expiredDate);
        this.name = this.cookieService.get('currentUser');
        this.token = this.cookieService.get('token');
        if (this.token !== "") {
          this.authenticationService.getAuthentication(this.token).subscribe(
            (result: any) => {
              this.authRes = result;
              if (this.authRes.isLogin === true) {
                this.router.navigateByUrl('/dashboard');
              }
            }
          )
        }
      }
    );

  }

  registerResponse = {
    isRegistered: false,
    userName: "",
    errors: {
      existedError: "",
      emailError: "",
      usernameError: "",
      passwordError: ""
    }
  }
  usernameForReg: string = "";
  passwordForReg: string = "";
  emailForReg: string = "";
  register() {
    var inputData = {
      userName: this.usernameForReg,
      password: this.passwordForReg,
      email: this.emailForReg
    }
    this.authenticationService.register(inputData).subscribe(
      (result: any) => {
        this.registerResponse = result
      }
    );
  }
  logout() {
    this.cookieService.delete('currentUser');
    this.cookieService.delete('token');

    this.token = "";
    this.name = "";
    this.authRes.isLogin = false;
  }
}

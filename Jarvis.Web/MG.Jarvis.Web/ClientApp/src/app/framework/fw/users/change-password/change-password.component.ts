import { Component, OnInit } from '@angular/core';
import {FormControl, Validators} from '@angular/forms';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'fw-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.css']
})
export class ChangePasswordComponent implements OnInit {

  hide1 = true;
  hide2 = true;
  hide3 = true;
  invalid: boolean;
  same: boolean;
  oldpassword = new FormControl('', [Validators.required]);
  newpassword = new FormControl('', [Validators.required]);
  confirmpassword = new FormControl('', [Validators.required]);
  constructor() { }

  ngOnInit() {
  }

  getErrorMessage1() {
    // return this.oldpassword.hasError('required') ? 'You must enter a value' : '';
  }
  getErrorMessage2() {
    // return this.oldpassword.hasError('required') ? 'You must enter a value' : '';
  }
  getErrorMessage3() {
  }

  checkLength(newPassword) {
    if (newPassword.length < 6 ) {
      this.invalid = true;
    } else {
     this.invalid = false;
    }
  }

  checkEqual(newPassword, confirmPassword) {
    if (newPassword === confirmPassword) {
      this.same = true;
    } else {
      this.same = false;
    }
  }
}
